
namespace YouTubeAsAlerm
{
    partial class FormSettings
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.ButtonUpdatePlaylist = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.PlaylistSelector = new System.Windows.Forms.ComboBox();
            this.GridPlaylistItems = new System.Windows.Forms.DataGridView();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.GridAlermSettings = new System.Windows.Forms.DataGridView();
            this.AlermColumn_Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlermColumn_OpenSettings = new System.Windows.Forms.DataGridViewButtonColumn();
            this.AlermColumn_Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlermTimer = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridPlaylistItems)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GridAlermSettings)).BeginInit();
            this.NotifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonUpdatePlaylist
            // 
            this.ButtonUpdatePlaylist.Location = new System.Drawing.Point(8, 7);
            this.ButtonUpdatePlaylist.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ButtonUpdatePlaylist.Name = "ButtonUpdatePlaylist";
            this.ButtonUpdatePlaylist.Size = new System.Drawing.Size(122, 23);
            this.ButtonUpdatePlaylist.TabIndex = 0;
            this.ButtonUpdatePlaylist.Text = "Update Playlist";
            this.ButtonUpdatePlaylist.UseVisualStyleBackColor = true;
            this.ButtonUpdatePlaylist.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(933, 562);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.PlaylistSelector);
            this.tabPage1.Controls.Add(this.GridPlaylistItems);
            this.tabPage1.Controls.Add(this.ButtonUpdatePlaylist);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 534);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Playlists";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // PlaylistSelector
            // 
            this.PlaylistSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PlaylistSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PlaylistSelector.FormattingEnabled = true;
            this.PlaylistSelector.Location = new System.Drawing.Point(136, 6);
            this.PlaylistSelector.Name = "PlaylistSelector";
            this.PlaylistSelector.Size = new System.Drawing.Size(781, 23);
            this.PlaylistSelector.TabIndex = 2;
            this.PlaylistSelector.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // GridPlaylistItems
            // 
            this.GridPlaylistItems.AllowUserToAddRows = false;
            this.GridPlaylistItems.AllowUserToDeleteRows = false;
            this.GridPlaylistItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GridPlaylistItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridPlaylistItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Id,
            this.Column_Title});
            this.GridPlaylistItems.Location = new System.Drawing.Point(8, 35);
            this.GridPlaylistItems.Name = "GridPlaylistItems";
            this.GridPlaylistItems.ReadOnly = true;
            this.GridPlaylistItems.RowTemplate.Height = 21;
            this.GridPlaylistItems.Size = new System.Drawing.Size(909, 483);
            this.GridPlaylistItems.TabIndex = 1;
            this.GridPlaylistItems.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridPlaylistItems_CellContentDoubleClick);
            // 
            // Column_Id
            // 
            this.Column_Id.HeaderText = "ID";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            // 
            // Column_Title
            // 
            this.Column_Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Title.HeaderText = "Title";
            this.Column_Title.Name = "Column_Title";
            this.Column_Title.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.GridAlermSettings);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 534);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Alerm";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // GridAlermSettings
            // 
            this.GridAlermSettings.AllowUserToDeleteRows = false;
            this.GridAlermSettings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GridAlermSettings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AlermColumn_Status,
            this.AlermColumn_OpenSettings,
            this.AlermColumn_Delete});
            this.GridAlermSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GridAlermSettings.Location = new System.Drawing.Point(3, 3);
            this.GridAlermSettings.MultiSelect = false;
            this.GridAlermSettings.Name = "GridAlermSettings";
            this.GridAlermSettings.ReadOnly = true;
            this.GridAlermSettings.RowTemplate.Height = 21;
            this.GridAlermSettings.Size = new System.Drawing.Size(919, 528);
            this.GridAlermSettings.TabIndex = 0;
            this.GridAlermSettings.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // AlermColumn_Status
            // 
            this.AlermColumn_Status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.AlermColumn_Status.HeaderText = "Status";
            this.AlermColumn_Status.Name = "AlermColumn_Status";
            this.AlermColumn_Status.ReadOnly = true;
            // 
            // AlermColumn_OpenSettings
            // 
            this.AlermColumn_OpenSettings.HeaderText = "Settings";
            this.AlermColumn_OpenSettings.Name = "AlermColumn_OpenSettings";
            this.AlermColumn_OpenSettings.ReadOnly = true;
            // 
            // AlermColumn_Delete
            // 
            this.AlermColumn_Delete.HeaderText = "Delete";
            this.AlermColumn_Delete.Name = "AlermColumn_Delete";
            this.AlermColumn_Delete.ReadOnly = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.NotifyMenu;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "YouTube as Alerm";
            this.notifyIcon1.Visible = true;
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showSettingsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.Size = new System.Drawing.Size(159, 48);
            // 
            // showSettingsToolStripMenuItem
            // 
            this.showSettingsToolStripMenuItem.Name = "showSettingsToolStripMenuItem";
            this.showSettingsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.showSettingsToolStripMenuItem.Text = "&Show Settings";
            this.showSettingsToolStripMenuItem.Click += new System.EventHandler(this.showSettingsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.exitToolStripMenuItem.Text = "&Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // AlermTimer
            // 
            this.AlermTimer.Enabled = true;
            this.AlermTimer.Interval = 1000;
            this.AlermTimer.Tick += new System.EventHandler(this.AlermTimer_Tick);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 562);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormSettings";
            this.Text = "YouTube as Alerm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSettings_FormClosing);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.Shown += new System.EventHandler(this.FormSettings_Shown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridPlaylistItems)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GridAlermSettings)).EndInit();
            this.NotifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonUpdatePlaylist;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox PlaylistSelector;
        private System.Windows.Forms.DataGridView GridPlaylistItems;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Title;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.DataGridView GridAlermSettings;
        private System.Windows.Forms.ToolStripMenuItem showSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Timer AlermTimer;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlermColumn_Status;
        private System.Windows.Forms.DataGridViewButtonColumn AlermColumn_OpenSettings;
        private System.Windows.Forms.DataGridViewButtonColumn AlermColumn_Delete;
    }
}

