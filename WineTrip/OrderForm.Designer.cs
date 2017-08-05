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
            this.rowHeaderSplitContainer = new System.Windows.Forms.SplitContainer();
            this.rowHeaderLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.gridPanel = new System.Windows.Forms.Panel();
            this.splitContainerColumnHeader = new System.Windows.Forms.SplitContainer();
            this.columnHeaderLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.columnHeaderFillerPanel = new System.Windows.Forms.Panel();
            this.buttonCreatePDF = new System.Windows.Forms.Button();
            this.showPriceCheckBox = new System.Windows.Forms.CheckBox();
            this.bodySplitContainer = new System.Windows.Forms.SplitContainer();
            this.columnFooterLayoutPanel = new System.Windows.Forms.Panel();
            this.columnFooterFillerPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonPayments = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.rowHeaderSplitContainer)).BeginInit();
            this.rowHeaderSplitContainer.Panel1.SuspendLayout();
            this.rowHeaderSplitContainer.Panel2.SuspendLayout();
            this.rowHeaderSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerColumnHeader)).BeginInit();
            this.splitContainerColumnHeader.Panel1.SuspendLayout();
            this.splitContainerColumnHeader.Panel2.SuspendLayout();
            this.splitContainerColumnHeader.SuspendLayout();
            this.columnHeaderFillerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodySplitContainer)).BeginInit();
            this.bodySplitContainer.Panel1.SuspendLayout();
            this.bodySplitContainer.Panel2.SuspendLayout();
            this.bodySplitContainer.SuspendLayout();
            this.columnFooterFillerPanel.SuspendLayout();
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
            this.rowHeaderSplitContainer.Size = new System.Drawing.Size(1331, 621);
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
            this.rowHeaderLayoutPanel.Size = new System.Drawing.Size(377, 621);
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
            this.gridPanel.Size = new System.Drawing.Size(950, 621);
            this.gridPanel.TabIndex = 0;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            this.gridPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseClick);
            // 
            // splitContainerColumnHeader
            // 
            this.splitContainerColumnHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerColumnHeader.Location = new System.Drawing.Point(0, 0);
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
            this.splitContainerColumnHeader.Size = new System.Drawing.Size(1331, 731);
            this.splitContainerColumnHeader.SplitterDistance = 51;
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
            this.columnHeaderLayoutPanel.Size = new System.Drawing.Size(942, 51);
            this.columnHeaderLayoutPanel.TabIndex = 1;
            // 
            // columnHeaderFillerPanel
            // 
            this.columnHeaderFillerPanel.Controls.Add(this.buttonPayments);
            this.columnHeaderFillerPanel.Controls.Add(this.buttonCreatePDF);
            this.columnHeaderFillerPanel.Controls.Add(this.showPriceCheckBox);
            this.columnHeaderFillerPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.columnHeaderFillerPanel.Location = new System.Drawing.Point(0, 0);
            this.columnHeaderFillerPanel.Name = "columnHeaderFillerPanel";
            this.columnHeaderFillerPanel.Size = new System.Drawing.Size(389, 51);
            this.columnHeaderFillerPanel.TabIndex = 0;
            // 
            // buttonCreatePDF
            // 
            this.buttonCreatePDF.Location = new System.Drawing.Point(99, 4);
            this.buttonCreatePDF.Name = "buttonCreatePDF";
            this.buttonCreatePDF.Size = new System.Drawing.Size(106, 47);
            this.buttonCreatePDF.TabIndex = 1;
            this.buttonCreatePDF.Text = "Create PDF";
            this.buttonCreatePDF.UseVisualStyleBackColor = true;
            this.buttonCreatePDF.Click += new System.EventHandler(this.buttonCreatePDF_Click);
            // 
            // showPriceCheckBox
            // 
            this.showPriceCheckBox.AutoSize = true;
            this.showPriceCheckBox.Checked = true;
            this.showPriceCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showPriceCheckBox.Location = new System.Drawing.Point(13, 13);
            this.showPriceCheckBox.Name = "showPriceCheckBox";
            this.showPriceCheckBox.Size = new System.Drawing.Size(79, 17);
            this.showPriceCheckBox.TabIndex = 0;
            this.showPriceCheckBox.Text = "Show price";
            this.showPriceCheckBox.UseVisualStyleBackColor = true;
            this.showPriceCheckBox.CheckedChanged += new System.EventHandler(this.showPriceCheckBox_CheckedChanged);
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
            this.bodySplitContainer.Size = new System.Drawing.Size(1331, 676);
            this.bodySplitContainer.SplitterDistance = 621;
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
            // buttonPayments
            // 
            this.buttonPayments.Location = new System.Drawing.Point(211, 4);
            this.buttonPayments.Name = "buttonPayments";
            this.buttonPayments.Size = new System.Drawing.Size(106, 47);
            this.buttonPayments.TabIndex = 2;
            this.buttonPayments.Text = "Payments";
            this.buttonPayments.UseVisualStyleBackColor = true;
            this.buttonPayments.Click += new System.EventHandler(this.buttonPayments_Click);
            // 
            // OrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1331, 731);
            this.Controls.Add(this.splitContainerColumnHeader);
            this.DoubleBuffered = true;
            this.Name = "OrderForm";
            this.Text = "Order";
            this.rowHeaderSplitContainer.Panel1.ResumeLayout(false);
            this.rowHeaderSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rowHeaderSplitContainer)).EndInit();
            this.rowHeaderSplitContainer.ResumeLayout(false);
            this.splitContainerColumnHeader.Panel1.ResumeLayout(false);
            this.splitContainerColumnHeader.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerColumnHeader)).EndInit();
            this.splitContainerColumnHeader.ResumeLayout(false);
            this.columnHeaderFillerPanel.ResumeLayout(false);
            this.columnHeaderFillerPanel.PerformLayout();
            this.bodySplitContainer.Panel1.ResumeLayout(false);
            this.bodySplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bodySplitContainer)).EndInit();
            this.bodySplitContainer.ResumeLayout(false);
            this.columnFooterFillerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer rowHeaderSplitContainer;
        private System.Windows.Forms.TableLayoutPanel rowHeaderLayoutPanel;
        private System.Windows.Forms.SplitContainer splitContainerColumnHeader;
        private System.Windows.Forms.Panel columnHeaderFillerPanel;
        private System.Windows.Forms.TableLayoutPanel columnHeaderLayoutPanel;
        private System.Windows.Forms.Panel gridPanel;
        private System.Windows.Forms.CheckBox showPriceCheckBox;
        private System.Windows.Forms.SplitContainer bodySplitContainer;
        private System.Windows.Forms.Panel columnFooterLayoutPanel;
        private System.Windows.Forms.Panel columnFooterFillerPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCreatePDF;
        private System.Windows.Forms.Button buttonPayments;
    }
}