namespace SamsaraCommissions
{
    partial class MinimalMarginDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MinimalMarginDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.mskName = new System.Windows.Forms.MaskedTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.gbxMinimalMargin = new System.Windows.Forms.GroupBox();
            this.txtMargin = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.gbxMinimalMargin.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(318, 54);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Margen:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre:";
            // 
            // mskName
            // 
            this.mskName.Location = new System.Drawing.Point(61, 19);
            this.mskName.Name = "mskName";
            this.mskName.PromptChar = ' ';
            this.mskName.ReadOnly = true;
            this.mskName.Size = new System.Drawing.Size(332, 20);
            this.mskName.TabIndex = 2;
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAccept.Location = new System.Drawing.Point(227, 54);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // gbxMinimalMargin
            // 
            this.gbxMinimalMargin.Controls.Add(this.txtMargin);
            this.gbxMinimalMargin.Controls.Add(this.label2);
            this.gbxMinimalMargin.Controls.Add(this.btnCancel);
            this.gbxMinimalMargin.Controls.Add(this.mskName);
            this.gbxMinimalMargin.Controls.Add(this.btnAccept);
            this.gbxMinimalMargin.Controls.Add(this.label1);
            this.gbxMinimalMargin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxMinimalMargin.Location = new System.Drawing.Point(0, 0);
            this.gbxMinimalMargin.Name = "gbxMinimalMargin";
            this.gbxMinimalMargin.Size = new System.Drawing.Size(405, 89);
            this.gbxMinimalMargin.TabIndex = 5;
            this.gbxMinimalMargin.TabStop = false;
            this.gbxMinimalMargin.Text = "[TITLE]";
            // 
            // txtMargin
            // 
            this.txtMargin.Location = new System.Drawing.Point(61, 45);
            this.txtMargin.MaskType = Samsara.Support.Util.TextMaskFormatEnum.Percentage;
            this.txtMargin.Name = "txtMargin";
            this.txtMargin.ReadOnly = false;
            this.txtMargin.Size = new System.Drawing.Size(99, 20);
            this.txtMargin.TabIndex = 5;
            this.txtMargin.Value = ((object)(resources.GetObject("txtMargin.Value")));
            // 
            // MinimalMarginDialog
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(405, 89);
            this.Controls.Add(this.gbxMinimalMargin);
            this.MinimumSize = new System.Drawing.Size(192, 127);
            this.Name = "MinimalMarginDialog";
            this.Text = "Editar Margen Mínimo";
            this.gbxMinimalMargin.ResumeLayout(false);
            this.gbxMinimalMargin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox mskName;
        private System.Windows.Forms.Button btnAccept;
        private Samsara.Base.Controls.Controls.SamsaraTextEditor txtMargin;
        internal System.Windows.Forms.GroupBox gbxMinimalMargin;
    }
}