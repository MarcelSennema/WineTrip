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
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonShowPrice,
            this.toolStripButtonCreatePDF,
            this.toolStripButtonPayments});
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
            this.gridPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridPanel.Location = new System.Drawing.Point(0, 50);
            this.gridPanel.Name = "gridPanel";
            this.gridPanel.Size = new System.Drawing.Size(1324, 750);
            this.gridPanel.TabIndex = 2;
            this.gridPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.gridPanel_Paint);
            this.gridPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseClick);
            this.gridPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gridPanel_MouseDown);
            this.gridPanel.Resize += new System.EventHandler(this.gridPanel_Resize);
            // 
            // BottleOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1324, 800);
            this.Controls.Add(this.gridPanel);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BottleOrderForm";
            this.Text = "BottleOrderForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonShowPrice;
        private System.Windows.Forms.ToolStripButton toolStripButtonCreatePDF;
        private System.Windows.Forms.ToolStripButton toolStripButtonPayments;
        private System.Windows.Forms.Panel gridPanel;
    }
}