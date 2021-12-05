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
    public partial class Fees : Form
    {

        public int sno = 0;

        Mess Mess = new Mess();
        DatabaseOperations DatabaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");


        public Fees()
        {
            InitializeComponent();
            hideMessCharges();
            int messCharges = int.Parse(Mess.label35.Text) * 30;
            textBox3.Text = Mess.label35.Text + " x 30 = " + messCharges;
            DatabaseOperations.getStudentIdsInComboBoxForFess(this);
            insertFeesRecordPanel.Hide();
            DatabaseOperations.displayFeesRecordInDGV(this);
            increaseDataGridViewWidth();
        }


        //Increase DataGridView Width Method ===================================
        public void increaseDataGridViewWidth()
        {

            for (int i = 0; i <= 6; i++)
            {

                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 200;

            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string check = comboBox1.SelectedItem.ToString();
            if (check == "Active") {

                comboBox1.ForeColor = Color.DarkGreen;
                textBox3.Show();
                label3.Show();

                if (textBox1.Text != "") {

                    int totalFess = int.Parse(textBox1.Text) + (int.Parse(Mess.label35.Text) * 30);
                    textBox4.Text = totalFess.ToString();

                }

            }
            else if (check == "Deactive") {

                comboBox1.ForeColor = Color.Red;
                hideMessCharges();

                textBox4.Text = textBox1.Text;

            }
        }

        private void hideMessCharges() {

            textBox3.Hide();
            label3.Hide();

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseOperations.getStudentNameInTextBoxForFees(this);
        }

        private void insertStudentFeesRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.insertFeesRecord(this);
            DatabaseOperations.displayFeesRecordInDGV(this);
        }

        private void openInsertFeesRecordPanelButton_Click(object sender, EventArgs e)
        {
            clear();
            updateFeesRecordButton.Hide();
            insertFeesRecordPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertFeesRecordPanel.Hide();
        }

        private void clear() {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            comboBox1.Text = "";
            comboBox5.Text = "";

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            string check = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (check == "Active")
            {

                comboBox1.Text = check;
                comboBox1.ForeColor = Color.DarkGreen;

            }
            else
            {
                comboBox1.Text = check;
                comboBox1.ForeColor = Color.Red;
            }
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Please Select A Row !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                label5.Text = "Update Fees Record";
                insertStudentFeesRecButton.Hide();
                updateFeesRecordButton.Show();
                insertFeesRecordPanel.Show();

            }

        }

        private void updateFeesRecordButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.updateFeesRecord(this);
            DatabaseOperations.displayFeesRecordInDGV(this);
        }

        private void deleteFeesRecordButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Please Select A Row !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                DatabaseOperations.deleteFeesRecord(this);
                DatabaseOperations.displayFeesRecordInDGV(this);

            }
        }
    }
}
