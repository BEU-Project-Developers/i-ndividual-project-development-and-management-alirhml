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
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private AppDbContext dbContext;

        public RegistrationForm()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            txtRegisterUsername = new TextBox();
            txtRegisterPassword = new TextBox();
            btnRegister = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtRegisterUsername
            // 
            txtRegisterUsername.Location = new Point(38, 106);
            txtRegisterUsername.Name = "txtRegisterUsername";
            txtRegisterUsername.Size = new Size(150, 23);
            txtRegisterUsername.TabIndex = 0;
            // 
            // txtRegisterPassword
            // 
            txtRegisterPassword.Location = new Point(38, 144);
            txtRegisterPassword.Name = "txtRegisterPassword";
            txtRegisterPassword.Size = new Size(150, 23);
            txtRegisterPassword.TabIndex = 1;
            // 
            // btnRegister
            // 
            btnRegister.Location = new Point(63, 180);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(100, 30);
            btnRegister.TabIndex = 2;
            btnRegister.Text = "Register";
            btnRegister.Click += btnRegister_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(38, 53);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 32);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Lucida Sans Unicode", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = SystemColors.InactiveCaptionText;
            textBox1.Location = new Point(82, 56);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(120, 32);
            textBox1.TabIndex = 4;
            textBox1.Text = "Instagram";
            textBox1.TextAlign = HorizontalAlignment.Center;
            // 
            // RegistrationForm
            // 
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(246, 281);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(txtRegisterUsername);
            Controls.Add(txtRegisterPassword);
            Controls.Add(btnRegister);
            Name = "RegistrationForm";
            Load += RegistrationForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}
