
namespace DownloadsOrganizer
{
    partial class MainForm
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
            this.status = new System.Windows.Forms.StatusStrip();
            this.statusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.log = new System.Windows.Forms.TextBox();
            this.grid = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOpenRoot = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.btnExecute = new System.Windows.Forms.Button();
            this.btnScan = new System.Windows.Forms.Button();
            this.chkWatcher = new System.Windows.Forms.CheckBox();
            this.chkDryRun = new System.Windows.Forms.CheckBox();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.chkIncludeSub = new System.Windows.Forms.CheckBox();
            this.chkCreateFolders = new System.Windows.Forms.CheckBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusText});
            this.status.Location = new System.Drawing.Point(0, 539);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(884, 22);
            this.status.TabIndex = 13;
            this.status.Text = "statusStrip1";
            // 
            // statusText
            // 
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(39, 17);
            this.statusText.Text = "Ready";
            // 
            // log
            // 
            this.log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.log.Location = new System.Drawing.Point(3, 416);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ReadOnly = true;
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(878, 120);
            this.log.TabIndex = 12;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(310, 3);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.Size = new System.Drawing.Size(565, 401);
            this.grid.TabIndex = 11;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.log, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.62337F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.37662F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(884, 539);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.grid, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(878, 407);
            this.tableLayoutPanel2.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOpenRoot);
            this.panel1.Controls.Add(this.btnUndo);
            this.panel1.Controls.Add(this.btnExecute);
            this.panel1.Controls.Add(this.btnScan);
            this.panel1.Controls.Add(this.chkWatcher);
            this.panel1.Controls.Add(this.chkDryRun);
            this.panel1.Controls.Add(this.chkOverwrite);
            this.panel1.Controls.Add(this.chkIncludeSub);
            this.panel1.Controls.Add(this.chkCreateFolders);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.txtRoot);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 401);
            this.panel1.TabIndex = 5;
            // 
            // btnOpenRoot
            // 
            this.btnOpenRoot.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOpenRoot.Location = new System.Drawing.Point(0, 265);
            this.btnOpenRoot.Name = "btnOpenRoot";
            this.btnOpenRoot.Size = new System.Drawing.Size(301, 35);
            this.btnOpenRoot.TabIndex = 10;
            this.btnOpenRoot.Text = "Open folder";
            this.btnOpenRoot.UseVisualStyleBackColor = true;
            // 
            // btnUndo
            // 
            this.btnUndo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUndo.Location = new System.Drawing.Point(0, 230);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(301, 35);
            this.btnUndo.TabIndex = 9;
            this.btnUndo.Text = "Undo";
            this.btnUndo.UseVisualStyleBackColor = true;
            // 
            // btnExecute
            // 
            this.btnExecute.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExecute.Location = new System.Drawing.Point(0, 195);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(301, 35);
            this.btnExecute.TabIndex = 8;
            this.btnExecute.Text = "Execute move";
            this.btnExecute.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            this.btnScan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnScan.Location = new System.Drawing.Point(0, 160);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(301, 35);
            this.btnScan.TabIndex = 7;
            this.btnScan.Text = "Scan / Update plan";
            this.btnScan.UseVisualStyleBackColor = true;
            // 
            // chkWatcher
            // 
            this.chkWatcher.AutoSize = true;
            this.chkWatcher.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkWatcher.Location = new System.Drawing.Point(0, 139);
            this.chkWatcher.Name = "chkWatcher";
            this.chkWatcher.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.chkWatcher.Size = new System.Drawing.Size(301, 21);
            this.chkWatcher.TabIndex = 6;
            this.chkWatcher.Text = "Real-time monitoring (automatic sorting of new files)";
            this.chkWatcher.UseVisualStyleBackColor = true;
            // 
            // chkDryRun
            // 
            this.chkDryRun.AutoSize = true;
            this.chkDryRun.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkDryRun.Location = new System.Drawing.Point(0, 118);
            this.chkDryRun.Name = "chkDryRun";
            this.chkDryRun.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.chkDryRun.Size = new System.Drawing.Size(301, 21);
            this.chkDryRun.TabIndex = 5;
            this.chkDryRun.Text = "Dry Run - just a plan, no move";
            this.chkDryRun.UseVisualStyleBackColor = true;
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkOverwrite.Location = new System.Drawing.Point(0, 97);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.chkOverwrite.Size = new System.Drawing.Size(301, 21);
            this.chkOverwrite.TabIndex = 4;
            this.chkOverwrite.Text = "Overwrite on name collision (o/w: (1), (2) ...)";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // chkIncludeSub
            // 
            this.chkIncludeSub.AutoSize = true;
            this.chkIncludeSub.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkIncludeSub.Location = new System.Drawing.Point(0, 76);
            this.chkIncludeSub.Name = "chkIncludeSub";
            this.chkIncludeSub.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.chkIncludeSub.Size = new System.Drawing.Size(301, 21);
            this.chkIncludeSub.TabIndex = 3;
            this.chkIncludeSub.Text = "Include subfolders";
            this.chkIncludeSub.UseVisualStyleBackColor = true;
            // 
            // chkCreateFolders
            // 
            this.chkCreateFolders.AutoSize = true;
            this.chkCreateFolders.Dock = System.Windows.Forms.DockStyle.Top;
            this.chkCreateFolders.Location = new System.Drawing.Point(0, 55);
            this.chkCreateFolders.Name = "chkCreateFolders";
            this.chkCreateFolders.Padding = new System.Windows.Forms.Padding(4, 4, 4, 0);
            this.chkCreateFolders.Size = new System.Drawing.Size(301, 21);
            this.chkCreateFolders.TabIndex = 2;
            this.chkCreateFolders.Text = "Create category folders";
            this.chkCreateFolders.UseVisualStyleBackColor = true;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBrowse.Location = new System.Drawing.Point(0, 20);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(301, 35);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            // 
            // txtRoot
            // 
            this.txtRoot.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtRoot.Location = new System.Drawing.Point(0, 0);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.ReadOnly = true;
            this.txtRoot.Size = new System.Drawing.Size(301, 20);
            this.txtRoot.TabIndex = 13;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.status);
            this.Name = "MainForm";
            this.Text = "Download Organizer";
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripStatusLabel statusText;
        private System.Windows.Forms.TextBox log;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox chkCreateFolders;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Button btnOpenRoot;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.CheckBox chkWatcher;
        private System.Windows.Forms.CheckBox chkDryRun;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.CheckBox chkIncludeSub;
    }
}