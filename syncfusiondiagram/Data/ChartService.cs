using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace syncfusiondiagram.Data
{
    public class ChartService
    {
        public async Task<DataTable> GetDashboardAsync()
        {
            DataTable table = new DataTable();
            table.Columns.Add(new DataColumn("Id", typeof(int)));
            table.Columns.Add(new DataColumn("ParentId", typeof(int)));
            table.Columns.Add(new DataColumn("DataCount", typeof(int)));
            table.Columns.Add(new DataColumn("Titel", typeof(string)));

            int maxNodes = 5;
            var row = table.NewRow();
            
            row["Id"] = 0;
            row["ParentId"] = 0;
            row["Titel"] = "Root";
            row["DataCount"] = new Random().Next(1, 300);
            table.Rows.Add(row);
            for (int i = 1; i < maxNodes; i++)
            {
                row = table.NewRow();
                row["Id"] = i;
                row["ParentId"] = i-1;
                row["Titel"] = $"node{i}";
                row["DataCount"] = new Random().Next(1,300);
                table.Rows.Add(row);
            }
            row = table.NewRow();
            row["Id"] = maxNodes;
            row["ParentId"] = 0;
            row["Titel"] = "sideNode";
            row["DataCount"] = new Random().Next(1, 300);
            table.Rows.Add(row);

            return table;
        }

    }
}
