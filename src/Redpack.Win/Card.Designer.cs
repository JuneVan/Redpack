
namespace Redpack
{
    partial class Card
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labTitle = new System.Windows.Forms.Label();
            this.labNum = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labTitle
            // 
            this.labTitle.AutoSize = true;
            this.labTitle.Location = new System.Drawing.Point(33, 69);
            this.labTitle.Name = "labTitle";
            this.labTitle.Size = new System.Drawing.Size(26, 17);
            this.labTitle.TabIndex = 1;
            this.labTitle.Text = "0%";
            // 
            // labNum
            // 
            this.labNum.AutoSize = true;
            this.labNum.Font = new System.Drawing.Font("Microsoft YaHei UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labNum.Location = new System.Drawing.Point(14, -1);
            this.labNum.Name = "labNum";
            this.labNum.Size = new System.Drawing.Size(62, 70);
            this.labNum.TabIndex = 2;
            this.labNum.Text = "1";
            // 
            // Card
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labNum);
            this.Controls.Add(this.labTitle);
            this.Name = "Card";
            this.Size = new System.Drawing.Size(90, 90);
            this.Load += new System.EventHandler(this.Card_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
          
        private System.Windows.Forms.Label labTitle; 
        private System.Windows.Forms.Label labNum;
    }
}
