using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using DB;
using System.Text.RegularExpressions;

namespace Ticket_System
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// 人員資料
        /// </summary>
        private Dictionary<string, DataRow> PersonalData;

        /// <summary>
        /// 任務資料
        /// </summary>
        private DataTable TaskData;

        /// <summary>
        /// 職級
        /// </summary>
        private string Job = null;

        /// <summary>
        /// 任務編號
        /// </summary>
        private int MissionNumer { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            GetPersonData();
            GetTaskData();
        }

        /// <summary>
        /// 查詢
        /// </summary>
        /// <param name="sender">查詢事件</param>
        /// <param name="e">查詢案件</param>
        private void Search_Click(object sender, EventArgs e)
        {
            ShowJob.Text = null;

            if (Regex.IsMatch(JobNumber.Text, "[A-Z][0-9]{5}")
                && PersonalData.TryGetValue(JobNumber.Text.ToUpper(), out DataRow personal))
            {
                Job = personal.Field<string>(Constant.RAND);
                ShowJob.Text = Job;
                CreatNewTask.Visible = Job == Constant.QA;
            }
        }

        /// <summary>
        /// 雙擊格子
        /// </summary>
        /// <param name="sender">雙擊格子按鍵</param>
        /// <param name="e">雙擊格子事件</param>
        private void Show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //欄位名稱
            string columnName = TaskData.Columns[e.ColumnIndex].ToString();

            //可修改欄位的條件
            List<Tuple<string, string>> editColumn = new List<Tuple<string, string>>
            {
                { new Tuple<string, string>( Constant.RD, "完成")},
                { new Tuple<string, string>( Constant.QA, "描述")},
                { new Tuple<string, string>( Constant.PM, "嚴重度")},
                { new Tuple<string, string>( Constant.PM, "優先度")},
            };

            Show.ReadOnly = !editColumn.Contains(new Tuple<string, string>(Job, columnName));
        }

        /// <summary>
        /// 欄位值修改後
        /// </summary>
        /// <param name="sender">欄位值修改後</param>
        /// <param name="e">欄位值修改後事件</param>
        private void Show_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
#if !DEBUG
            string columnName = TaskData.Columns[Show.SelectedCells[0].ColumnIndex].ToString();
            int rowPosition = Show.SelectedCells[0].RowIndex;

            string taskId = TaskData.Rows[rowPosition].Field<string>("TaskID");
            string content = TaskData.Rows[rowPosition].Field<string>(columnName);

            string sqlCommand = $@"UPDATE [任務]
                                   SET {columnName} = N'{content}'
                                   WHERE [TaskID] = taskId";
#endif
            Show.ReadOnly = true;
        }

        /// <summary>
        /// 創建新任務
        /// </summary>
        /// <param name="sender">新任務按鍵</param>
        /// <param name="e">新任務事件</param>
        private void CreatNewTask_Click(object sender, EventArgs e)
        {
            NewTask newMission = new NewTask(this);
            newMission.Show(this);
        }

        /// <summary>
        /// 新增任務
        /// </summary>
        /// <param name="content">描述</param>
        public void GetMessage(string content)
        {
            MissionNumer++;
            DataRow row = TaskData.NewRow();
            row["CTIME"] = DateTime.Now;
            row["TaskID"] = MissionNumer;
            row["InCharge"] = PersonalData[JobNumber.Text].Field<string>("姓名");
            row["描述"] = content;
            row["嚴重度"] = 99;
            row["優先度"] = 99;
            row["完成"] = 0;
            TaskData.Rows.Add(row);

#if !DEBUG
            string sqlCommand = $@"INSERT INTO [任務](CTIME,TaskID,InCharge,描述,嚴重度,優先度,完成)
                                   VALUES({DateTime.Now},
                                          {row.Field<string>("TaskID")},
                                          {row.Field<string>("InCharge")},
                                          {row.Field<string>("描述")},
                                          {row.Field<string>("嚴重度")},
                                          {row.Field<string>("優先度")},
                                          {row.Field<string>("完成")})";
            DBRelated.DoSQLQuery(sqlCommand, DB.DBRelated.GetConnectString());
#endif
        }

        /// <summary>
        /// 刪除
        /// </summary>
        /// <param name="sender">刪除按鍵</param>
        /// <param name="e">Delete事件</param>
        private void Show_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && Job == Constant.QA)
            {
                int rowPosition = Show.SelectedCells[0].RowIndex;

#if !DEBUG
                string command = $@"DELETE
                                    FROM [任務]
                                    WHERE TaskID = N'{TaskData.AsEnumerable().ToList()[rowPosition].Field<string>("TaskID")}'";
                DBRelated.DoSQLQuery(command, DBRelated.GetConnectString());
#endif
                TaskData.Rows.RemoveAt(rowPosition);
            }
        }

        /// <summary>
        /// 取得人員資料
        /// </summary>
        private void GetPersonData()
        {
#if DEBUG
            //建立假資料
            DataTable personData = new TestData().GetPersonalData();

#else
            string command = $@"SELECT
                                    [工號]
                                    ,[職級]
                                    ,[姓名]
                                FROM [職級表]";
            string lineString = "192.168.XX.X;XXXXXXXXXX";

            DataTable personData = DBRelated.DoSQLQuery(command, lineString);
#endif
            PersonalData = personData.AsEnumerable()
                                     .ToDictionary(
                                        key => key.Field<string>(Constant.JOB_ID),
                                        value => value);
        }

        /// <summary>
        /// 取得任務資料
        /// </summary>
        private void GetTaskData()
        {
#if DEBUG
            //建立假資料
            TaskData = new TestData().GetTaskData();
#else
            string command = $@"SELECT TOP(20)
                                     [CTIME]
                                    ,[TaskID]
                                    ,[InCharge]
                                    ,[描述]
                                    ,[嚴重度]
                                    ,[優先度]
                                    ,[完成]
                                FROM [任務]";
                                ORDER BY [TaskID] DESC
            string lineString = "192.168.XX.X;XXXXXXXXXX";
            DataTable taskData = DBRelated.DoSQLQuery(command, lineString);
#endif

            List<DataRow> task = TaskData.AsEnumerable().ToList(); ;
            MissionNumer = task.Any() ?
                                task.Max(data => int.Parse(data.Field<string>("TaskID"))) :
                                0;

            Show.DataSource = TaskData;
        }
    }
}