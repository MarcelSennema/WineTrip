namespace WineTrip
{
    partial class OrderForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderForm));
            this.rowHeaderSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rowHeaderLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.splitContainerColumnHeader = new System.Windows.Forms.SplitContainer();
            this.columnHeaderLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.columnHeaderFillerPanel = new System.Windows.Forms.Panel();
            this.bodySplitContainer = new System.Windows.Forms.SplitContainer();
            this.columnFooterLayoutPanel = new System.Windows.Forms.Panel();
            this.columnFooterFillerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonShowPrice = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonCreatePDF = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPayments = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.rowHeaderSplitContainer)).BeginInit();
            this.rowHeaderSplitContainer.Panel1.SuspendLayout();
            this.rowHeaderSplitContainer.Panel2.SuspendLayout();
            this.rowHeaderSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerColumnHeader)).BeginInit();
            this.splitContainerColumnHeader.Panel1.SuspendLayout();
            this.splitContainerColumnHeader.Panel2.SuspendLayout();
            this.splitContainerColumnHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodySplitContainer)).BeginInit();
            this.bodySplitContainer.Panel1.SuspendLayout();
            this.bodySplitContainer.Panel2.SuspendLayout();
            this.bodySplitContainer.SuspendLayout();
            this.columnFooterFillerPanel.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rowHeaderSplitContainer
            // 
            this.rowHeaderSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowHeaderSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.rowHeaderSplitContainer.Name = "rowHeaderSplitContainer";
            // 
            // rowHeaderSplitContainer.Panel1
            // 
            this.rowHeaderSplitContainer.Panel1.Controls.Add(this.rowHeaderLayoutPanel);
            // 
            // rowHeaderSplitContainer.Panel2
            // 
            this.rowHeaderSplitContainer.Panel2.Controls.Add(this.gridPanel);
            this.rowHeaderSplitContainer.Size = new System.Drawing.Size(1331, 575);
            this.rowHeaderSplitContainer.SplitterDistance = 377;
            this.rowHeaderSplitContainer.TabIndex = 0;
            // 
            // rowHeaderLayoutPanel
            // 
            this.rowHeaderLayoutPanel.AutoScroll = true;
            this.rowHeaderLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.rowHeaderLayoutPanel.ColumnCount = 1;
            this.rowHeaderLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rowHeaderLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rowHeaderLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.rowHeaderLayoutPanel.Name = "rowHeaderLayoutPanel";
            this.rowHeaderLayoutPanel.RowCount = 1;
            this.rowHeaderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rowHeaderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.rowHeaderLayoutPanel.Size = new System.Drawing.Size(377, 575);
            this.rowHeaderLayoutPanel.TabIndex = 2;
            this.rowHeaderLayoutPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.rowHeaderLayoutPanel_Scroll);
            this.rowHeaderLayoutPanel.Resize += new System.EventHandler(this.bottleLayoutPanel_Resize);
            // 
            // gridPanel
            // 
            this.gridPanel.BackColor = System.Drawing.Color.LightYellow;
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 0);
            this.gridPanel.Margin = new System.Windows.Forms.Padding(0);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(950, 575);
            this.gridPanel.TabIndex = 0;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            this.gridPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseClick);
            // 
            // splitContainerColumnHeader
            // 
            this.splitContainerColumnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerColumnHeader.Location = new System.Drawing.Point(0, 50);
            this.splitContainerColumnHeader.Name = "splitContainerColumnHeader";
            this.splitContainerColumnHeader.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerColumnHeader.Panel1
            // 
            this.splitContainerColumnHeader.Panel1.Controls.Add(this.columnHeaderLayoutPanel);
            this.splitContainerColumnHeader.Panel1.Controls.Add(this.columnHeaderFillerPanel);
            // 
            // splitContainerColumnHeader.Panel2
            // 
            this.splitContainerColumnHeader.Panel2.Controls.Add(this.bodySplitContainer);
            this.splitContainerColumnHeader.Size = new System.Drawing.Size(1331, 681);
            this.splitContainerColumnHeader.SplitterDistance = 47;
            this.splitContainerColumnHeader.TabIndex = 0;
            // 
            // columnHeaderLayoutPanel
            // 
            this.columnHeaderLayoutPanel.ColumnCount = 1;
            this.columnHeaderLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.columnHeaderLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnHeaderLayoutPanel.Location = new System.Drawing.Point(389, 0);
            this.columnHeaderLayoutPanel.Name = "columnHeaderLayoutPanel";
            this.columnHeaderLayoutPanel.RowCount = 1;
            this.columnHeaderLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.columnHeaderLayoutPanel.Size = new System.Drawing.Size(942, 47);
            this.columnHeaderLayoutPanel.TabIndex = 1;
            // 
            // columnHeaderFillerPanel
            // 
            this.columnHeaderFillerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.columnHeaderFillerPanel.Location = new System.Drawing.Point(0, 0);
            this.columnHeaderFillerPanel.Name = "columnHeaderFillerPanel";
            this.columnHeaderFillerPanel.Size = new System.Drawing.Size(389, 47);
            this.columnHeaderFillerPanel.TabIndex = 0;
            // 
            // bodySplitContainer
            // 
            this.bodySplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodySplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.bodySplitContainer.Location = new System.Drawing.Point(0, 0);
            this.bodySplitContainer.Name = "bodySplitContainer";
            this.bodySplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bodySplitContainer.Panel1
            // 
            this.bodySplitContainer.Panel1.Controls.Add(this.rowHeaderSplitContainer);
            // 
            // bodySplitContainer.Panel2
            // 
            this.bodySplitContainer.Panel2.Controls.Add(this.columnFooterLayoutPanel);
            this.bodySplitContainer.Panel2.Controls.Add(this.columnFooterFillerPanel);
            this.bodySplitContainer.Size = new System.Drawing.Size(1331, 630);
            this.bodySplitContainer.SplitterDistance = 575;
            this.bodySplitContainer.TabIndex = 0;
            // 
            // columnFooterLayoutPanel
            // 
            this.columnFooterLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.columnFooterLayoutPanel.Location = new System.Drawing.Point(389, 0);
            this.columnFooterLayoutPanel.Name = "columnFooterLayoutPanel";
            this.columnFooterLayoutPanel.Size = new System.Drawing.Size(942, 51);
            this.columnFooterLayoutPanel.TabIndex = 2;
            this.columnFooterLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.columnFooterLayoutPanel_Paint);
            // 
            // columnFooterFillerPanel
            // 
            this.columnFooterFillerPanel.Controls.Add(this.label1);
            this.columnFooterFillerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.columnFooterFillerPanel.Location = new System.Drawing.Point(0, 0);
            this.columnFooterFillerPanel.Name = "columnFooterFillerPanel";
            this.columnFooterFillerPanel.Size = new System.Drawing.Size(389, 51);
            this.columnFooterFillerPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonShowPrice,
            this.toolStripButtonCreatePDF,
            this.toolStripButtonPayments});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1331, 50);
            this.toolStrip1.TabIndex = 0;
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
            this.toolStripButtonShowPrice.Click += new System.EventHandler(this.showPriceCheckBox_CheckedChanged);
            // 
            // toolStripButtonCreatePDF
            // 
            this.toolStripButtonCreatePDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonCreatePDF.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonCreatePDF.Image")));
            this.toolStripButtonCreatePDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonCreatePDF.Name = "toolStripButtonCreatePDF";
            this.toolStripButtonCreatePDF.Size = new System.Drawing.Size(69, 47);
            this.toolStripButtonCreatePDF.Text = "Create PDF";
            this.toolStripButtonCreatePDF.Click += new System.EventHandler(this.buttonCreatePDF_Click);
            // 
            // toolStripButtonPayments
            // 
            this.toolStripButtonPayments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPayments.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPayments.Image")));
            this.toolStripButtonPayments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPayments.Name = "toolStripButtonPayments";
            this.toolStripButtonPayments.Size = new System.Drawing.Size(63, 47);
            this.toolStripButtonPayments.Text = "Payments";
            this.toolStripButtonPayments.Click += new System.EventHandler(this.buttonPayments_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 731);
            this.Controls.Add(this.splitContainerColumnHeader);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.Name = "OrderForm";
            this.Text = "Order";
            this.Shown += new System.EventHandler(this.OrderForm_Shown);
            this.rowHeaderSplitContainer.Panel1.ResumeLayout(false);
            this.rowHeaderSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rowHeaderSplitContainer)).EndInit();
            this.rowHeaderSplitContainer.ResumeLayout(false);
            this.splitContainerColumnHeader.Panel1.ResumeLayout(false);
            this.splitContainerColumnHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerColumnHeader)).EndInit();
            this.splitContainerColumnHeader.ResumeLayout(false);
            this.bodySplitContainer.Panel1.ResumeLayout(false);
            this.bodySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bodySplitContainer)).EndInit();
            this.bodySplitContainer.ResumeLayout(false);
            this.columnFooterFillerPanel.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer rowHeaderSplitContainer;
        private System.Windows.Forms.TableLayoutPanel rowHeaderLayoutPanel;
        private System.Windows.Forms.SplitContainer splitContainerColumnHeader;
        private System.Windows.Forms.Panel columnHeaderFillerPanel;
        private System.Windows.Forms.TableLayoutPanel columnHeaderLayoutPanel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.SplitContainer bodySplitContainer;
        private System.Windows.Forms.Panel columnFooterLayoutPanel;
        private System.Windows.Forms.Panel columnFooterFillerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowPrice;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreatePDF;
        private System.Windows.Forms.ToolStripButton toolStripButtonPayments;
    }
}