using System.IO;

namespace FeiTypeCodeBatch_FTCB_
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SaveFb = new System.Windows.Forms.Button();
            this.SaveCmd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(-2, 91);
            this.textBox1.Margin = new System.Windows.Forms.Padding(1);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(549, 660);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 46);
            this.button1.TabIndex = 1;
            this.button1.Text = "start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(104, 46);
            this.button2.TabIndex = 2;
            this.button2.Text = "save as the .bat file(cmd）";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaveFb
            // 
            this.SaveFb.Location = new System.Drawing.Point(381, 24);
            this.SaveFb.Margin = new System.Windows.Forms.Padding(1);
            this.SaveFb.Name = "SaveFb";
            this.SaveFb.Size = new System.Drawing.Size(113, 48);
            this.SaveFb.TabIndex = 3;
            this.SaveFb.Text = "save as the .fbpm file(FeiBatch Plus Method)";
            this.SaveFb.UseVisualStyleBackColor = true;
            this.SaveFb.Click += new System.EventHandler(this.SaveFb_Click);
            // 
            // SaveCmd
            // 
            this.SaveCmd.Location = new System.Drawing.Point(258, 26);
            this.SaveCmd.Margin = new System.Windows.Forms.Padding(1);
            this.SaveCmd.Name = "SaveCmd";
            this.SaveCmd.Size = new System.Drawing.Size(101, 46);
            this.SaveCmd.TabIndex = 4;
            this.SaveCmd.Text = "save as the .cmd file(cmd)";
            this.SaveCmd.UseVisualStyleBackColor = true;
            this.SaveCmd.Click += new System.EventHandler(this.SaveCmd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Warning";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Error";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 393);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SaveCmd);
            this.Controls.Add(this.SaveFb);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "Form1";
            this.Text = "FeiBatch-Code Editer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        public System.Windows.Forms.Button SaveFb;
        public System.Windows.Forms.Button SaveCmd;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
    }
}

