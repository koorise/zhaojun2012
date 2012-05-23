//****************************************************************************************************
//            Author:          Koorise
//            DateTime:        2012/5/21 23:14:47
//            SearchMe:        http://www.Utopia-Studio.com
//            FileName:        ExamItem
//            Function:                
//            Description:    
//
//****************************************************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataCollectionApp
{
    /// <summary>
    /// 试题单元
    /// </summary>
    public class ExamItem
    {
        public string ExamID { get; set; }
        public string Content { get; set; }
        public string Exam_Type { get; set; }
        public string SelectNum { get; set; }
        public string OrderID { get; set; }
        public string Link_ExamID { get; set; }
        public string Link_Num { get; set; }
        public string Answer { get; set; }
        public string UserAnswer { get; set; }
        public string EScore { get; set; }
        public string UScore { get; set; }

        public string Analysis { get; set; }
        public string ReviewCount { get; set; }
        public string AnalyseNum { get; set; }

    }
}
