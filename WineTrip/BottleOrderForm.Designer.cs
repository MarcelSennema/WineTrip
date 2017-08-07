namespace WineTrip
{
    partial class BottleOrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BottleOrderForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonShowPrice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCreatePDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPayments = new System.Windows.Forms.ToolStripButton();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.bodyPanel = new System.Windows.Forms.Panel();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.buttonAddBottle = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.topPanel.SuspendLayout();
            this.bodyPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonCreatePDF,
            this.toolStripButtonPayments,
            this.toolStripButtonShowPrice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1324, 50);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonShowPrice
            // 
            this.toolStripButtonShowPrice.AutoSize = false;
            this.toolStripButtonShowPrice.Checked = true;
            this.toolStripButtonShowPrice.CheckOnClick = true;
            this.toolStripButtonShowPrice.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonShowPrice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonShowPrice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShowPrice.Image")));
            this.toolStripButtonShowPrice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShowPrice.Name = "toolStripButtonShowPrice";
            this.toolStripButtonShowPrice.Size = new System.Drawing.Size(98, 47);
            this.toolStripButtonShowPrice.Text = "Show Price";
            this.toolStripButtonShowPrice.ToolTipText = "Show price";
            this.toolStripButtonShowPrice.Click += new System.EventHandler(this.toolStripButtonShowPrice_Click);
            // 
            // toolStripButtonCreatePDF
            // 
            this.toolStripButtonCreatePDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCreatePDF.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCreatePDF.Image")));
            this.toolStripButtonCreatePDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreatePDF.Name = "toolStripButtonCreatePDF";
            this.toolStripButtonCreatePDF.Size = new System.Drawing.Size(69, 47);
            this.toolStripButtonCreatePDF.Text = "Create PDF";
            // 
            // toolStripButtonPayments
            // 
            this.toolStripButtonPayments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPayments.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPayments.Image")));
            this.toolStripButtonPayments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPayments.Name = "toolStripButtonPayments";
            this.toolStripButtonPayments.Size = new System.Drawing.Size(63, 47);
            this.toolStripButtonPayments.Text = "Payments";
            // 
            // gridPanel
            // 
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridPanel.Location = new System.Drawing.Point(0, 0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(1307, 703);
            this.gridPanel.TabIndex = 2;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            this.gridPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseClick);
            this.gridPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseDown);
            this.gridPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseMove);
            this.gridPanel.Resize += new System.EventHandler(this.gridPanel_Resize);
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.buttonAddBottle);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Location = new System.Drawing.Point(0, 50);
            this.topPanel.Name = "topPanel";
            this.topPanel.Size = new System.Drawing.Size(1324, 48);
            this.topPanel.TabIndex = 0;
            this.topPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.topPanel_Paint);
            // 
            // bodyPanel
            // 
            this.bodyPanel.AutoScroll = true;
            this.bodyPanel.Controls.Add(this.gridPanel);
            this.bodyPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyPanel.Location = new System.Drawing.Point(0, 98);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(1324, 649);
            this.bodyPanel.TabIndex = 0;
            // 
            // bottomPanel
            // 
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 747);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1324, 53);
            this.bottomPanel.TabIndex = 0;
            this.bottomPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bottomPanel_Paint);
            // 
            // buttonAddBottle
            // 
            this.buttonAddBottle.Location = new System.Drawing.Point(9, 3);
            this.buttonAddBottle.Name = "buttonAddBottle";
            this.buttonAddBottle.Size = new System.Drawing.Size(99, 42);
            this.buttonAddBottle.TabIndex = 0;
            this.buttonAddBottle.Text = "Add bottle";
            this.buttonAddBottle.UseVisualStyleBackColor = true;
            this.buttonAddBottle.Click += new System.EventHandler(this.buttonAddBottle_Click);
            // 
            // BottleOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 800);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.topPanel);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "BottleOrderForm";
            this.Text = "BottleOrderForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.topPanel.ResumeLayout(false);
            this.bodyPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowPrice;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreatePDF;
        private System.Windows.Forms.ToolStripButton toolStripButtonPayments;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel bodyPanel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button buttonAddBottle;
    }
}