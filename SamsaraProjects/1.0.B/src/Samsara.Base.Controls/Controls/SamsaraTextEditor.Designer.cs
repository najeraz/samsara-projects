
namespace Samsara.Base.Controls.Controls
{
    partial class SamsaraTextEditor
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
            this.sumeValue = new SamsaraUltraMaskedEdit();
            this.SuspendLayout();
            // 
            // sumeValue
            // 
            this.sumeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sumeValue.Location = new System.Drawing.Point(0, 0);
            this.sumeValue.Name = "sumeValue";
            this.sumeValue.PromptChar = ' ';
            this.sumeValue.Size = new System.Drawing.Size(150, 20);
            this.sumeValue.TabIndex = 0;
            // 
            // SamsaraTextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.sumeValue);
            this.Name = "SamsaraTextEditor";
            this.Size = new System.Drawing.Size(150, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SamsaraUltraMaskedEdit sumeValue;
    }
}
