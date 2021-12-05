using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Hostel_Managment_System
{
    class LogInFunctions
    {
        

        // Method For Username Enter Event
        public string userNameEnter(LogIn logIn)
        {
            if (logIn.textBox1.Text == "Username") {

                logIn.textBox1.Text = "";
                
            }
            logIn.textBox1.ForeColor = Color.Black;
            return logIn.textBox1.Text;
        }

        // Method For Username Leave Event
        public string userNameLeave(LogIn logIn)
        {
            if (logIn.textBox1.Text == "")
            {
                logIn.textBox1.Text = "Username";
                logIn.textBox1.ForeColor = Color.DarkGray;
            }
            else
            {
                logIn.textBox1.ForeColor = Color.Black;
            }

            return logIn.textBox1.Text;
        }
        

        // Method For Password Enter Event
        public string passwordEnter(LogIn logIn)
        {
            if (logIn.textBox2.Text == "Password")
            {
                logIn.textBox2.Text = "";
            }
            logIn.textBox2.ForeColor = Color.Black;
            logIn.textBox2.UseSystemPasswordChar = true;
            return logIn.textBox2.Text;
        }

        // Method For Password Leave Event
        public string passwordLeave(LogIn logIn)
        {

            if (logIn.textBox2.Text == "")
            {
                logIn.textBox2.Text = "Password";
                logIn.textBox2.UseSystemPasswordChar = false;
                logIn.textBox2.ForeColor = Color.DarkGray;
            }

            return logIn.textBox2.Text;
        }

        // Method to show or hide password
        public void passwordShowHide(LogIn logIn)
        {
            if (logIn.checkBox1.Checked || logIn.textBox2.Text == "Password")
            {
                logIn.textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                logIn.textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}


