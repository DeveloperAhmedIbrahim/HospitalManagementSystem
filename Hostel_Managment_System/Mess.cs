using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hostel_Managment_System.Expences;

namespace Hostel_Managment_System
{
    public partial class Mess : Form
    {
        public int sno = 0;
        DatabaseOperations DatabaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
        public Mess()
        {
            InitializeComponent();
            updateInchargePanel.Hide();
            DatabaseOperations.getEmployIdsInComboBox(this);
            DatabaseOperations.getStudentIdsInComboBox(this);
            DatabaseOperations.getMessInchargeValuesInLabels(this);
            DatabaseOperations.DisplayStudentInMessRecDGV(this);
            DatabaseOperations.displayMealScheduleInDGV(this);
            DatabaseOperations.DisplayExpencesInLabels(this);
            insertStudentInMessProgramPanel.Hide();
            updateMealTimePanel.Hide();
            updateItemPanel.Hide();
            DatabaseOperations.displayMealTimingInDGV(this);
            dataGridView2.ScrollBars = ScrollBars.None;
            Meal_Schedule_Panel.Hide();
            expencesPanel.Hide();
        }

        private void showUpdateInchargePanel_Click(object sender, EventArgs e)
        {
            updateInchargePanel.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            updateInchargePanel.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != null) {

                DatabaseOperations.getEmployNameInTextBox(this);

            }
        }

        private void updateMessInchargeButton_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" || comboBox1.Text != "") {


                DatabaseOperations.updateMessIncharge(this);
                DatabaseOperations.getMessInchargeValuesInLabels(this);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            insertStudentInMessProgramPanel.Hide();
        }

        private void openAddRoomPanel_Click(object sender, EventArgs e)
        {
            insertStudentInMessProgramPanel.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DatabaseOperations.getStudentNameInTextBox(this);
        }

        private void addStudentInMessProgramButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.insertStudentInMess(this);
            DatabaseOperations.DisplayStudentInMessRecDGV(this);
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sno = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
        }

        // Delete Student In Mess Program
        private void button4_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do You Really Want To Delete Record ??","Information",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes) {

                DatabaseOperations.deleteStudentInMess(this);
                DatabaseOperations.DisplayStudentInMessRecDGV(this);

            }
        }

        private void dateTimePicker1_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker1.CustomFormat = "hh:mm";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            updateMealTimePanel.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateMealTimePanel.Show();
        }

        private void dateTimePicker2_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker2.CustomFormat = "hh:mm";
        }

        private void dateTimePicker3_MouseDown(object sender, MouseEventArgs e)
        {
            dateTimePicker3.CustomFormat = "hh:mm";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatabaseOperations.updateMealTiming(this);
            DatabaseOperations.displayMealTimingInDGV(this);
        }

        private void updateMealTimePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Meal_Schedule_Panel.Show();
            Meal_Schedule_Panel.Dock = DockStyle.Fill;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Meal_Schedule_Panel.Hide();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            sno = int.Parse(dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString());
            string day = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            string time = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            label23.Text = day;
            label24.Text = time;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            updateItemPanel.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (label23.Text == "label23")
            {

                MessageBox.Show("Please select a row !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            { 
                updateItemPanel.Width = 300;
                updateItemPanel.Show();

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

       
                DatabaseOperations.updateMealItem(this);
                DatabaseOperations.displayMealScheduleInDGV(this);

            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            expencesPanel.Dock = DockStyle.Fill;
            expencesPanel.Show();

        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            expencesPanel.Hide();
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox5.Text;
            textBox11.Text = textBox5.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox5.Text = textBox6.Text;
            textBox11.Text = textBox6.Text;
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            textBox6.Text = textBox11.Text;
            textBox5.Text = textBox11.Text;
        }

        public string perDayPerPersonCharges;

        private void calculateButton_Click(object sender, EventArgs e)
        {

            Breakfast breakfast = new Breakfast(int.Parse(textBox5.Text),int.Parse(textBox8.Text));
            textBox7.Text = breakfast.TotalBreakfastCost().ToString() + " Rs.";

            Lunch lunch = new Lunch(int.Parse(textBox6.Text), int.Parse(textBox10.Text));
            textBox9.Text = lunch.TotalLunchCost().ToString() + " Rs.";

            Dinner dinner = new Dinner(int.Parse(textBox11.Text), int.Parse(textBox13.Text));
            textBox12.Text = dinner.TotalDinnerCost().ToString() + " Rs.";

            int perdayExp = breakfast.TotalBreakfastCost() + lunch.TotalLunchCost() + dinner.TotalDinnerCost();

            perDayExpencesLabel.Text = perdayExp.ToString() + " Rs.";

            int monthlyExp = perdayExp * 30;

            monthlyExpencesLabel.Text = monthlyExp.ToString() + " Rs.";

            int perDayPerPersonCharges = int.Parse(textBox8.Text) + int.Parse(textBox10.Text) + int.Parse(textBox13.Text);
            label35.Text = perDayPerPersonCharges.ToString();
        }

        private void label40_Click(object sender, EventArgs e)
        {

        }

        private void label39_Click_1(object sender, EventArgs e)
        {

        }

        private void expencesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateMessExpences_Click(object sender, EventArgs e)
        {
            DatabaseOperations.updateMessExpences(this);
            DatabaseOperations.DisplayExpencesInLabels(this);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DatabaseOperations.DisplayExpencesInLabels(this);
        }
    }
}
