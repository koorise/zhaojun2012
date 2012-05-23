//****************************************************************************************************
//            Author:          Koorise
//            DateTime:        2012/5/22 13:54:50
//            SearchMe:        http://www.Utopia-Studio.com
//            FileName:        ComboxItem
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
    public class ComboxItem
    {  
        private string _Text;
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
            }
        }

        private string _Value;
        public string Value
        {
            get { return _Value; }
            set
            {
                _Value = value;
            }
        }

        public override string ToString()
        {
            return Text;
        }

    }
}
