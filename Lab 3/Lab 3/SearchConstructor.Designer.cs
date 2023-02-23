namespace Lab_3
{
    partial class SearchConstructor
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.labelPageAmount = new System.Windows.Forms.Label();
            this.textBoxPagesTo = new System.Windows.Forms.TextBox();
            this.textBoxPagesFrom = new System.Windows.Forms.TextBox();
            this.textBoxYearFrom = new System.Windows.Forms.TextBox();
            this.textBoxYearTo = new System.Windows.Forms.TextBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.checkBoxNameFullMatches = new System.Windows.Forms.CheckBox();
            this.checkBoxPublisherFullMatches = new System.Windows.Forms.CheckBox();
            this.buttonFind = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(12, 12);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PlaceholderText = "Name";
            this.textBoxName.Size = new System.Drawing.Size(177, 23);
            this.textBoxName.TabIndex = 0;
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Location = new System.Drawing.Point(12, 41);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.PlaceholderText = "Publisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(177, 23);
            this.textBoxPublisher.TabIndex = 1;
            // 
            // labelPageAmount
            // 
            this.labelPageAmount.AutoSize = true;
            this.labelPageAmount.Location = new System.Drawing.Point(12, 67);
            this.labelPageAmount.Name = "labelPageAmount";
            this.labelPageAmount.Size = new System.Drawing.Size(81, 15);
            this.labelPageAmount.TabIndex = 2;
            this.labelPageAmount.Text = "Page amount:";
            // 
            // textBoxPagesTo
            // 
            this.textBoxPagesTo.Location = new System.Drawing.Point(108, 85);
            this.textBoxPagesTo.Name = "textBoxPagesTo";
            this.textBoxPagesTo.PlaceholderText = "To";
            this.textBoxPagesTo.Size = new System.Drawing.Size(81, 23);
            this.textBoxPagesTo.TabIndex = 3;
            // 
            // textBoxPagesFrom
            // 
            this.textBoxPagesFrom.Location = new System.Drawing.Point(12, 85);
            this.textBoxPagesFrom.Name = "textBoxPagesFrom";
            this.textBoxPagesFrom.PlaceholderText = "From";
            this.textBoxPagesFrom.Size = new System.Drawing.Size(81, 23);
            this.textBoxPagesFrom.TabIndex = 4;
            // 
            // textBoxYearFrom
            // 
            this.textBoxYearFrom.Location = new System.Drawing.Point(12, 129);
            this.textBoxYearFrom.Name = "textBoxYearFrom";
            this.textBoxYearFrom.PlaceholderText = "From";
            this.textBoxYearFrom.Size = new System.Drawing.Size(81, 23);
            this.textBoxYearFrom.TabIndex = 7;
            // 
            // textBoxYearTo
            // 
            this.textBoxYearTo.Location = new System.Drawing.Point(108, 129);
            this.textBoxYearTo.Name = "textBoxYearTo";
            this.textBoxYearTo.PlaceholderText = "To";
            this.textBoxYearTo.Size = new System.Drawing.Size(81, 23);
            this.textBoxYearTo.TabIndex = 6;
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(12, 111);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(32, 15);
            this.labelYear.TabIndex = 5;
            this.labelYear.Text = "Year:";
            // 
            // checkBoxNameFullMatches
            // 
            this.checkBoxNameFullMatches.AutoSize = true;
            this.checkBoxNameFullMatches.Location = new System.Drawing.Point(195, 14);
            this.checkBoxNameFullMatches.Name = "checkBoxNameFullMatches";
            this.checkBoxNameFullMatches.Size = new System.Drawing.Size(119, 19);
            this.checkBoxNameFullMatches.TabIndex = 9;
            this.checkBoxNameFullMatches.Text = "Full matches only";
            this.checkBoxNameFullMatches.UseVisualStyleBackColor = true;
            // 
            // checkBoxPublisherFullMatches
            // 
            this.checkBoxPublisherFullMatches.AutoSize = true;
            this.checkBoxPublisherFullMatches.Location = new System.Drawing.Point(195, 43);
            this.checkBoxPublisherFullMatches.Name = "checkBoxPublisherFullMatches";
            this.checkBoxPublisherFullMatches.Size = new System.Drawing.Size(119, 19);
            this.checkBoxPublisherFullMatches.TabIndex = 10;
            this.checkBoxPublisherFullMatches.Text = "Full matches only";
            this.checkBoxPublisherFullMatches.UseVisualStyleBackColor = true;
            // 
            // buttonFind
            // 
            this.buttonFind.Location = new System.Drawing.Point(75, 166);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(177, 23);
            this.buttonFind.TabIndex = 12;
            this.buttonFind.Text = "Find";
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.Click += new System.EventHandler(this.buttonFind_Click);
            // 
            // SearchConstructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 206);
            this.Controls.Add(this.buttonFind);
            this.Controls.Add(this.checkBoxPublisherFullMatches);
            this.Controls.Add(this.checkBoxNameFullMatches);
            this.Controls.Add(this.textBoxYearFrom);
            this.Controls.Add(this.textBoxYearTo);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.textBoxPagesFrom);
            this.Controls.Add(this.textBoxPagesTo);
            this.Controls.Add(this.labelPageAmount);
            this.Controls.Add(this.textBoxPublisher);
            this.Controls.Add(this.textBoxName);
            this.Name = "SearchConstructor";
            this.Text = "Search query constructor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxName;
        private TextBox textBoxPublisher;
        private Label labelPageAmount;
        private TextBox textBoxPagesTo;
        private TextBox textBoxPagesFrom;
        private TextBox textBoxYearFrom;
        private TextBox textBoxYearTo;
        private Label labelYear;
        private CheckBox checkBoxNameFullMatches;
        private CheckBox checkBoxPublisherFullMatches;
        private Button buttonFind;
    }
}