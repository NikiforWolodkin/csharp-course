namespace Lab_2
{
    partial class Library
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.textBoxAuthorName = new System.Windows.Forms.TextBox();
            this.textBoxAuthorCountry = new System.Windows.Forms.TextBox();
            this.maskedTextBoxAuthorID = new System.Windows.Forms.MaskedTextBox();
            this.errorProviderApp = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelBook = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.groupBoxFormat = new System.Windows.Forms.GroupBox();
            this.radioButtonTXT = new System.Windows.Forms.RadioButton();
            this.radioButtonFB2 = new System.Windows.Forms.RadioButton();
            this.radioButtonPDF = new System.Windows.Forms.RadioButton();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).BeginInit();
            this.groupBoxFormat.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(218, 9);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 15);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Author";
            // 
            // textBoxAuthorName
            // 
            this.textBoxAuthorName.Location = new System.Drawing.Point(218, 27);
            this.textBoxAuthorName.Name = "textBoxAuthorName";
            this.textBoxAuthorName.PlaceholderText = "Name";
            this.textBoxAuthorName.Size = new System.Drawing.Size(100, 23);
            this.textBoxAuthorName.TabIndex = 1;
            this.textBoxAuthorName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAuthorName_Validating);
            this.textBoxAuthorName.Validated += new System.EventHandler(this.textBoxAuthorName_Validated);
            // 
            // textBoxAuthorCountry
            // 
            this.textBoxAuthorCountry.Location = new System.Drawing.Point(218, 56);
            this.textBoxAuthorCountry.Name = "textBoxAuthorCountry";
            this.textBoxAuthorCountry.PlaceholderText = "Country";
            this.textBoxAuthorCountry.Size = new System.Drawing.Size(100, 23);
            this.textBoxAuthorCountry.TabIndex = 2;
            this.textBoxAuthorCountry.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAuthorCountry_Validating);
            this.textBoxAuthorCountry.Validated += new System.EventHandler(this.textBoxAuthorCountry_Validated);
            // 
            // maskedTextBoxAuthorID
            // 
            this.maskedTextBoxAuthorID.Location = new System.Drawing.Point(218, 100);
            this.maskedTextBoxAuthorID.Mask = "0000";
            this.maskedTextBoxAuthorID.Name = "maskedTextBoxAuthorID";
            this.maskedTextBoxAuthorID.Size = new System.Drawing.Size(100, 23);
            this.maskedTextBoxAuthorID.TabIndex = 3;
            this.maskedTextBoxAuthorID.ValidatingType = typeof(int);
            this.maskedTextBoxAuthorID.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBoxAuthorID_Validating);
            this.maskedTextBoxAuthorID.Validated += new System.EventHandler(this.maskedTextBoxAuthorID_Validated);
            // 
            // errorProviderApp
            // 
            this.errorProviderApp.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProviderApp.ContainerControl = this;
            // 
            // labelBook
            // 
            this.labelBook.AutoSize = true;
            this.labelBook.Location = new System.Drawing.Point(12, 9);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(34, 15);
            this.labelBook.TabIndex = 4;
            this.labelBook.Text = "Book";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(218, 82);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(21, 15);
            this.labelID.TabIndex = 5;
            this.labelID.Text = "ID:";
            // 
            // groupBoxFormat
            // 
            this.groupBoxFormat.Controls.Add(this.radioButtonTXT);
            this.groupBoxFormat.Controls.Add(this.radioButtonFB2);
            this.groupBoxFormat.Controls.Add(this.radioButtonPDF);
            this.groupBoxFormat.Location = new System.Drawing.Point(12, 23);
            this.groupBoxFormat.Name = "groupBoxFormat";
            this.groupBoxFormat.Size = new System.Drawing.Size(200, 100);
            this.groupBoxFormat.TabIndex = 7;
            this.groupBoxFormat.TabStop = false;
            this.groupBoxFormat.Text = "groupBox1";
            this.groupBoxFormat.Leave += new System.EventHandler(this.groupBoxFormat_Leave);
            // 
            // radioButtonTXT
            // 
            this.radioButtonTXT.AutoSize = true;
            this.radioButtonTXT.Location = new System.Drawing.Point(6, 72);
            this.radioButtonTXT.Name = "radioButtonTXT";
            this.radioButtonTXT.Size = new System.Drawing.Size(44, 19);
            this.radioButtonTXT.TabIndex = 2;
            this.radioButtonTXT.Text = "TXT";
            this.radioButtonTXT.UseVisualStyleBackColor = true;
            // 
            // radioButtonFB2
            // 
            this.radioButtonFB2.AutoSize = true;
            this.radioButtonFB2.Location = new System.Drawing.Point(6, 47);
            this.radioButtonFB2.Name = "radioButtonFB2";
            this.radioButtonFB2.Size = new System.Drawing.Size(44, 19);
            this.radioButtonFB2.TabIndex = 1;
            this.radioButtonFB2.Text = "FB2";
            this.radioButtonFB2.UseVisualStyleBackColor = true;
            // 
            // radioButtonPDF
            // 
            this.radioButtonPDF.AutoSize = true;
            this.radioButtonPDF.Checked = true;
            this.radioButtonPDF.Location = new System.Drawing.Point(6, 22);
            this.radioButtonPDF.Name = "radioButtonPDF";
            this.radioButtonPDF.Size = new System.Drawing.Size(46, 19);
            this.radioButtonPDF.TabIndex = 0;
            this.radioButtonPDF.TabStop = true;
            this.radioButtonPDF.Text = "PDF";
            this.radioButtonPDF.UseVisualStyleBackColor = true;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(12, 415);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(93, 415);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(75, 23);
            this.buttonLoad.TabIndex = 9;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxFormat);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelBook);
            this.Controls.Add(this.maskedTextBoxAuthorID);
            this.Controls.Add(this.textBoxAuthorCountry);
            this.Controls.Add(this.textBoxAuthorName);
            this.Controls.Add(this.labelAuthor);
            this.Name = "Library";
            this.Text = "Library";
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).EndInit();
            this.groupBoxFormat.ResumeLayout(false);
            this.groupBoxFormat.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelAuthor;
        private TextBox textBoxAuthorName;
        private TextBox textBoxAuthorCountry;
        private MaskedTextBox maskedTextBoxAuthorID;
        private ErrorProvider errorProviderApp;
        private GroupBox groupBoxFormat;
        private RadioButton radioButtonTXT;
        private RadioButton radioButtonFB2;
        private RadioButton radioButtonPDF;
        private Label labelID;
        private Label labelBook;
        private Button buttonSave;
        private Button buttonLoad;
    }
}