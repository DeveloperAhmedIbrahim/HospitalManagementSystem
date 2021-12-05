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
using System.Runtime.InteropServices;

namespace Hostel_Managment_System
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

            
        // Object of LogInFunction Class Having All Methods
        LogInFunctions logInFunctions = new LogInFunctions();


        // Code To Move Window
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr intPtr, int wmsg, int wparam, int lparam);

        // Log In Button                                                
        private void loginButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations databaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
            databaseOperations.logIn(textBox1.Text,textBox2.Text,this);
           
        }

        // Close Button
        private void CloseButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Minimize Button
        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Move Panel 
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        // Username Enter Event
        private void textBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Text = logInFunctions.userNameEnter(this);
        }

        // Username Leave Event
        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Text = logInFunctions.userNameLeave(this);
        }

        // Password Enter Event
        private void textBox2_Enter(object sender, EventArgs e)
        {
            textBox2.Text = logInFunctions.passwordEnter(this);
        }

        // Password Leave Event
        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = logInFunctions.passwordLeave(this);
        }

        // CheckBox Event
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            logInFunctions.passwordShowHide(this);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

    }
}
