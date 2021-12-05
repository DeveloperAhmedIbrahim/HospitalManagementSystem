using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hostel_Managment_System
{
    public partial class Student : Form
    {

        int id = 0;
        public Student()
        {
            InitializeComponent();
            this.addRoomPanel.Hide();// Hide Add Student Panel
            Display(); // Display Student Record In Data Grid View
            increaseDataGridViewWidth(); // Calling Increase DataGridView Width Method
        }

        // Increase DataGridView Width Method ===================================
        public void increaseDataGridViewWidth() {

            for (int i = 0; i <= 8; i++) {

                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 150;

            }

        }

        // Close addStudentPanel Button
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.addRoomPanel.Hide();
            this.label1.Show();
        }

        // Open Panel To Insert Student Record
        private void openAddStudentPanel_Click(object sender, EventArgs e)
        {
            Clear();
            this.addRoomPanel.Show();
            this.updateStudentButton.Hide();
            this.label1.Hide();
        }

        // Display Student Data In Data Grig Veiw
        public void Display() {

            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.DisplayStudentRecInDGV(this);

        }

        // Data Gird View Row Header Mouse Click Event
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            this.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString());
            string gender = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            if (gender == "Male") {

                radioButton1.Checked = true;

            }
            if (gender == "Female")
            {

                radioButton2.Checked = true;

            }
        }

        // Update Student Record Button
        private void updateStudentRecord_Click(object sender, EventArgs e)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.updateStudentRecord(this,id);
        }

        // Open Panel To Update Student Record
        private void openStudentUpdatePanel_Click(object sender, EventArgs e)
        {
            addRoomPanel.Show();
            insertStudentButton.Hide();
            updateStudentButton.Show();
            label2.Text = "Update Student";
        }

        // Insert Student Record Button
        private void insertStudentButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.insertStudentRecord(this);
        }

        // Refresh Button
        private void refreshButton_Click(object sender, EventArgs e)
        {
            Display();
        }

        // Clear Method
        public void Clear() {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want To Delete Student Record !!", "Open Paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
                databaseOperations.DeleteStudentRec(this, id);
                Display();
            }
            else {

                Display();
            }
        }
    }
}
