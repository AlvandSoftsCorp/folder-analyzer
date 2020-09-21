namespace FolderAnalizer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGatherInfo = new System.Windows.Forms.Button();
            this.fldrBrwsTargetDir = new System.Windows.Forms.FolderBrowserDialog();
            this.txtTargetDir = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.grpbxSelectTargetDir = new System.Windows.Forms.GroupBox();
            this.dgvFileTable = new System.Windows.Forms.DataGridView();
            this.mnuFileTable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openContainingFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRemoveFile = new System.Windows.Forms.ToolStripMenuItem();
            this.txtMessages = new System.Windows.Forms.TextBox();
            this.btnClearDatabase = new System.Windows.Forms.Button();
            this.lblVisited = new System.Windows.Forms.Label();
            this.lblVisitedVal = new System.Windows.Forms.Label();
            this.gbxInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentDir = new System.Windows.Forms.Label();
            this.lblCurrentDirVal = new System.Windows.Forms.Label();
            this.lblCurrentFile = new System.Windows.Forms.Label();
            this.lblCurrentFileVal = new System.Windows.Forms.Label();
            this.gbxHotFiles = new System.Windows.Forms.GroupBox();
            this.btnExtractHotFiles = new System.Windows.Forms.Button();
            this.chbxUnusedRecently = new System.Windows.Forms.CheckBox();
            this.chbxOldest = new System.Windows.Forms.CheckBox();
            this.chbxLargest = new System.Windows.Forms.CheckBox();
            this.gbxSimularFiles = new System.Windows.Forms.GroupBox();
            this.btnExtractSimularFiles = new System.Windows.Forms.Button();
            this.radHavingSimularSizes = new System.Windows.Forms.RadioButton();
            this.radHavingSimularNames = new System.Windows.Forms.RadioButton();
            this.lblTop = new System.Windows.Forms.Label();
            this.nupdMaxRecords = new System.Windows.Forms.NumericUpDown();
            this.btnClearHotFiles = new System.Windows.Forms.Button();
            this.grbxHotFolders = new System.Windows.Forms.GroupBox();
            this.btnHotFolders = new System.Windows.Forms.Button();
            this.radFoldersContiningLargestFiles = new System.Windows.Forms.RadioButton();
            this.radFoldersContiningLotsOfFiles = new System.Windows.Forms.RadioButton();
            this.radFoldersContainingMaxTotalFileSize = new System.Windows.Forms.RadioButton();
            this.grpbxSelectTargetDir.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTable)).BeginInit();
            this.mnuFileTable.SuspendLayout();
            this.gbxInfo.SuspendLayout();
            this.gbxHotFiles.SuspendLayout();
            this.gbxSimularFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdMaxRecords)).BeginInit();
            this.grbxHotFolders.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGatherInfo
            // 
            this.btnGatherInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGatherInfo.Location = new System.Drawing.Point(252, 16);
            this.btnGatherInfo.Name = "btnGatherInfo";
            this.btnGatherInfo.Size = new System.Drawing.Size(111, 23);
            this.btnGatherInfo.TabIndex = 0;
            this.btnGatherInfo.Text = "Gather Information";
            this.btnGatherInfo.UseVisualStyleBackColor = true;
            this.btnGatherInfo.Click += new System.EventHandler(this.btnGatheringInfo_Click);
            // 
            // txtTargetDir
            // 
            this.txtTargetDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetDir.Location = new System.Drawing.Point(6, 19);
            this.txtTargetDir.Name = "txtTargetDir";
            this.txtTargetDir.Size = new System.Drawing.Size(206, 20);
            this.txtTargetDir.TabIndex = 1;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFolder.Location = new System.Drawing.Point(218, 16);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(28, 23);
            this.btnSelectFolder.TabIndex = 2;
            this.btnSelectFolder.Text = "...";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // grpbxSelectTargetDir
            // 
            this.grpbxSelectTargetDir.Controls.Add(this.txtTargetDir);
            this.grpbxSelectTargetDir.Controls.Add(this.btnSelectFolder);
            this.grpbxSelectTargetDir.Controls.Add(this.btnGatherInfo);
            this.grpbxSelectTargetDir.Location = new System.Drawing.Point(12, 12);
            this.grpbxSelectTargetDir.Name = "grpbxSelectTargetDir";
            this.grpbxSelectTargetDir.Size = new System.Drawing.Size(369, 51);
            this.grpbxSelectTargetDir.TabIndex = 3;
            this.grpbxSelectTargetDir.TabStop = false;
            this.grpbxSelectTargetDir.Text = "Select a Directory";
            // 
            // dgvFileTable
            // 
            this.dgvFileTable.AllowUserToAddRows = false;
            this.dgvFileTable.AllowUserToDeleteRows = false;
            this.dgvFileTable.AllowUserToOrderColumns = true;
            this.dgvFileTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFileTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFileTable.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFileTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvFileTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFileTable.ContextMenuStrip = this.mnuFileTable;
            this.dgvFileTable.Location = new System.Drawing.Point(12, 114);
            this.dgvFileTable.Name = "dgvFileTable";
            this.dgvFileTable.ReadOnly = true;
            this.dgvFileTable.RowHeadersVisible = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Maroon;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFileTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvFileTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFileTable.Size = new System.Drawing.Size(913, 100);
            this.dgvFileTable.TabIndex = 4;
            // 
            // mnuFileTable
            // 
            this.mnuFileTable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openContainingFolderToolStripMenuItem,
            this.mnuRemoveDirectory,
            this.mnuRemoveFile});
            this.mnuFileTable.Name = "mnuFileTable";
            this.mnuFileTable.Size = new System.Drawing.Size(188, 70);
            // 
            // openContainingFolderToolStripMenuItem
            // 
            this.openContainingFolderToolStripMenuItem.Name = "openContainingFolderToolStripMenuItem";
            this.openContainingFolderToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.openContainingFolderToolStripMenuItem.Text = "Open Containing Folder";
            this.openContainingFolderToolStripMenuItem.Click += new System.EventHandler(this.OpenContainingFoldermnuFileTable_Click);
            // 
            // mnuRemoveDirectory
            // 
            this.mnuRemoveDirectory.Name = "mnuRemoveDirectory";
            this.mnuRemoveDirectory.Size = new System.Drawing.Size(187, 22);
            this.mnuRemoveDirectory.Text = "Remove Directory";
            this.mnuRemoveDirectory.Click += new System.EventHandler(this.RemoveDirectoryTable_Click);
            // 
            // mnuRemoveFile
            // 
            this.mnuRemoveFile.Name = "mnuRemoveFile";
            this.mnuRemoveFile.Size = new System.Drawing.Size(187, 22);
            this.mnuRemoveFile.Text = "Remove File";
            this.mnuRemoveFile.Click += new System.EventHandler(this.RemoveFileTable_Click);
            // 
            // txtMessages
            // 
            this.txtMessages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessages.Location = new System.Drawing.Point(12, 229);
            this.txtMessages.Multiline = true;
            this.txtMessages.Name = "txtMessages";
            this.txtMessages.Size = new System.Drawing.Size(913, 86);
            this.txtMessages.TabIndex = 5;
            // 
            // btnClearDatabase
            // 
            this.btnClearDatabase.Location = new System.Drawing.Point(176, 75);
            this.btnClearDatabase.Name = "btnClearDatabase";
            this.btnClearDatabase.Size = new System.Drawing.Size(100, 23);
            this.btnClearDatabase.TabIndex = 6;
            this.btnClearDatabase.Text = "Clear Database";
            this.btnClearDatabase.UseVisualStyleBackColor = true;
            this.btnClearDatabase.Click += new System.EventHandler(this.btnClearDatabase_Click);
            // 
            // lblVisited
            // 
            this.lblVisited.AutoSize = true;
            this.lblVisited.Location = new System.Drawing.Point(6, 17);
            this.lblVisited.Name = "lblVisited";
            this.lblVisited.Size = new System.Drawing.Size(41, 13);
            this.lblVisited.TabIndex = 7;
            this.lblVisited.Text = "Visited:";
            // 
            // lblVisitedVal
            // 
            this.lblVisitedVal.AutoSize = true;
            this.lblVisitedVal.Location = new System.Drawing.Point(72, 17);
            this.lblVisitedVal.Name = "lblVisitedVal";
            this.lblVisitedVal.Size = new System.Drawing.Size(13, 13);
            this.lblVisitedVal.TabIndex = 8;
            this.lblVisitedVal.Text = "0";
            // 
            // gbxInfo
            // 
            this.gbxInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxInfo.Controls.Add(this.lblCurrentDir);
            this.gbxInfo.Controls.Add(this.lblCurrentDirVal);
            this.gbxInfo.Controls.Add(this.lblCurrentFile);
            this.gbxInfo.Controls.Add(this.lblCurrentFileVal);
            this.gbxInfo.Controls.Add(this.lblVisited);
            this.gbxInfo.Controls.Add(this.lblVisitedVal);
            this.gbxInfo.Location = new System.Drawing.Point(11, 314);
            this.gbxInfo.Name = "gbxInfo";
            this.gbxInfo.Size = new System.Drawing.Size(914, 76);
            this.gbxInfo.TabIndex = 9;
            this.gbxInfo.TabStop = false;
            this.gbxInfo.Text = "Information";
            // 
            // lblCurrentDir
            // 
            this.lblCurrentDir.AutoSize = true;
            this.lblCurrentDir.Location = new System.Drawing.Point(7, 53);
            this.lblCurrentDir.Name = "lblCurrentDir";
            this.lblCurrentDir.Size = new System.Drawing.Size(54, 13);
            this.lblCurrentDir.TabIndex = 11;
            this.lblCurrentDir.Text = "CurrentDir";
            // 
            // lblCurrentDirVal
            // 
            this.lblCurrentDirVal.AutoSize = true;
            this.lblCurrentDirVal.Location = new System.Drawing.Point(73, 53);
            this.lblCurrentDirVal.Name = "lblCurrentDirVal";
            this.lblCurrentDirVal.Size = new System.Drawing.Size(16, 13);
            this.lblCurrentDirVal.TabIndex = 12;
            this.lblCurrentDirVal.Text = "---";
            // 
            // lblCurrentFile
            // 
            this.lblCurrentFile.AutoSize = true;
            this.lblCurrentFile.Location = new System.Drawing.Point(6, 34);
            this.lblCurrentFile.Name = "lblCurrentFile";
            this.lblCurrentFile.Size = new System.Drawing.Size(60, 13);
            this.lblCurrentFile.TabIndex = 9;
            this.lblCurrentFile.Text = "CurrentFile:";
            // 
            // lblCurrentFileVal
            // 
            this.lblCurrentFileVal.AutoSize = true;
            this.lblCurrentFileVal.Location = new System.Drawing.Point(72, 34);
            this.lblCurrentFileVal.Name = "lblCurrentFileVal";
            this.lblCurrentFileVal.Size = new System.Drawing.Size(16, 13);
            this.lblCurrentFileVal.TabIndex = 10;
            this.lblCurrentFileVal.Text = "---";
            // 
            // gbxHotFiles
            // 
            this.gbxHotFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxHotFiles.Controls.Add(this.btnExtractHotFiles);
            this.gbxHotFiles.Controls.Add(this.chbxUnusedRecently);
            this.gbxHotFiles.Controls.Add(this.chbxOldest);
            this.gbxHotFiles.Controls.Add(this.chbxLargest);
            this.gbxHotFiles.Location = new System.Drawing.Point(387, 12);
            this.gbxHotFiles.Name = "gbxHotFiles";
            this.gbxHotFiles.Size = new System.Drawing.Size(128, 96);
            this.gbxHotFiles.TabIndex = 12;
            this.gbxHotFiles.TabStop = false;
            this.gbxHotFiles.Text = "Hot Files";
            // 
            // btnExtractHotFiles
            // 
            this.btnExtractHotFiles.Location = new System.Drawing.Point(12, 67);
            this.btnExtractHotFiles.Name = "btnExtractHotFiles";
            this.btnExtractHotFiles.Size = new System.Drawing.Size(101, 23);
            this.btnExtractHotFiles.TabIndex = 3;
            this.btnExtractHotFiles.Text = "ExtractHotFiles";
            this.btnExtractHotFiles.UseVisualStyleBackColor = true;
            this.btnExtractHotFiles.Click += new System.EventHandler(this.btnExtractHotFiles_Click);
            // 
            // chbxUnusedRecently
            // 
            this.chbxUnusedRecently.AutoSize = true;
            this.chbxUnusedRecently.Location = new System.Drawing.Point(12, 45);
            this.chbxUnusedRecently.Name = "chbxUnusedRecently";
            this.chbxUnusedRecently.Size = new System.Drawing.Size(105, 17);
            this.chbxUnusedRecently.TabIndex = 2;
            this.chbxUnusedRecently.Text = "UnusedRecently";
            this.chbxUnusedRecently.UseVisualStyleBackColor = true;
            // 
            // chbxOldest
            // 
            this.chbxOldest.AutoSize = true;
            this.chbxOldest.Location = new System.Drawing.Point(12, 29);
            this.chbxOldest.Name = "chbxOldest";
            this.chbxOldest.Size = new System.Drawing.Size(56, 17);
            this.chbxOldest.TabIndex = 1;
            this.chbxOldest.Text = "Oldest";
            this.chbxOldest.UseVisualStyleBackColor = true;
            // 
            // chbxLargest
            // 
            this.chbxLargest.AutoSize = true;
            this.chbxLargest.Location = new System.Drawing.Point(12, 12);
            this.chbxLargest.Name = "chbxLargest";
            this.chbxLargest.Size = new System.Drawing.Size(61, 17);
            this.chbxLargest.TabIndex = 0;
            this.chbxLargest.Text = "Largest";
            this.chbxLargest.UseVisualStyleBackColor = true;
            // 
            // gbxSimularFiles
            // 
            this.gbxSimularFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxSimularFiles.Controls.Add(this.btnExtractSimularFiles);
            this.gbxSimularFiles.Controls.Add(this.radHavingSimularSizes);
            this.gbxSimularFiles.Controls.Add(this.radHavingSimularNames);
            this.gbxSimularFiles.Location = new System.Drawing.Point(521, 12);
            this.gbxSimularFiles.Name = "gbxSimularFiles";
            this.gbxSimularFiles.Size = new System.Drawing.Size(144, 96);
            this.gbxSimularFiles.TabIndex = 13;
            this.gbxSimularFiles.TabStop = false;
            this.gbxSimularFiles.Text = "Simular Files";
            // 
            // btnExtractSimularFiles
            // 
            this.btnExtractSimularFiles.Location = new System.Drawing.Point(6, 67);
            this.btnExtractSimularFiles.Name = "btnExtractSimularFiles";
            this.btnExtractSimularFiles.Size = new System.Drawing.Size(124, 23);
            this.btnExtractSimularFiles.TabIndex = 4;
            this.btnExtractSimularFiles.Text = "Extract Simular Files";
            this.btnExtractSimularFiles.UseVisualStyleBackColor = true;
            this.btnExtractSimularFiles.Click += new System.EventHandler(this.btnExtractSimularFiles_Click);
            // 
            // radHavingSimularSizes
            // 
            this.radHavingSimularSizes.AutoSize = true;
            this.radHavingSimularSizes.Location = new System.Drawing.Point(6, 42);
            this.radHavingSimularSizes.Name = "radHavingSimularSizes";
            this.radHavingSimularSizes.Size = new System.Drawing.Size(124, 17);
            this.radHavingSimularSizes.TabIndex = 2;
            this.radHavingSimularSizes.Text = "Having Simular Sizes";
            this.radHavingSimularSizes.UseVisualStyleBackColor = true;
            // 
            // radHavingSimularNames
            // 
            this.radHavingSimularNames.AutoSize = true;
            this.radHavingSimularNames.Checked = true;
            this.radHavingSimularNames.Location = new System.Drawing.Point(6, 19);
            this.radHavingSimularNames.Name = "radHavingSimularNames";
            this.radHavingSimularNames.Size = new System.Drawing.Size(132, 17);
            this.radHavingSimularNames.TabIndex = 1;
            this.radHavingSimularNames.TabStop = true;
            this.radHavingSimularNames.Text = "Having Simular Names";
            this.radHavingSimularNames.UseVisualStyleBackColor = true;
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.Location = new System.Drawing.Point(15, 80);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(84, 13);
            this.lblTop.TabIndex = 4;
            this.lblTop.Text = "Extract only Top";
            // 
            // nupdMaxRecords
            // 
            this.nupdMaxRecords.Location = new System.Drawing.Point(105, 78);
            this.nupdMaxRecords.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nupdMaxRecords.Name = "nupdMaxRecords";
            this.nupdMaxRecords.Size = new System.Drawing.Size(65, 20);
            this.nupdMaxRecords.TabIndex = 5;
            this.nupdMaxRecords.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // btnClearHotFiles
            // 
            this.btnClearHotFiles.Location = new System.Drawing.Point(281, 75);
            this.btnClearHotFiles.Name = "btnClearHotFiles";
            this.btnClearHotFiles.Size = new System.Drawing.Size(100, 23);
            this.btnClearHotFiles.TabIndex = 14;
            this.btnClearHotFiles.Text = "Clear Hot Files";
            this.btnClearHotFiles.UseVisualStyleBackColor = true;
            this.btnClearHotFiles.Click += new System.EventHandler(this.btnClearHotFiles_Click);
            // 
            // grbxHotFolders
            // 
            this.grbxHotFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grbxHotFolders.Controls.Add(this.radFoldersContainingMaxTotalFileSize);
            this.grbxHotFolders.Controls.Add(this.btnHotFolders);
            this.grbxHotFolders.Controls.Add(this.radFoldersContiningLargestFiles);
            this.grbxHotFolders.Controls.Add(this.radFoldersContiningLotsOfFiles);
            this.grbxHotFolders.Location = new System.Drawing.Point(671, 12);
            this.grbxHotFolders.Name = "grbxHotFolders";
            this.grbxHotFolders.Size = new System.Drawing.Size(254, 96);
            this.grbxHotFolders.TabIndex = 15;
            this.grbxHotFolders.TabStop = false;
            this.grbxHotFolders.Text = "Hot Folders";
            // 
            // btnHotFolders
            // 
            this.btnHotFolders.Location = new System.Drawing.Point(10, 67);
            this.btnHotFolders.Name = "btnHotFolders";
            this.btnHotFolders.Size = new System.Drawing.Size(124, 23);
            this.btnHotFolders.TabIndex = 4;
            this.btnHotFolders.Text = "Extract Hot Folders";
            this.btnHotFolders.UseVisualStyleBackColor = true;
            this.btnHotFolders.Click += new System.EventHandler(this.HotFolders_Click);
            // 
            // radFoldersContiningLargestFiles
            // 
            this.radFoldersContiningLargestFiles.AutoSize = true;
            this.radFoldersContiningLargestFiles.Location = new System.Drawing.Point(10, 31);
            this.radFoldersContiningLargestFiles.Name = "radFoldersContiningLargestFiles";
            this.radFoldersContiningLargestFiles.Size = new System.Drawing.Size(168, 17);
            this.radFoldersContiningLargestFiles.TabIndex = 2;
            this.radFoldersContiningLargestFiles.Text = "Folders Contining Largest Files";
            this.radFoldersContiningLargestFiles.UseVisualStyleBackColor = true;
            // 
            // radFoldersContiningLotsOfFiles
            // 
            this.radFoldersContiningLotsOfFiles.AutoSize = true;
            this.radFoldersContiningLotsOfFiles.Checked = true;
            this.radFoldersContiningLotsOfFiles.Location = new System.Drawing.Point(10, 13);
            this.radFoldersContiningLotsOfFiles.Name = "radFoldersContiningLotsOfFiles";
            this.radFoldersContiningLotsOfFiles.Size = new System.Drawing.Size(167, 17);
            this.radFoldersContiningLotsOfFiles.TabIndex = 1;
            this.radFoldersContiningLotsOfFiles.TabStop = true;
            this.radFoldersContiningLotsOfFiles.Text = "Folders Contining Lots Of Files";
            this.radFoldersContiningLotsOfFiles.UseVisualStyleBackColor = true;
            // 
            // radFoldersContainingMaxTotalFileSize
            // 
            this.radFoldersContainingMaxTotalFileSize.AutoSize = true;
            this.radFoldersContainingMaxTotalFileSize.Location = new System.Drawing.Point(10, 47);
            this.radFoldersContainingMaxTotalFileSize.Name = "radFoldersContainingMaxTotalFileSize";
            this.radFoldersContainingMaxTotalFileSize.Size = new System.Drawing.Size(204, 17);
            this.radFoldersContainingMaxTotalFileSize.TabIndex = 5;
            this.radFoldersContainingMaxTotalFileSize.Text = "Folders Containing Max Total File Size";
            this.radFoldersContainingMaxTotalFileSize.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 391);
            this.Controls.Add(this.grbxHotFolders);
            this.Controls.Add(this.nupdMaxRecords);
            this.Controls.Add(this.btnClearHotFiles);
            this.Controls.Add(this.lblTop);
            this.Controls.Add(this.gbxInfo);
            this.Controls.Add(this.gbxSimularFiles);
            this.Controls.Add(this.gbxHotFiles);
            this.Controls.Add(this.txtMessages);
            this.Controls.Add(this.btnClearDatabase);
            this.Controls.Add(this.dgvFileTable);
            this.Controls.Add(this.grpbxSelectTargetDir);
            this.Name = "frmMain";
            this.Text = "Directory Analyser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpbxSelectTargetDir.ResumeLayout(false);
            this.grpbxSelectTargetDir.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFileTable)).EndInit();
            this.mnuFileTable.ResumeLayout(false);
            this.gbxInfo.ResumeLayout(false);
            this.gbxInfo.PerformLayout();
            this.gbxHotFiles.ResumeLayout(false);
            this.gbxHotFiles.PerformLayout();
            this.gbxSimularFiles.ResumeLayout(false);
            this.gbxSimularFiles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupdMaxRecords)).EndInit();
            this.grbxHotFolders.ResumeLayout(false);
            this.grbxHotFolders.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGatherInfo;
        private System.Windows.Forms.FolderBrowserDialog fldrBrwsTargetDir;
        private System.Windows.Forms.TextBox txtTargetDir;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.GroupBox grpbxSelectTargetDir;
        private System.Windows.Forms.DataGridView dgvFileTable;
        private System.Windows.Forms.TextBox txtMessages;
        private System.Windows.Forms.Button btnClearDatabase;
        private System.Windows.Forms.Label lblVisited;
        private System.Windows.Forms.Label lblVisitedVal;
        private System.Windows.Forms.GroupBox gbxInfo;
        private System.Windows.Forms.Label lblCurrentDir;
        private System.Windows.Forms.Label lblCurrentDirVal;
        private System.Windows.Forms.Label lblCurrentFile;
        private System.Windows.Forms.Label lblCurrentFileVal;
        private System.Windows.Forms.GroupBox gbxHotFiles;
        private System.Windows.Forms.CheckBox chbxLargest;
        private System.Windows.Forms.Button btnExtractHotFiles;
        private System.Windows.Forms.CheckBox chbxUnusedRecently;
        private System.Windows.Forms.CheckBox chbxOldest;
        private System.Windows.Forms.GroupBox gbxSimularFiles;
        private System.Windows.Forms.RadioButton radHavingSimularSizes;
        private System.Windows.Forms.RadioButton radHavingSimularNames;
        private System.Windows.Forms.Button btnExtractSimularFiles;
        private System.Windows.Forms.NumericUpDown nupdMaxRecords;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.Button btnClearHotFiles;
        private System.Windows.Forms.ContextMenuStrip mnuFileTable;
        private System.Windows.Forms.ToolStripMenuItem openContainingFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveDirectory;
        private System.Windows.Forms.ToolStripMenuItem mnuRemoveFile;
        private System.Windows.Forms.GroupBox grbxHotFolders;
        private System.Windows.Forms.Button btnHotFolders;
        private System.Windows.Forms.RadioButton radFoldersContiningLargestFiles;
        private System.Windows.Forms.RadioButton radFoldersContiningLotsOfFiles;
        private System.Windows.Forms.RadioButton radFoldersContainingMaxTotalFileSize;
    }
}

