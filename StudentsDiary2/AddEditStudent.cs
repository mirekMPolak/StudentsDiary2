using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class AddEditStudent : Form
    {
        private int _studentId;
        private Student _student;
        private Group _group;

        private readonly FileHelper<List<Student>> _fileHelperOfStudents = new FileHelper<List<Student>>(Program.FilePathOfStudents);
        private readonly FileHelper<List<Group>> _fileHelperOfGroups = new FileHelper<List<Group>>(Program.FilePathOfGroups);

        public AddEditStudent(int id = 0)
        {
            InitializeComponent();
            _studentId = id;
            RefreshCbGroupId(2);
            GetStudentData();
            tbFirstName.Select();
        }

        private void GetStudentData()
        {
            if (_studentId != 0)
            {
                Text = "Edytowanie danych ucznia";

                var students = _fileHelperOfStudents.DeserializeFromFile();
                _student = students.FirstOrDefault(x => x.Id == _studentId);

                if (_student == null)
                {
                    throw new Exception("Brak użytkownika o podanym Id");
                }

                var groups = _fileHelperOfGroups.DeserializeFromFile();
                _group = groups.FirstOrDefault(x => x.GroupId == _student.StudentsGroupId);

                FillTextBoxes();
            }
        }

        private void FillTextBoxes()
        {
            tbId.Text = _student.Id.ToString();
            tbFirstName.Text = _student.FirstName;
            tbLastName.Text = _student.LastName;
            tbMath.Text = _student.Math;
            tbPhysics.Text = _student.Physics;
            tbTechnology.Text = _student.Technology;
            tbPolishLang.Text = _student.PolishLang;
            tbForeignLang.Text = _student.ForeignLang;
            rtbComments.Text = _student.Comments;
            chbAddClasses.Checked = _student.AdditionalClasses;
            cbGroupId.SelectedValue = _group.GroupId;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            var students = _fileHelperOfStudents.DeserializeFromFile();

            if (_studentId != 0)
            {
                students.RemoveAll(x => x.Id == _studentId);
            }
            else
            {
                AssignIdToNewStudent(students);
            }

            AddNewUserToList(students);

            _fileHelperOfStudents.SerializeToFile(students);

            Close();
        }

        private void AssignIdToNewStudent(List<Student> students)
        {
            var studentWithHighestId = students.OrderByDescending(x => x.Id).FirstOrDefault();
            _studentId = studentWithHighestId == null ? 1 : studentWithHighestId.Id + 1;
        }

        private void AddNewUserToList(List<Student> students)
        {
            var student = new Student
            {
                Id = _studentId,
                FirstName = tbFirstName.Text,
                LastName = tbLastName.Text,
                Comments = rtbComments.Text,
                ForeignLang = tbForeignLang.Text,
                Math = tbMath.Text,
                Physics = tbPhysics.Text,
                PolishLang = tbPolishLang.Text,
                Technology = tbTechnology.Text,
                AdditionalClasses = chbAddClasses.Checked,
                StudentsGroupId = Convert.ToInt32(cbGroupId.SelectedValue)
            };

            students.Add(student);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void RefreshCbGroupId(int setId)
        {
            var groups = _fileHelperOfGroups.DeserializeFromFile();
            groups.RemoveAll(x => x.GroupId == 1);
            cbGroupId.ValueMember = "GroupId";
            cbGroupId.DisplayMember = "GroupName";
            cbGroupId.DataSource = groups;
            cbGroupId.SelectedValue = setId;
        }
    }
}
