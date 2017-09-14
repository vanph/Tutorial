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
            using (var dbContent = new LoginEntities())
            {
                var checkUserId = dbContent.Users.Any(x => x.UserID == txtUser.Text);
                var checkPassword = dbContent.Users.Any(x => x.Password == txtPassword.Text);

                if (!checkUserId)
                {
                    MessageBox.Show(StringMessages.LoginWrongUserID);
                }
                if (!checkPassword)
                {
                    MessageBox.Show(StringMessages.LoginWrongPassword);
                }
                if (checkUserId && checkPassword)
                {
                    MessageBox.Show(StringMessages.LoginSuccess);
                }
            }
           
        }
    }
}
