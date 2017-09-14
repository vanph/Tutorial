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
            var login = new User();
           
            if (login.UserName != txtUser.Text)
            {
                MessageBox.Show(StringMessages.LoginWrongUserID);
            }
            if ( login.Password != txtPassword.Text)
            {
                MessageBox.Show(StringMessages.LoginWrongPassword);
            }
            if (login.UserName == txtUser.Text && login.Password == txtPassword.Text)
            {
                MessageBox.Show(StringMessages.LoginSuccess);
            }
        }
    }
}
