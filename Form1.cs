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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            btnOpenLoginForm = new Button();
            btnOpenPostListForm = new Button();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnOpenLoginForm
            // 
            btnOpenLoginForm.BackColor = SystemColors.InactiveCaption;
            btnOpenLoginForm.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenLoginForm.Location = new Point(83, 174);
            btnOpenLoginForm.Name = "btnOpenLoginForm";
            btnOpenLoginForm.Size = new Size(152, 48);
            btnOpenLoginForm.TabIndex = 0;
            btnOpenLoginForm.Text = "Login / Register";
            btnOpenLoginForm.UseVisualStyleBackColor = false;
            btnOpenLoginForm.Click += btnOpenLoginForm_Click;
        
            btnOpenPostListForm.BackColor = SystemColors.InactiveCaption;
            btnOpenPostListForm.Font = new Font("Times New Roman", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOpenPostListForm.Location = new Point(262, 174);
            btnOpenPostListForm.Name = "btnOpenPostListForm";
            btnOpenPostListForm.Size = new Size(141, 48);
            btnOpenPostListForm.TabIndex = 1;
            btnOpenPostListForm.Text = "Post Section";
            btnOpenPostListForm.UseVisualStyleBackColor = false;
            btnOpenPostListForm.Click += btnOpenPostListForm_Click;
           
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(131, 71);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(63, 56);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
           
            textBox1.BackColor = SystemColors.ActiveCaption;
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Font = new Font("Times New Roman", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(206, 79);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 50);
            textBox1.TabIndex = 3;
            textBox1.Text = "Instagram";
        
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(507, 311);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Controls.Add(btnOpenLoginForm);
            Controls.Add(btnOpenPostListForm);
            Name = "Form1";
            Text = "Main Form";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
           
        }
    }
}
