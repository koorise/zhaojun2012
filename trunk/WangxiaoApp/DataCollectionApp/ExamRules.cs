//****************************************************************************************************
//            Author:          Koorise
//            DateTime:        2012/5/21 23:12:51
//            SearchMe:        http://www.Utopia-Studio.com
//            FileName:        ExamRules
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
    /// 试题分组--组单元
    /// </summary>
    public class ExamRules
    {
        public string RulesID { get; set; }

        public string RulesTitle { get; set; }
        public string RulesScore { get; set; }
        public string RulesScoreSet { get; set; }
        public List<ExamItem> examlist { get; set; } 
    }
}
