
using Samsara.Controls.Controls;

namespace Samsara.Base.Controls.Controls
{
    partial class SamsaraEntityChooserControl<T, TId, TService, TDao, TPmt> : SamsaraUserControl
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
            Infragistics.Win.UltraWinEditors.EditorButton editorButton1 = new Infragistics.Win.UltraWinEditors.EditorButton("Add");
            this.suceEntities = new Samsara.Controls.Controls.SamsaraUltraComboEditor();
            ((System.ComponentModel.ISupportInitialize)(this.suceEntities)).BeginInit();
            this.SuspendLayout();
            // 
            // suceEntities
            // 
            editorButton1.Key = "Add";
            editorButton1.Text = "+";
            this.suceEntities.ButtonsLeft.Add(editorButton1);
            this.suceEntities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.suceEntities.Location = new System.Drawing.Point(0, 0);
            this.suceEntities.Name = "suceEntities";
            this.suceEntities.Size = new System.Drawing.Size(226, 21);
            this.suceEntities.TabIndex = 0;
            this.suceEntities.ValueChanged += new System.EventHandler(this.suceEntities_ValueChanged);
            // 
            // SamsaraEntityChooserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.suceEntities);
            this.Name = "SamsaraEntityChooserControl";
            this.Size = new System.Drawing.Size(226, 22);
            ((System.ComponentModel.ISupportInitialize)(this.suceEntities)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SamsaraUltraComboEditor suceEntities;
    }
}
