// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransformWord.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Demo.Operations
{
    using Rhino.Etl.Core;
    using Rhino.Etl.Core.Operations;

    public class TransformWord : AbstractOperation
    {
        public override IEnumerable<Row> Execute(IEnumerable<Row> rows)
        {
            foreach (var row in rows)
            {
                var revWord = (string) row["AWord"];
                row["AWord"] = new string(revWord.ToCharArray().ToArray());
                yield return row;
            }
        }
    }
}