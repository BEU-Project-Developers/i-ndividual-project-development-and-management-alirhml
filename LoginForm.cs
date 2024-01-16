using System;
using System.Linq;
using System.Windows.Forms;
using MyWinFormsApp.data;
using MyWinFormsApp.model;

namespace MyWinFormsApp
{
    public partial class LoginForm : Form
    {
        private TextBox txtLoginUsername;
        private TextBox txtLoginPassword;
        private Button btnLogin;
        private Button btnOpenPostForm;
        private Button btnOpenRegistrationFormForm;
        private AppDbContext dbContext;
        private int loggedInUserId;

        public LoginForm()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        private void InitializeComponent()
        {
            this.txtLoginUsername = new TextBox
            {
                Location = new System.Drawing.Point(50, 50),
                Size = new System.Drawing.Size(300, 30),
                Font = new System.Drawing.Font("Arial", 12),
                PlaceholderText = "Username"
            };
            this.txtLoginUsername.HandleCreated += (s, e) => SendMessage(txtLoginUsername.Handle, 0x1501, 1, "Username");

            this.Controls.Add(this.txtLoginUsername);

            this.txtLoginPassword = new TextBox
            {
                Location = new System.Drawing.Point(50, 90),
                Size = new System.Drawing.Size(300, 30),
                Font = new System.Drawing.Font("Arial", 12),
                UseSystemPasswordChar = true,
                PlaceholderText = "Password"
            };
            this.txtLoginPassword.HandleCreated += (s, e) => SendMessage(txtLoginPassword.Handle, 0x1501, 1, "Password");

            this.Controls.Add(this.txtLoginPassword);

            this.btnLogin = new Button
            {
                Location = new System.Drawing.Point(50, 130),
                Size = new System.Drawing.Size(150, 35),
                Text = "Login",
                Font = new System.Drawing.Font("Arial", 12)
            };
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);
            this.Controls.Add(this.btnLogin);

            this.btnOpenPostForm = new Button
            {
                Location = new System.Drawing.Point(50, 175),
                Size = new System.Drawing.Size(150, 35),
                Text = "Open Post Form",
                Font = new System.Drawing.Font("Arial", 12)
            };
            this.btnOpenPostForm.Click += new EventHandler(this.btnOpenPostForm_Click);
            this.Controls.Add(this.btnOpenPostForm);

            this.btnOpenRegistrationFormForm = new Button
            {
                Location = new System.Drawing.Point(50, 220),
                Size = new System.Drawing.Size(200, 35),
                Text = "Open Registration Form",
                Font = new System.Drawing.Font("Arial", 12)
            };
            this.btnOpenRegistrationFormForm.Click += new EventHandler(this.btnOpenRegistrationFormForm_Click);
            this.Controls.Add(this.btnOpenRegistrationFormForm);
        }

        private void btnOpenRegistrationFormForm_Click(object sender, EventArgs e)
        {
            RegistrationForm loginForm = new RegistrationForm();
            loginForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtLoginUsername.Text;
            string password = txtLoginPassword.Text;

            User user = dbContext.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                MessageBox.Show($"Welcome, {user.Username}!");
                loggedInUserId = user.Id;

               
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }
        }


        private void btnOpenPostForm_Click(object sender, EventArgs e)
        {
            if (loggedInUserId > 0)
            {
                PostForm postForm = new PostForm(loggedInUserId);
                postForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please login first!");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Size = new System.Drawing.Size(400, 350);
            CenterToScreen();
        }

        // Placeholder text için gerekli Windows API fonksiyonu
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPWStr)] string lParam);
    }
}
