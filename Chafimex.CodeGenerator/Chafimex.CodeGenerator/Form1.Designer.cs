namespace Chafimex.CodeGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ubtnGenerate = new Infragistics.Win.Misc.UltraButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxDetSearchFile = new System.Windows.Forms.GroupBox();
            this.btnDetSearchFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.gbxDetSearchFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // ubtnGenerate
            // 
            this.ubtnGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ubtnGenerate.Location = new System.Drawing.Point(278, 54);
            this.ubtnGenerate.Name = "ubtnGenerate";
            this.ubtnGenerate.Size = new System.Drawing.Size(75, 23);
            this.ubtnGenerate.TabIndex = 1;
            this.ubtnGenerate.Text = "Generar";
            this.ubtnGenerate.Click += new System.EventHandler(this.ubtnGenerate_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbxDetSearchFile);
            this.panel1.Controls.Add(this.ubtnGenerate);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(365, 89);
            this.panel1.TabIndex = 4;
            // 
            // gbxDetSearchFile
            // 
            this.gbxDetSearchFile.Controls.Add(this.btnDetSearchFile);
            this.gbxDetSearchFile.Controls.Add(this.txtFile);
            this.gbxDetSearchFile.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxDetSearchFile.Location = new System.Drawing.Point(0, 0);
            this.gbxDetSearchFile.Name = "gbxDetSearchFile";
            this.gbxDetSearchFile.Size = new System.Drawing.Size(365, 45);
            this.gbxDetSearchFile.TabIndex = 58;
            this.gbxDetSearchFile.TabStop = false;
            this.gbxDetSearchFile.Text = "Archivo:";
            // 
            // btnDetSearchFile
            // 
            this.btnDetSearchFile.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnDetSearchFile.Image = ((System.Drawing.Image)(resources.GetObject("btnDetSearchFile.Image")));
            this.btnDetSearchFile.Location = new System.Drawing.Point(3, 16);
            this.btnDetSearchFile.Name = "btnDetSearchFile";
            this.btnDetSearchFile.Size = new System.Drawing.Size(32, 26);
            this.btnDetSearchFile.TabIndex = 13;
            this.btnDetSearchFile.UseVisualStyleBackColor = true;
            this.btnDetSearchFile.Click += new System.EventHandler(this.btnDetSearchFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(41, 16);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(314, 20);
            this.txtFile.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 89);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.gbxDetSearchFile.ResumeLayout(false);
            this.gbxDetSearchFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.Misc.UltraButton ubtnGenerate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbxDetSearchFile;
        internal System.Windows.Forms.Button btnDetSearchFile;
        private System.Windows.Forms.TextBox txtFile;
    }
}

