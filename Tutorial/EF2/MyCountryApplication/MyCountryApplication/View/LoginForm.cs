using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyCountry.DataAccess.Model;
using MyCountry.DataAccess.Persistence;
using MyCountryApplication.Common;


namespace MyCountryApplication.View
{
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName;
            if (IsMember(out userName))
            {
                Constants.IsLoggedIn = true;
                Constants.UserName = userName;
                Close();
            }
        }

       

        private Boolean IsMember(out string userName)
        {
            bool checkUserName;
            using (var dbContent = new MyCountryEntities())
            {
                userName = "";
                checkUserName = dbContent.Users.Any(x => x.UserName == txtUser.Text);
                var checkPassword = dbContent.Users.Any(x => x.Password == txtPassword.Text);

                if (!checkUserName)
                {
                    MessageBox.Show(StringMessages.LoginWrongUserID);
                    return false;
                }
                if (!checkPassword)
                {
                    MessageBox.Show(StringMessages.LoginWrongPassword);
                    return false;
                }

                userName = txtUser.Text;
                return true;
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
        }

      
    }
}
