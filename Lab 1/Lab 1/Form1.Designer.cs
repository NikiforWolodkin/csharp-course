namespace Lab_1
{
    partial class Calculator
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
            this.textBoxInputField = new System.Windows.Forms.TextBox();
            this.labelOperation = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSubtract = new System.Windows.Forms.Button();
            this.buttonDivide = new System.Windows.Forms.Button();
            this.buttonMultiply = new System.Windows.Forms.Button();
            this.labelIncorrectInput = new System.Windows.Forms.Label();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonWholeFromDivision = new System.Windows.Forms.Button();
            this.buttonDivisionRemainder = new System.Windows.Forms.Button();
            this.buttonCopyToMemory = new System.Windows.Forms.Button();
            this.buttonSaveToMemory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxInputField
            // 
            this.textBoxInputField.Location = new System.Drawing.Point(12, 12);
            this.textBoxInputField.Name = "textBoxInputField";
            this.textBoxInputField.Size = new System.Drawing.Size(156, 23);
            this.textBoxInputField.TabIndex = 0;
            this.textBoxInputField.TextChanged += new System.EventHandler(this.textBoxInputField_TextChanged);
            // 
            // labelOperation
            // 
            this.labelOperation.AutoSize = true;
            this.labelOperation.Location = new System.Drawing.Point(174, 15);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(0, 15);
            this.labelOperation.TabIndex = 1;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 41);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "+";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonSubtract
            // 
            this.buttonSubtract.Location = new System.Drawing.Point(12, 70);
            this.buttonSubtract.Name = "buttonSubtract";
            this.buttonSubtract.Size = new System.Drawing.Size(75, 23);
            this.buttonSubtract.TabIndex = 3;
            this.buttonSubtract.Text = "-";
            this.buttonSubtract.UseVisualStyleBackColor = true;
            this.buttonSubtract.Click += new System.EventHandler(this.buttonSubtract_Click);
            // 
            // buttonDivide
            // 
            this.buttonDivide.Location = new System.Drawing.Point(12, 128);
            this.buttonDivide.Name = "buttonDivide";
            this.buttonDivide.Size = new System.Drawing.Size(75, 23);
            this.buttonDivide.TabIndex = 5;
            this.buttonDivide.Text = "/";
            this.buttonDivide.UseVisualStyleBackColor = true;
            this.buttonDivide.Click += new System.EventHandler(this.buttonDivide_Click);
            // 
            // buttonMultiply
            // 
            this.buttonMultiply.Location = new System.Drawing.Point(12, 99);
            this.buttonMultiply.Name = "buttonMultiply";
            this.buttonMultiply.Size = new System.Drawing.Size(75, 23);
            this.buttonMultiply.TabIndex = 4;
            this.buttonMultiply.Text = "*";
            this.buttonMultiply.UseVisualStyleBackColor = true;
            this.buttonMultiply.Click += new System.EventHandler(this.buttonMultiply_Click);
            // 
            // labelIncorrectInput
            // 
            this.labelIncorrectInput.AutoSize = true;
            this.labelIncorrectInput.ForeColor = System.Drawing.Color.Red;
            this.labelIncorrectInput.Location = new System.Drawing.Point(12, 221);
            this.labelIncorrectInput.Name = "labelIncorrectInput";
            this.labelIncorrectInput.Size = new System.Drawing.Size(0, 15);
            this.labelIncorrectInput.TabIndex = 6;
            // 
            // buttonEquals
            // 
            this.buttonEquals.Location = new System.Drawing.Point(93, 41);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(75, 23);
            this.buttonEquals.TabIndex = 7;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseVisualStyleBackColor = true;
            this.buttonEquals.Click += new System.EventHandler(this.buttonEquals_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(93, 70);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonWholeFromDivision
            // 
            this.buttonWholeFromDivision.Location = new System.Drawing.Point(12, 157);
            this.buttonWholeFromDivision.Name = "buttonWholeFromDivision";
            this.buttonWholeFromDivision.Size = new System.Drawing.Size(75, 23);
            this.buttonWholeFromDivision.TabIndex = 10;
            this.buttonWholeFromDivision.Text = "/ (int)";
            this.buttonWholeFromDivision.UseVisualStyleBackColor = true;
            this.buttonWholeFromDivision.Click += new System.EventHandler(this.buttonWholeFromDivision_Click);
            // 
            // buttonDivisionRemainder
            // 
            this.buttonDivisionRemainder.Location = new System.Drawing.Point(12, 186);
            this.buttonDivisionRemainder.Name = "buttonDivisionRemainder";
            this.buttonDivisionRemainder.Size = new System.Drawing.Size(75, 23);
            this.buttonDivisionRemainder.TabIndex = 9;
            this.buttonDivisionRemainder.Text = "%";
            this.buttonDivisionRemainder.UseVisualStyleBackColor = true;
            this.buttonDivisionRemainder.Click += new System.EventHandler(this.buttonDivisionRemainder_Click);
            // 
            // buttonCopyToMemory
            // 
            this.buttonCopyToMemory.Location = new System.Drawing.Point(93, 128);
            this.buttonCopyToMemory.Name = "buttonCopyToMemory";
            this.buttonCopyToMemory.Size = new System.Drawing.Size(75, 23);
            this.buttonCopyToMemory.TabIndex = 12;
            this.buttonCopyToMemory.Text = "Copy";
            this.buttonCopyToMemory.UseVisualStyleBackColor = true;
            this.buttonCopyToMemory.Click += new System.EventHandler(this.buttonCopyToMemory_Click);
            // 
            // buttonSaveToMemory
            // 
            this.buttonSaveToMemory.Location = new System.Drawing.Point(93, 99);
            this.buttonSaveToMemory.Name = "buttonSaveToMemory";
            this.buttonSaveToMemory.Size = new System.Drawing.Size(75, 23);
            this.buttonSaveToMemory.TabIndex = 11;
            this.buttonSaveToMemory.Text = "Save";
            this.buttonSaveToMemory.UseVisualStyleBackColor = true;
            this.buttonSaveToMemory.Click += new System.EventHandler(this.buttonSaveToMemory_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 250);
            this.Controls.Add(this.buttonCopyToMemory);
            this.Controls.Add(this.buttonSaveToMemory);
            this.Controls.Add(this.buttonWholeFromDivision);
            this.Controls.Add(this.buttonDivisionRemainder);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.labelIncorrectInput);
            this.Controls.Add(this.buttonDivide);
            this.Controls.Add(this.buttonMultiply);
            this.Controls.Add(this.buttonSubtract);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelOperation);
            this.Controls.Add(this.textBoxInputField);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxInputField;
        private Label labelOperation;
        private Button buttonAdd;
        private Button buttonSubtract;
        private Button buttonDivide;
        private Button buttonMultiply;
        private Label labelIncorrectInput;
        private Button buttonEquals;
        private Button buttonClear;
        private Button buttonWholeFromDivision;
        private Button buttonDivisionRemainder;
        private Button buttonCopyToMemory;
        private Button buttonSaveToMemory;
    }
}