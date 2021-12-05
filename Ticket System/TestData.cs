using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket_System
{
    /// <summary>
    /// 測試資料
    /// </summary>
    internal class TestData
    {
        /// <summary>
        /// 取得追蹤任務
        /// </summary>
        /// <returns>任務資料表</returns>
        internal DataTable GetTaskData()
        {
            DataTable TaskData = new DataTable();
            List<string> columnName = new List<string> { "CTIME", "TaskID", "InCharge", "描述", "嚴重度", "優先度", Constant.FINISH };
            columnName.ForEach(data => TaskData.Columns.Add(data));
            DataRow row = TaskData.NewRow();
            row["CTIME"] = DateTime.Now;
            row["TaskID"] = 1;
            row["InCharge"] = "王";
            row["描述"] = "測試";
            row["嚴重度"] = 0;
            row["優先度"] = 0;
            row[Constant.FINISH] = 1;
            TaskData.Rows.Add(row);
            return TaskData;
        }

        /// <summary>
        /// 取得人員資料
        /// </summary>
        /// <returns>人員資料表</returns>
        internal DataTable GetPersonalData()
        {
            DataTable personData = new DataTable();
            List<string> columnName = new List<string> { Constant.JOB_ID, Constant.RAND, Constant.NAME };
            columnName.ForEach(data => personData.Columns.Add(data));
            List<string> jobId = new List<string> { "A11111", "B22222", "C33333" };
            List<string> rank = new List<string> { Constant.QA, Constant.RD, Constant.PM };
            List<string> namd = new List<string> { "李", "王", "陳" };
            for (int i = 0; i < jobId.Count; i++)
            {
                DataRow row = personData.NewRow();
                row[Constant.JOB_ID] = jobId[i];
                row[Constant.RAND] = rank[i];
                row[Constant.NAME] = namd[i];
                personData.Rows.Add(row);
            }

            return personData;
        }
    }
}