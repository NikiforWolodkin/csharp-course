namespace binary
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
            this.textBoxFirst = new System.Windows.Forms.TextBox();
            this.textBoxSecond = new System.Windows.Forms.TextBox();
            this.buttonAnd = new System.Windows.Forms.Button();
            this.buttonOr = new System.Windows.Forms.Button();
            this.buttonXor = new System.Windows.Forms.Button();
            this.buttonNot = new System.Windows.Forms.Button();
            this.labelOperation = new System.Windows.Forms.Label();
            this.labelIncorrectInput = new System.Windows.Forms.Label();
            this.buttonEquals = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonBase16 = new System.Windows.Forms.Button();
            this.buttonBase10 = new System.Windows.Forms.Button();
            this.buttonBase8 = new System.Windows.Forms.Button();
            this.buttonBase2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFirst
            // 
            this.textBoxFirst.Location = new System.Drawing.Point(12, 12);
            this.textBoxFirst.Name = "textBoxFirst";
            this.textBoxFirst.Size = new System.Drawing.Size(125, 27);
            this.textBoxFirst.TabIndex = 0;
            this.textBoxFirst.TextChanged += new System.EventHandler(this.textBoxFirst_TextChanged);
            // 
            // textBoxSecond
            // 
            this.textBoxSecond.Location = new System.Drawing.Point(190, 12);
            this.textBoxSecond.Name = "textBoxSecond";
            this.textBoxSecond.Size = new System.Drawing.Size(125, 27);
            this.textBoxSecond.TabIndex = 1;
            this.textBoxSecond.TextChanged += new System.EventHandler(this.textBoxSecond_TextChanged);
            // 
            // buttonAnd
            // 
            this.buttonAnd.Location = new System.Drawing.Point(12, 45);
            this.buttonAnd.Name = "buttonAnd";
            this.buttonAnd.Size = new System.Drawing.Size(94, 29);
            this.buttonAnd.TabIndex = 2;
            this.buttonAnd.Text = "AND";
            this.buttonAnd.UseVisualStyleBackColor = true;
            this.buttonAnd.Click += new System.EventHandler(this.buttonAnd_Click);
            // 
            // buttonOr
            // 
            this.buttonOr.Location = new System.Drawing.Point(12, 80);
            this.buttonOr.Name = "buttonOr";
            this.buttonOr.Size = new System.Drawing.Size(94, 29);
            this.buttonOr.TabIndex = 3;
            this.buttonOr.Text = "OR";
            this.buttonOr.UseVisualStyleBackColor = true;
            this.buttonOr.Click += new System.EventHandler(this.buttonOr_Click);
            // 
            // buttonXor
            // 
            this.buttonXor.Location = new System.Drawing.Point(12, 115);
            this.buttonXor.Name = "buttonXor";
            this.buttonXor.Size = new System.Drawing.Size(94, 29);
            this.buttonXor.TabIndex = 4;
            this.buttonXor.Text = "XOR";
            this.buttonXor.UseVisualStyleBackColor = true;
            this.buttonXor.Click += new System.EventHandler(this.buttonXor_Click);
            // 
            // buttonNot
            // 
            this.buttonNot.Location = new System.Drawing.Point(12, 150);
            this.buttonNot.Name = "buttonNot";
            this.buttonNot.Size = new System.Drawing.Size(94, 29);
            this.buttonNot.TabIndex = 5;
            this.buttonNot.Text = "NOT";
            this.buttonNot.UseVisualStyleBackColor = true;
            this.buttonNot.Click += new System.EventHandler(this.buttonNot_Click);
            // 
            // labelOperation
            // 
            this.labelOperation.AutoSize = true;
            this.labelOperation.Location = new System.Drawing.Point(143, 15);
            this.labelOperation.Name = "labelOperation";
            this.labelOperation.Size = new System.Drawing.Size(41, 20);
            this.labelOperation.TabIndex = 6;
            this.labelOperation.Text = "AND";
            // 
            // labelIncorrectInput
            // 
            this.labelIncorrectInput.AutoSize = true;
            this.labelIncorrectInput.Location = new System.Drawing.Point(12, 182);
            this.labelIncorrectInput.Name = "labelIncorrectInput";
            this.labelIncorrectInput.Size = new System.Drawing.Size(0, 20);
            this.labelIncorrectInput.TabIndex = 7;
            // 
            // buttonEquals
            // 
            this.buttonEquals.Location = new System.Drawing.Point(212, 45);
            this.buttonEquals.Name = "buttonEquals";
            this.buttonEquals.Size = new System.Drawing.Size(94, 29);
            this.buttonEquals.TabIndex = 8;
            this.buttonEquals.Text = "=";
            this.buttonEquals.UseVisualStyleBackColor = true;
            this.buttonEquals.Click += new System.EventHandler(this.buttonEquals_Click);
            // 
            // labelResult
            // 
            this.labelResult.AutoSize = true;
            this.labelResult.Location = new System.Drawing.Point(321, 15);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(19, 20);
            this.labelResult.TabIndex = 9;
            this.labelResult.Text = "=";
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(212, 80);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(94, 29);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonBase16
            // 
            this.buttonBase16.Location = new System.Drawing.Point(112, 150);
            this.buttonBase16.Name = "buttonBase16";
            this.buttonBase16.Size = new System.Drawing.Size(94, 29);
            this.buttonBase16.TabIndex = 14;
            this.buttonBase16.Text = "16";
            this.buttonBase16.UseVisualStyleBackColor = true;
            this.buttonBase16.Click += new System.EventHandler(this.buttonBase16_Click);
            // 
            // buttonBase10
            // 
            this.buttonBase10.Location = new System.Drawing.Point(112, 115);
            this.buttonBase10.Name = "buttonBase10";
            this.buttonBase10.Size = new System.Drawing.Size(94, 29);
            this.buttonBase10.TabIndex = 13;
            this.buttonBase10.Text = "10";
            this.buttonBase10.UseVisualStyleBackColor = true;
            this.buttonBase10.Click += new System.EventHandler(this.buttonBase10_Click);
            // 
            // buttonBase8
            // 
            this.buttonBase8.Location = new System.Drawing.Point(112, 80);
            this.buttonBase8.Name = "buttonBase8";
            this.buttonBase8.Size = new System.Drawing.Size(94, 29);
            this.buttonBase8.TabIndex = 12;
            this.buttonBase8.Text = "8";
            this.buttonBase8.UseVisualStyleBackColor = true;
            this.buttonBase8.Click += new System.EventHandler(this.buttonBase8_Click);
            // 
            // buttonBase2
            // 
            this.buttonBase2.Location = new System.Drawing.Point(112, 45);
            this.buttonBase2.Name = "buttonBase2";
            this.buttonBase2.Size = new System.Drawing.Size(94, 29);
            this.buttonBase2.TabIndex = 11;
            this.buttonBase2.Text = "2";
            this.buttonBase2.UseVisualStyleBackColor = true;
            this.buttonBase2.Click += new System.EventHandler(this.buttonBase2_Click);
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonBase16);
            this.Controls.Add(this.buttonBase10);
            this.Controls.Add(this.buttonBase8);
            this.Controls.Add(this.buttonBase2);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonEquals);
            this.Controls.Add(this.labelIncorrectInput);
            this.Controls.Add(this.labelOperation);
            this.Controls.Add(this.buttonNot);
            this.Controls.Add(this.buttonXor);
            this.Controls.Add(this.buttonOr);
            this.Controls.Add(this.buttonAnd);
            this.Controls.Add(this.textBoxSecond);
            this.Controls.Add(this.textBoxFirst);
            this.Name = "Calculator";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxFirst;
        private TextBox textBoxSecond;
        private Button buttonAnd;
        private Button buttonOr;
        private Button buttonXor;
        private Button buttonNot;
        private Label labelOperation;
        private Label labelIncorrectInput;
        private Button buttonEquals;
        private Label labelResult;
        private Button buttonClear;
        private Button buttonBase16;
        private Button buttonBase10;
        private Button buttonBase8;
        private Button buttonBase2;
    }
}