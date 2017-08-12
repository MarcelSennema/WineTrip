namespace WineTrip
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tripBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.calenderPanel = new System.Windows.Forms.TableLayoutPanel();
            this.calenderTabControl = new System.Windows.Forms.TabControl();
            this.detailsPanel = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.buttonBottleOrder = new System.Windows.Forms.Button();
            this.buttonVisitWebSite = new System.Windows.Forms.Button();
            this.textBoxWebSite = new System.Windows.Forms.TextBox();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textboxDuration = new System.Windows.Forms.TextBox();
            this.textboxDescription = new System.Windows.Forms.RichTextBox();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxGPSLocation = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mapTabControl = new System.Windows.Forms.TabControl();
            this.localMap = new System.Windows.Forms.TabPage();
            this.buttonVerifyAdress = new System.Windows.Forms.Button();
            this.pictureBoxLocalMap = new System.Windows.Forms.PictureBox();
            this.fromMap = new System.Windows.Forms.TabPage();
            this.distanceLabelFrom = new System.Windows.Forms.Label();
            this.pictureBoxTransferFrom = new System.Windows.Forms.PictureBox();
            this.toMap = new System.Windows.Forms.TabPage();
            this.distanceLabelTo = new System.Windows.Forms.Label();
            this.pictureBoxTransFerTo = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dataGridViewMembers = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.membersBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumberOfDays = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStripButtonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSave = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCalculate = new System.Windows.Forms.ToolStripButton();
            this.membersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tripBindingSource)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.calenderPanel.SuspendLayout();
            this.detailsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            this.panel2.SuspendLayout();
            this.mapTabControl.SuspendLayout();
            this.localMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocalMap)).BeginInit();
            this.fromMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransferFrom)).BeginInit();
            this.toMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransFerTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource1)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tripBindingSource, "region", true));
            this.textBox1.Location = new System.Drawing.Point(94, 3);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(364, 20);
            this.textBox1.TabIndex = 0;
            // 
            // tripBindingSource
            // 
            this.tripBindingSource.DataSource = typeof(WineTrip.DataModel.Trip);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Region ";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripFileName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 784);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1577, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripFileName
            // 
            this.toolStripFileName.Name = "toolStripFileName";
            this.toolStripFileName.Size = new System.Drawing.Size(34, 17);
            this.toolStripFileName.Text = "none";
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "wtf";
            this.openFileDialog.FileName = "WineTrip";
            this.openFileDialog.Filter = "WineTrip Files|*.wtf";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "wtf";
            this.saveFileDialog.Filter = "WineTrip Files|*.wtf";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.dataGridViewMembers);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxNumberOfDays);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1577, 734);
            this.panel1.TabIndex = 5;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(467, 22);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.calenderPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.detailsPanel);
            this.splitContainer1.Size = new System.Drawing.Size(1107, 709);
            this.splitContainer1.SplitterDistance = 556;
            this.splitContainer1.TabIndex = 10;
            // 
            // calenderPanel
            // 
            this.calenderPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.calenderPanel.ColumnCount = 1;
            this.calenderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.calenderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.calenderPanel.Controls.Add(this.calenderTabControl, 0, 0);
            this.calenderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calenderPanel.Location = new System.Drawing.Point(0, 0);
            this.calenderPanel.Name = "calenderPanel";
            this.calenderPanel.RowCount = 1;
            this.calenderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.calenderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 717F));
            this.calenderPanel.Size = new System.Drawing.Size(556, 709);
            this.calenderPanel.TabIndex = 1;
            // 
            // calenderTabControl
            // 
            this.calenderTabControl.AllowDrop = true;
            this.calenderTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calenderTabControl.Location = new System.Drawing.Point(3, 3);
            this.calenderTabControl.MinimumSize = new System.Drawing.Size(200, 100);
            this.calenderTabControl.Name = "calenderTabControl";
            this.calenderTabControl.SelectedIndex = 0;
            this.calenderTabControl.Size = new System.Drawing.Size(550, 711);
            this.calenderTabControl.TabIndex = 0;
            this.calenderTabControl.SelectedIndexChanged += new System.EventHandler(this.CalenderTabs_SelectedIndexChanged);
            this.calenderTabControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.CalenderTabs_DragEnter);
            this.calenderTabControl.DragOver += new System.Windows.Forms.DragEventHandler(this.calenderTabControl_DragOver);
            // 
            // detailsPanel
            // 
            this.detailsPanel.Controls.Add(this.splitContainer2);
            this.detailsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailsPanel.Location = new System.Drawing.Point(0, 0);
            this.detailsPanel.Name = "detailsPanel";
            this.detailsPanel.Size = new System.Drawing.Size(547, 709);
            this.detailsPanel.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.buttonVerifyAdress);
            this.splitContainer2.Panel1.Controls.Add(this.buttonBottleOrder);
            this.splitContainer2.Panel1.Controls.Add(this.buttonVisitWebSite);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxWebSite);
            this.splitContainer2.Panel1.Controls.Add(this.label12);
            this.splitContainer2.Panel1.Controls.Add(this.buttonDelete);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.label11);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxName);
            this.splitContainer2.Panel1.Controls.Add(this.textboxDuration);
            this.splitContainer2.Panel1.Controls.Add(this.textboxDescription);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxAddress);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxEmail);
            this.splitContainer2.Panel1.Controls.Add(this.textBoxGPSLocation);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(547, 709);
            this.splitContainer2.SplitterDistance = 322;
            this.splitContainer2.TabIndex = 6;
            // 
            // buttonBottleOrder
            // 
            this.buttonBottleOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonBottleOrder.Location = new System.Drawing.Point(0, 284);
            this.buttonBottleOrder.Name = "buttonBottleOrder";
            this.buttonBottleOrder.Size = new System.Drawing.Size(77, 36);
            this.buttonBottleOrder.TabIndex = 10;
            this.buttonBottleOrder.Text = "Order";
            this.buttonBottleOrder.UseVisualStyleBackColor = true;
            this.buttonBottleOrder.Click += new System.EventHandler(this.buttonBottleOrder_Click);
            // 
            // buttonVisitWebSite
            // 
            this.buttonVisitWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonVisitWebSite.Location = new System.Drawing.Point(467, 99);
            this.buttonVisitWebSite.Name = "buttonVisitWebSite";
            this.buttonVisitWebSite.Size = new System.Drawing.Size(77, 20);
            this.buttonVisitWebSite.TabIndex = 6;
            this.buttonVisitWebSite.Text = "Visit";
            this.buttonVisitWebSite.UseVisualStyleBackColor = true;
            this.buttonVisitWebSite.Click += new System.EventHandler(this.buttonVisitWebSite_Click);
            // 
            // textBoxWebSite
            // 
            this.textBoxWebSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxWebSite.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "webSite", true));
            this.textBoxWebSite.Location = new System.Drawing.Point(91, 99);
            this.textBoxWebSite.Name = "textBoxWebSite";
            this.textBoxWebSite.Size = new System.Drawing.Size(369, 20);
            this.textBoxWebSite.TabIndex = 5;
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(WineTrip.DataModel.Event);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 11;
            this.label12.Text = "Web site";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(467, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(77, 20);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Label";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Description";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(47, 13);
            this.label11.TabIndex = 5;
            this.label11.Text = "Duration";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "name", true));
            this.textBoxName.Location = new System.Drawing.Point(91, 4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(369, 20);
            this.textBoxName.TabIndex = 0;
            this.textBoxName.Validated += new System.EventHandler(this.generic_Validated);
            // 
            // textboxDuration
            // 
            this.textboxDuration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxDuration.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "duration", true));
            this.textboxDuration.Location = new System.Drawing.Point(91, 30);
            this.textboxDuration.Name = "textboxDuration";
            this.textboxDuration.Size = new System.Drawing.Size(110, 20);
            this.textboxDuration.TabIndex = 2;
            this.textboxDuration.Validated += new System.EventHandler(this.generic_Validated);
            // 
            // textboxDescription
            // 
            this.textboxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textboxDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "description", true));
            this.textboxDescription.Location = new System.Drawing.Point(91, 176);
            this.textboxDescription.Name = "textboxDescription";
            this.textboxDescription.Size = new System.Drawing.Size(453, 100);
            this.textboxDescription.TabIndex = 9;
            this.textboxDescription.Text = "";
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "address", true));
            this.textBoxAddress.Location = new System.Drawing.Point(91, 56);
            this.textBoxAddress.Multiline = true;
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(369, 36);
            this.textBoxAddress.TabIndex = 3;
            this.textBoxAddress.Validated += new System.EventHandler(this.generic_Validated);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "eMail", true));
            this.textBoxEmail.Location = new System.Drawing.Point(91, 124);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(453, 20);
            this.textBoxEmail.TabIndex = 7;
            // 
            // textBoxGPSLocation
            // 
            this.textBoxGPSLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGPSLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "GPSLocation", true));
            this.textBoxGPSLocation.Location = new System.Drawing.Point(90, 150);
            this.textBoxGPSLocation.Name = "textBoxGPSLocation";
            this.textBoxGPSLocation.ReadOnly = true;
            this.textBoxGPSLocation.Size = new System.Drawing.Size(453, 20);
            this.textBoxGPSLocation.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Address";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 153);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "GPS-location";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "eMail";
            // 
            // panel2
            // 
            this.panel2.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.panel2.Controls.Add(this.mapTabControl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 383);
            this.panel2.TabIndex = 1;
            // 
            // mapTabControl
            // 
            this.mapTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapTabControl.Controls.Add(this.localMap);
            this.mapTabControl.Controls.Add(this.fromMap);
            this.mapTabControl.Controls.Add(this.toMap);
            this.mapTabControl.Location = new System.Drawing.Point(-1, 3);
            this.mapTabControl.Name = "mapTabControl";
            this.mapTabControl.SelectedIndex = 0;
            this.mapTabControl.Size = new System.Drawing.Size(551, 385);
            this.mapTabControl.TabIndex = 10;
            // 
            // localMap
            // 
            this.localMap.Controls.Add(this.pictureBoxLocalMap);
            this.localMap.Location = new System.Drawing.Point(4, 22);
            this.localMap.Name = "localMap";
            this.localMap.Padding = new System.Windows.Forms.Padding(3);
            this.localMap.Size = new System.Drawing.Size(543, 359);
            this.localMap.TabIndex = 0;
            this.localMap.Text = "Local map";
            this.localMap.UseVisualStyleBackColor = true;
            // 
            // buttonVerifyAdress
            // 
            this.buttonVerifyAdress.Location = new System.Drawing.Point(467, 56);
            this.buttonVerifyAdress.Name = "buttonVerifyAdress";
            this.buttonVerifyAdress.Size = new System.Drawing.Size(77, 36);
            this.buttonVerifyAdress.TabIndex = 4;
            this.buttonVerifyAdress.Text = "Verify Address";
            this.buttonVerifyAdress.UseVisualStyleBackColor = true;
            this.buttonVerifyAdress.Click += new System.EventHandler(this.buttonVerifyAdress_Click);
            // 
            // pictureBoxLocalMap
            // 
            this.pictureBoxLocalMap.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.eventBindingSource, "map", true));
            this.pictureBoxLocalMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLocalMap.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLocalMap.Name = "pictureBoxLocalMap";
            this.pictureBoxLocalMap.Size = new System.Drawing.Size(537, 353);
            this.pictureBoxLocalMap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLocalMap.TabIndex = 9;
            this.pictureBoxLocalMap.TabStop = false;
            // 
            // fromMap
            // 
            this.fromMap.Controls.Add(this.distanceLabelFrom);
            this.fromMap.Controls.Add(this.pictureBoxTransferFrom);
            this.fromMap.Location = new System.Drawing.Point(4, 22);
            this.fromMap.Name = "fromMap";
            this.fromMap.Padding = new System.Windows.Forms.Padding(3);
            this.fromMap.Size = new System.Drawing.Size(543, 359);
            this.fromMap.TabIndex = 1;
            this.fromMap.Text = "Transfer from previous";
            this.fromMap.UseVisualStyleBackColor = true;
            // 
            // distanceLabelFrom
            // 
            this.distanceLabelFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.distanceLabelFrom.AutoSize = true;
            this.distanceLabelFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distanceLabelFrom.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "transferFrom.metrics", true));
            this.distanceLabelFrom.Location = new System.Drawing.Point(6, 341);
            this.distanceLabelFrom.Name = "distanceLabelFrom";
            this.distanceLabelFrom.Size = new System.Drawing.Size(26, 15);
            this.distanceLabelFrom.TabIndex = 4;
            this.distanceLabelFrom.Text = " km";
            // 
            // pictureBoxTransferFrom
            // 
            this.pictureBoxTransferFrom.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.eventBindingSource, "transferFrom.map", true));
            this.pictureBoxTransferFrom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTransferFrom.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxTransferFrom.Name = "pictureBoxTransferFrom";
            this.pictureBoxTransferFrom.Size = new System.Drawing.Size(537, 353);
            this.pictureBoxTransferFrom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTransferFrom.TabIndex = 1;
            this.pictureBoxTransferFrom.TabStop = false;
            // 
            // toMap
            // 
            this.toMap.Controls.Add(this.distanceLabelTo);
            this.toMap.Controls.Add(this.pictureBoxTransFerTo);
            this.toMap.Location = new System.Drawing.Point(4, 22);
            this.toMap.Name = "toMap";
            this.toMap.Padding = new System.Windows.Forms.Padding(3);
            this.toMap.Size = new System.Drawing.Size(543, 359);
            this.toMap.TabIndex = 2;
            this.toMap.Text = "Transfer to next";
            this.toMap.UseVisualStyleBackColor = true;
            // 
            // distanceLabelTo
            // 
            this.distanceLabelTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.distanceLabelTo.AutoSize = true;
            this.distanceLabelTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.distanceLabelTo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "transferTo.metrics", true));
            this.distanceLabelTo.Location = new System.Drawing.Point(7, 340);
            this.distanceLabelTo.Name = "distanceLabelTo";
            this.distanceLabelTo.Size = new System.Drawing.Size(26, 15);
            this.distanceLabelTo.TabIndex = 3;
            this.distanceLabelTo.Text = " km";
            // 
            // pictureBoxTransFerTo
            // 
            this.pictureBoxTransFerTo.DataBindings.Add(new System.Windows.Forms.Binding("Image", this.eventBindingSource, "transferTo.map", true));
            this.pictureBoxTransFerTo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxTransFerTo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxTransFerTo.Name = "pictureBoxTransFerTo";
            this.pictureBoxTransFerTo.Size = new System.Drawing.Size(537, 353);
            this.pictureBoxTransFerTo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxTransFerTo.TabIndex = 2;
            this.pictureBoxTransFerTo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Calender";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Members";
            // 
            // dataGridViewMembers
            // 
            this.dataGridViewMembers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridViewMembers.AutoGenerateColumns = false;
            this.dataGridViewMembers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMembers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn});
            this.dataGridViewMembers.DataSource = this.membersBindingSource1;
            this.dataGridViewMembers.Location = new System.Drawing.Point(6, 98);
            this.dataGridViewMembers.Name = "dataGridViewMembers";
            this.dataGridViewMembers.Size = new System.Drawing.Size(452, 633);
            this.dataGridViewMembers.TabIndex = 3;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            // 
            // membersBindingSource1
            // 
            this.membersBindingSource1.DataMember = "members";
            this.membersBindingSource1.DataSource = this.tripBindingSource;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tripBindingSource, "startDate", true));
            this.dateTimePicker1.Location = new System.Drawing.Point(94, 30);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Start date";
            // 
            // textBoxNumberOfDays
            // 
            this.textBoxNumberOfDays.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tripBindingSource, "numberOfDays", true));
            this.textBoxNumberOfDays.Location = new System.Drawing.Point(94, 56);
            this.textBoxNumberOfDays.Name = "textBoxNumberOfDays";
            this.textBoxNumberOfDays.Size = new System.Drawing.Size(100, 20);
            this.textBoxNumberOfDays.TabIndex = 2;
            this.textBoxNumberOfDays.Validated += new System.EventHandler(this.textBoxNumberOfDays_Validated);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "# of days";
            // 
            // toolStripButtonOpen
            // 
            this.toolStripButtonOpen.AutoSize = false;
            this.toolStripButtonOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonOpen.Image")));
            this.toolStripButtonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonOpen.Name = "toolStripButtonOpen";
            this.toolStripButtonOpen.Size = new System.Drawing.Size(47, 47);
            this.toolStripButtonOpen.Text = "Open";
            this.toolStripButtonOpen.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripButtonSave
            // 
            this.toolStripButtonSave.AutoSize = false;
            this.toolStripButtonSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSave.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSave.Image")));
            this.toolStripButtonSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSave.Name = "toolStripButtonSave";
            this.toolStripButtonSave.Size = new System.Drawing.Size(47, 47);
            this.toolStripButtonSave.Text = "Save";
            this.toolStripButtonSave.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonOpen,
            this.toolStripButtonSave,
            this.toolStripButtonSaveAs,
            this.toolStripButtonCalculate});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1577, 50);
            this.toolStrip.TabIndex = 3;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.AutoSize = false;
            this.toolStripButtonSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveAs.Image")));
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(47, 47);
            this.toolStripButtonSaveAs.Text = "Save As";
            this.toolStripButtonSaveAs.Click += new System.EventHandler(this.toolStripButtonSaveAs_Click);
            // 
            // toolStripButtonCalculate
            // 
            this.toolStripButtonCalculate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCalculate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCalculate.Image")));
            this.toolStripButtonCalculate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCalculate.Name = "toolStripButtonCalculate";
            this.toolStripButtonCalculate.Size = new System.Drawing.Size(60, 47);
            this.toolStripButtonCalculate.Text = "Calculate";
            this.toolStripButtonCalculate.ToolTipText = "Calculate driving distances and times";
            this.toolStripButtonCalculate.Click += new System.EventHandler(this.toolStripButtonCalculate_Click);
            // 
            // membersBindingSource
            // 
            this.membersBindingSource.DataMember = "Members";
            this.membersBindingSource.DataSource = this.tripBindingSource;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1577, 806);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip);
            this.Name = "MainForm";
            this.Text = "Winetrip";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tripBindingSource)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.calenderPanel.ResumeLayout(false);
            this.detailsPanel.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            this.panel2.ResumeLayout(false);
            this.mapTabControl.ResumeLayout(false);
            this.localMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLocalMap)).EndInit();
            this.fromMap.ResumeLayout(false);
            this.fromMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransferFrom)).EndInit();
            this.toMap.ResumeLayout(false);
            this.toMap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTransFerTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMembers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource1)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.membersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.BindingSource tripBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNumberOfDays;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridViewMembers;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource membersBindingSource;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButtonOpen;
        private System.Windows.Forms.ToolStripButton toolStripButtonSave;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TextBox textBoxGPSLocation;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox textboxDescription;
        private System.Windows.Forms.TableLayoutPanel calenderPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl calenderTabControl;
        private System.Windows.Forms.Panel detailsPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textboxDuration;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonVerifyAdress;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pictureBoxLocalMap;
        private System.Windows.Forms.TabControl mapTabControl;
        private System.Windows.Forms.TabPage localMap;
        private System.Windows.Forms.TabPage fromMap;
        private System.Windows.Forms.PictureBox pictureBoxTransferFrom;
        private System.Windows.Forms.TabPage toMap;
        private System.Windows.Forms.PictureBox pictureBoxTransFerTo;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonCalculate;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.BindingSource membersBindingSource1;
        private System.Windows.Forms.Label distanceLabelTo;
        private System.Windows.Forms.Label distanceLabelFrom;
        private System.Windows.Forms.TextBox textBoxWebSite;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonVisitWebSite;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        private System.Windows.Forms.Button buttonBottleOrder;
    }
}

