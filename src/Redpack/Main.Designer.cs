
namespace Redpack
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.rbMinValue = new System.Windows.Forms.RadioButton();
            this.rbMaxValue = new System.Windows.Forms.RadioButton();
            this.rbMiddleValue = new System.Windows.Forms.RadioButton();
            this.numPerAmount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.numPerCount = new System.Windows.Forms.NumericUpDown();
            this.numTotalCount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lstRedpack = new System.Windows.Forms.ListBox();
            this.lstProbability = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPerAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalCount)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.rbMinValue);
            this.groupBox1.Controls.Add(this.rbMaxValue);
            this.groupBox1.Controls.Add(this.rbMiddleValue);
            this.groupBox1.Controls.Add(this.numPerAmount);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.numPerCount);
            this.groupBox1.Controls.Add(this.numTotalCount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "参数";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "随机方式：";
            // 
            // rbMinValue
            // 
            this.rbMinValue.AutoSize = true;
            this.rbMinValue.Location = new System.Drawing.Point(234, 78);
            this.rbMinValue.Name = "rbMinValue";
            this.rbMinValue.Size = new System.Drawing.Size(62, 21);
            this.rbMinValue.TabIndex = 6;
            this.rbMinValue.Text = "最小值";
            this.rbMinValue.UseVisualStyleBackColor = true;
            // 
            // rbMaxValue
            // 
            this.rbMaxValue.AutoSize = true;
            this.rbMaxValue.Location = new System.Drawing.Point(166, 78);
            this.rbMaxValue.Name = "rbMaxValue";
            this.rbMaxValue.Size = new System.Drawing.Size(62, 21);
            this.rbMaxValue.TabIndex = 6;
            this.rbMaxValue.Text = "最大值";
            this.rbMaxValue.UseVisualStyleBackColor = true;
            // 
            // rbMiddleValue
            // 
            this.rbMiddleValue.AutoSize = true;
            this.rbMiddleValue.Checked = true;
            this.rbMiddleValue.Location = new System.Drawing.Point(98, 78);
            this.rbMiddleValue.Name = "rbMiddleValue";
            this.rbMiddleValue.Size = new System.Drawing.Size(62, 21);
            this.rbMiddleValue.TabIndex = 6;
            this.rbMiddleValue.TabStop = true;
            this.rbMiddleValue.Text = "中位数";
            this.rbMiddleValue.UseVisualStyleBackColor = true;
            // 
            // numPerAmount
            // 
            this.numPerAmount.Location = new System.Drawing.Point(276, 33);
            this.numPerAmount.Name = "numPerAmount";
            this.numPerAmount.Size = new System.Drawing.Size(55, 23);
            this.numPerAmount.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(178, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "每个红包金额：";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(479, 71);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 28);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.button1_Click);
            // 
            // numPerCount
            // 
            this.numPerCount.Location = new System.Drawing.Point(499, 33);
            this.numPerCount.Name = "numPerCount";
            this.numPerCount.Size = new System.Drawing.Size(55, 23);
            this.numPerCount.TabIndex = 2;
            // 
            // numTotalCount
            // 
            this.numTotalCount.Location = new System.Drawing.Point(98, 33);
            this.numTotalCount.Name = "numTotalCount";
            this.numTotalCount.Size = new System.Drawing.Size(55, 23);
            this.numTotalCount.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(349, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "每个红包可领取个数：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "红包总个数：";
            // 
            // lstRedpack
            // 
            this.lstRedpack.Dock = System.Windows.Forms.DockStyle.Left;
            this.lstRedpack.FormattingEnabled = true;
            this.lstRedpack.ItemHeight = 17;
            this.lstRedpack.Location = new System.Drawing.Point(0, 115);
            this.lstRedpack.Name = "lstRedpack";
            this.lstRedpack.Size = new System.Drawing.Size(371, 416);
            this.lstRedpack.TabIndex = 1;
            // 
            // lstProbability
            // 
            this.lstProbability.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstProbability.FormattingEnabled = true;
            this.lstProbability.ItemHeight = 17;
            this.lstProbability.Location = new System.Drawing.Point(371, 115);
            this.lstProbability.Name = "lstProbability";
            this.lstProbability.Size = new System.Drawing.Size(205, 416);
            this.lstProbability.TabIndex = 2;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 531);
            this.Controls.Add(this.lstProbability);
            this.Controls.Add(this.lstRedpack);
            this.Controls.Add(this.groupBox1);
            this.Name = "Main";
            this.Text = "红包概率生成器";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPerAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPerCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2; 
        private System.Windows.Forms.NumericUpDown numTotalCount; 
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.NumericUpDown numPerCount;
        private System.Windows.Forms.NumericUpDown numPerAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbMinValue;
        private System.Windows.Forms.RadioButton rbMaxValue;
        private System.Windows.Forms.RadioButton rbMiddleValue; 
        private System.Windows.Forms.ListBox lstRedpack; 
        private System.Windows.Forms.ListBox lstProbability;
    }
}

