using System;
using System.Linq;
using System.Windows.Forms;
using MyWinFormsApp.data;
using MyWinFormsApp.model;

namespace MyWinFormsApp
{
    public partial class PostListForm : Form
    {
        private FlowLayoutPanel flowLayoutPanel;
        private Button btnRefresh;
        private AppDbContext dbContext;

        public PostListForm()
        {
            InitializeComponent();
            dbContext = new AppDbContext();
        }

        private void InitializeComponent()
        {
           

            this.flowLayoutPanel = new FlowLayoutPanel();
            this.flowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            this.flowLayoutPanel.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel.Size = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.flowLayoutPanel);

            this.btnRefresh = new Button();
            this.btnRefresh.Location = new System.Drawing.Point(12, 420);
            this.btnRefresh.Size = new System.Drawing.Size(100, 30);
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);
            this.Controls.Add(this.btnRefresh);

         
            this.Load += new EventHandler(this.PostListForm_Load);
        }

        private void PostListForm_Load(object sender, EventArgs e)
        {
            LoadPosts();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPosts();
        }

        private void LoadPosts()
        {
            
            flowLayoutPanel.Controls.Clear();

            var posts = dbContext.Posts.ToList();
            foreach (var post in posts)
            {
                
                var user = dbContext.Users.FirstOrDefault(u => u.Id == post.UserId);

                string postInfo = $"{post.Title} - {post.Content} by {user?.Username}";

               
                if (!string.IsNullOrEmpty(post.PhotoPath))
                {
                    postInfo += $" - Photo: {post.PhotoPath}";

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.ImageLocation = Path.Combine("wwwroot", post.PhotoPath);
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; 

                    Label label = new Label();
                    label.Text = postInfo;

                    Panel postPanel = new Panel();
                    postPanel.Controls.Add(label);
                    postPanel.Controls.Add(pictureBox);

                    flowLayoutPanel.Controls.Add(postPanel);
                }
                else
                {
                    Label label = new Label();
                    label.Text = postInfo;
                    flowLayoutPanel.Controls.Add(label);
                }
            }
        }
    }
}