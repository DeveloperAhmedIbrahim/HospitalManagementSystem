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
    public partial class Room : Form
    {
        int sno = 0;
        string p1;
        string p2;
        public Room()
        {
            InitializeComponent();
            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.DisplayRoomRecInDGV(this);
            increaseDataGridViewWidth();
            addRoomPanel.Hide();
            allotRoomPanel.Hide();
            removePersonPanel.Hide();
            getInComboBox();
            setAllotStudentPanel();
        }

        public void getInComboBox() {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source = SIDDIQUICOMPUTE\SQLEXPRESS01; Initial Catalog = Hostel_Managment_System; Integrated Security = True");
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Student ",sqlConnection);
            sqlConnection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read()) {

                int id = sqlDataReader.GetInt32(1);
                comboBox5.Items.Add(id);

            }

            sqlConnection.Close();

        }

        public void increaseDataGridViewWidth()
        {
            for (int i = 0; i <= 7; i++)
            {

                DataGridViewColumn column = dataGridView1.Columns[i];
                column.Width = 200;

            }
        }

        private void insertButtonButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.insertRoomRecord(this);
        }

        private void openAddRoomPanel_Click(object sender, EventArgs e)
        {
            Clear();
            addRoomPanel.Show();
            allotRoomButton.Hide();

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {

            this.addRoomPanel.Hide();

        }

        private void Clear()
        {

            this.comboBox1.SelectedText = "";
            this.comboBox2.SelectedText = "";
            this.comboBox3.SelectedText = "";

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            label7.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            label8.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            label9.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            p1 = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            p2 = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (p1 == "" && p2 == "") {

                label10.Text = "Empty";
            }
            else if (p1 == "" && p2 != "") {

                label10.Text = "Half";

            }
            else if (p2 == "" && p1 != "")
            {

                label10.Text = "Half";

            }
            else if(p2 != "" && p1 != ""){

                label10.Text = "Full";

            }
        }
        private void setAllotStudentPanel() {

            this.label7.Text = "";
            this.label8.Text = "";
            this.label9.Text = "";
            this.label10.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            allotRoomPanel.Hide();
        }

        private void openAllotRoomPanel_Click(object sender, EventArgs e)
        {
            if (label7.Text == "")
            {
                MessageBox.Show("Please select a row before allot the Room !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                allotRoomPanel.Show();
                allotRoomButton.Show();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedItem.ToString() != null)
            { 

                int c_id = int.Parse(comboBox5.SelectedItem.ToString());
                SqlConnection sqlConnection = new SqlConnection(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Student WHERE std_id = @id ", sqlConnection);
                sqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id",c_id);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {

                    textBox2.Text = dataTable.Rows[0]["std_name"].ToString();

                }

            }
        }

        private void allotRoomButton_Click(object sender, EventArgs e)
        {
            if (label10.Text == "Full")
            {

                MessageBox.Show("Room is already full you cant add another", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else if(label10.Text == "Empty") {

                SqlConnection sqlConnection = new SqlConnection(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand("UPDATE Room SET room_person_one_id = @s_one_id , room_person_one_name = @s_one_name WHERE sno = @sno",sqlConnection);
                sqlCommand.Parameters.AddWithValue("@sno",sno);
                sqlCommand.Parameters.AddWithValue("@s_one_id",comboBox5.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@s_one_name",textBox2.Text);
                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
                label10.Text = "Half";

            }
            else if (label10.Text == "Half")
            {

                SqlConnection sqlConnection = new SqlConnection(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
                SqlCommand sqlCommand = new SqlCommand("UPDATE Room SET room_person_two_id = @s_two_id , room_person_two_name = @s_two_name WHERE sno = @sno", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@sno", sno);
                sqlCommand.Parameters.AddWithValue("@s_two_id", comboBox5.SelectedItem);
                sqlCommand.Parameters.AddWithValue("@s_two_name", textBox2.Text);
                sqlConnection.Open();
                int check = sqlCommand.ExecuteNonQuery();
                if (check > 0) {

                    label10.Text = "Full";
                    MessageBox.Show("Another Student Added In The Room Successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

                }
                sqlConnection.Close();

            }
        }

        private void refreshRoomRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.DisplayRoomRecInDGV(this);
        }
        
        private void removePersonButton_Click(object sender, EventArgs e)
        {
            removePersonPanel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            removePersonPanel.Hide();
        }

        // Remove Person One
        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("UPDATE Room SET room_person_one_id = NULL , room_person_one_name = NULL WHERE sno = @sno", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@sno", sno);
            sqlConnection.Open();
            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {               
                MessageBox.Show("Member Removed Successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (label10.Text == "Full") {

                    label10.Text = "Half";
                }
                else if (p1 == "" && label10.Text == "Half") {

                    label10.Text = "Half";

                }
            }

            sqlConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlConnection sqlConnection = new SqlConnection(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            SqlCommand sqlCommand = new SqlCommand("UPDATE Room SET room_person_two_id = NULL , room_person_two_name = NULL WHERE sno = @sno", sqlConnection);
            sqlCommand.Parameters.AddWithValue("@sno", sno);
            sqlConnection.Open();
            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {
                MessageBox.Show("Member Removed Successfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (label10.Text == "Full")
                {

                    label10.Text = "Half";
                }
                else if (p2 == "" && label10.Text == "Half")
                {

                    label10.Text = "Half";

                }
                else if (label10.Text == "Half")
                {

                    label10.Text = "Null";

                }
            }

            sqlConnection.Close();

        }
    }
}
