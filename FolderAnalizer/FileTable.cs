using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System;
namespace FolderAnalizer
{
    
    
    public class FileTable
    {

        public OleDbCommand Command = new OleDbCommand();

        public FileTable(OleDbConnection AConnection)
        {
            Command.Connection = AConnection;
        }

        public string TableName = "FileTable";

        public List<FileTableRow> Select(string SQLCommand)
        {
            Command.CommandText = SQLCommand;

            if (Command.Connection.State == ConnectionState.Closed)
            {
                Command.Connection.Open();
            }
            OleDbDataReader dr = Command.ExecuteReader();
            List<FileTableRow> res = new List<FileTableRow>();
            while (dr.Read())
            {
                res.Add(new FileTableRow(dr, false));
            }
            dr.Close();
            return res;
        }

        public void Insert(
            string Directory,
            string FileName,
            long FileSize,
            DateTime LastAccessed,
            DateTime LastModified,
            string Attrib)

        {
            string sql = string.Format(
                "Insert Into {0} ({1}, {2}, {3}, {4}, {5}, {6} ) values (\"{7}\", \"{8}\", {9}, '{10}', '{11}', '{12}')",
                this.TableName,

                FileTableFields.Directory.ToString(),
                FileTableFields.FileName.ToString(),
                FileTableFields.FileSize.ToString(),
                FileTableFields.LastAccessed.ToString(),
                FileTableFields.LastModified.ToString(),
                FileTableFields.Attrib.ToString(),

                Directory,
                FileName,
                FileSize,
                LastAccessed,
                LastModified,
                Attrib
                );

            Command.CommandText = sql;
            if (Command.Connection.State == ConnectionState.Closed)
            {
                Command.Connection.Open();
            }

            Command.ExecuteNonQuery();
        }


        public int Update(string UpdateCommand)
        {

            Command.CommandText = UpdateCommand;
            if (Command.Connection.State == ConnectionState.Closed)
            {
                Command.Connection.Open();
            }
            return Command.ExecuteNonQuery();
        }


        public int Delete(long DirID)
        {
            string sql = string.Format(
                "Delete from {0}  where {1} = {2}",

                this.TableName,

                FileTableFields.Directory.ToString(),
                DirID
                );

            Command.CommandText = sql;
            if (Command.Connection.State == ConnectionState.Closed)
            {
                Command.Connection.Open();
            }
            return Command.ExecuteNonQuery();
        }

        public FileTableRow this[long DirID]
        {
            get
            {

                Command.CommandText = string.Format("Select * from {0} where {1} = {2}",
                    this.TableName, FileTableFields.Directory.ToString(), DirID);



                if (Command.Connection.State == ConnectionState.Closed)
                {
                    Command.Connection.Open();
                }


                OleDbDataReader dr = Command.ExecuteReader();
                if (dr == null)
                {
                    // an empty FileTablerow:
                    return new FileTableRow();
                }


                if (dr.Read())
                {
                    FileTableRow res = new FileTableRow(dr, true);
                    dr.Close();
                    return res;
                }
                dr.Close();
                return new FileTableRow();
            }
        }
        
        


        internal int DeleteAll()
        {
            string sql = string.Format(
                "Delete from {0}",
                this.TableName
                );

            Command.CommandText = sql;
            if (Command.Connection.State == ConnectionState.Closed)
            {
                Command.Connection.Open();
            }
            return Command.ExecuteNonQuery();
        }
    }

    public class FileTableRow
    {
        public FileTableRow()
        {
            id = -1;
            directory = "";
            file_name = "";
            file_size = 0;
            last_accessed = DateTime.MinValue;
            last_modified = DateTime.MinValue;
            attrib = "";
        }

        public FileTableRow(OleDbDataReader ADataReader, bool CloseReader)
        {
            id = Globals.ObjectToInt64(ADataReader[FileTableFields.ID.ToString()]);
            directory = Globals.ObjectToString(ADataReader[FileTableFields.Directory.ToString()]);
            file_name = Globals.ObjectToString(ADataReader[FileTableFields.FileName.ToString()]);
            file_size = Globals.ObjectToInt32(ADataReader[FileTableFields.FileSize.ToString()]);
            last_accessed = Globals.ObjectToDateTime(ADataReader[FileTableFields.LastAccessed.ToString()]);
            last_modified = Globals.ObjectToDateTime(ADataReader[FileTableFields.LastModified.ToString()]);
            attrib = Globals.ObjectToString(ADataReader[FileTableFields.Attrib.ToString()]);

            if (CloseReader)
            {
                ADataReader.Close();
            }
        }

        private long id = 0;
        public long ID
        {
            get
            {
                return id;
            }
        }



        private string directory = "";
        public string Directory
        {
            get
            {
                return directory;
            }
            set
            {
                DAL.FileTable.Update(string.Format("Update FileTable Set {0} = {1} where {2} = {3}",
                    FileTableFields.Directory.ToString(),
                    value,
                    FileTableFields.ID.ToString(),
                    this.ID));
            }
        }


        private string file_name = "";
        public string FileName
        {
            get
            {
                return file_name;
            }
            set
            {
                DAL.FileTable.Update(string.Format("Update FileTable Set {0} = '{1}' where {2} = {3}",
                    FileTableFields.FileName.ToString(),
                    value,
                    FileTableFields.ID.ToString(),
                    this.ID));
            }
        }



        private long file_size = 0;
        public long FileSize
        {
            get
            {
                return file_size;
            }
            set
            {
                DAL.FileTable.Update(string.Format("Update FileTable Set {0} = {1} where {2} = {3}",
                    FileTableFields.FileSize.ToString(),
                    value,
                    FileTableFields.ID.ToString(),
                    this.ID));
            }
        }


        private DateTime last_accessed = DateTime.MinValue;
        public DateTime LastAccessed
        {
            get
            {
                return last_accessed;
            }
            set
            {
                DAL.FileTable.Update(string.Format("Update FileTable Set {0} = {1} where {2} = {3}",
                FileTableFields.LastAccessed.ToString(),
                value,
                FileTableFields.ID.ToString(),
                this.ID));
            }
        }


        private DateTime last_modified = DateTime.MinValue;
        public DateTime LastModified
        {
            get
            {
                return last_modified;
            }
            set
            {
                DAL.FileTable.Update(string.Format("Update FileTable Set {0} = '{1}' where {2} = {3}",
                FileTableFields.LastModified.ToString(),
                value,
                FileTableFields.ID.ToString(),
                this.ID));
            }
        }



        private string attrib = "";
        public string Attrib
        {
            get
            {
                return attrib;
            }
            set
            {
                DAL.FileTable.Update(string.Format("Update FileTable Set {0} = '{1}' where {2} = {3}",
                FileTableFields.Attrib.ToString(),
                value,
                FileTableFields.ID.ToString(),
                this.ID));
            }
        }

    }

}
