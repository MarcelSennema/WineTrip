namespace WineTrip
{
    partial class MemberGridControl
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
            this.panelMember = new System.Windows.Forms.Panel();
            this.buttonAddMember = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panelMember
            // 
            this.panelMember.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMember.Location = new System.Drawing.Point(3, 51);
            this.panelMember.Name = "panelMember";
            this.panelMember.Size = new System.Drawing.Size(422, 353);
            this.panelMember.TabIndex = 1;
            this.panelMember.Paint += new System.Windows.Forms.PaintEventHandler(this.panelMember_Paint);
            this.panelMember.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelMember_MouseClick);
            // 
            // buttonAddMember
            // 
            this.buttonAddMember.Location = new System.Drawing.Point(3, 3);
            this.buttonAddMember.Name = "buttonAddMember";
            this.buttonAddMember.Size = new System.Drawing.Size(99, 42);
            this.buttonAddMember.TabIndex = 15;
            this.buttonAddMember.Text = "Add member";
            this.buttonAddMember.UseVisualStyleBackColor = true;
            this.buttonAddMember.Click += new System.EventHandler(this.buttonAddMember_Click);
            // 
            // MemberGridControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.buttonAddMember);
            this.Controls.Add(this.panelMember);
            this.Name = "MemberGridControl";
            this.Size = new System.Drawing.Size(445, 461);
            this.Resize += new System.EventHandler(this.MemberGridControl_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMember;
        private System.Windows.Forms.Button buttonAddMember;
    }
}
