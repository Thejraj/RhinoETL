using Demo.Operations;
using Rhino.Etl.Core;
using Rhino.Etl.Core.Operations;

namespace Demo
{
    public class ImportFiles : EtlProcess
    {
        private readonly string _database;
        private readonly string _directory;
        private readonly string _table;

        public ImportFiles(string path, string databaseName, string table)
        {
            _directory = path;
            _database = databaseName;
            _table = table;
        }

        protected override void Initialize()
        {
            //Extraction process
            Register(new JoinWordLists()
                .Left(new SimpleFileDataGet(_directory + @"Product.txt"))
                .Right(new SimpleFileDataGet(_directory + @"Specifications.txt")));

            //Transofrmation process
            Register(new TransformWord());

            //Load process
            Register(new BranchingOperation()
                .Add(new BaseBulkInsertData(_database, _table, 30))
                .Add(new PutData()));
        }
    }
}