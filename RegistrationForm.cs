using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using MyWinFormsApp.data;
using MyWinFormsApp.model;

namespace MyWinFormsApp
{
    public partial class RegistrationForm : Form
    {
        private TextBox txtRegisterUsername;
        private TextBox txtRegisterPassword;
        private Button btnRegister;
        private AppDbContext dbContext;

        public RegistrationForm()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        private void InitializeComponent()
        {
            // RegistrationForm tasarım kodu burada yer alır

            // Örneğin:
            this.txtRegisterUsername = new TextBox();
            this.txtRegisterUsername.Location = new System.Drawing.Point(50, 50);
            this.txtRegisterUsername.Size = new System.Drawing.Size(150, 22);
            this.Controls.Add(this.txtRegisterUsername);

            this.txtRegisterPassword = new TextBox();
            this.txtRegisterPassword.Location = new System.Drawing.Point(50, 80);
            this.txtRegisterPassword.Size = new System.Drawing.Size(150, 22);
            this.Controls.Add(this.txtRegisterPassword);

            this.btnRegister = new Button();
            this.btnRegister.Location = new System.Drawing.Point(50, 110);
            this.btnRegister.Size = new System.Drawing.Size(100, 30);
            this.btnRegister.Text = "Register";
            this.btnRegister.Click += new EventHandler(this.btnRegister_Click);
            this.Controls.Add(this.btnRegister);
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtRegisterUsername.Text;
            string password = txtRegisterPassword.Text;

            if (!dbContext.Users.Any(u => u.Username == username))
            {
                User newUser = new User { Username = username, Password = password };
                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                MessageBox.Show("Registration successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Username is already taken. Choose another one.");
            }
        }
    }
}
