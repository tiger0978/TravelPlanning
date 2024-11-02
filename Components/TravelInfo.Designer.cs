namespace 旅遊景點規劃.Components
{
    partial class TravelInfo
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.title = new System.Windows.Forms.Label();
            this.delete = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Location = new System.Drawing.Point(0, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(260, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.click_OpenTravelDetail);
            // 
            // title
            // 
            this.title.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.title.Location = new System.Drawing.Point(3, 11);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(253, 25);
            this.title.TabIndex = 1;
            this.title.Text = "臺北二日遊";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.title.Click += new System.EventHandler(this.click_OpenTravelDetail);
            // 
            // delete
            // 
            this.delete.InitialImage = null;
            this.delete.Location = new System.Drawing.Point(210, 281);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(45, 45);
            this.delete.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.delete.TabIndex = 2;
            this.delete.TabStop = false;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // TravelInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.delete);
            this.Controls.Add(this.title);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(3, 3, 15, 3);
            this.Name = "TravelInfo";
            this.Size = new System.Drawing.Size(259, 342);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            this.Click += new System.EventHandler(this.click_OpenTravelDetail);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.delete)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox delete;
    }
}
