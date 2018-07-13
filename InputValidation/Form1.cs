using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace InputValidation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^([A-Za-z]*\s*)+$"))
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");

            if (!Regex.IsMatch(txtPhone.Text, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$"))
                MessageBox.Show("The phone number is not a valid US phone number");

            if (!Regex.IsMatch(txtEmail.Text, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"))
                MessageBox.Show("The e-mail address is not valid.");
        }
    }
}
