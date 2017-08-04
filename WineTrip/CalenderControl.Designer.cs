namespace WineTrip
{
    partial class CalenderControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CalenderControl
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.DoubleBuffered = true;
            this.Name = "CalenderControl";
            this.Size = new System.Drawing.Size(156, 113);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CalenderControl_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CalenderControl_DragEnter);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.CalenderControl_DragOver);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CalenderControl_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CalenderControl_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.CalenderControl_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CalenderControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CalenderControl_MouseMove);
            this.Resize += new System.EventHandler(this.CalenderControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
