using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Hostel_Managment_System
{
    public partial class HMS_Panel : Form
    {

        public HMS_Panel()
        {
            InitializeComponent();
            showSubForms(new Intro());
            
        }

        private void HMS_Panel_Load(object sender, EventArgs e)
        {

        }


        // Maximize Button ===========================================
        private void MaximizeButton_Click(object sender, EventArgs e)
        {
          
            if (this.WindowState == FormWindowState.Normal)
            {

                this.WindowState = FormWindowState.Maximized;

            }
            else if (this.WindowState == FormWindowState.Maximized)
            {

                this.WindowState = FormWindowState.Normal;
       
            }


        }

           

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }


        // Menu Button ===========================================
        private void ManuButton_Click(object sender, EventArgs e)
        {
            if (this.SideBarPanel.Width == 200) {

                this.SideBarPanel.Width = 60;

            }
            else if (this.SideBarPanel.Width == 60) {

                this.SideBarPanel.Width = 200;
            }
        }

        // Close Button ===========================================
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimize Button ===========================================
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        // Method To Open Child From =======================================
        public void showSubForms(object childForm) {

            if (this.mainPanel.Controls.Count > 0) {
                this.mainPanel.Controls.RemoveAt(0);
                Form Form = childForm as Form;
                Form.TopLevel = false;
                Form.Dock = DockStyle.Fill;
                this.mainPanel.Controls.Add(Form);
                this.mainPanel.Tag = Form;
                Form.Show();
            }

        }


        public void deactivateAll()
        {

            // Deactivate Buttons
            button8.BackColor = Color.Transparent;
            button2.BackColor = Color.Transparent;
            button3.BackColor = Color.Transparent;
            button4.BackColor = Color.Transparent;
            button5.BackColor = Color.Transparent;
            button6.BackColor = Color.Transparent;
            button7.BackColor = Color.Transparent;
            button1.BackColor = Color.Transparent;

            // Deactivate Icons
            panel4.BackColor = Color.Transparent;
            panel5.BackColor = Color.Transparent;
            panel6.BackColor = Color.Transparent;
            panel7.BackColor = Color.Transparent;
            panel8.BackColor = Color.Transparent;
            panel9.BackColor = Color.Transparent;
            panel10.BackColor = Color.Transparent;
            panel12.BackColor = Color.Transparent;

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Lavender;

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.DodgerBlue;
        }

        // Admin Icon
        private void panel4_Click(object sender, EventArgs e)
        {
            showSubForms(new Admin());
            this.deactivateAll();
            panel4.BackColor = Color.Lavender;
            button1.BackColor = Color.Lavender;

        }

        // Admin Button 
        private void button1_Click(object sender, EventArgs e)
        {
            showSubForms(new Admin());
            this.deactivateAll();
            panel4.BackColor = Color.Lavender;
            button1.BackColor = Color.Lavender;
        }

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            panel3.BackColor = Color.Lavender; 
        }

        private void panel4_MouseLeave(object sender, EventArgs e)
        {
            panel3.BackColor = Color.DodgerBlue;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Lavender;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.DodgerBlue;
        }

        private void panel5_MouseEnter(object sender, EventArgs e)
        {
            panel13.BackColor = Color.Lavender;
        }

        private void panel5_MouseLeave(object sender, EventArgs e)
        {
            panel13.BackColor = Color.DodgerBlue;
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            panel16.BackColor = Color.Lavender;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            panel16.BackColor = Color.DodgerBlue;
        }

        private void panel6_MouseEnter(object sender, EventArgs e)
        {
            panel16.BackColor = Color.Lavender;
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            panel16.BackColor = Color.DodgerBlue;
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            panel17.BackColor = Color.Lavender;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            panel17.BackColor = Color.DodgerBlue;
        }

        private void panel7_MouseEnter(object sender, EventArgs e)
        {
            panel17.BackColor = Color.Lavender;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
            panel17.BackColor = Color.DodgerBlue;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            panel18.BackColor = Color.Lavender;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DodgerBlue;
        }

        private void panel8_MouseEnter(object sender, EventArgs e)
        {
            panel18.BackColor = Color.Lavender;
        }

        private void panel8_MouseLeave(object sender, EventArgs e)
        {
            panel18.BackColor = Color.DodgerBlue;
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            panel19.BackColor = Color.Lavender;
        }

        private void button6_MouseLeave(object sender, EventArgs e)
        {
            panel19.BackColor = Color.DodgerBlue;
        }

        private void panel9_MouseEnter(object sender, EventArgs e)
        {
            panel19.BackColor = Color.Lavender;
        }

        private void panel9_MouseLeave(object sender, EventArgs e)
        {
            panel19.BackColor = Color.DodgerBlue;
        }

        private void button7_MouseEnter(object sender, EventArgs e)
        {
            panel20.BackColor = Color.Lavender;
        }

        private void button7_MouseLeave(object sender, EventArgs e)
        {
            panel20.BackColor = Color.DodgerBlue;
        }

        private void panel10_MouseEnter(object sender, EventArgs e)
        {
            panel20.BackColor = Color.Lavender;
        }

        private void panel10_MouseLeave(object sender, EventArgs e)
        {
            panel20.BackColor = Color.DodgerBlue;
        }

        private void button8_MouseEnter(object sender, EventArgs e)
        {
            panel21.BackColor = Color.Lavender;
        }

        private void button8_MouseLeave(object sender, EventArgs e)
        {
            panel21.BackColor = Color.DodgerBlue;
        }

        private void panel12_MouseEnter(object sender, EventArgs e)
        {
            panel21.BackColor = Color.Lavender;
        }

        private void panel12_MouseLeave(object sender, EventArgs e)
        {
            panel21.BackColor = Color.DodgerBlue;
        }

        // Room Button
        private void button2_Click(object sender, EventArgs e)
        {
            showSubForms(new Room());
            this.deactivateAll();
            panel5.BackColor = Color.Lavender;
            button2.BackColor = Color.Lavender;
        }

        // Room Panel
        private void panel5_Click(object sender, EventArgs e)
        {
            showSubForms(new Room());
            this.deactivateAll();
            panel5.BackColor = Color.Lavender;
            button2.BackColor = Color.Lavender;
        }

        // Student Button
        private void button3_Click(object sender, EventArgs e)
        {
            showSubForms(new Student());
            this.deactivateAll();
            panel6.BackColor = Color.Lavender;
            button3.BackColor = Color.Lavender;
        }

        // Student Icon
        private void panel6_Click(object sender, EventArgs e)
        {
            showSubForms(new Student());
            this.deactivateAll();
            panel6.BackColor = Color.Lavender;
            button3.BackColor = Color.Lavender;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel7.BackColor = Color.Lavender;
            button4.BackColor = Color.Lavender;
            showSubForms(new Employ());
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel7.BackColor = Color.Lavender;
            button4.BackColor = Color.Lavender;
            showSubForms(new Employ());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel8.BackColor = Color.Lavender;
            button5.BackColor = Color.Lavender;
            showSubForms(new Mess());
        }

        private void panel8_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel8.BackColor = Color.Lavender;
            button5.BackColor = Color.Lavender;
            showSubForms(new Mess());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel9.BackColor = Color.Lavender;
            button6.BackColor = Color.Lavender;
            showSubForms(new Fees());

        }

        private void panel9_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel9.BackColor = Color.Lavender;
            button6.BackColor = Color.Lavender;
            showSubForms(new Fees());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel10.BackColor = Color.Lavender;
            button7.BackColor = Color.Lavender;
            showSubForms(new Furniture());
        }

        private void panel10_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel10.BackColor = Color.Lavender;
            button7.BackColor = Color.Lavender;
            showSubForms(new Furniture());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel12.BackColor = Color.Lavender;
            button8.BackColor = Color.Lavender;
            showSubForms(new Visitor());
        }

        private void panel12_Click(object sender, EventArgs e)
        {
            this.deactivateAll();
            panel12.BackColor = Color.Lavender;
            button8.BackColor = Color.Lavender;
            showSubForms(new Visitor());
        }

        // Code To Move Window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr intPtr, int wmsg, int wparam, int lparam);

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
