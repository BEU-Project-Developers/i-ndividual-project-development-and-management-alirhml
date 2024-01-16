using System;
using System.IO;
using System.Windows.Forms;
using MyWinFormsApp.data;
using MyWinFormsApp.model;

namespace MyWinFormsApp
{
    public partial class PostForm : Form
    {

        public string FilePath { get; set; }

        private TextBox txtPostTitle;
        private TextBox txtPostContent;
        private Button btnSharePost;
        private Button btnAddPhoto;
        private PictureBox picPostPhoto;
        private AppDbContext dbContext;
        private int loggedInUserId;
        private byte[] selectedPhoto;

        public PostForm(int userId)
        {
            InitializeComponent();
            loggedInUserId = userId;
            dbContext = new AppDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                
                picPostPhoto.Image?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPostTitle = new TextBox
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(300, 22)
            };
            Controls.Add(txtPostTitle);

            txtPostContent = new TextBox
            {
                Location = new System.Drawing.Point(12, 40),
                Size = new System.Drawing.Size(300, 150)
            };
            Controls.Add(txtPostContent);

            btnSharePost = new Button
            {
                Location = new System.Drawing.Point(12, 200),
                Size = new System.Drawing.Size(150, 30),
                Text = "Share Post"
            };
            btnSharePost.Click += new EventHandler(btnSharePost_Click);
            Controls.Add(btnSharePost);

            btnAddPhoto = new Button
            {
                Location = new System.Drawing.Point(180, 200),
                Size = new System.Drawing.Size(150, 30),
                Text = "Add Photo"
            };
            btnAddPhoto.Click += new EventHandler(btnAddPhoto_Click);
            Controls.Add(btnAddPhoto);

            picPostPhoto = new PictureBox
            {
                Location = new System.Drawing.Point(320, 12),
                Size = new System.Drawing.Size(150, 150)
            };
            Controls.Add(picPostPhoto);
        }

        private void btnSharePost_Click(object sender, EventArgs e)
        {
            string title = txtPostTitle.Text;
            string content = txtPostContent.Text;

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(content))
            {
                MessageBox.Show("Title and content cannot be empty!");
                return;
            }

            Post newPost = new Post
            {
                Title = title,
                Content = content,
                UserId = loggedInUserId,
                PhotoPath = FilePath 
            };

            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();

            MessageBox.Show("Post shared successfully!");
            Close();
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            
            string saveDirectory = @"C:\Users\Noah\Desktop\form'\Windovsform-Sosial\wwwroot\Photos\";
            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(saveDirectory))
                    {
                        Directory.CreateDirectory(saveDirectory);
                    }

                    string fileName = Path.GetFileName(openFileDialog1.FileName);
                    string fileSavePath = Path.Combine(saveDirectory, fileName);

                    FilePath = fileSavePath;
                    File.Copy(openFileDialog1.FileName, fileSavePath, true);
                }
            }
        }
    }
}
