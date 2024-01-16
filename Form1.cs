using System;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    public partial class Form1 : Form
    {
        private Button btnOpenLoginForm;
        private Button btnOpenPostListForm;

        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            // Form1 tasarım kodu burada yer alır

            // btnOpenLoginForm
            this.btnOpenLoginForm = new Button
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(120, 30),
                Text = "Open Login Form"
            };
            this.btnOpenLoginForm.Click += new EventHandler(this.btnOpenLoginForm_Click);
            this.Controls.Add(this.btnOpenLoginForm);

            // btnOpenPostListForm
            this.btnOpenPostListForm = new Button
            {
                Location = new System.Drawing.Point(150, 12),
                Size = new System.Drawing.Size(150, 30),
                Text = "Open Post List Form"
            };
            this.btnOpenPostListForm.Click += new EventHandler(this.btnOpenPostListForm_Click);
            this.Controls.Add(this.btnOpenPostListForm);

            // Form1
            this.ClientSize = new System.Drawing.Size(800, 850);
            this.Text = "Main Form";
            this.Load += new EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
        }

        private void btnOpenLoginForm_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.ShowDialog();
        }

        private void btnOpenPostListForm_Click(object sender, EventArgs e)
        {
            PostListForm postListForm = new PostListForm();
            postListForm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Form yüklendiğinde yapılacak işlemler
        }
    }
}
