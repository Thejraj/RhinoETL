// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseBulkInsertData.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace Demo.Operations
{
    public class BaseBulkInsertData : SqlBulkInsertOperation
    {
        public BaseBulkInsertData(string databaseName, string targetTable, int timeout)
            : base(databaseName, targetTable, timeout)
        {
        }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            //Console.WriteLine("Truncating Table");
            //TruncateTable(this.TargetTable, this.ConnectionStringSettings.ConnectionString);
            Console.WriteLine("Current feed data processing started");
            var rowsToBeInserted = new List<Row>();
            foreach (var row in rows)
            {
                var array = row["AWord"].ToString().Split(',');
                var i = 1;
                row["Name"] = array[i++];
                row["Description"] = array[i++];
                row["ImagePath"] = array[i++];
                row["PromotionId"] = array[i++];
                row["RAM"] = array[i++];
                row["Harddisk"] = array[i++];
                row["Processor"] = array[i++];
                row["Display"] = array[i++];
                rowsToBeInserted.Add(row);
            }
            //Bulk insert data
            var results = base.Execute(rowsToBeInserted.AsEnumerable());

            //Display all the rows to be inserted
            DisplayRows(rowsToBeInserted);

            Console.WriteLine("Feeds are processed");
            return results;
        }

        private static void DisplayRows(IEnumerable<Row> rowsToBeInserted)
        {
            foreach (var row in rowsToBeInserted)
            {
                Console.WriteLine(
                    "Name\t\t: {0}\nDescription\t: {1}\nImagePath\t: {2}\nPromotionId\t: {3}\nRAM\t\t: {4}\nHarddisk\t: {5}\nProcessor\t: {6}\nDisplay\t\t: {7}\n",
                    row["Name"],
                    row["Description"],
                    row["ImagePath"],
                    row["PromotionId"],
                    row["RAM"],
                    row["Harddisk"],
                    row["Processor"],
                    row["Display"]);
            }
        }

        public static void TruncateTable(string tableName, string connectionString)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var query = "TRUNCATE TABLE " + tableName;
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }

        protected override void PrepareSchema()
        {
            Schema["Id"] = typeof (int);
            Schema["Name"] = typeof (string);
            Schema["Description"] = typeof (string);
            Schema["ImagePath"] = typeof (string);
            Schema["PromotionId"] = typeof (int);
            Schema["RAM"] = typeof (string);
            Schema["Harddisk"] = typeof (string);
            Schema["Processor"] = typeof (string);
            Schema["Display"] = typeof (int);
        }
    }
}