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
        private int result;

        public TableFill()
        {
            table.Columns.Add("დაკავებულობა", typeof(string));
            table.Columns.Add("აღწერილობა", typeof(string));
            table.Columns.Add("ფართი", typeof(double));
            table.Columns.Add("დაკავებულობის დატვირთვის ფაქტორი", typeof(double));
            table.Columns.Add("დ.დ.", typeof(int));
        }

        private static decimal CustomRound(decimal x)
        {
            return decimal.Round(x - 0.001m, 2, MidpointRounding.AwayFromZero);
        }

        public void GetValues(string type1, string type2, double scale, double factor)
        {
            result = (int)Math.Round(scale / factor);
            table.Rows.Add(type1, type2, scale, factor, result);
        }

        public DataTable TableRetrun()
        {
            return table;
        }
    }
}
