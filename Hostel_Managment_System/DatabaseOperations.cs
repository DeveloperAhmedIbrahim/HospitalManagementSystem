using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace Hostel_Managment_System
{
    class DatabaseOperations
    {
        SqlConnection connection;
        SqlCommand sqlCommand;
        SqlDataAdapter SqlDataAdapter;
        DataTable DataTable;

        
        // Passing Database Connection String Through Constructor
        public DatabaseOperations(string con_string)
        {
            this.connection = new SqlConnection(con_string);
        }

        // Calling Value From Database To LogIn
        public void logIn(string username , string password) {

            sqlCommand = new SqlCommand("SELECT admin_username , admin_password " +
                "FROM admin WHERE admin_username = '" + username + "' " +
                "AND admin_password = '" + password + "'",connection);

            SqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            
        }

        // Checking Connection Stablity & Matching Values
        public void logIn(string username, string password, LogIn logIn) {

            this.logIn(username,password);
            connection.Open();
            if (DataTable.Rows.Count > 0)
            {

                HMS_Panel hMS_Panel = new HMS_Panel();
                hMS_Panel.Show();
                logIn.Hide();

            }
            else
            {

                MessageBox.Show("Invalid Username OR Password !","Information",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

            }
            connection.Close();
        }

        // Getting Admin Table From Database To Show In Labeles
        public void getValuesInLabels(Admin admin)
        {

            connection.Open();
            sqlCommand = new SqlCommand("SELECT * FROM admin WHERE  admin_id = 1", connection);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {

                admin.label9.Text = (dr["admin_name"].ToString());
                admin.label13.Text = (dr["admin_cell"].ToString());
                admin.label14.Text = (dr["admin_email"].ToString());
                admin.label15.Text = (dr["admin_gender"].ToString());
                admin.label16.Text = (dr["admin_join_date"].ToString());
                admin.label19.Text = (dr["admin_age"].ToString());
                admin.label17.Text = (dr["admin_username"].ToString());
                admin.label18.Text = (dr["admin_password"].ToString());

            }
            connection.Close();
        }

        // Getting Admin Table From Database To Show In TextBoxes
        public void getValuesInTextBoxes(Admin admin)
        {

            connection.Open();
            sqlCommand = new SqlCommand("SELECT * FROM admin WHERE  admin_id = 1", connection);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {

                admin.textBox2.Text = (dr["admin_name"].ToString());
                admin.textBox3.Text = (dr["admin_cell"].ToString());
                admin.textBox4.Text = (dr["admin_email"].ToString());
                string check = (dr["admin_gender"].ToString());
                if (check == "male" || check == "Male") {

                    admin.radioButton1.Checked = true;

                }
                else if (check == "female" || check == "Female") {

                    admin.radioButton2.Checked = true;

                }
                admin.dateTimePicker1.Value = Convert.ToDateTime((dr["admin_join_date"].ToString()));
                
                admin.textBox6.Text = (dr["admin_age"].ToString());
                admin.textBox7.Text = (dr["admin_username"].ToString());
                admin.textBox8.Text = (dr["admin_password"].ToString());

            }
            connection.Close();
        }

        // Update Admin Record 
        public void updateAdminRecord(Admin admin) {

            connection.Open();
            sqlCommand = new SqlCommand("Update admin SET admin_name = @name , admin_cell = @num, admin_email = @email, admin_age = @age , admin_join_date = @date , admin_gender = @gender , admin_username = @user, admin_password = @pass WHERE admin_id = 1", connection);
            sqlCommand.Parameters.AddWithValue("@name", admin.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@num", admin.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@email", admin.textBox4.Text);
            if (admin.radioButton1.Checked == true)
            {

                sqlCommand.Parameters.AddWithValue("@gender", admin.radioButton1.Text);

            }
            else if (admin.radioButton2.Checked == true)
            {

                sqlCommand.Parameters.AddWithValue("@gender", admin.radioButton2.Text);

            }
            sqlCommand.Parameters.AddWithValue("@date", admin.dateTimePicker1.Value.ToString());
            sqlCommand.Parameters.AddWithValue("@age", admin.textBox6.Text);
            sqlCommand.Parameters.AddWithValue("@user", admin.textBox7.Text);
            sqlCommand.Parameters.AddWithValue("@pass", admin.textBox8.Text);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Data Update Successfully");
            connection.Close();

        }


        //Insert Student Recodt Into Student Tables
        public void insertStudentRecord(Student student)
        {

            sqlCommand = new SqlCommand("INSERT INTO Student (std_id,std_name,std_father_name,std_department,std_address,std_cell,std_age,std_dob,std_gender) values (@std_id,@name,@father,@dep,@address,@cell,@age,@dob,@gender)", connection);
            sqlCommand.Parameters.AddWithValue("@name", student.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@std_id", student.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@father", student.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@dep", student.textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@address", student.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@cell", student.textBox6.Text);
            sqlCommand.Parameters.AddWithValue("@age", student.textBox7.Text);
            sqlCommand.Parameters.AddWithValue("@dob", student.dateTimePicker1.Value.ToString());
            if (student.radioButton1.Checked == true) {

                sqlCommand.Parameters.AddWithValue("@gender", student.radioButton1.Text);

            }
            else if (student.radioButton2.Checked == true) {

                sqlCommand.Parameters.AddWithValue("@gender", student.radioButton2.Text);
            }
            connection.Open();
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Insert Successfully");

            }
            else
            {

                MessageBox.Show("Invalid Values");

            }
            connection.Close();
        }


        //Insert Student Recodt Into Student Tables
        public void updateStudentRecord(Student student,int id)
        {

            sqlCommand = new SqlCommand("UPDATE Student SET std_id = @std_id, std_name = @name , std_father_name  = @father , std_department = @dep , std_address  = @address , std_cell = @cell , std_age = @age , std_dob = @dob ,  std_gender = @gender WHERE sno = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            sqlCommand.Parameters.AddWithValue("@name", student.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@std_id", student.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@father", student.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@dep", student.textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@address", student.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@cell", student.textBox6.Text);
            sqlCommand.Parameters.AddWithValue("@age", student.textBox7.Text);
            sqlCommand.Parameters.AddWithValue("@dob", student.dateTimePicker1.Value.ToString());
            if (student.radioButton1.Checked == true)
            {

                sqlCommand.Parameters.AddWithValue("@gender", student.radioButton1.Text);

            }
            else if (student.radioButton2.Checked == true)
            {

                sqlCommand.Parameters.AddWithValue("@gender", student.radioButton2.Text);
            }
            connection.Open();
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Update Successfully !", "Update Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        // Display Student Record In Data Grid View
        public void DisplayStudentRecInDGV(Student student) {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Student ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            student.dataGridView1.DataSource = DataTable;
            connection.Close();

        }

        // Delete Student Record
        public void DeleteStudentRec(Student student , int id) {

            connection.Open();
            sqlCommand = new SqlCommand("DELETE FROM Student WHERE sno = '"+id+"'",connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();
            

        }

        //Insert Room Record Into Room Table
        public void insertRoomRecord(Room room)
        {

            sqlCommand = new SqlCommand("INSERT INTO Room (room_num,room_block,room_floor) values (@rnum,@rblock,@rfloor)", connection);
            sqlCommand.Parameters.AddWithValue("@rnum", room.comboBox3.SelectedItem);
            sqlCommand.Parameters.AddWithValue("@rfloor", room.comboBox1.SelectedItem);
            sqlCommand.Parameters.AddWithValue("@rblock", room.comboBox2.SelectedItem);
            connection.Open();
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Insert Successfully");

            }
            else
            {

                MessageBox.Show("Invalid Values");

            }
            connection.Close();
        }

        // Display Room Record In Data Grid View
        public void DisplayRoomRecInDGV(Room room)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Room ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            room.dataGridView1.DataSource = DataTable;
            connection.Close();

        }

        // Display Employ Record In Data Grid View
        public void DisplayEmployRecInDGV(Employ employ)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Employ ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            employ.dataGridView1.DataSource = DataTable;
            connection.Close();

        }

        //Insert Employ Record Into Student Tables
        public void insertEmployRecord(Employ employ)
        {
            
            sqlCommand = new SqlCommand("INSERT INTO Employ (emp_name,emp_address,emp_salary,emp_cell,emp_designation,emp_gender,emp_joining_date) values (@emp_name,@emp_address,@emp_salary,@emp_cell,@emp_designation,@emp_gender,@emp_joining_date)", connection);
            sqlCommand.Parameters.AddWithValue("@emp_name", employ.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@emp_address", employ.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@emp_salary", employ.textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@emp_cell", employ.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@emp_designation", employ.textBox6.Text);
            sqlCommand.Parameters.AddWithValue("@emp_joining_date", employ.dateTimePicker1.Value.ToString());
            
            if (employ.radioButton1.Checked == true)
            {
            
                sqlCommand.Parameters.AddWithValue("@emp_gender", employ.radioButton1.Text);
            
            }
            else if (employ.radioButton2.Checked == true)
            {
            
                sqlCommand.Parameters.AddWithValue("@emp_gender", employ.radioButton2.Text);
            }
            connection.Open();
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Insert Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show("Invalid Values", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            connection.Close();
        }

        // Update Employ Record 
        public void updateEmployRecord(Employ employ)
        {

            sqlCommand = new SqlCommand("UPDATE Employ SET emp_name = @emp_name , emp_address = @emp_address,emp_salary = @emp_salary,emp_cell = @emp_cell, emp_designation = @emp_designation , emp_gender = @emp_gender , emp_joining_date = @emp_joining_date WHERE emp_id = @id", connection);
            sqlCommand.Parameters.AddWithValue("@id", employ.id);
            sqlCommand.Parameters.AddWithValue("@emp_name", employ.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@emp_address", employ.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@emp_salary", employ.textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@emp_cell", employ.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@emp_designation", employ.textBox6.Text);
            sqlCommand.Parameters.AddWithValue("@emp_joining_date", employ.dateTimePicker1.Value.ToString());

            if (employ.radioButton1.Checked == true)
            {

                sqlCommand.Parameters.AddWithValue("@emp_gender", employ.radioButton1.Text);

            }
            else if (employ.radioButton2.Checked == true)
            {

                sqlCommand.Parameters.AddWithValue("@emp_gender", employ.radioButton2.Text);
            }
            connection.Open();
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Record Updated Successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            else
            {

                MessageBox.Show("Invalid Values", "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            connection.Close();
        }

        // Delete Employ Record
        public void deleteEmployRecord(Employ employ) {

            connection.Open();
            sqlCommand = new SqlCommand("DELETE FROM Employ WHERE emp_id = '" + employ.id + "'", connection);
            sqlCommand.ExecuteNonQuery();
            connection.Close();

        }

        // Get Employ ID'S In ComboBox
        public void getEmployIdsInComboBox(Mess mess)
        {

            sqlCommand = new SqlCommand("SELECT * FROM Employ ", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                int id = sqlDataReader.GetInt32(0);
                mess.comboBox1.Items.Add(id);

            }

            connection.Close();

        }

        // Show Name In TextBox According To ID
        public void getEmployNameInTextBox(Mess mess) {

            int incharge_id = int.Parse(mess.comboBox1.SelectedItem.ToString());
            SqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Employ WHERE emp_id = @id ", connection);
            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", incharge_id);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {

                mess.textBox2.Text = DataTable.Rows[0]["emp_name"].ToString();
               
            }

        }

        // Getting Admin Table From Database To Show In Labeles
        public void getMessInchargeValuesInLabels(Mess mess)
        {

            connection.Open();
            sqlCommand = new SqlCommand("SELECT * FROM Mess_Incharge_Rec WHERE Mess_Incharge_SNO = 1", connection);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {

                mess.label3.Text = (dr["Mess_Incharge_ID"].ToString());
                mess.label4.Text = (dr["Mess_Incharge_Name"].ToString());
               

            }
            connection.Close();
        }

        // Update Mess Incharge
        public void updateMessIncharge(Mess mess) {

            connection.Open();
            sqlCommand = new SqlCommand("UPDATE Mess_Incharge_Rec SET Mess_Incharge_ID = '"+ mess.comboBox1.Text + "' , Mess_Incharge_Name = '" + mess.textBox2.Text + "' WHERE Mess_Incharge_SNO = 1",connection);
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0) {

                MessageBox.Show("Record Updated Successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            connection.Close();

        }

        // Get Student ID'S In ComboBox To Add In Mess Program
        public void getStudentIdsInComboBox(Mess mess)
        {

            sqlCommand = new SqlCommand("SELECT * FROM Student ", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                int id = sqlDataReader.GetInt32(1);
                mess.comboBox2.Items.Add(id);

            }

            connection.Close();

        }


        // Show Name In TextBox According To ID To Add Student In Mess Program
        public void getStudentNameInTextBox(Mess mess)
        {

            int std_id = int.Parse(mess.comboBox2.SelectedItem.ToString());
            SqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Student WHERE std_id = @id ", connection);
            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", std_id);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {

                mess.textBox3.Text = DataTable.Rows[0]["std_name"].ToString();

            }

        }

        // Display Student In Mess Record Data Grid View
        public void DisplayStudentInMessRecDGV(Mess mess)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Student_In_Mess_Program ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            mess.dataGridView1.DataSource = DataTable;
            connection.Close();

        }
        // Insert Student In Mess Record 
        public void insertStudentInMess(Mess mess)
        {

            connection.Open();
            sqlCommand = new SqlCommand("INSERT INTO Student_In_Mess_Program (Student_ID,Student_Name) values(@Student_ID,@Student_Name)", connection);
            sqlCommand.Parameters.AddWithValue("@Student_ID",mess.comboBox2.Text);
            sqlCommand.Parameters.AddWithValue("@Student_Name", mess.textBox3.Text);
            int check  =  sqlCommand.ExecuteNonQuery();
            if (check > 0) {

                MessageBox.Show("Student Entered Successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            connection.Close();

        }

        // Delete Student In Mess Record 
        public void deleteStudentInMess(Mess mess)
        {

            connection.Open();
            sqlCommand = new SqlCommand("DELETE FROM Student_In_Mess_Program WHERE sno = @sno", connection);
            sqlCommand.Parameters.AddWithValue("@sno", mess.sno);
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Student Removed Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();

        }

        // Display Meal Timing In DataGrideView 
        public void displayMealTimingInDGV(Mess mess)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Meal_Timing ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            mess.dataGridView2.DataSource = DataTable;
            connection.Close();

        }
        // Update Meal Timing In DataGrideView 
        public void updateMealTiming(Mess mess)
        {

            connection.Open();
            sqlCommand = new SqlCommand("Update Meal_Timing SET Break_Fast = @Break_Fast , Lunch = @Lunch , Dinner = @Dinner , Update_Date = @Update_Date WHERE sno = 1", connection);
            sqlCommand.Parameters.AddWithValue("@Break_Fast",mess.dateTimePicker1.Value.ToLongTimeString());
            sqlCommand.Parameters.AddWithValue("@Lunch", mess.dateTimePicker2.Value.ToLongTimeString());
            sqlCommand.Parameters.AddWithValue("@Dinner", mess.dateTimePicker3.Value.ToLongTimeString());
            sqlCommand.Parameters.AddWithValue("@Update_Date", mess.dateTimePicker1.Value.ToShortDateString());
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0) {

                MessageBox.Show("Time Updated Sccessfully !", "Information" , MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();

        }

        // Display Meal Schedule In DataGrideView 
        public void displayMealScheduleInDGV(Mess mess)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Meal_Schedule ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            mess.dataGridView3.DataSource = DataTable;
            connection.Close();

        }

        // Update Meal Item In DataGrideView 
        public void updateMealItem(Mess mess)
        {

            connection.Open();
            sqlCommand = new SqlCommand("Update Meal_Schedule SET Item = @Item WHERE sno = @sno", connection);
            sqlCommand.Parameters.AddWithValue("@sno", mess.sno);
            sqlCommand.Parameters.AddWithValue("@Item", mess.textBox4.Text);
            
            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Item Updated Sccessfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();

        }
        
        // Display Monthly Expences 
        public void DisplayExpencesInLabels(Mess mess)
        {


            connection.Open();
            sqlCommand = new SqlCommand("SELECT * FROM Mess_Monthly_Expences WHERE  mess_expences_id = 1", connection);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read())
            {

                mess.textBox5.Text = (dr["totalperson"].ToString());
                mess.textBox6.Text = (dr["totalperson"].ToString());
                mess.textBox11.Text = (dr["totalperson"].ToString());
                mess.textBox8.Text = (dr["breakfastperperson"].ToString());
                mess.textBox10.Text = (dr["lunchperperson"].ToString());
                mess.textBox13.Text = (dr["dinnerperperson"].ToString());
                mess.textBox7.Text = (dr["breakfastperday"].ToString());
                mess.textBox9.Text = (dr["lunchperday"].ToString());
                mess.textBox12.Text = (dr["dinnerperday"].ToString());
                mess.perDayExpencesLabel.Text = (dr["totalperdayexpences"].ToString());
                mess.monthlyExpencesLabel.Text = (dr["monthly_expences"].ToString());
                mess.label8.Text = (dr["monthly_expences"].ToString());
                mess.label35.Text = (dr["totalperdayperperson"].ToString());
            }
            connection.Close();
        }

        // Update Meal Item In DataGrideView 
        public void updateMessExpences(Mess mess)
        {

            connection.Open();
            sqlCommand = new SqlCommand("Update Mess_Monthly_Expences SET totalperson = @totalperson , breakfastperperson = @breakfastperperson , breakfastperday = @breakfastperday , lunchperperson = @lunchperperson , lunchperday = @lunchperday , dinnerperperson = @dinnerperperson , dinnerperday = @dinnerperday , totalperdayexpences = @totalperdayexpences , monthly_expences = @monthly_expences , totalperdayperperson = @totalperdayperperson WHERE mess_expences_id = 1", connection);
            sqlCommand.Parameters.AddWithValue("@totalperson", mess.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@breakfastperperson", mess.textBox8.Text);
            sqlCommand.Parameters.AddWithValue("@breakfastperday", mess.textBox7.Text);
            sqlCommand.Parameters.AddWithValue("@lunchperperson", mess.textBox10.Text);
            sqlCommand.Parameters.AddWithValue("@lunchperday", mess.textBox9.Text);
            sqlCommand.Parameters.AddWithValue("@dinnerperperson", mess.textBox13.Text);
            sqlCommand.Parameters.AddWithValue("@dinnerperday", mess.textBox12.Text);
            sqlCommand.Parameters.AddWithValue("@totalperdayexpences", mess.perDayExpencesLabel.Text);
            sqlCommand.Parameters.AddWithValue("@monthly_expences", mess.monthlyExpencesLabel.Text);
            sqlCommand.Parameters.AddWithValue("@totalperdayperperson", mess.label35.Text);

            int check = sqlCommand.ExecuteNonQuery();
            if (check > 0)
            {

                MessageBox.Show("Expences Updated Sccessfully !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();

        }


        // Get Student ID'S In ComboBox For Fees Handling
        public void getStudentIdsInComboBoxForFess(Fees fees)
        {

            sqlCommand = new SqlCommand("SELECT * FROM Student ", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                int id = sqlDataReader.GetInt32(1);
                fees.comboBox5.Items.Add(id);

            }

            connection.Close();

        }


        // Show Name In TextBox According To ID To For Fees Handling
        public void getStudentNameInTextBoxForFees(Fees fees)
        {

            int std_id = int.Parse(fees.comboBox5.SelectedItem.ToString());
            SqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Student WHERE std_id = @id ", connection);
            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", std_id);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {

                fees.textBox2.Text = DataTable.Rows[0]["std_name"].ToString();

            }

        }

        // Insert Fees Record
        public void insertFeesRecord(Fees fees) {

            connection.Open();
            sqlCommand = new SqlCommand("INSERT INTO Fees (student_id,student_name,student_hostel_fees,student_mess_status,student_mess_charges,student_total_fees) values (@student_id,@student_name,@student_hostel_fees,@student_mess_status,@student_mess_charges,@student_total_fees)",connection);
            sqlCommand.Parameters.AddWithValue("@student_id", fees.comboBox5.Text);
            sqlCommand.Parameters.AddWithValue("@student_name", fees.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@student_hostel_fees", fees.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@student_mess_status", fees.comboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@student_mess_charges", fees.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@student_total_fees", fees.textBox4.Text);

            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0) {

                MessageBox.Show("Fess Record Inserted Successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);

            }
            connection.Close();
        }

        // Display Fees Record In DataGrideView 
        public void displayFeesRecordInDGV(Fees fees)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Fees ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            fees.dataGridView1.DataSource = DataTable;
            connection.Close();

        }

        // Update Fees Record
        public void updateFeesRecord(Fees fees)
        {

            connection.Open();
            sqlCommand = new SqlCommand("UPDATE Fees SET student_id = @student_id , student_name = @student_name , student_hostel_fees = @student_hostel_fees , student_mess_status = @student_mess_status , student_mess_charges = @student_mess_charges ,student_total_fees = @student_total_fees WHERE sno = @sno", connection);
            sqlCommand.Parameters.AddWithValue("@sno", fees.sno);
            sqlCommand.Parameters.AddWithValue("@student_id", fees.comboBox5.Text);
            sqlCommand.Parameters.AddWithValue("@student_name", fees.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@student_hostel_fees", fees.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@student_mess_status", fees.comboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@student_mess_charges", fees.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@student_total_fees", fees.textBox4.Text);

            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {

                MessageBox.Show("Fess Record Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();
        }

        // Delete Fees Record
        public void deleteFeesRecord(Fees fees)
        {

            if (MessageBox.Show("Do You Really Want To Delete Record","Question",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes) {

                connection.Open();
                sqlCommand = new SqlCommand("DELETE FROM Fees  WHERE sno = @sno", connection);
                sqlCommand.Parameters.AddWithValue("sno", fees.sno);
                int check = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }


        // Get Room ID'S In ComboBox For Furniture Handling
        public void getRoomIdsInComboBoxForFurniture(Furniture furniture)
        {

            sqlCommand = new SqlCommand("SELECT * FROM Room ", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                int id = sqlDataReader.GetInt32(0);
                furniture.comboBox5.Items.Add(id);

            }

            connection.Close();

        }

        // Show Name In TextBox According To ID To For Fees Handling
        public void getRoomDetailsInTextBoxForFees(Furniture furniture)
        {

            int std_id = int.Parse(furniture.comboBox5.SelectedItem.ToString());
            SqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Room WHERE sno = @id ", connection);
            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", std_id);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {

                furniture.textBox1.Text = DataTable.Rows[0]["room_floor"].ToString();
                furniture.textBox2.Text = DataTable.Rows[0]["room_block"].ToString();
                furniture.textBox3.Text = DataTable.Rows[0]["room_num"].ToString();

            }

        }

        // Insert Furniture Record
        public void insertFurnitureRecord(Furniture furniture)
        {

            connection.Open();
            sqlCommand = new SqlCommand("INSERT INTO Furniture (room_id,room_floor,room_block,room_no,furniture_name,details) values (@room_id,@room_floor,@room_block,@room_no,@furniture_name,@details)", connection);
            sqlCommand.Parameters.AddWithValue("@room_id", furniture.comboBox5.Text);
            sqlCommand.Parameters.AddWithValue("@room_floor", furniture.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@room_block", furniture.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@room_no", furniture.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@furniture_name", furniture.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@details", furniture.textBox4.Text);

            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {

                MessageBox.Show("Furniture Record Inserted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();
        }

        // Display Fees Record In DataGrideView 
        public void displayFurnitureRecordInDGV(Furniture furniture)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Furniture ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            furniture.dataGridView1.DataSource = DataTable;
            connection.Close();

        }

        // Update Furniture Record
        public void updateFurnitureRecord(Furniture furniture)
        {

            connection.Open();
            sqlCommand = new SqlCommand("UPDATE Furniture SET room_id = @room_id , room_floor = @room_floor , room_block = @room_block , room_no = @room_no , furniture_name = @furniture_name , details = @details WHERE sno = @sno", connection);
            sqlCommand.Parameters.AddWithValue("@sno", furniture.sno);
            sqlCommand.Parameters.AddWithValue("@room_id", furniture.comboBox5.Text);
            sqlCommand.Parameters.AddWithValue("@room_floor", furniture.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@room_block", furniture.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@room_no", furniture.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@furniture_name", furniture.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@details", furniture.textBox4.Text);

            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {

                MessageBox.Show("Furniture Record Updated Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();
        }

        // Delete Furniture Record
        public void deleteFurnitureRecord(Furniture furniture)
        {

            if (MessageBox.Show("Do You Really Want To Delete Record", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {

                connection.Open();
                sqlCommand = new SqlCommand("DELETE FROM Furniture  WHERE sno = @sno", connection);
                sqlCommand.Parameters.AddWithValue("sno", furniture.sno);
                int check = sqlCommand.ExecuteNonQuery();
                connection.Close();
            }
        }

        // Get Room ID'S In ComboBox For Visitor Handling
        public void getRoomIdsInComboBoxForVisitor(Visitor visitor)
        {

            sqlCommand = new SqlCommand("SELECT * FROM Room ", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                int id = sqlDataReader.GetInt32(0);
                visitor.comboBox1.Items.Add(id);

            }

            connection.Close();

        }

        // Show Name In TextBox According To ID To For Visitor Handling
        public void getRoomDetailsInTextBoxForVisitor(Visitor visitor)
        {

            int std_id = int.Parse(visitor.comboBox1.SelectedItem.ToString());
            SqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Room WHERE sno = @id ", connection);
            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", std_id);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {

                visitor.textBox1.Text = DataTable.Rows[0]["room_floor"].ToString();
                visitor.textBox2.Text = DataTable.Rows[0]["room_block"].ToString();
                visitor.textBox3.Text = DataTable.Rows[0]["room_num"].ToString();

            }

        }

        // Get Student ID'S In ComboBox For Visitor Handling
        public void getStudentIdsInComboBoxForVisitor(Visitor visitor)
        {

            sqlCommand = new SqlCommand("SELECT * FROM Student ", connection);
            connection.Open();
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

                int id = sqlDataReader.GetInt32(1);
                visitor.comboBox2.Items.Add(id);

            }

            connection.Close();

        }


        // Show Name In TextBox According To ID To For Visitors Handling
        public void getStudentNameInTextBoxForVisitors(Visitor visitor)
        {

            int std_id = int.Parse(visitor.comboBox2.SelectedItem.ToString());
            SqlDataAdapter = new SqlDataAdapter(" SELECT * FROM Student WHERE std_id = @id ", connection);
            SqlDataAdapter.SelectCommand.Parameters.AddWithValue("@id", std_id);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            if (DataTable.Rows.Count > 0)
            {

                visitor.textBox4.Text = DataTable.Rows[0]["std_name"].ToString();

            }

        }

        // Insert Furniture Record
        public void insertVisitorRecord(Visitor visitor)
        {

            connection.Open();
            sqlCommand = new SqlCommand("INSERT INTO Visitor (visiter_name,room_id,room_floor,room_block,room_no,student_id,student_name,entry_time,leaving_time) values (@visiter_name,@room_id,@room_floor,@room_block,@room_no,@student_id,@student_name,@entry_time,@leaving_time)", connection);
            sqlCommand.Parameters.AddWithValue("@visiter_name", visitor.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@room_id", visitor.comboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@room_floor", visitor.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@room_block", visitor.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@room_no", visitor.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@student_id", visitor.comboBox2.Text);
            sqlCommand.Parameters.AddWithValue("@student_name",visitor.textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@entry_time",visitor.dateTimePicker1.Value.ToString());
            sqlCommand.Parameters.AddWithValue("@leaving_time",visitor.dateTimePicker2.Value.ToString());
            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {

                MessageBox.Show("Visitor Record Inserted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();
        }

        // Display Fees Record In DataGrideView 
        public void displayVisitorRecordInDGV(Visitor visitor)
        {

            connection.Open();
            SqlDataAdapter = new SqlDataAdapter("SELECT * FROM Visitor ", connection);
            DataTable = new DataTable();
            SqlDataAdapter.Fill(DataTable);
            visitor.dataGridView1.DataSource = DataTable;
            connection.Close();

        }

        // Update Furniture Record
        public void updateVisitorRecord(Visitor visitor)
        {

            connection.Open();
            sqlCommand = new SqlCommand("Update Visitor SET visiter_name = @visiter_name , room_id = @room_id , room_floor = @room_floor , room_block = @room_block , room_no = @room_no , student_id = @student_id , student_name = @student_name , entry_time = @entry_time , leaving_time = @leaving_time WHERE visiter_id = @visiter_id", connection);
            sqlCommand.Parameters.AddWithValue("@visiter_id", visitor.sno);
            sqlCommand.Parameters.AddWithValue("@visiter_name", visitor.textBox5.Text);
            sqlCommand.Parameters.AddWithValue("@room_id", visitor.comboBox1.Text);
            sqlCommand.Parameters.AddWithValue("@room_floor", visitor.textBox1.Text);
            sqlCommand.Parameters.AddWithValue("@room_block", visitor.textBox2.Text);
            sqlCommand.Parameters.AddWithValue("@room_no", visitor.textBox3.Text);
            sqlCommand.Parameters.AddWithValue("@student_id", visitor.comboBox2.Text);
            sqlCommand.Parameters.AddWithValue("@student_name", visitor.textBox4.Text);
            sqlCommand.Parameters.AddWithValue("@entry_time", visitor.dateTimePicker1.Value.ToString());
            sqlCommand.Parameters.AddWithValue("@leaving_time", visitor.dateTimePicker2.Value.ToString());
            int check = sqlCommand.ExecuteNonQuery();

            if (check > 0)
            {

                MessageBox.Show("Visitor Record Update Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            connection.Close();
        }

        // Delete Visitor Record
        public void deleteVisitorRecord(Visitor visitor)
        {

            if (MessageBox.Show("Do You Really Want To Delete Record", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                connection.Open();
                sqlCommand = new SqlCommand("DELETE FROM Visitor WHERE visiter_id = @visiter_id ", connection);
                sqlCommand.Parameters.AddWithValue("@visiter_id", visitor.sno);
                int check = sqlCommand.ExecuteNonQuery();
                if (check > 0)
                {
                    MessageBox.Show("Record Delete Successfully","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                connection.Close();
            }
        }


    }
}
