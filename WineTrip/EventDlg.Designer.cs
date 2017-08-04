namespace WineTrip
{
    partial class EventDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.startTime = new System.Windows.Forms.TextBox();
            this.eventBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.description = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.duration = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.adress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.email = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gpsLocation = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Start time";
            // 
            // startTime
            // 
            this.startTime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "startString", true));
            this.startTime.Location = new System.Drawing.Point(102, 10);
            this.startTime.Name = "startTime";
            this.startTime.Size = new System.Drawing.Size(100, 20);
            this.startTime.TabIndex = 1;
            this.startTime.Validating += new System.ComponentModel.CancelEventHandler(this.startTime_Validating);
            // 
            // eventBindingSource
            // 
            this.eventBindingSource.DataSource = typeof(WineTrip.DataModel.Event);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";
            // 
            // name
            // 
            this.name.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "name", true));
            this.name.Location = new System.Drawing.Point(102, 37);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(455, 20);
            this.name.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description";
            // 
            // description
            // 
            this.description.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "description", true));
            this.description.Location = new System.Drawing.Point(102, 64);
            this.description.Name = "description";
            this.description.Size = new System.Drawing.Size(455, 227);
            this.description.TabIndex = 8;
            this.description.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(222, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Duration";
            // 
            // duration
            // 
            this.duration.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "duration", true));
            this.duration.Location = new System.Drawing.Point(289, 10);
            this.duration.Name = "duration";
            this.duration.Size = new System.Drawing.Size(100, 20);
            this.duration.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Address";
            // 
            // adress
            // 
            this.adress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "address", true));
            this.adress.Location = new System.Drawing.Point(102, 298);
            this.adress.Multiline = true;
            this.adress.Name = "adress";
            this.adress.Size = new System.Drawing.Size(455, 112);
            this.adress.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 420);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "eMail";
            // 
            // email
            // 
            this.email.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "eMail", true));
            this.email.Location = new System.Drawing.Point(102, 417);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(455, 20);
            this.email.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 447);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "GPS Location";
            // 
            // gpsLocation
            // 
            this.gpsLocation.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.eventBindingSource, "GPSLocation", true));
            this.gpsLocation.Location = new System.Drawing.Point(102, 444);
            this.gpsLocation.Name = "gpsLocation";
            this.gpsLocation.Size = new System.Drawing.Size(455, 20);
            this.gpsLocation.TabIndex = 14;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(401, 493);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 15;
            this.OKButton.Text = "&OK";
            this.OKButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(482, 493);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 16;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // EventDlg
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(569, 528);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.gpsLocation);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.adress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.duration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.description);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.startTime);
            this.Controls.Add(this.label1);
            this.Name = "EventDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create an Event";
            ((System.ComponentModel.ISupportInitialize)(this.eventBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startTime;
        private System.Windows.Forms.BindingSource eventBindingSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox duration;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox adress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox gpsLocation;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ErrorProvider errorProvider;
    }
}