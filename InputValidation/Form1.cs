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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (!ValidName(txtName.Text))
                MessageBox.Show("The name is invalid (only alphabetical characters are allowed)");

            txtPhone = ReformatPhone(txtPhone.Text);

            if (!ValidPhone(txtPhone))
                MessageBox.Show("The phone number is not a valid US phone number");
            else
            {
                MessageBox.Show(ReformatPhone(txtPhone.Text));
            }

            if (!ValidEmail(txtEmail.Text))
                MessageBox.Show("The e-mail address is not valid.");
        }

        private bool ValidName(string txt)
        {
            string name = @"[A-Za-z]";
            string whitespace = @"\s";
            return Regex.IsMatch(txt, @"^(" + name + whitespace + "*)+$");
        }

        private bool ValidPhone(string txt)
        {
            return Regex.IsMatch(txt, @"^((\(\d{3}\)?)|(\d{3}-))?\d{3}-\d{4}$");
        }

        private bool ValidEmail(string txt)
        {
            return Regex.IsMatch(txt, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        private string ReformatPhone(string s)
        {
            Match m = Regex.Match(s, @"^\(?(\d{3})\)?[\s\-]?(\d{3})\-?(\d{4})$");

            return String.Format("({0}) {1}-{2}",
                                 m.Groups[1],
                                 m.Groups[2],
                                 m.Groups[3]);
        }
    }
}
