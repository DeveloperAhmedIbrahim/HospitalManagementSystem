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
    public partial class Furniture : Form
    {
        public int sno = 0;
        DatabaseOperations DatabaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
        public Furniture()
        {
            InitializeComponent();
            DatabaseOperations.getRoomIdsInComboBoxForFurniture(this);
            DatabaseOperations.displayFurnitureRecordInDGV(this);
            insertFurnitureRecordPanel.Hide();
            increaseDataGridViewWidth();
            
        }

        // Increase DataGridView Width Method ===================================
        public void increaseDataGridViewWidth()
        {

            for (int i = 0; i <= 6; i++)
            {

                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 150;

            }

        }


        private void openInsertFurnitureRecordPanelButton_Click(object sender, EventArgs e)
        {
            Clear();
            insertFurnitureRecButton.Show();
            insertFurnitureRecordPanel.Show();
            updateFurnitureRecButton.Hide();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseOperations.getRoomDetailsInTextBoxForFees(this);
        }

        private void insertFurnitureRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.insertFurnitureRecord(this);
            DatabaseOperations.displayFurnitureRecordInDGV(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            insertFurnitureRecordPanel.Hide();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            comboBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void Clear() {

            comboBox5.Text = "";
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {

                MessageBox.Show("Please Selete A Row !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                label5.Text = "Update Furniture Record";
                insertFurnitureRecButton.Hide();
                updateFurnitureRecButton.Show();
                insertFurnitureRecordPanel.Show();

            }

        }

        private void updateFurnitureRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.updateFurnitureRecord(this);
            DatabaseOperations.displayFurnitureRecordInDGV(this);
        }

        private void deleteFurnitureRecordButton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Please Select A Row !");

            }
            else {

                DatabaseOperations.deleteFurnitureRecord(this);
                DatabaseOperations.displayFurnitureRecordInDGV(this);
            }
        }
    }
}
