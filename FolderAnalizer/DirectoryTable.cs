using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System;
namespace FolderAnalizer
{


    public class DirectoryTable
    {

        public OleDbCommand Command = new OleDbCommand();

        public DirectoryTable(OleDbConnection AConnection)
        {
            Command.Connection = AConnection;
        }

        public string TableName = "DirectoryTable";

        public List<DirectoryTableRow> Select(string SQLCommand)
        {
            Command.CommandText = SQLCommand;

            if (Command.Connection.State == ConnectionState.Closed)
            {
                Command.Connection.Open();
            }
            OleDbDataReader dr = Command.ExecuteReader();
            List<DirectoryTableRow> res = new List<DirectoryTableRow>();
            while (dr.Read())
            {
                res.Add(new DirectoryTableRow(dr, false));
            }
            dr.Close();
            return res;
        }
    }

    public class DirectoryTableRow
    {
        private string directory = "";
        public string Diretory
        {
            get
            {
                return directory;
            }
        }
        
        private Int64 numeric_data = 0;
        public Int64 NumericData
        {
            get
            {
                return numeric_data;
            }
        }
        
        public DirectoryTableRow()
        {
            directory = "";
            numeric_data = 0;
        }

        public DirectoryTableRow(OleDbDataReader ADataReader, bool CloseReader)
        {
            directory = Globals.ObjectToString(ADataReader[DirectoryTableFields.Directory.ToString()]);
            numeric_data = Globals.ObjectToInt64(ADataReader[DirectoryTableFields.NumericData.ToString()]);
            if (CloseReader)
            {
                ADataReader.Close();
            }
        }
    }

}
