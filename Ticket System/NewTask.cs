using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticket_System
{
    /// <summary>
    /// 新增任務
    /// </summary>
    public partial class NewTask : Form
    {
        /// <summary>
        /// 主視窗
        /// </summary>
        private Form1 Main_Form;

        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="mainForm">主視窗</param>
        public NewTask(Form1 mainForm)
        {
            InitializeComponent();
            Main_Form = mainForm;
        }

        /// <summary>
        /// 將描述回傳
        /// </summary>
        /// <param name="sender">確定按鍵</param>
        /// <param name="e">確定事件</param>
        private void 確定_Click(object sender, EventArgs e)
        {
            Main_Form.Invoke(new Action(() => Main_Form.GetMessage(Content.Text)));
            this.Dispose();
        }
    }
}