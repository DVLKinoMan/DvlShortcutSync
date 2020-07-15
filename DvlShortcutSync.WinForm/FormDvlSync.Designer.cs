namespace DvlShortcutSync.WinForm
{
    partial class FormDvlSync
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDvlSync));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CustomNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.CustomContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxTimer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.errorProviderTimer = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridViewFoldersToSync = new System.Windows.Forms.DataGridView();
            this.ColumnFirstFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSecondFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.CustomContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTimer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoldersToSync)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CustomNotifyIcon
            // 
            this.CustomNotifyIcon.ContextMenuStrip = this.CustomContextMenu;
            this.CustomNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("CustomNotifyIcon.Icon")));
            this.CustomNotifyIcon.Text = "DvlSync";
            this.CustomNotifyIcon.Visible = true;
            this.CustomNotifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CustomNotifyIcon_MouseClick);
            this.CustomNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // CustomContextMenu
            // 
            this.CustomContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CustomContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.CustomContextMenu.Name = "CustomContextMenu";
            this.CustomContextMenu.Size = new System.Drawing.Size(103, 28);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(52, 333);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(210, 48);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxTimer
            // 
            this.textBoxTimer.Location = new System.Drawing.Point(52, 281);
            this.textBoxTimer.Name = "textBoxTimer";
            this.textBoxTimer.Size = new System.Drawing.Size(295, 22);
            this.textBoxTimer.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 254);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Timer Interval in Milliseconds:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Folder Paths to Sync:";
            // 
            // errorProviderTimer
            // 
            this.errorProviderTimer.ContainerControl = this;
            // 
            // dataGridViewFoldersToSync
            // 
            this.dataGridViewFoldersToSync.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewFoldersToSync.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFoldersToSync.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnFirstFolder,
            this.ColumnSecondFolder});
            this.dataGridViewFoldersToSync.Location = new System.Drawing.Point(52, 63);
            this.dataGridViewFoldersToSync.Name = "dataGridViewFoldersToSync";
            this.dataGridViewFoldersToSync.RowHeadersWidth = 51;
            this.dataGridViewFoldersToSync.RowTemplate.Height = 24;
            this.dataGridViewFoldersToSync.Size = new System.Drawing.Size(564, 172);
            this.dataGridViewFoldersToSync.TabIndex = 6;
            this.dataGridViewFoldersToSync.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewFoldersToSync_CellDoubleClick);
            // 
            // ColumnFirstFolder
            // 
            this.ColumnFirstFolder.HeaderText = "First Folder Path";
            this.ColumnFirstFolder.MinimumWidth = 6;
            this.ColumnFirstFolder.Name = "ColumnFirstFolder";
            this.ColumnFirstFolder.Width = 125;
            // 
            // ColumnSecondFolder
            // 
            this.ColumnSecondFolder.HeaderText = "Second Folder Path";
            this.ColumnSecondFolder.MinimumWidth = 6;
            this.ColumnSecondFolder.Name = "ColumnSecondFolder";
            this.ColumnSecondFolder.Width = 125;
            // 
            // FormDvlSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 393);
            this.Controls.Add(this.dataGridViewFoldersToSync);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxTimer);
            this.Controls.Add(this.buttonSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormDvlSync";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "DvlSync";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDvlSync_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.CustomContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderTimer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFoldersToSync)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NotifyIcon CustomNotifyIcon;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.TextBox textBoxTimer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ContextMenuStrip CustomContextMenu;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ErrorProvider errorProviderTimer;
        private System.Windows.Forms.DataGridView dataGridViewFoldersToSync;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFirstFolder;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSecondFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

