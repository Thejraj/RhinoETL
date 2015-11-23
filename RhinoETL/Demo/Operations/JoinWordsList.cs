// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JoinWordsList.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------


namespace Demo.Operations
{
    using Rhino.Etl.Core;
    using Rhino.Etl.Core.Operations;

    public class JoinWordLists : JoinOperation
    {
        protected override void SetupJoinConditions()
        {
            FullOuterJoin
                .Left("Id")
                .Right("Id");
        }

        protected override Row MergeRows(Row leftRow, Row rightRow)
        {
            var row = leftRow.Clone();
            row["AWord"] = leftRow["Id"] + "," + leftRow["AWord"] + "," +
                           rightRow["AWord"];
            return row;
        }
    }
}