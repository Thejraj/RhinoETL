using System;

namespace Demo
{
    internal class Program
    {
        private const string DatabaseName = "DellIntegration";
        private const string TableName = "dbo.Product";

        private static void Main(string[] args)
        {
            //Set source data path
            var filePath = AppDomain.CurrentDomain.BaseDirectory + @"SourceFiles\";
            //ConfigurationManager.AppSettings["FilesPath"];

            //Validate does source path contain any files
            if (Helper.IsAnyAvailable(filePath))
            {
                Console.WriteLine("No files available. Existing!!!");
                return;
            }

            Console.WriteLine("Product enrichment started...");
            //Initialize info to ETL
            var operation = new ImportFiles(filePath, DatabaseName, TableName);
            //Starting process
            operation.Execute();
            //Confirms operation completed

            Console.WriteLine("Product enrichment completed...");

            Console.ReadKey();
        }
    }
}