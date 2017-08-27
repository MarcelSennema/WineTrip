namespace WineTrip
{
    partial class BottleDetailForm
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.bottlesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.priceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.volumeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.vintageTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxSparkling = new System.Windows.Forms.CheckBox();
            this.checkBoxDesert = new System.Windows.Forms.CheckBox();
            this.radioButtonRed = new System.Windows.Forms.RadioButton();
            this.radioButtonWhite = new System.Windows.Forms.RadioButton();
            this.radioButtonRose = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxGrape = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bottlesBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // nameTextBox
            // 
            this.nameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bottlesBindingSource, "name", true));
            this.nameTextBox.Location = new System.Drawing.Point(79, 8);
            this.nameTextBox.MinimumSize = new System.Drawing.Size(4, 20);
            this.nameTextBox.Multiline = true;
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(536, 20);
            this.nameTextBox.TabIndex = 0;
            // 
            // bottlesBindingSource
            // 
            this.bottlesBindingSource.DataSource = typeof(WineTrip.DataModel.Bottle);
            // 
            // priceTextBox
            // 
            this.priceTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bottlesBindingSource, "price", true));
            this.priceTextBox.Location = new System.Drawing.Point(79, 86);
            this.priceTextBox.Name = "priceTextBox";
            this.priceTextBox.Size = new System.Drawing.Size(70, 20);
            this.priceTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Price";
            // 
            // volumeTextBox
            // 
            this.volumeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bottlesBindingSource, "volume", true));
            this.volumeTextBox.Location = new System.Drawing.Point(79, 60);
            this.volumeTextBox.Name = "volumeTextBox";
            this.volumeTextBox.Size = new System.Drawing.Size(40, 20);
            this.volumeTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Volume";
            // 
            // vintageTextBox
            // 
            this.vintageTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bottlesBindingSource, "vintage", true));
            this.vintageTextBox.Location = new System.Drawing.Point(79, 34);
            this.vintageTextBox.Name = "vintageTextBox";
            this.vintageTextBox.Size = new System.Drawing.Size(40, 20);
            this.vintageTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Vintage";
            // 
            // checkBoxSparkling
            // 
            this.checkBoxSparkling.AutoSize = true;
            this.checkBoxSparkling.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bottlesBindingSource, "isSparklingWine", true));
            this.checkBoxSparkling.Location = new System.Drawing.Point(222, 140);
            this.checkBoxSparkling.Name = "checkBoxSparkling";
            this.checkBoxSparkling.Size = new System.Drawing.Size(70, 17);
            this.checkBoxSparkling.TabIndex = 8;
            this.checkBoxSparkling.Text = "Sparkling";
            this.checkBoxSparkling.UseVisualStyleBackColor = true;
            // 
            // checkBoxDesert
            // 
            this.checkBoxDesert.AutoSize = true;
            this.checkBoxDesert.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bottlesBindingSource, "isDessertWine", true));
            this.checkBoxDesert.Location = new System.Drawing.Point(312, 140);
            this.checkBoxDesert.Name = "checkBoxDesert";
            this.checkBoxDesert.Size = new System.Drawing.Size(62, 17);
            this.checkBoxDesert.TabIndex = 9;
            this.checkBoxDesert.Text = "Dessert";
            this.checkBoxDesert.UseVisualStyleBackColor = true;
            // 
            // radioButtonRed
            // 
            this.radioButtonRed.AutoSize = true;
            this.radioButtonRed.Location = new System.Drawing.Point(14, 139);
            this.radioButtonRed.Name = "radioButtonRed";
            this.radioButtonRed.Size = new System.Drawing.Size(45, 17);
            this.radioButtonRed.TabIndex = 5;
            this.radioButtonRed.TabStop = true;
            this.radioButtonRed.Text = "Red";
            this.radioButtonRed.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhite
            // 
            this.radioButtonWhite.AutoSize = true;
            this.radioButtonWhite.Location = new System.Drawing.Point(79, 139);
            this.radioButtonWhite.Name = "radioButtonWhite";
            this.radioButtonWhite.Size = new System.Drawing.Size(53, 17);
            this.radioButtonWhite.TabIndex = 6;
            this.radioButtonWhite.TabStop = true;
            this.radioButtonWhite.Text = "White";
            this.radioButtonWhite.UseVisualStyleBackColor = true;
            // 
            // radioButtonRose
            // 
            this.radioButtonRose.AutoSize = true;
            this.radioButtonRose.Location = new System.Drawing.Point(152, 139);
            this.radioButtonRose.Name = "radioButtonRose";
            this.radioButtonRose.Size = new System.Drawing.Size(50, 17);
            this.radioButtonRose.TabIndex = 7;
            this.radioButtonRose.TabStop = true;
            this.radioButtonRose.Text = "Rose";
            this.radioButtonRose.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bottlesBindingSource, "notitie", true));
            this.textBox1.Location = new System.Drawing.Point(12, 163);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(603, 179);
            this.textBox1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 116);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Grape";
            // 
            // textBoxGrape
            // 
            this.textBoxGrape.AutoCompleteCustomSource.AddRange(new string[] {
            "Chardonnay",
            "Pinot blanc",
            "Pinot noir"});
            this.textBoxGrape.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.textBoxGrape.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBoxGrape.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bottlesBindingSource, "grape", true));
            this.textBoxGrape.Location = new System.Drawing.Point(79, 113);
            this.textBoxGrape.Name = "textBoxGrape";
            this.textBoxGrape.Size = new System.Drawing.Size(247, 20);
            this.textBoxGrape.TabIndex = 4;
            // 
            // BottleDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Beige;
            this.ClientSize = new System.Drawing.Size(627, 354);
            this.Controls.Add(this.textBoxGrape);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.radioButtonRose);
            this.Controls.Add(this.radioButtonWhite);
            this.Controls.Add(this.radioButtonRed);
            this.Controls.Add(this.checkBoxDesert);
            this.Controls.Add(this.checkBoxSparkling);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.priceTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.volumeTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.vintageTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BottleDetailForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Wine description";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BottleDetailForm_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.bottlesBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox priceTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox volumeTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vintageTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource bottlesBindingSource;
        private System.Windows.Forms.CheckBox checkBoxSparkling;
        private System.Windows.Forms.CheckBox checkBoxDesert;
        private System.Windows.Forms.RadioButton radioButtonRed;
        private System.Windows.Forms.RadioButton radioButtonWhite;
        private System.Windows.Forms.RadioButton radioButtonRose;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxGrape;
    }
}