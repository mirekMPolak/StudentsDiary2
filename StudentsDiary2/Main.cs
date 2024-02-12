using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using StudentsDiary.Properties;


namespace StudentsDiary
{
    public partial class Main : Form
    {
        private readonly FileHelper<List<Student>> _fileHelperOfStudents = new FileHelper<List<Student>>(Program.FilePathOfStudents);
        private readonly FileHelper<List<Group>> _fileHelperOfGroups = new FileHelper<List<Group>>(Program.FilePathOfGroups);

        public bool IsMaximize
        {
            get
            {
                return Settings.Default.IsMaximize;
            }

            set
            {
                Settings.Default.IsMaximize = value;
            }
        }

        public Main()
        {
            InitializeComponent();
            SetGroupsOnFirstRun();
            RefreshCbGroupsFiltering(1);
            RefreshDiary();
            SetColumnsHeader();

            if (IsMaximize)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void RefreshDiary()
        {
            var students = _fileHelperOfStudents.DeserializeFromFile();

            if (Convert.ToInt32(cbGroupsFiltering.SelectedValue) == 1)
            {
                dgvDiary.DataSource = students;
            }
            else
            {
                dgvDiary.DataSource = students.Where(x => x.StudentsGroupId == Convert.ToInt32(cbGroupsFiltering.SelectedValue)).ToList();
            }
        }

        private void SetColumnsHeader()
        {
            dgvDiary.Columns[0].HeaderText = "Numer";
            dgvDiary.Columns[1].HeaderText = "Imię";
            dgvDiary.Columns[2].HeaderText = "Nazwisko";
            dgvDiary.Columns[3].HeaderText = "Uwagi";
            dgvDiary.Columns[4].HeaderText = "Matematyka";
            dgvDiary.Columns[5].HeaderText = "Technologia";
            dgvDiary.Columns[6].HeaderText = "Fizyka";
            dgvDiary.Columns[7].HeaderText = "Język polski";
            dgvDiary.Columns[8].HeaderText = "Język obcy";
            dgvDiary.Columns[9].HeaderText = "Zajęcia dodatkowe";
            dgvDiary.Columns[10].Visible = false;   // "Numer grupy"
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addEditStudent = new AddEditStudent();
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void AddEditStudent_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshDiary();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz ucznia, którego dane chcesz edytować");
                return;
            }

            var addEditStudent = new AddEditStudent(Convert.ToInt32(dgvDiary.SelectedRows[0].Cells[0].Value));
            addEditStudent.FormClosing += AddEditStudent_FormClosing;
            addEditStudent.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDiary.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz ucznia, którego dane chcesz usunąć");
                return;
            }

            var selectedStudent = dgvDiary.SelectedRows[0];

            var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć ucznia {(selectedStudent.Cells[1].Value.ToString() + ' ' + selectedStudent.Cells[2].Value.ToString()).Trim()}", "Usuwanie ucznia", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                DeleteStudent(Convert.ToInt32(selectedStudent.Cells[0].Value));
                RefreshDiary();
            }
        }

        private void DeleteStudent(int id)
        {
            var students = _fileHelperOfStudents.DeserializeFromFile();
            students.RemoveAll(x => x.Id == id);
            _fileHelperOfStudents.SerializeToFile(students);
        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                IsMaximize = true;
            }
            else
            {
                IsMaximize = false;
            }

            Settings.Default.Save();
        }

        private void cbGroupsFiltering_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshDiary();
        }

        private void btnGroupsEditing_Click(object sender, EventArgs e)
        {
            var addRemoveGroup = new AddRemoveGroup();
            addRemoveGroup.FormClosing += AddRemoveGroup_FormClosing;
            addRemoveGroup.ShowDialog();
        }

        private void AddRemoveGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefreshCbGroupsFiltering(Convert.ToInt32(cbGroupsFiltering.SelectedValue));
        }

        private void RefreshCbGroupsFiltering(int setId)
        {
            var groups = _fileHelperOfGroups.DeserializeFromFile();
            cbGroupsFiltering.ValueMember = "GroupId";
            cbGroupsFiltering.DisplayMember = "GroupName";
            cbGroupsFiltering.DataSource = groups;
            if (setId == 0 || (setId > 2 && !groups.Exists(x => x.GroupId == setId)))
            {
                setId = 1;
            }
            cbGroupsFiltering.SelectedValue = setId;
        }

        private void SetGroupsOnFirstRun()
        {
            var groups = _fileHelperOfGroups.DeserializeFromFile();
            if (groups.Count == 0)
            {
                groups.Add(new Group() { GroupId = 1, GroupName = "* wszyscy *" });
                groups.Add(new Group() { GroupId = 2, GroupName = "* nieprzypisany *" });
                _fileHelperOfGroups.SerializeToFile(groups);
            }
        }
    }
}
