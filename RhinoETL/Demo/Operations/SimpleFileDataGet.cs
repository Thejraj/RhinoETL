// -----------------------------------------------------------------------
// <copyright file="SimpleFileDataGet.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace Demo.Operations
{
    using Rhino.Etl.Core;
    using Rhino.Etl.Core.Files;
    using Rhino.Etl.Core.Operations;

    public class SimpleFileDataGet : AbstractOperation
    {
        public SimpleFileDataGet(string inPutFilepath)
        {
            FilePath = inPutFilepath;
        }

        public string FilePath { get; set; }

        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            using (var file = FluentFile.For<DataRecord>().From(FilePath))
            {
                foreach (var obj in file)
                {
                    yield return Row.FromObject(obj);
                }
            }
        }
    }
}