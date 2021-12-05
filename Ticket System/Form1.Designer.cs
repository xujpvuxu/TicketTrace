
namespace Ticket_System
{
    partial class Form1
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Show = new System.Windows.Forms.DataGridView();
            this.JobNumber = new System.Windows.Forms.TextBox();
            this.Search = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShowJob = new System.Windows.Forms.Label();
            this.CreatNewTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Show)).BeginInit();
            this.SuspendLayout();
            // 
            // Show
            // 
            this.Show.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Show.Location = new System.Drawing.Point(12, 86);
            this.Show.Name = "Show";
            this.Show.ReadOnly = true;
            this.Show.RowHeadersWidth = 62;
            this.Show.RowTemplate.Height = 31;
            this.Show.Size = new System.Drawing.Size(776, 352);
            this.Show.TabIndex = 0;
            this.Show.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Show_CellDoubleClick);
            this.Show.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Show_CellEndEdit);
            this.Show.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Show_KeyDown);
            // 
            // JobNumber
            // 
            this.JobNumber.Location = new System.Drawing.Point(74, 32);
            this.JobNumber.Name = "JobNumber";
            this.JobNumber.Size = new System.Drawing.Size(174, 29);
            this.JobNumber.TabIndex = 1;
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(262, 28);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(75, 36);
            this.Search.TabIndex = 2;
            this.Search.Text = "查詢";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "工號";
            // 
            // ShowJob
            // 
            this.ShowJob.AutoSize = true;
            this.ShowJob.Location = new System.Drawing.Point(357, 38);
            this.ShowJob.Name = "ShowJob";
            this.ShowJob.Size = new System.Drawing.Size(0, 18);
            this.ShowJob.TabIndex = 4;
            // 
            // CreatNewTask
            // 
            this.CreatNewTask.Location = new System.Drawing.Point(462, 34);
            this.CreatNewTask.Name = "CreatNewTask";
            this.CreatNewTask.Size = new System.Drawing.Size(105, 32);
            this.CreatNewTask.TabIndex = 5;
            this.CreatNewTask.Text = "建立新任務";
            this.CreatNewTask.UseVisualStyleBackColor = true;
            this.CreatNewTask.Visible = false;
            this.CreatNewTask.Click += new System.EventHandler(this.CreatNewTask_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CreatNewTask);
            this.Controls.Add(this.ShowJob);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Search);
            this.Controls.Add(this.JobNumber);
            this.Controls.Add(this.Show);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Show)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Show;
        private System.Windows.Forms.TextBox JobNumber;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ShowJob;
        private System.Windows.Forms.Button CreatNewTask;
    }
}

