namespace ComisionesAgentes
{
    partial class ComisionDataDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComisionDataDialog));
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAccept = new System.Windows.Forms.Button();
            this.rbtnMes = new System.Windows.Forms.RadioButton();
            this.rbtnAño = new System.Windows.Forms.RadioButton();
            this.txtComision = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.txtCuota = new Samsara.Base.Controls.Controls.SamsaraTextEditor();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(231, 57);
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
            this.label1.Location = new System.Drawing.Point(8, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Comision:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cuota:";
            // 
            // btnAccept
            // 
            this.btnAccept.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAccept.Location = new System.Drawing.Point(140, 57);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(75, 23);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Aceptar";
            this.btnAccept.UseVisualStyleBackColor = true;
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // rbtnMes
            // 
            this.rbtnMes.AutoSize = true;
            this.rbtnMes.Location = new System.Drawing.Point(172, 6);
            this.rbtnMes.Name = "rbtnMes";
            this.rbtnMes.Size = new System.Drawing.Size(134, 17);
            this.rbtnMes.TabIndex = 3;
            this.rbtnMes.TabStop = true;
            this.rbtnMes.Text = "Establecer solo al Mes.";
            this.rbtnMes.UseVisualStyleBackColor = true;
            this.rbtnMes.CheckedChanged += new System.EventHandler(this.rbtnMes_CheckedChanged);
            // 
            // rbtnAño
            // 
            this.rbtnAño.AutoSize = true;
            this.rbtnAño.Location = new System.Drawing.Point(172, 32);
            this.rbtnAño.Name = "rbtnAño";
            this.rbtnAño.Size = new System.Drawing.Size(144, 17);
            this.rbtnAño.TabIndex = 3;
            this.rbtnAño.TabStop = true;
            this.rbtnAño.Text = "Establecer a todo el Año.";
            this.rbtnAño.UseVisualStyleBackColor = true;
            this.rbtnAño.CheckedChanged += new System.EventHandler(this.rbtnAño_CheckedChanged);
            // 
            // txtComision
            // 
            this.txtComision.Location = new System.Drawing.Point(67, 32);
            this.txtComision.MaskType = Samsara.Support.Util.TextMaskFormatEnum.Percentage;
            this.txtComision.Name = "txtComision";
            this.txtComision.ReadOnly = false;
            this.txtComision.Size = new System.Drawing.Size(99, 20);
            this.txtComision.TabIndex = 4;
            this.txtComision.Value = ((object)(resources.GetObject("txtComision.Value")));
            // 
            // txtCuota
            // 
            this.txtCuota.Location = new System.Drawing.Point(67, 6);
            this.txtCuota.MaskType = Samsara.Support.Util.TextMaskFormatEnum.Currency;
            this.txtCuota.Name = "txtCuota";
            this.txtCuota.ReadOnly = false;
            this.txtCuota.Size = new System.Drawing.Size(99, 20);
            this.txtCuota.TabIndex = 4;
            this.txtCuota.Value = ((object)(resources.GetObject("txtCuota.Value")));
            // 
            // ComisionDataDialog
            // 
            this.AcceptButton = this.btnAccept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(315, 89);
            this.Controls.Add(this.txtCuota);
            this.Controls.Add(this.txtComision);
            this.Controls.Add(this.rbtnAño);
            this.Controls.Add(this.rbtnMes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAccept);
            this.Controls.Add(this.btnCancel);
            this.MinimumSize = new System.Drawing.Size(192, 127);
            this.Name = "ComisionDataDialog";
            this.Text = "Cuota/Comision";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.RadioButton rbtnMes;
        private System.Windows.Forms.RadioButton rbtnAño;
        private Samsara.Base.Controls.Controls.SamsaraTextEditor txtComision;
        private Samsara.Base.Controls.Controls.SamsaraTextEditor txtCuota;
    }
}