
namespace Ticket_System
{
    partial class NewTask
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
            this.Content = new System.Windows.Forms.RichTextBox();
            this.確定 = new System.Windows.Forms.Button();
            this.Describe = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Location = new System.Drawing.Point(12, 113);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(588, 152);
            this.Content.TabIndex = 1;
            this.Content.Text = "";
            // 
            // 確定
            // 
            this.確定.Location = new System.Drawing.Point(240, 286);
            this.確定.Name = "確定";
            this.確定.Size = new System.Drawing.Size(99, 46);
            this.確定.TabIndex = 2;
            this.確定.Text = "Check";
            this.確定.UseVisualStyleBackColor = true;
            this.確定.Click += new System.EventHandler(this.確定_Click);
            // 
            // Describe
            // 
            this.Describe.AutoSize = true;
            this.Describe.Location = new System.Drawing.Point(222, 77);
            this.Describe.Name = "Describe";
            this.Describe.Size = new System.Drawing.Size(44, 18);
            this.Describe.TabIndex = 3;
            this.Describe.Text = "描述";
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 392);
            this.Controls.Add(this.Describe);
            this.Controls.Add(this.確定);
            this.Controls.Add(this.Content);
            this.Name = "NewTask";
            this.Text = "NewTask";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox Content;
        private System.Windows.Forms.Button 確定;
        private System.Windows.Forms.Label Describe;
    }
}