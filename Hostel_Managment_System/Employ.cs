using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hostel_Managment_System
{
    public partial class Employ : Form
    {
        public int id = 0;

        DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");


        public Employ()
        {
            InitializeComponent();
            databaseOperations.DisplayEmployRecInDGV(this);
            addEmployPanel.Hide();
        }

        private void openAddStudentPanel_Click(object sender, EventArgs e)
        {
            Clear();
            updateEmployButton.Hide();
            addEmployPanel.Show();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            addEmployPanel.Hide();
        }

        private void insertEmployButton_Click(object sender, EventArgs e)
        {
            databaseOperations.insertEmployRecord(this);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString());
            string gender = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (gender == "Male")
            {

                radioButton1.Checked = true;

            }
            if (gender == "Female")
            {

                radioButton2.Checked = true;

            }
        }

        private void openStudentUpdatePanel_Click(object sender, EventArgs e)
        {
            label2.Text = "Update Employ";
            addEmployPanel.Show();
            insertEmployButton.Hide();
            updateEmployButton.Show();
        }

        public void Clear() {

            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            radioButton1.Checked = false;
            radioButton2.Checked = false;

        }

        private void updateEmployButton_Click(object sender, EventArgs e)
        {
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want To Delete Student Record !!", "Open Paint", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                databaseOperations.deleteEmployRecord(this);
                databaseOperations.DisplayEmployRecInDGV(this);
            }
            else
            {

                databaseOperations.DisplayEmployRecInDGV(this);
            }
        }

        private void updateEmployButton_Click_1(object sender, EventArgs e)
        {
            databaseOperations.updateEmployRecord(this);
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            databaseOperations.DisplayEmployRecInDGV(this);
        }
    }
}
