using GoogleMapAPI.Places;
using GoogleMapAPI.Places.PlaceDetail;
using GoogleMapAPI.Places.PlacePhoto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 旅遊景點規劃.Components
{
    public partial class PictureBoxes : UserControl
    {
        private List<Image> placeImages = new List<Image>();
        private PlaceDetailResponse _placeDetail;
        private int pictureIndex = 0;
       

        public PictureBoxes(PlaceDetailResponse placeDetail)
        {
            InitializeComponent();
            btn_Previous.Enabled = false;
            _placeDetail = placeDetail;
            GetImage();
            GetOtherImage();
        }

        private async void GetImage()
        {
            string firstPhoto = _placeDetail.result.photos[0].photo_reference;
            Image image = await PlaceService.GetPlacePhotoImage(firstPhoto,232) ; //先拿回第一張照片
            placeImages.Add(image); 
            CreatePictureBox(placeImages.First()); //讓第一張照片先渲染
        }
        private void Next_Click(object sender, EventArgs e)
        {
            btn_Previous.Enabled = true;
            pictureIndex += 1;
            Image currentImage = placeImages[pictureIndex];
            CreatePictureBox(currentImage);
            btn_Next.Enabled = pictureIndex != placeImages.Count - 1 ? true : false;
        }
        private void Previous_Click(object sender, EventArgs e)
        {
            btn_Next.Enabled = true;
            pictureIndex -= 1;
            Image currentImage = placeImages[pictureIndex];
            CreatePictureBox(currentImage);
            btn_Previous.Enabled = pictureIndex != 0 ? true : false;
        }

        private void CreatePictureBox(Image image)
        {
            flowLayoutPanel1.Controls.Clear();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Size = new Size(346, 232);
            pictureBox.TabStop = false;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = image;
            flowLayoutPanel1.Controls.Add(pictureBox);
        }

        private void GetOtherImage() //渲染過程先將其他照片抓下來放入list中
        {
            List<Task<Image>> taskImages = new List<Task<Image>>();
            for(int i =1; i<_placeDetail.result.photos.Length; i++)
            {
                string photoRef = _placeDetail.result.photos[i].photo_reference;
                Task<Image> taskImage = PlaceService.GetPlacePhotoImage(photoRef,232);
                taskImages.Add(taskImage);
            }
            Task.Run(() =>
            {
                Task.WhenAll(taskImages).Wait();
                List<Image> temp = new List<Image>();
                taskImages.ForEach(async x => {
                    temp.Add((await x));
                });
                placeImages.AddRange(temp);
            });
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBoxes_Load(object sender, EventArgs e)
        {

        }
    }
}
