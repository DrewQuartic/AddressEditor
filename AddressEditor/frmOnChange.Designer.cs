namespace AddressEditor
{
    partial class frmOnChange
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
            this.btnApply = new System.Windows.Forms.Button();
            this.ucPosition1 = new AddressEditor.ucPosition();
            this.SuspendLayout();
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(170, 13);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // ucPosition1
            // 
            this.ucPosition1.Location = new System.Drawing.Point(13, 13);
            this.ucPosition1.Name = "ucPosition1";
            this.ucPosition1.Size = new System.Drawing.Size(151, 53);
            this.ucPosition1.TabIndex = 3;
            // 
            // frmOnChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 86);
            this.Controls.Add(this.ucPosition1);
            this.Controls.Add(this.btnApply);
            this.Name = "frmOnChange";
            this.Text = "frmOnChange";
            this.Load += new System.EventHandler(this.frmOnChange_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnApply;
        private ucPosition ucPosition1;
    }
}