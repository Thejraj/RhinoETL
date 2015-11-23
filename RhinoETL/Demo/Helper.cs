// -----------------------------------------------------------------------
// <copyright file="Helper.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;
using System.Linq;

namespace Demo
{
    /// <summary>
    ///     TODO: Update summary.
    /// </summary>
    public class Helper
    {
        public static bool IsAnyAvailable(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }
    }
}