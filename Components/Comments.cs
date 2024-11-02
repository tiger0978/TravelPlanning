using GoogleMapAPI.Places.PlaceDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static GoogleMapAPI.Places.PlaceDetail.PlaceDetailResponse;

namespace 旅遊景點規劃.Components
{
    public partial class Comments : UserControl
    {
        public Comments(Review review)
        {
            
            InitializeComponent();
            rating.Text = "";
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, avatar.Width, avatar.Height );
            Region rg = new Region(gp);
            avatar.Region = rg;
            avatar.SizeMode = PictureBoxSizeMode.StretchImage;
            try
            {
                authorName.Text = review.author_name;
                commentDate.Text = review.relative_time_description;
                comment.Text = review.text;
                for (int i = 0; i < review.rating; i++)
                {
                    rating.Text += "★";
                }
                avatar.Load(review.profile_photo_url);
            }
            catch (Exception ex) 
            {
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Comments_Load(object sender, EventArgs e)
        {

        }
    }
}
