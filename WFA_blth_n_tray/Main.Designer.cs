namespace WFA_blth_n_tray
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hi1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMouseClickTimer = new System.Windows.Forms.Timer(this.components);
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.netSettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.FindDvProgressBar = new System.Windows.Forms.ProgressBar();
            this.RefreshDvLstButton = new System.Windows.Forms.Button();
            this.DvListBox = new System.Windows.Forms.ListBox();
            this.BlthDvRadioButton = new System.Windows.Forms.RadioButton();
            this.AllNtDvRadioButton = new System.Windows.Forms.RadioButton();
            this.detailsGroupBox = new System.Windows.Forms.GroupBox();
            this.DetailsDvTextBox = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.connectPointsListBox = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.controledByPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.controledByTextBox = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.MyComputersListBox = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.IPAddressMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.FindDvBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.mainFormMenuStrip.SuspendLayout();
            this.notifyContextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.netSettingsGroupBox.SuspendLayout();
            this.detailsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.controledByPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // mainFormMenuStrip
            // 
            this.mainFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.mainFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.mainFormMenuStrip.Name = "mainFormMenuStrip";
            this.mainFormMenuStrip.Size = new System.Drawing.Size(484, 24);
            this.mainFormMenuStrip.TabIndex = 0;
            this.mainFormMenuStrip.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hi1ToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 20);
            this.toolStripMenuItem1.Text = "Main";
            // 
            // hi1ToolStripMenuItem
            // 
            this.hi1ToolStripMenuItem.Name = "hi1ToolStripMenuItem";
            this.hi1ToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.hi1ToolStripMenuItem.Text = "Exit";
            this.hi1ToolStripMenuItem.Click += new System.EventHandler(this.hi1ToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenuStrip;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "WFA";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // notifyContextMenuStrip
            // 
            this.notifyContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.notifyContextMenuStrip.Name = "notifyContextMenuStrip";
            this.notifyContextMenuStrip.Size = new System.Drawing.Size(102, 26);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(101, 22);
            this.toolStripMenuItem2.Text = "Main";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(92, 22);
            this.toolStripTextBox1.Text = "Exit";
            this.toolStripTextBox1.Click += new System.EventHandler(this.toolStripTextBox1_Click);
            // 
            // notifyMouseClickTimer
            // 
            this.notifyMouseClickTimer.Interval = 1;
            this.notifyMouseClickTimer.Tick += new System.EventHandler(this.notifyMouseClickTimer_Tick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(484, 340);
            this.splitContainer1.SplitterDistance = 120;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.netSettingsGroupBox);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.detailsGroupBox);
            this.splitContainer2.Size = new System.Drawing.Size(484, 120);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 0;
            // 
            // netSettingsGroupBox
            // 
            this.netSettingsGroupBox.Controls.Add(this.FindDvProgressBar);
            this.netSettingsGroupBox.Controls.Add(this.RefreshDvLstButton);
            this.netSettingsGroupBox.Controls.Add(this.DvListBox);
            this.netSettingsGroupBox.Controls.Add(this.BlthDvRadioButton);
            this.netSettingsGroupBox.Controls.Add(this.AllNtDvRadioButton);
            this.netSettingsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.netSettingsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.netSettingsGroupBox.Name = "netSettingsGroupBox";
            this.netSettingsGroupBox.Size = new System.Drawing.Size(250, 120);
            this.netSettingsGroupBox.TabIndex = 0;
            this.netSettingsGroupBox.TabStop = false;
            this.netSettingsGroupBox.Text = "Settings";
            // 
            // FindDvProgressBar
            // 
            this.FindDvProgressBar.Location = new System.Drawing.Point(12, 95);
            this.FindDvProgressBar.Name = "FindDvProgressBar";
            this.FindDvProgressBar.Size = new System.Drawing.Size(103, 19);
            this.FindDvProgressBar.TabIndex = 4;
            this.FindDvProgressBar.Visible = false;
            // 
            // RefreshDvLstButton
            // 
            this.RefreshDvLstButton.Location = new System.Drawing.Point(12, 67);
            this.RefreshDvLstButton.Name = "RefreshDvLstButton";
            this.RefreshDvLstButton.Size = new System.Drawing.Size(103, 22);
            this.RefreshDvLstButton.TabIndex = 3;
            this.RefreshDvLstButton.Text = "Refresh";
            this.RefreshDvLstButton.UseVisualStyleBackColor = true;
            this.RefreshDvLstButton.Click += new System.EventHandler(this.RefreshDvLstButton_Click);
            // 
            // DvListBox
            // 
            this.DvListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DvListBox.FormattingEnabled = true;
            this.DvListBox.HorizontalScrollbar = true;
            this.DvListBox.IntegralHeight = false;
            this.DvListBox.Location = new System.Drawing.Point(128, 19);
            this.DvListBox.Name = "DvListBox";
            this.DvListBox.ScrollAlwaysVisible = true;
            this.DvListBox.Size = new System.Drawing.Size(119, 95);
            this.DvListBox.TabIndex = 2;
            this.DvListBox.SelectedIndexChanged += new System.EventHandler(this.DvListBox_SelectedIndexChanged);
            // 
            // BlthDvRadioButton
            // 
            this.BlthDvRadioButton.AutoSize = true;
            this.BlthDvRadioButton.Enabled = false;
            this.BlthDvRadioButton.Location = new System.Drawing.Point(12, 21);
            this.BlthDvRadioButton.Name = "BlthDvRadioButton";
            this.BlthDvRadioButton.Size = new System.Drawing.Size(110, 17);
            this.BlthDvRadioButton.TabIndex = 1;
            this.BlthDvRadioButton.Text = "Bluetooth devices";
            this.BlthDvRadioButton.UseVisualStyleBackColor = true;
            // 
            // AllNtDvRadioButton
            // 
            this.AllNtDvRadioButton.AutoSize = true;
            this.AllNtDvRadioButton.Checked = true;
            this.AllNtDvRadioButton.Location = new System.Drawing.Point(12, 44);
            this.AllNtDvRadioButton.Name = "AllNtDvRadioButton";
            this.AllNtDvRadioButton.Size = new System.Drawing.Size(103, 17);
            this.AllNtDvRadioButton.TabIndex = 0;
            this.AllNtDvRadioButton.TabStop = true;
            this.AllNtDvRadioButton.Text = "All net interfaces";
            this.AllNtDvRadioButton.UseVisualStyleBackColor = true;
            // 
            // detailsGroupBox
            // 
            this.detailsGroupBox.Controls.Add(this.DetailsDvTextBox);
            this.detailsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsGroupBox.Location = new System.Drawing.Point(0, 0);
            this.detailsGroupBox.Name = "detailsGroupBox";
            this.detailsGroupBox.Size = new System.Drawing.Size(230, 120);
            this.detailsGroupBox.TabIndex = 0;
            this.detailsGroupBox.TabStop = false;
            this.detailsGroupBox.Text = "Details";
            // 
            // DetailsDvTextBox
            // 
            this.DetailsDvTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailsDvTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DetailsDvTextBox.Location = new System.Drawing.Point(3, 16);
            this.DetailsDvTextBox.Multiline = true;
            this.DetailsDvTextBox.Name = "DetailsDvTextBox";
            this.DetailsDvTextBox.ReadOnly = true;
            this.DetailsDvTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.DetailsDvTextBox.Size = new System.Drawing.Size(224, 101);
            this.DetailsDvTextBox.TabIndex = 0;
            this.DetailsDvTextBox.WordWrap = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tabControl);
            this.splitContainer3.Size = new System.Drawing.Size(484, 216);
            this.splitContainer3.SplitterDistance = 161;
            this.splitContainer3.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.connectPointsListBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(161, 216);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connect points";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(87, 181);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Del point";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(12, 181);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Add point";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // connectPointsListBox
            // 
            this.connectPointsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectPointsListBox.FormattingEnabled = true;
            this.connectPointsListBox.HorizontalScrollbar = true;
            this.connectPointsListBox.IntegralHeight = false;
            this.connectPointsListBox.Location = new System.Drawing.Point(12, 22);
            this.connectPointsListBox.Name = "connectPointsListBox";
            this.connectPointsListBox.ScrollAlwaysVisible = true;
            this.connectPointsListBox.Size = new System.Drawing.Size(143, 153);
            this.connectPointsListBox.TabIndex = 3;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(319, 216);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ServerLabel);
            this.tabPage1.Controls.Add(this.controledByPanel);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.MyComputersListBox);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 190);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ServerLabel
            // 
            this.ServerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Location = new System.Drawing.Point(6, 11);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(87, 13);
            this.ServerLabel.TabIndex = 9;
            this.ServerLabel.Text = "My remoute PCs:";
            // 
            // controledByPanel
            // 
            this.controledByPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controledByPanel.Controls.Add(this.label3);
            this.controledByPanel.Controls.Add(this.controledByTextBox);
            this.controledByPanel.Location = new System.Drawing.Point(6, 133);
            this.controledByPanel.Name = "controledByPanel";
            this.controledByPanel.Size = new System.Drawing.Size(297, 49);
            this.controledByPanel.TabIndex = 8;
            this.controledByPanel.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "I am controled by:";
            // 
            // controledByTextBox
            // 
            this.controledByTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controledByTextBox.Location = new System.Drawing.Point(3, 26);
            this.controledByTextBox.Name = "controledByTextBox";
            this.controledByTextBox.ReadOnly = true;
            this.controledByTextBox.Size = new System.Drawing.Size(291, 20);
            this.controledByTextBox.TabIndex = 0;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.Location = new System.Drawing.Point(228, 104);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(77, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = ">>Hot keys";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.Location = new System.Drawing.Point(228, 56);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Delete PC";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Location = new System.Drawing.Point(228, 27);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 5;
            this.button4.Text = "Control PC";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // MyComputersListBox
            // 
            this.MyComputersListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyComputersListBox.FormattingEnabled = true;
            this.MyComputersListBox.HorizontalScrollbar = true;
            this.MyComputersListBox.IntegralHeight = false;
            this.MyComputersListBox.Location = new System.Drawing.Point(6, 27);
            this.MyComputersListBox.Name = "MyComputersListBox";
            this.MyComputersListBox.ScrollAlwaysVisible = true;
            this.MyComputersListBox.Size = new System.Drawing.Size(216, 100);
            this.MyComputersListBox.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.numericUpDown1);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.PortMaskedTextBox);
            this.tabPage2.Controls.Add(this.IPAddressMaskedTextBox);
            this.tabPage2.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 190);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Client";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(9, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(170, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Send \"add me\" request";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(133, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP address";
            // 
            // PortMaskedTextBox
            // 
            this.PortMaskedTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PortMaskedTextBox.Location = new System.Drawing.Point(136, 19);
            this.PortMaskedTextBox.Mask = "00000";
            this.PortMaskedTextBox.Name = "PortMaskedTextBox";
            this.PortMaskedTextBox.Size = new System.Drawing.Size(43, 18);
            this.PortMaskedTextBox.TabIndex = 1;
            this.PortMaskedTextBox.ValidatingType = typeof(int);
            // 
            // IPAddressMaskedTextBox
            // 
            this.IPAddressMaskedTextBox.BeepOnError = true;
            this.IPAddressMaskedTextBox.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IPAddressMaskedTextBox.Location = new System.Drawing.Point(9, 19);
            this.IPAddressMaskedTextBox.Mask = "990\\.990\\.990\\.990";
            this.IPAddressMaskedTextBox.Name = "IPAddressMaskedTextBox";
            this.IPAddressMaskedTextBox.PromptChar = ' ';
            this.IPAddressMaskedTextBox.Size = new System.Drawing.Size(121, 18);
            this.IPAddressMaskedTextBox.TabIndex = 0;
            // 
            // FindDvBackgroundWorker
            // 
            this.FindDvBackgroundWorker.WorkerReportsProgress = true;
            this.FindDvBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FindDvBackgroundWorker_DoWork);
            this.FindDvBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.FindDvBackgroundWorker_ProgressChanged);
            this.FindDvBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.FindDvBackgroundWorker_RunWorkerCompleted);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Location = new System.Drawing.Point(9, 113);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 18);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.Value = new decimal(new int[] {
            190,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(6, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Delay for mouse";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(484, 364);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.mainFormMenuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainFormMenuStrip;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.Text = "WFA";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.mainFormMenuStrip.ResumeLayout(false);
            this.mainFormMenuStrip.PerformLayout();
            this.notifyContextMenuStrip.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.netSettingsGroupBox.ResumeLayout(false);
            this.netSettingsGroupBox.PerformLayout();
            this.detailsGroupBox.ResumeLayout(false);
            this.detailsGroupBox.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.controledByPanel.ResumeLayout(false);
            this.controledByPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainFormMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hi1ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
        private System.Windows.Forms.Timer notifyMouseClickTimer;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox netSettingsGroupBox;
        private System.Windows.Forms.GroupBox detailsGroupBox;
        private System.Windows.Forms.ListBox DvListBox;
        private System.Windows.Forms.RadioButton BlthDvRadioButton;
        private System.Windows.Forms.RadioButton AllNtDvRadioButton;
        private System.Windows.Forms.Button RefreshDvLstButton;
        private System.Windows.Forms.ProgressBar FindDvProgressBar;
        private System.ComponentModel.BackgroundWorker FindDvBackgroundWorker;
        private System.Windows.Forms.TextBox DetailsDvTextBox;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox connectPointsListBox;
        private System.Windows.Forms.MaskedTextBox PortMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox IPAddressMaskedTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox MyComputersListBox;
        private System.Windows.Forms.Panel controledByPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox controledByTextBox;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;

    }
}

