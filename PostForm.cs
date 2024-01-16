using System;
using System.IO;
using System.Windows.Forms;
using MyWinFormsApp.data;
using MyWinFormsApp.model;

namespace MyWinFormsApp
{
    public partial class PostForm : Form
    {
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
                // Fotoğraf kontrolü için Dispose
                picPostPhoto.Image?.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // PostForm tasarım kodu burada yer alır

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

            string photoFileName = SavePhoto();

            Post newPost = new Post
            {
                Title = title,
                Content = content,
                UserId = loggedInUserId,
                PhotoPath = Path.Combine("Photos", photoFileName) // wwwroot içindeki yolu ayarla
            };

            dbContext.Posts.Add(newPost);
            dbContext.SaveChanges();

            MessageBox.Show("Post shared successfully!");
            Close();
        }

        private string SavePhoto()
        {
            if (selectedPhoto != null)
            {
                string wwwRootPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
                string photoFolder = Path.Combine(wwwRootPath, "Photos");

                if (!Directory.Exists(photoFolder))
                {
                    Directory.CreateDirectory(photoFolder);
                }

                string photoFileName = $"{Guid.NewGuid()}.jpg";

                string photoFilePath = Path.Combine(photoFolder, photoFileName);
                File.WriteAllBytes(photoFilePath, selectedPhoto);

                return photoFileName;
            }

            return null;
        }

        private void btnAddPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                selectedPhoto = File.ReadAllBytes(filePath);

                if (selectedPhoto != null)
                {
                    MemoryStream ms = new MemoryStream(selectedPhoto);
                    picPostPhoto.Image?.Dispose(); // Eski resmi temizle
                    picPostPhoto.Image = System.Drawing.Image.FromStream(ms);
                }
            }
        }
    }
}
