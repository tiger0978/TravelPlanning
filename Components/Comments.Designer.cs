using System.Drawing;

namespace 旅遊景點規劃.Components
{
    partial class Comments
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comments));
            this.comment = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.commentDate = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.authorName = new System.Windows.Forms.Label();
            this.rating = new System.Windows.Forms.Label();
            this.avatar = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).BeginInit();
            this.SuspendLayout();
            // 
            // comment
            // 
            this.comment.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comment.Location = new System.Drawing.Point(27, 82);
            this.comment.Multiline = true;
            this.comment.Name = "comment";
            this.comment.ReadOnly = true;
            this.comment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.comment.Size = new System.Drawing.Size(422, 171);
            this.comment.TabIndex = 3;
            this.comment.Text = resources.GetString("comment.Text");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // commentDate
            // 
            this.commentDate.AutoSize = true;
            this.commentDate.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.commentDate.Location = new System.Drawing.Point(338, 50);
            this.commentDate.Name = "commentDate";
            this.commentDate.Size = new System.Drawing.Size(83, 17);
            this.commentDate.TabIndex = 6;
            this.commentDate.Text = "4 weeks ago";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // authorName
            // 
            this.authorName.AutoSize = true;
            this.authorName.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.authorName.Location = new System.Drawing.Point(96, 22);
            this.authorName.Name = "authorName";
            this.authorName.Size = new System.Drawing.Size(61, 22);
            this.authorName.TabIndex = 8;
            this.authorName.Text = "王小名";
            // 
            // rating
            // 
            this.rating.AutoSize = true;
            this.rating.Font = new System.Drawing.Font("新細明體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rating.ForeColor = System.Drawing.Color.Gold;
            this.rating.Location = new System.Drawing.Point(96, 49);
            this.rating.Name = "rating";
            this.rating.Size = new System.Drawing.Size(98, 18);
            this.rating.TabIndex = 9;
            this.rating.Text = "★★★★★";
            // 
            // avatar
            // 
            this.avatar.Location = new System.Drawing.Point(27, 21);
            this.avatar.Name = "avatar";
            this.avatar.Size = new System.Drawing.Size(55, 55);
            this.avatar.TabIndex = 10;
            this.avatar.TabStop = false;
            // 
            // Comments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.avatar);
            this.Controls.Add(this.rating);
            this.Controls.Add(this.authorName);
            this.Controls.Add(this.commentDate);
            this.Controls.Add(this.comment);
            this.Name = "Comments";
            this.Size = new System.Drawing.Size(460, 264);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox comment;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label commentDate;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label authorName;
        private System.Windows.Forms.Label rating;
        private System.Windows.Forms.PictureBox avatar;
    }
}
