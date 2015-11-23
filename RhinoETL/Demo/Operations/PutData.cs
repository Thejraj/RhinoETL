// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PutData.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Demo.Operations
{

    using Rhino.Etl.Core;
    using Rhino.Etl.Core.Operations;
    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class PutData : AbstractOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach (var row in rows)
            {
                var record = new DataRecord
                {
                    Id = (int) row["Id"],
                    AWord = (string) row["AWord"]
                };
                Console.WriteLine(record.AWord);
            }
            yield break;
        }
    }
}