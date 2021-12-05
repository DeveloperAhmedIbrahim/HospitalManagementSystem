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
    public partial class Visitor : Form
    {
        DatabaseOperations DatabaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
        public int sno = 0;

        public Visitor()
        {
            InitializeComponent();
            insertVisitorRecordPanel.Hide();
            DatabaseOperations.getRoomIdsInComboBoxForVisitor(this);
            DatabaseOperations.getStudentIdsInComboBoxForVisitor(this);
            DatabaseOperations.displayVisitorRecordInDGV(this);
      
        }

        private void openInsertVisitorRecordPanelButton_Click(object sender, EventArgs e)
        {
            updateVisitorRecButton.Hide();
            insertVisitorRecordPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertVisitorRecordPanel.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseOperations.getRoomDetailsInTextBoxForVisitor(this);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseOperations.getStudentNameInTextBoxForVisitors(this);
        }

        private void insertVisitorRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.insertVisitorRecord(this);
            DatabaseOperations.displayVisitorRecordInDGV(this);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Long;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Format = DateTimePickerFormat.Long;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Please Selete A Row !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                insertVisitorRecButton.Hide();
                label1.Text = "Update Visitor Record";
                updateVisitorRecButton.Show();
                insertVisitorRecordPanel.Show();

            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
        }

        private void updateVisitorRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.updateVisitorRecord(this);
            DatabaseOperations.displayVisitorRecordInDGV(this);
        }

        private void deleteVisitorRecordButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Please Selete A Row !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                DatabaseOperations.deleteVisitorRecord(this);
                DatabaseOperations.displayVisitorRecordInDGV(this);

            }
        }
    }
}
