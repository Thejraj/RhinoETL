// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataRecord.cs" company="">
//   TODO: Update copyright text.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Demo.Operations
{
    using FileHelpers;

    [DelimitedRecord(",")]
    public class DataRecord
    {
        public int Id;
        public string AWord;
    }
}