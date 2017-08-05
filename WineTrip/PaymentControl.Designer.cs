namespace WineTrip
{
    partial class PaymentControl
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
            this.components = new System.ComponentModel.Container();
            this.buttonMember = new System.Windows.Forms.Button();
            this.textBoxAmount = new System.Windows.Forms.TextBox();
            this.paymentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.paymentsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonMember
            // 
            this.buttonMember.Location = new System.Drawing.Point(0, 0);
            this.buttonMember.Name = "buttonMember";
            this.buttonMember.Size = new System.Drawing.Size(137, 43);
            this.buttonMember.TabIndex = 0;
            this.buttonMember.UseVisualStyleBackColor = true;
            this.buttonMember.Click += new System.EventHandler(this.buttonMember_Click);
            // 
            // textBoxAmount
            // 
            this.textBoxAmount.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.paymentsBindingSource, "amount", true));
            this.textBoxAmount.Location = new System.Drawing.Point(143, 12);
            this.textBoxAmount.Name = "textBoxAmount";
            this.textBoxAmount.Size = new System.Drawing.Size(100, 20);
            this.textBoxAmount.TabIndex = 1;
            // 
            // paymentsBindingSource
            // 
            this.paymentsBindingSource.DataSource = typeof(WineTrip.DataModel.Payment);
            // 
            // PaymentControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxAmount);
            this.Controls.Add(this.buttonMember);
            this.Name = "PaymentControl";
            this.Size = new System.Drawing.Size(248, 43);
            ((System.ComponentModel.ISupportInitialize)(this.paymentsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonMember;
        private System.Windows.Forms.TextBox textBoxAmount;
        private System.Windows.Forms.BindingSource paymentsBindingSource;
    }
}
