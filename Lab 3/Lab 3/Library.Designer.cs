namespace Lab_3
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.hScrollBarFileSize = new System.Windows.Forms.HScrollBar();
            this.labelFileSize = new System.Windows.Forms.Label();
            this.richTextBoxAuthorsAndLinks = new System.Windows.Forms.RichTextBox();
            this.labelauthorsAndLinks = new System.Windows.Forms.Label();
            this.checkBoxFree = new System.Windows.Forms.CheckBox();
            this.labelYear = new System.Windows.Forms.Label();
            this.maskedTextBoxYear = new System.Windows.Forms.MaskedTextBox();
            this.labelUDC = new System.Windows.Forms.Label();
            this.textBoxUDC = new System.Windows.Forms.TextBox();
            this.textBoxPublisher = new System.Windows.Forms.TextBox();
            this.textBoxPages = new System.Windows.Forms.TextBox();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.labelUploadDate = new System.Windows.Forms.Label();
            this.numericUpDownChapters = new System.Windows.Forms.NumericUpDown();
            this.labelChapters = new System.Windows.Forms.Label();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItemSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.byPublisherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byYearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byPageAmountToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchQueryConstructorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.byUploadDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSearchResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelBooks = new System.Windows.Forms.Label();
            this.listBoxBooks = new System.Windows.Forms.ListBox();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.upToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.downToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.clearToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.deleteToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.hideToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.buttonShowToolStrip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).BeginInit();
            this.groupBoxFormat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChapters)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Location = new System.Drawing.Point(434, 24);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(44, 15);
            this.labelAuthor.TabIndex = 0;
            this.labelAuthor.Text = "Author";
            // 
            // textBoxAuthorName
            // 
            this.textBoxAuthorName.Location = new System.Drawing.Point(434, 42);
            this.textBoxAuthorName.Name = "textBoxAuthorName";
            this.textBoxAuthorName.PlaceholderText = "Name";
            this.textBoxAuthorName.Size = new System.Drawing.Size(200, 23);
            this.textBoxAuthorName.TabIndex = 1;
            this.textBoxAuthorName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAuthorName_Validating);
            this.textBoxAuthorName.Validated += new System.EventHandler(this.textBoxAuthorName_Validated);
            // 
            // textBoxAuthorCountry
            // 
            this.textBoxAuthorCountry.Location = new System.Drawing.Point(434, 71);
            this.textBoxAuthorCountry.Name = "textBoxAuthorCountry";
            this.textBoxAuthorCountry.PlaceholderText = "Country";
            this.textBoxAuthorCountry.Size = new System.Drawing.Size(200, 23);
            this.textBoxAuthorCountry.TabIndex = 2;
            this.textBoxAuthorCountry.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxAuthorCountry_Validating);
            this.textBoxAuthorCountry.Validated += new System.EventHandler(this.textBoxAuthorCountry_Validated);
            // 
            // maskedTextBoxAuthorID
            // 
            this.maskedTextBoxAuthorID.Location = new System.Drawing.Point(434, 115);
            this.maskedTextBoxAuthorID.Mask = "0000";
            this.maskedTextBoxAuthorID.Name = "maskedTextBoxAuthorID";
            this.maskedTextBoxAuthorID.Size = new System.Drawing.Size(200, 23);
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
            this.labelBook.Location = new System.Drawing.Point(218, 24);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(34, 15);
            this.labelBook.TabIndex = 4;
            this.labelBook.Text = "Book";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Location = new System.Drawing.Point(434, 97);
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
            this.groupBoxFormat.Location = new System.Drawing.Point(218, 334);
            this.groupBoxFormat.Name = "groupBoxFormat";
            this.groupBoxFormat.Size = new System.Drawing.Size(200, 100);
            this.groupBoxFormat.TabIndex = 7;
            this.groupBoxFormat.TabStop = false;
            this.groupBoxFormat.Text = "Format";
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
            this.buttonSave.Location = new System.Drawing.Point(218, 441);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(200, 23);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(218, 42);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.PlaceholderText = "Name";
            this.textBoxName.Size = new System.Drawing.Size(200, 23);
            this.textBoxName.TabIndex = 10;
            this.textBoxName.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxName_Validating);
            this.textBoxName.Validated += new System.EventHandler(this.textBoxName_Validated);
            // 
            // hScrollBarFileSize
            // 
            this.hScrollBarFileSize.Location = new System.Drawing.Point(437, 276);
            this.hScrollBarFileSize.Name = "hScrollBarFileSize";
            this.hScrollBarFileSize.Size = new System.Drawing.Size(200, 17);
            this.hScrollBarFileSize.TabIndex = 11;
            this.hScrollBarFileSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBarFileSize_Scroll);
            // 
            // labelFileSize
            // 
            this.labelFileSize.AutoSize = true;
            this.labelFileSize.Location = new System.Drawing.Point(434, 258);
            this.labelFileSize.Name = "labelFileSize";
            this.labelFileSize.Size = new System.Drawing.Size(81, 15);
            this.labelFileSize.TabIndex = 12;
            this.labelFileSize.Text = "File size: small";
            // 
            // richTextBoxAuthorsAndLinks
            // 
            this.richTextBoxAuthorsAndLinks.Location = new System.Drawing.Point(218, 232);
            this.richTextBoxAuthorsAndLinks.Name = "richTextBoxAuthorsAndLinks";
            this.richTextBoxAuthorsAndLinks.Size = new System.Drawing.Size(200, 96);
            this.richTextBoxAuthorsAndLinks.TabIndex = 13;
            this.richTextBoxAuthorsAndLinks.Text = "";
            this.richTextBoxAuthorsAndLinks.TextChanged += new System.EventHandler(this.richTextBoxAuthorsAndLinks_TextChanged);
            // 
            // labelauthorsAndLinks
            // 
            this.labelauthorsAndLinks.AutoSize = true;
            this.labelauthorsAndLinks.Location = new System.Drawing.Point(218, 214);
            this.labelauthorsAndLinks.Name = "labelauthorsAndLinks";
            this.labelauthorsAndLinks.Size = new System.Drawing.Size(102, 15);
            this.labelauthorsAndLinks.TabIndex = 14;
            this.labelauthorsAndLinks.Text = "Authors and links:";
            // 
            // checkBoxFree
            // 
            this.checkBoxFree.AutoSize = true;
            this.checkBoxFree.Location = new System.Drawing.Point(434, 309);
            this.checkBoxFree.Name = "checkBoxFree";
            this.checkBoxFree.Size = new System.Drawing.Size(48, 19);
            this.checkBoxFree.TabIndex = 15;
            this.checkBoxFree.Text = "Free";
            this.checkBoxFree.UseVisualStyleBackColor = true;
            this.checkBoxFree.CheckedChanged += new System.EventHandler(this.checkBoxFree_CheckedChanged);
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(324, 97);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(32, 15);
            this.labelYear.TabIndex = 17;
            this.labelYear.Text = "Year:";
            // 
            // maskedTextBoxYear
            // 
            this.maskedTextBoxYear.Location = new System.Drawing.Point(324, 115);
            this.maskedTextBoxYear.Mask = "0000";
            this.maskedTextBoxYear.Name = "maskedTextBoxYear";
            this.maskedTextBoxYear.Size = new System.Drawing.Size(94, 23);
            this.maskedTextBoxYear.TabIndex = 16;
            this.maskedTextBoxYear.ValidatingType = typeof(int);
            this.maskedTextBoxYear.Validating += new System.ComponentModel.CancelEventHandler(this.maskedTextBoxYear_Validating);
            this.maskedTextBoxYear.Validated += new System.EventHandler(this.maskedTextBoxYear_Validated);
            // 
            // labelUDC
            // 
            this.labelUDC.AutoSize = true;
            this.labelUDC.Location = new System.Drawing.Point(218, 97);
            this.labelUDC.Name = "labelUDC";
            this.labelUDC.Size = new System.Drawing.Size(34, 15);
            this.labelUDC.TabIndex = 19;
            this.labelUDC.Text = "UDC:";
            // 
            // textBoxUDC
            // 
            this.textBoxUDC.Location = new System.Drawing.Point(218, 115);
            this.textBoxUDC.Name = "textBoxUDC";
            this.textBoxUDC.Size = new System.Drawing.Size(100, 23);
            this.textBoxUDC.TabIndex = 20;
            this.textBoxUDC.TextChanged += new System.EventHandler(this.textBoxUDC_TextChanged);
            // 
            // textBoxPublisher
            // 
            this.textBoxPublisher.Location = new System.Drawing.Point(218, 71);
            this.textBoxPublisher.Name = "textBoxPublisher";
            this.textBoxPublisher.PlaceholderText = "Publisher";
            this.textBoxPublisher.Size = new System.Drawing.Size(200, 23);
            this.textBoxPublisher.TabIndex = 21;
            this.textBoxPublisher.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPublisher_Validating);
            this.textBoxPublisher.Validated += new System.EventHandler(this.textBoxPublisher_Validated);
            // 
            // textBoxPages
            // 
            this.textBoxPages.Location = new System.Drawing.Point(218, 144);
            this.textBoxPages.Name = "textBoxPages";
            this.textBoxPages.PlaceholderText = "Pages";
            this.textBoxPages.Size = new System.Drawing.Size(200, 23);
            this.textBoxPages.TabIndex = 22;
            this.textBoxPages.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPages_Validating);
            this.textBoxPages.Validated += new System.EventHandler(this.textBoxPages_Validated);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(434, 232);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker.TabIndex = 23;
            this.dateTimePicker.ValueChanged += new System.EventHandler(this.dateTimePicker_ValueChanged);
            // 
            // labelUploadDate
            // 
            this.labelUploadDate.AutoSize = true;
            this.labelUploadDate.Location = new System.Drawing.Point(434, 214);
            this.labelUploadDate.Name = "labelUploadDate";
            this.labelUploadDate.Size = new System.Drawing.Size(74, 15);
            this.labelUploadDate.TabIndex = 24;
            this.labelUploadDate.Text = "Upload date:";
            // 
            // numericUpDownChapters
            // 
            this.numericUpDownChapters.Location = new System.Drawing.Point(218, 188);
            this.numericUpDownChapters.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownChapters.Name = "numericUpDownChapters";
            this.numericUpDownChapters.Size = new System.Drawing.Size(200, 23);
            this.numericUpDownChapters.TabIndex = 25;
            this.numericUpDownChapters.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownChapters.ValueChanged += new System.EventHandler(this.numericUpDownChapters_ValueChanged);
            // 
            // labelChapters
            // 
            this.labelChapters.AutoSize = true;
            this.labelChapters.Location = new System.Drawing.Point(218, 170);
            this.labelChapters.Name = "labelChapters";
            this.labelChapters.Size = new System.Drawing.Size(57, 15);
            this.labelChapters.TabIndex = 26;
            this.labelChapters.Text = "Chapters:";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.sortToolStripMenuItem,
            this.saveSearchResultsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(650, 24);
            this.menuStrip.TabIndex = 27;
            this.menuStrip.Text = "menuStrip1";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byNameToolStripMenuItemSearch,
            this.byPublisherToolStripMenuItem,
            this.byYearToolStripMenuItem,
            this.byPageAmountToolStripMenuItem,
            this.searchQueryConstructorToolStripMenuItem});
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            // 
            // byNameToolStripMenuItemSearch
            // 
            this.byNameToolStripMenuItemSearch.Name = "byNameToolStripMenuItemSearch";
            this.byNameToolStripMenuItemSearch.Size = new System.Drawing.Size(206, 22);
            this.byNameToolStripMenuItemSearch.Text = "By name";
            this.byNameToolStripMenuItemSearch.Click += new System.EventHandler(this.byNameToolStripMenuItemSearch_Click);
            // 
            // byPublisherToolStripMenuItem
            // 
            this.byPublisherToolStripMenuItem.Name = "byPublisherToolStripMenuItem";
            this.byPublisherToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.byPublisherToolStripMenuItem.Text = "By publisher";
            this.byPublisherToolStripMenuItem.Click += new System.EventHandler(this.byPublisherToolStripMenuItem_Click);
            // 
            // byYearToolStripMenuItem
            // 
            this.byYearToolStripMenuItem.Name = "byYearToolStripMenuItem";
            this.byYearToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.byYearToolStripMenuItem.Text = "By year";
            this.byYearToolStripMenuItem.Click += new System.EventHandler(this.byYearToolStripMenuItem_Click);
            // 
            // byPageAmountToolStripMenuItem
            // 
            this.byPageAmountToolStripMenuItem.Name = "byPageAmountToolStripMenuItem";
            this.byPageAmountToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.byPageAmountToolStripMenuItem.Text = "By page amount";
            this.byPageAmountToolStripMenuItem.Click += new System.EventHandler(this.byPageAmountToolStripMenuItem_Click);
            // 
            // searchQueryConstructorToolStripMenuItem
            // 
            this.searchQueryConstructorToolStripMenuItem.Name = "searchQueryConstructorToolStripMenuItem";
            this.searchQueryConstructorToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.searchQueryConstructorToolStripMenuItem.Text = "Search query constructor";
            this.searchQueryConstructorToolStripMenuItem.Click += new System.EventHandler(this.searchQueryConstructorToolStripMenuItem_Click);
            // 
            // sortToolStripMenuItem
            // 
            this.sortToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.byNameToolStripMenuItem,
            this.byUploadDateToolStripMenuItem});
            this.sortToolStripMenuItem.Name = "sortToolStripMenuItem";
            this.sortToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.sortToolStripMenuItem.Text = "Sort";
            // 
            // byNameToolStripMenuItem
            // 
            this.byNameToolStripMenuItem.Name = "byNameToolStripMenuItem";
            this.byNameToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.byNameToolStripMenuItem.Text = "By name";
            this.byNameToolStripMenuItem.Click += new System.EventHandler(this.byNameToolStripMenuItem_Click);
            // 
            // byUploadDateToolStripMenuItem
            // 
            this.byUploadDateToolStripMenuItem.Name = "byUploadDateToolStripMenuItem";
            this.byUploadDateToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.byUploadDateToolStripMenuItem.Text = "By upload date";
            this.byUploadDateToolStripMenuItem.Click += new System.EventHandler(this.byUploadDateToolStripMenuItem_Click);
            // 
            // saveSearchResultsToolStripMenuItem
            // 
            this.saveSearchResultsToolStripMenuItem.Name = "saveSearchResultsToolStripMenuItem";
            this.saveSearchResultsToolStripMenuItem.Size = new System.Drawing.Size(117, 20);
            this.saveSearchResultsToolStripMenuItem.Text = "Save search results";
            this.saveSearchResultsToolStripMenuItem.Click += new System.EventHandler(this.saveSearchResultsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // labelBooks
            // 
            this.labelBooks.AutoSize = true;
            this.labelBooks.Location = new System.Drawing.Point(12, 24);
            this.labelBooks.Name = "labelBooks";
            this.labelBooks.Size = new System.Drawing.Size(39, 15);
            this.labelBooks.TabIndex = 28;
            this.labelBooks.Text = "Books";
            // 
            // listBoxBooks
            // 
            this.listBoxBooks.FormattingEnabled = true;
            this.listBoxBooks.ItemHeight = 15;
            this.listBoxBooks.Location = new System.Drawing.Point(12, 42);
            this.listBoxBooks.Name = "listBoxBooks";
            this.listBoxBooks.Size = new System.Drawing.Size(200, 394);
            this.listBoxBooks.TabIndex = 29;
            this.listBoxBooks.SelectedIndexChanged += new System.EventHandler(this.listBoxBooks_SelectedIndexChanged);
            // 
            // toolStrip
            // 
            this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.upToolStripButton,
            this.downToolStripButton,
            this.clearToolStripButton,
            this.deleteToolStripButton,
            this.hideToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 473);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(650, 25);
            this.toolStrip.TabIndex = 30;
            this.toolStrip.Text = "toolStrip1";
            // 
            // upToolStripButton
            // 
            this.upToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.upToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.upToolStripButton.Name = "upToolStripButton";
            this.upToolStripButton.Size = new System.Drawing.Size(26, 22);
            this.upToolStripButton.Text = "Up";
            this.upToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.upToolStripButton.Click += new System.EventHandler(this.upToolStripButton_Click);
            // 
            // downToolStripButton
            // 
            this.downToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.downToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.downToolStripButton.Name = "downToolStripButton";
            this.downToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.downToolStripButton.Text = "Down";
            this.downToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.downToolStripButton.Click += new System.EventHandler(this.downToolStripButton_Click);
            // 
            // clearToolStripButton
            // 
            this.clearToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearToolStripButton.Name = "clearToolStripButton";
            this.clearToolStripButton.Size = new System.Drawing.Size(38, 22);
            this.clearToolStripButton.Text = "Clear";
            this.clearToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.clearToolStripButton.Click += new System.EventHandler(this.clearToolStripButton_Click);
            // 
            // deleteToolStripButton
            // 
            this.deleteToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteToolStripButton.Name = "deleteToolStripButton";
            this.deleteToolStripButton.Size = new System.Drawing.Size(44, 22);
            this.deleteToolStripButton.Text = "Delete";
            this.deleteToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.deleteToolStripButton.Click += new System.EventHandler(this.deleteToolStripButton_Click);
            // 
            // hideToolStripButton
            // 
            this.hideToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hideToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hideToolStripButton.Name = "hideToolStripButton";
            this.hideToolStripButton.Size = new System.Drawing.Size(36, 22);
            this.hideToolStripButton.Text = "Hide";
            this.hideToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            this.hideToolStripButton.Click += new System.EventHandler(this.hideToolStripButton_Click);
            // 
            // buttonShowToolStrip
            // 
            this.buttonShowToolStrip.Location = new System.Drawing.Point(12, 442);
            this.buttonShowToolStrip.Name = "buttonShowToolStrip";
            this.buttonShowToolStrip.Size = new System.Drawing.Size(200, 22);
            this.buttonShowToolStrip.TabIndex = 31;
            this.buttonShowToolStrip.Text = "Show toolstrip";
            this.buttonShowToolStrip.UseVisualStyleBackColor = true;
            this.buttonShowToolStrip.Visible = false;
            this.buttonShowToolStrip.Click += new System.EventHandler(this.buttonShowToolStrip_Click);
            // 
            // Library
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 498);
            this.Controls.Add(this.buttonShowToolStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.listBoxBooks);
            this.Controls.Add(this.labelBooks);
            this.Controls.Add(this.labelChapters);
            this.Controls.Add(this.numericUpDownChapters);
            this.Controls.Add(this.labelUploadDate);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.textBoxPages);
            this.Controls.Add(this.textBoxPublisher);
            this.Controls.Add(this.textBoxUDC);
            this.Controls.Add(this.labelUDC);
            this.Controls.Add(this.labelYear);
            this.Controls.Add(this.maskedTextBoxYear);
            this.Controls.Add(this.checkBoxFree);
            this.Controls.Add(this.labelauthorsAndLinks);
            this.Controls.Add(this.richTextBoxAuthorsAndLinks);
            this.Controls.Add(this.labelFileSize);
            this.Controls.Add(this.hScrollBarFileSize);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxFormat);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelBook);
            this.Controls.Add(this.maskedTextBoxAuthorID);
            this.Controls.Add(this.textBoxAuthorCountry);
            this.Controls.Add(this.textBoxAuthorName);
            this.Controls.Add(this.labelAuthor);
            this.Controls.Add(this.menuStrip);
            this.Name = "Library";
            this.Text = "Library";
            this.Load += new System.EventHandler(this.Library_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderApp)).EndInit();
            this.groupBoxFormat.ResumeLayout(false);
            this.groupBoxFormat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownChapters)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
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
        private TextBox textBoxName;
        private Label labelFileSize;
        private HScrollBar hScrollBarFileSize;
        private Label labelauthorsAndLinks;
        private RichTextBox richTextBoxAuthorsAndLinks;
        private CheckBox checkBoxFree;
        private Label labelYear;
        private MaskedTextBox maskedTextBoxYear;
        private TextBox textBoxUDC;
        private Label labelUDC;
        private TextBox textBoxPublisher;
        private TextBox textBoxPages;
        private DateTimePicker dateTimePicker;
        private Label labelUploadDate;
        private Label labelChapters;
        private NumericUpDown numericUpDownChapters;
        private MenuStrip menuStrip;
        private ToolStripMenuItem searchToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItemSearch;
        private ToolStripMenuItem byPublisherToolStripMenuItem;
        private ToolStripMenuItem byYearToolStripMenuItem;
        private ToolStripMenuItem byPageAmountToolStripMenuItem;
        private ToolStripMenuItem sortToolStripMenuItem;
        private ToolStripMenuItem byNameToolStripMenuItem;
        private ToolStripMenuItem byUploadDateToolStripMenuItem;
        private ToolStripMenuItem saveSearchResultsToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ListBox listBoxBooks;
        private Label labelBooks;
        private ToolStrip toolStrip;
        private ToolStripButton upToolStripButton;
        private ToolStripButton downToolStripButton;
        private ToolStripButton hideToolStripButton;
        private Button buttonShowToolStrip;
        private ToolStripButton deleteToolStripButton;
        private ToolStripButton clearToolStripButton;
        private ToolStripMenuItem searchQueryConstructorToolStripMenuItem;
    }
}