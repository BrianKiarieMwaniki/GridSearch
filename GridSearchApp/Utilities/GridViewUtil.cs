using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridSearchApp.Utilities
{
    public static class GridViewUtil
    {
        public static void HideGridColumns(DataGridView gridView, params string[] columns)
        {
            if (columns is null) return;

            foreach(var column in columns)
            {
                var hasColumn = gridView.Columns.Contains(column);
                if (!hasColumn) return;

                gridView.Columns[column].Visible = false;
            }
        }
        
    }
}
