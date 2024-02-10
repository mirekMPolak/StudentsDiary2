using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace StudentsDiary
{
    public partial class AddRemoveGroup : Form
    {
        private int _groupId;
        private Student _student;

        private readonly FileHelper<List<Group>> _fileHelperGroups = new FileHelper<List<Group>>(Program.FilePathOfGroups);
        private readonly FileHelper<List<Student>> _fileHelperStudents = new FileHelper<List<Student>>(Program.FilePathOfStudents);

        public AddRemoveGroup()
        {
            InitializeComponent();
            RefreshGroups();
            SetColumnsHeader();
        }

        private void RefreshGroups()
        {
            var groups = _fileHelperGroups.DeserializeFromFile();
            dgvGroupNames.DataSource = groups;
        }

        private void SetColumnsHeader()
        {
            dgvGroupNames.Columns[0].Visible = false;   // "Numer grupy"
            dgvGroupNames.Columns[1].HeaderText = "Nazwa grupy";
        }

        private void btnAddNewGroup_Click(object sender, EventArgs e)
        {
            var groups = _fileHelperGroups.DeserializeFromFile();

            if (tbGroupName.Text == String.Empty)
            {
                MessageBox.Show("Nie podano nazwy grupy !");
                return;
            }

            if (groups.Exists(x => x.GroupName == tbGroupName.Text))
            {
                MessageBox.Show("Grupa o takiej nazwie już istnieje !");
                return;
            }

            AssignIdToNewGroup(groups);
            AddNewGroupToList(groups);
            _fileHelperGroups.SerializeToFile(groups);
            RefreshGroups();
        }

        private void AssignIdToNewGroup(List<Group> groups)
        {
            var groupWithHighestId = groups.OrderByDescending(x => x.GroupId).FirstOrDefault();
            _groupId = groupWithHighestId == null ? 1 : groupWithHighestId.GroupId + 1;
        }

        private void AddNewGroupToList(List<Group> groups)
        {
            var group = new Group
            {
                GroupId = _groupId,
                GroupName = tbGroupName.Text.Trim()
            };

            groups.Add(group);
        }

        private void btnRemoveGroup_Click(object sender, EventArgs e)
        {
            if (dgvGroupNames.SelectedRows.Count == 0)
            {
                MessageBox.Show("Proszę zaznacz grupę, której nazwę chcesz usunąć");
                return;
            }

            if (dgvGroupNames.RowCount == 0)
            {
                MessageBox.Show("Nie ma grup do usunięcia");
                return;
            }

            var selectedGroup = dgvGroupNames.SelectedRows[0];

            if (Convert.ToInt32(selectedGroup.Cells[0].Value) == 1 || Convert.ToInt32(selectedGroup.Cells[0].Value) == 2)
            {
                MessageBox.Show($"Grupy: {selectedGroup.Cells[1].Value.ToString().Trim()} nie można usunąć.");
                return;
            }

            var students = _fileHelperStudents.DeserializeFromFile();
            _student = students.Find(x => x.StudentsGroupId == Convert.ToInt32(selectedGroup.Cells[0].Value));

            if (_student != null)
            {
                MessageBox.Show($"Nie można usunąć grupy: > {selectedGroup.Cells[1].Value.ToString().Trim()} <, ponieważ jest w użyciu.");
                return;
            }

            var confirmDelete = MessageBox.Show($"Czy na pewno chcesz usunąć grupę: > {selectedGroup.Cells[1].Value.ToString().Trim()} <", "Usuwanie grupy", MessageBoxButtons.OKCancel);

            if (confirmDelete == DialogResult.OK)
            {
                DeleteGroup(Convert.ToInt32(selectedGroup.Cells[0].Value));
                RefreshGroups();
            }
        }

        private void DeleteGroup(int id)
        {
            var groups = _fileHelperGroups.DeserializeFromFile();
            groups.RemoveAll(x => x.GroupId == id);
            _fileHelperGroups.SerializeToFile(groups);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
