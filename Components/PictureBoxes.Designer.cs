namespace 旅遊景點規劃.Components
{
    partial class PictureBoxes
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
            this.btn_Previous = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_Previous
            // 
            this.btn_Previous.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Previous.Location = new System.Drawing.Point(3, 101);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(40, 50);
            this.btn_Previous.TabIndex = 1;
            this.btn_Previous.Text = "◀";
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.Previous_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btn_Next.Location = new System.Drawing.Point(404, 101);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(40, 50);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = "▶";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.Next_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(49, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(349, 235);
            this.flowLayoutPanel1.TabIndex = 3;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // PictureBoxes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_Next);
            this.Controls.Add(this.btn_Previous);
            this.Name = "PictureBoxes";
            this.Size = new System.Drawing.Size(447, 241);
            this.Load += new System.EventHandler(this.PictureBoxes_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}
