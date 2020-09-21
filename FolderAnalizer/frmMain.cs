using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace FolderAnalizer
{
    public partial class frmMain : Form
    {
        private DataTable dir_table = new DataTable();

        public frmMain()
        {
            InitializeComponent();
            Init();
        }

        private void Init()
        {
            dir_table.Columns.Add("Row");
            dir_table.Columns.Add("Directory");
            dir_table.Columns.Add("FileName");
            dir_table.Columns.Add("Size");
            dir_table.Columns.Add("LastAccessed");
            dir_table.Columns.Add("LastModified");
            dir_table.Columns.Add("Attrib");

        }

        private void btnGatheringInfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Gathering information takes time continue?", "Information Gathering", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            if (MessageBox.Show("Delete Previouse Data? ", "Delete Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                txtMessages.AppendText("Start deleting old data in database...\n");
                DAL.FileTable.DeleteAll();
                txtMessages.AppendText("Data is removed from database...\n");
            }

            txtMessages.AppendText("Starting PreAnalysis ...\n");
            PreAnalysis();
            txtMessages.AppendText("PreAnalysis Done!\n");
            MessageBox.Show("Gathering information is now complete.");
        }

        private bool PreAnalysis()
        {
            if (!Directory.Exists(txtTargetDir.Text))
            {
                MessageBox.Show("Invalid Directory");
                return false;
            }
            
            DirQueue.Clear();
            string tmp_dir = txtTargetDir.Text;
            string[] children_dirs = null;
            string[] including_files = null;
            FileInfo tmp_file_info = null;



            DirQueue.Enqueue(tmp_dir);

            int row_counter = 1;
            while (DirQueue.Count != 0)
            {

                tmp_dir = DirQueue.Dequeue();
                if (!Directory.Exists(tmp_dir)) continue;

                try
                {
                    including_files = Directory.GetFiles(tmp_dir);
                }
                catch (Exception ex)
                {
                    txtMessages.AppendText(string.Format("Directory: {0}, Message: {1}\n", tmp_dir, ex.Message));
                }
                for (int i = 0; i < including_files.Length; i++)
                {
                    tmp_file_info = new FileInfo(including_files[i]);
                    //dgvOutput.Rows.Add(row_counter, tmp_dir, tmp_file_info.Name, tmp_file_info.Length, File.GetAttributes(including_files[i]));
                    dir_table.Rows.Add(row_counter, tmp_dir, tmp_file_info.Name, tmp_file_info.Length, tmp_file_info.LastAccessTime, tmp_file_info.LastWriteTime, File.GetAttributes(including_files[i]));
                    DAL.FileTable.Insert(tmp_dir, tmp_file_info.Name, tmp_file_info.Length, tmp_file_info.LastAccessTime, tmp_file_info.LastWriteTime, File.GetAttributes(including_files[i]).ToString());
                    
                    row_counter++;
                    if ((row_counter % 100) == 0)
                    {
                        ShowInfo(tmp_dir, tmp_file_info.Name, row_counter);
                    }
                }

                try
                {
                    children_dirs = Directory.GetDirectories(tmp_dir);
                }
                catch (Exception ex)
                {
                    txtMessages.AppendText(string.Format("Directory: {0}, Message: {1}\n", tmp_dir, ex.Message));
                }

                for (int i = 0; i < children_dirs.Length; i++)
                {
                    DirQueue.Enqueue(children_dirs[i]);
                }
            }
            ShowInfo(tmp_dir, tmp_file_info.Name, row_counter);
            return true;
        }

        private void ShowInfo(string CurrentDir, string CurrentFileName, int CurrentRow)
        {
            lblVisitedVal.Text = CurrentRow.ToString();
            lblCurrentDirVal.Text = CurrentDir;
            lblCurrentFileVal.Text = CurrentFileName;
            Application.DoEvents();
        }

        Queue<string> DirQueue = new Queue<string>();

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            fldrBrwsTargetDir.ShowDialog();
            if (!Directory.Exists(fldrBrwsTargetDir.SelectedPath))
            {
                txtTargetDir.Text = "<Select A Directoy First...>";
                return;
            }
            txtTargetDir.Text = fldrBrwsTargetDir.SelectedPath;
        }

        private void btnClearDatabase_Click(object sender, EventArgs e)
        {
            DAL.FileTable.DeleteAll();
            MessageBox.Show("Delete data complete");
        }



        DataTable FileTable = new DataTable();
        DataTable DirectoryTable = new DataTable();

        private void btnExtractHotFiles_Click(object sender, EventArgs e)
        {
            
            
            if (FileTable.Columns.IndexOf("Row") == -1) FileTable.Columns.Add("Row");
            if (FileTable.Columns.IndexOf("Directory") == -1) FileTable.Columns.Add("Directory");
            if (FileTable.Columns.IndexOf("FileName") == -1) FileTable.Columns.Add("FileName");
            if (FileTable.Columns.IndexOf("FileSize") == -1) FileTable.Columns.Add("FileSize");
            if (FileTable.Columns.IndexOf("LastAccessed") == -1) FileTable.Columns.Add("LastAccessed");
            if (FileTable.Columns.IndexOf("LastModified") == -1) FileTable.Columns.Add("LastModified");
            if (FileTable.Columns.IndexOf("Attrib") == -1) FileTable.Columns.Add("Attrib");

            FileTable.Rows.Clear();

            string sql = string.Format(" SELECT Top {0} * FROM FileTable ", nupdMaxRecords.Value);
            bool order_by = chbxLargest.Checked | chbxUnusedRecently.Checked | chbxOldest.Checked;
            if (order_by) sql += " ORDER BY ";

            List<string> Orders = new List<string>();

            if (chbxLargest.Checked) Orders.Add("FileSize DESC");
            if (chbxUnusedRecently.Checked) Orders.Add("LastAccessed ASC");
            if (chbxOldest.Checked) Orders.Add("LastModified ASC");

            
            for (int i = 0; i < Orders.Count; i++)
            {
                if (i != Orders.Count - 1)
                {
                    sql += Orders[i] + ", ";
                }
                else
                {
                    sql += Orders[i];
                }
            }

            List<FileTableRow> result = DAL.FileTable.Select(sql);
            for (int i = 0; i < result.Count; i++)
            {
                FileTable.Rows.Add(
                    i+1, 
                    result[i].Directory, 
                    result[i].FileName, 
                    result[i].FileSize, 
                    result[i].LastAccessed,
                    result[i].LastModified,
                    result[i].Attrib
                    );
            }
            dgvFileTable.DataSource = FileTable;
            SetColumnsForFileTableSize();

        }

        private void SetColumnsForFileTableSize()
        {
            dgvFileTable.Columns["Row"].Width = 45;
            dgvFileTable.Columns["Directory"].Width = 250;
            dgvFileTable.Columns["FileName"].Width = 200;
            dgvFileTable.Columns["FileSize"].Width = 100;
            dgvFileTable.Columns["LastAccessed"].Width = 100;
            dgvFileTable.Columns["LastModified"].Width = 100;
            dgvFileTable.Columns["Attrib"].Width = 100;
        }

        private void btnClearHotFiles_Click(object sender, EventArgs e)
        {
            FileTable.Rows.Clear();
        }

        private void btnExtractSimularFiles_Click(object sender, EventArgs e)
        {
            if (FileTable.Columns.IndexOf("Row") == -1) FileTable.Columns.Add("Row");
            if (FileTable.Columns.IndexOf("Directory") == -1) FileTable.Columns.Add("Directory");
            if (FileTable.Columns.IndexOf("FileName") == -1) FileTable.Columns.Add("FileName");
            if (FileTable.Columns.IndexOf("FileSize") == -1) FileTable.Columns.Add("FileSize");
            if (FileTable.Columns.IndexOf("LastAccessed") == -1) FileTable.Columns.Add("LastAccessed");
            if (FileTable.Columns.IndexOf("LastModified") == -1) FileTable.Columns.Add("LastModified");
            if (FileTable.Columns.IndexOf("Attrib") == -1) FileTable.Columns.Add("Attrib");

            FileTable.Rows.Clear();

            string sql = "";
            if (radHavingSimularNames.Checked)
            {
                sql = string.Format("Select Top {0} ID, Directory, FileName, FileSize, LastAccessed, LastModified, Attrib " +
                     "From SimularFileNameCountFull Order By FileName, FileSize, LastAccessed", nupdMaxRecords.Value);
            }
            else if (radHavingSimularSizes.Checked)
            {
                sql = string.Format("Select Top {0} ID, Directory, FileName, FileSize, LastAccessed, LastModified, Attrib " +
                     "From SimularFileSizeCountFull Order By FileSize DESC, FileName, LastAccessed", nupdMaxRecords.Value);
            }

            List<FileTableRow> result = DAL.FileTable.Select(sql);
            for (int i = 0; i < result.Count; i++)
            {
                FileTable.Rows.Add(
                    i + 1,
                    result[i].Directory,
                    result[i].FileName,
                    result[i].FileSize,
                    result[i].LastAccessed,
                    result[i].LastModified,
                    result[i].Attrib
                    );
            }
            dgvFileTable.DataSource = FileTable;
            SetColumnsForFileTableSize();

        }

        private void OpenContainingFoldermnuFileTable_Click(object sender, EventArgs e)
        {
            if (dgvFileTable.SelectedRows.Count == 0) return;
            string tmp_dir = "";
            for (int i = 0; i < dgvFileTable.SelectedRows.Count; i++)
            {
                 tmp_dir = dgvFileTable.SelectedRows[i].Cells["Directory"].Value.ToString();
                 if (!System.IO.Directory.Exists(tmp_dir))
                 {
                     txtMessages.AppendText(string.Format("Attempting to open directory failed. Missing Directory: \"{0}\"\n", tmp_dir));
                     continue;
                 }
                 Process.Start("Explorer.exe", tmp_dir);
            }
        }

        private void RemoveDirectoryTable_Click(object sender, EventArgs e)
        {
            if (dgvFileTable.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Please Make sure you do not need the folder any more.\n " +
                "All files in the selected folder will be removed permanently. \n" +
                "Continue any way?\n" +
                "Yes = Delete\n" + "No = Cancel", "Delete Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            else
            {
                string tmp_dir = "";
                for (int i = 0; i < dgvFileTable.SelectedRows.Count; i++)
                {
                    tmp_dir = dgvFileTable.SelectedRows[i].Cells["Directory"].Value.ToString();
                    if (!System.IO.Directory.Exists(tmp_dir))
                    {
                        txtMessages.AppendText(string.Format("Attempting to delete failed. Missing Directory: \"{0}\"\n", tmp_dir));
                        continue;
                    }
                    try
                    {
                        System.IO.Directory.Delete(tmp_dir, true);
                    }
                    catch (Exception Ex)
                    {
                        txtMessages.AppendText(string.Format("Attempting to delete \"{0}\" failed. Message: \"{1}\"\n", tmp_dir, Ex.Message));
                        continue;
                    }
                }
            }

            if (
            MessageBox.Show("Database may not be synchronous with your directory structue\n" +
                "It's recommanded that you scan the folder again.\n" +
                "Do you want to scan the folder now? ", "Warning, database is out of date", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ScanFolder();
            }
        }

        private void ScanFolder()
        {
            txtMessages.AppendText("Start deleting old data in database...\n");
            DAL.FileTable.DeleteAll();
            txtMessages.AppendText("Data is removed from database...\n");

            txtMessages.AppendText("Starting PreAnalysis ...\n");
            if (PreAnalysis())
            {
                txtMessages.AppendText("PreAnalysis Done!\n");
                MessageBox.Show("Gathering information is now complete.");
            }
            else
            {
                txtMessages.AppendText("PreAnalysis Failed!\n");
                MessageBox.Show("Gathering information Failed.");
            }
        }

        private void RemoveFileTable_Click(object sender, EventArgs e)
        {
            if (dgvFileTable.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Please Make sure you do not need the files any more.\n " +
                "All selected files will be removed permanently. \n" +
                "Continue any way?\n" +
                "Yes = Delete\n" + "No = Cancel", "Delete Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            else
            {
                string tmp_dir = "";
                string tmp_file_name = "";
                string full_file_name = "";
                for (int i = 0; i < dgvFileTable.SelectedRows.Count; i++)
                {
                    tmp_dir = dgvFileTable.SelectedRows[i].Cells["Directory"].Value.ToString();
                    tmp_file_name = dgvFileTable.SelectedRows[i].Cells["FileName"].Value.ToString();
                    full_file_name = tmp_dir + "\\" + tmp_file_name;

                    if (!System.IO.File.Exists(full_file_name))
                    {
                        txtMessages.AppendText(string.Format("Attempting to delete failed. Missing file or directory: \"{0}\"\n", full_file_name));
                        continue;
                    }
                    try
                    {
                        System.IO.File.Delete(full_file_name);
                    }
                    catch (Exception Ex)
                    {
                        txtMessages.AppendText(string.Format("Attempting to delete \"{0}\" failed. Message: \"{1}\"\n", full_file_name, Ex.Message));
                        continue;
                    }
                }
            }

            if (
            MessageBox.Show("Database may not be synchronous with your directory structue\n" +
                "It's recommanded that you scan the folder again.\n" +
                "Do you want to scan the folder now? ", "Warning, database is out of date", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ScanFolder();
            }
        }

        private void HotFolders_Click(object sender, EventArgs e)
        {
            if (radFoldersContiningLotsOfFiles.Checked)
            {
                FoldersContainingLotsOfFiles();
            }
            else if (radFoldersContiningLargestFiles.Checked)
            {
                FoldersContainingLaggestFiles();
            }
            else if (radFoldersContainingMaxTotalFileSize.Checked)
            {
                FoldersContainingMaxTotalFileSize();
            }
        }

        private void FoldersContainingMaxTotalFileSize()
        {
            DirectoryTable.Rows.Clear();
            DirectoryTable.Columns.Clear();
            DirectoryTable.Columns.Add("Row");
            DirectoryTable.Columns.Add("Directory");
            DirectoryTable.Columns.Add("TotalSize");


            string sql = string.Format("Select Top {0} * from FoldersContainingMaxTotalFileSize", nupdMaxRecords.Value);

            List<DirectoryTableRow> result = DAL.DirectoryTable.Select(sql);
            for (int i = 0; i < result.Count; i++)
            {
                DirectoryTable.Rows.Add(
                    i + 1,
                    result[i].Diretory,
                    result[i].NumericData
                    );
            }

            dgvFileTable.DataSource = DirectoryTable;
            dgvFileTable.Columns["Row"].Width = 45;
            dgvFileTable.Columns["TotalSize"].Width = 100;
            dgvFileTable.Columns["Directory"].Width = dgvFileTable.Width - 20 - 145;
        }

        private void FoldersContainingLotsOfFiles()
        {
            DirectoryTable.Rows.Clear();
            DirectoryTable.Columns.Clear();
            DirectoryTable.Columns.Add("Row");
            DirectoryTable.Columns.Add("Directory");
            DirectoryTable.Columns.Add("FileCount");

            
            string sql = string.Format("Select Top {0} * from FoldersContainingLotsOfFiles", nupdMaxRecords.Value);

            List<DirectoryTableRow> result = DAL.DirectoryTable.Select(sql);
            for (int i = 0; i < result.Count; i++)
            {
                DirectoryTable.Rows.Add(
                    i + 1,
                    result[i].Diretory,
                    result[i].NumericData
                    );
            }

            dgvFileTable.DataSource = DirectoryTable;
            dgvFileTable.Columns["Row"].Width = 45;
            dgvFileTable.Columns["FileCount"].Width = 100;
            dgvFileTable.Columns["Directory"].Width = dgvFileTable.Width - 20 - 145;
        }

        private void FoldersContainingLaggestFiles()
        {
            DirectoryTable.Rows.Clear();
            DirectoryTable.Columns.Clear();
            DirectoryTable.Columns.Add("Row");
            DirectoryTable.Columns.Add("Directory");
            DirectoryTable.Columns.Add("MaxFileSize");
            
            string sql = string.Format("Select Top {0} * from FoldersContainingLaggestFiles", nupdMaxRecords.Value);

            List<DirectoryTableRow> result = DAL.DirectoryTable.Select(sql);
            for (int i = 0; i < result.Count; i++)
            {
                DirectoryTable.Rows.Add(
                    i + 1,
                    result[i].Diretory,
                    result[i].NumericData
                    );
            }

            dgvFileTable.DataSource = DirectoryTable;
            dgvFileTable.Columns["Row"].Width = 45;
            dgvFileTable.Columns["MaxFileSize"].Width = 100;
            dgvFileTable.Columns["Directory"].Width = dgvFileTable.Width - 20 - 145;
        }
    }
}
