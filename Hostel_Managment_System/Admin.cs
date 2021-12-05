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
    public partial class Admin : Form
    {
        DatabaseOperations DatabaseOperations = new DatabaseOperations(@"Data Source=SIDDIQUICOMPUTE\SQLEXPRESS01;Initial Catalog=Hostel_Managment_System;Integrated Security=True");
        // Admin Panel Constructors
        public Admin()
        {
            InitializeComponent();
            this.updateAdminPanel.Hide(); // Hide Update Panel Initialy
            DatabaseOperations.getValuesInLabels(this); // Getting Values In Labels
            DatabaseOperations.getValuesInTextBoxes(this); // Getting Values In Update Panel Text Boxes

        }
        
        // Close Admin Panel Button
        private void CloseButton_Click_1(object sender, EventArgs e)
        {
            updateAdminPanel.Hide();
        }

        // Refresh Admin Record Button
        private void refreshAdminRecButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.getValuesInLabels(this);
        }

        // Update Admin Record Button
        private void updateAdminButton_Click(object sender, EventArgs e)
        {
            DatabaseOperations.updateAdminRecord(this);
        }

        // Open Admin Panel Button
        private void openUpdateAdminPanel_Click(object sender, EventArgs e)
        {
            updateAdminPanel.Show();
        }
    }    
}
