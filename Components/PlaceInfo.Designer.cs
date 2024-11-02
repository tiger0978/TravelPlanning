namespace 旅遊景點規劃.Components
{
    partial class PlaceInfo
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
            this.placeName = new System.Windows.Forms.Label();
            this.rating_Num = new System.Windows.Forms.Label();
            this.rating = new System.Windows.Forms.Label();
            this.commentNum = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Address = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.phone = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.website = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // placeName
            // 
            this.placeName.AutoSize = true;
            this.placeName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.placeName.Location = new System.Drawing.Point(19, 12);
            this.placeName.Name = "placeName";
            this.placeName.Size = new System.Drawing.Size(168, 25);
            this.placeName.TabIndex = 0;
            this.placeName.Text = "台北101購物中心";
            // 
            // rating_Num
            // 
            this.rating_Num.AutoSize = true;
            this.rating_Num.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rating_Num.Location = new System.Drawing.Point(25, 45);
            this.rating_Num.Name = "rating_Num";
            this.rating_Num.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rating_Num.Size = new System.Drawing.Size(30, 19);
            this.rating_Num.TabIndex = 1;
            this.rating_Num.Text = "4.4";
            // 
            // rating
            // 
            this.rating.AutoSize = true;
            this.rating.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rating.ForeColor = System.Drawing.Color.Gold;
            this.rating.Location = new System.Drawing.Point(61, 45);
            this.rating.Name = "rating";
            this.rating.Size = new System.Drawing.Size(98, 18);
            this.rating.TabIndex = 10;
            this.rating.Text = "★★★★★";
            // 
            // commentNum
            // 
            this.commentNum.AutoSize = true;
            this.commentNum.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.commentNum.Location = new System.Drawing.Point(165, 44);
            this.commentNum.Name = "commentNum";
            this.commentNum.Size = new System.Drawing.Size(64, 19);
            this.commentNum.TabIndex = 11;
            this.commentNum.Text = "(61461)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(19, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 29);
            this.label3.TabIndex = 12;
            this.label3.Text = "📍";
            // 
            // Address
            // 
            this.Address.AutoSize = true;
            this.Address.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Address.Location = new System.Drawing.Point(57, 75);
            this.Address.Name = "Address";
            this.Address.Size = new System.Drawing.Size(238, 19);
            this.Address.TabIndex = 13;
            this.Address.Text = "110台灣台北市信義區市府路45 號";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(25, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "📞";
            // 
            // phone
            // 
            this.phone.AutoSize = true;
            this.phone.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.phone.Location = new System.Drawing.Point(57, 105);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(116, 19);
            this.phone.TabIndex = 15;
            this.phone.Text = "102 8101 8800";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(24, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 23);
            this.label5.TabIndex = 16;
            this.label5.Text = "🌍";
            // 
            // website
            // 
            this.website.AutoSize = true;
            this.website.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.website.Location = new System.Drawing.Point(60, 133);
            this.website.Name = "website";
            this.website.Size = new System.Drawing.Size(254, 19);
            this.website.TabIndex = 17;
            this.website.Text = "https://stage.taipei101mall.com.tw/";
            // 
            // PlaceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.website);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Address);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.commentNum);
            this.Controls.Add(this.rating);
            this.Controls.Add(this.rating_Num);
            this.Controls.Add(this.placeName);
            this.Name = "PlaceInfo";
            this.Size = new System.Drawing.Size(472, 166);
            this.Load += new System.EventHandler(this.PlaceInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label placeName;
        private System.Windows.Forms.Label rating_Num;
        private System.Windows.Forms.Label rating;
        private System.Windows.Forms.Label commentNum;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Address;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label website;
    }
}
