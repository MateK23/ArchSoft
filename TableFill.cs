using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchSoft
{
    class TableFill
    {
        DataTable table = new DataTable();
        private double factor = 0.0;
        private int result = 0;

        public TableFill()
        {
            table.Columns.Add("დაკავებულობა", typeof(string));
            table.Columns.Add("აღწერილობა", typeof(string));
            table.Columns.Add("ფართი", typeof(double));
            table.Columns.Add("დაკავებულობის დატვირთვის ფაქტორი", typeof(double));
            table.Columns.Add("დ.დ.", typeof(int));
        }

        public void GetValues(string type1, string type2, double scale)
        {
            table.Rows.Add(type1, type2, scale, factor, result);
        }

        public DataTable TableRetrun()
        {
            return table;
        }
    }
}
