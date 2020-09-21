using System.Data.OleDb;

namespace FolderAnalizer
{
    public enum FileTableFields : int { ID, Directory, FileName, FileSize, LastAccessed, LastModified, Attrib };
    public enum DirectoryTableFields : int { NumericData, Directory};
    class DAL
    {
        static string ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Data.mdb;Persist Security Info=False";
        private static OleDbConnection Connection = new OleDbConnection(ConnectionString);

        public static FileTable FileTable = new FileTable(Connection);
        public static DirectoryTable DirectoryTable = new DirectoryTable(Connection);

    }
}
