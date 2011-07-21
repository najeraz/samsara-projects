namespace Samsara.ProjectsAndTendering.Controls
{
    partial class SamsaraTenderControl
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SamsaraTenderControl));
            this.button1 = new System.Windows.Forms.Button();
            this.upSeparator1 = new Infragistics.Win.Misc.UltraPanel();
            this.upBody = new Infragistics.Win.Misc.UltraPanel();
            this.upSeparator2 = new Infragistics.Win.Misc.UltraPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.upSeparator1.SuspendLayout();
            this.upBody.ClientArea.SuspendLayout();
            this.upBody.SuspendLayout();
            this.upSeparator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Left;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 22);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // upSeparator1
            // 
            this.upSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.upSeparator1.Location = new System.Drawing.Point(32, 0);
            this.upSeparator1.Name = "upSeparator1";
            this.upSeparator1.Size = new System.Drawing.Size(10, 22);
            this.upSeparator1.TabIndex = 3;
            // 
            // upBody
            // 
            // 
            // upBody.ClientArea
            // 
            this.upBody.ClientArea.Controls.Add(this.txtName);
            this.upBody.ClientArea.Controls.Add(this.upSeparator2);
            this.upBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upBody.Location = new System.Drawing.Point(42, 0);
            this.upBody.Name = "upBody";
            this.upBody.Size = new System.Drawing.Size(287, 22);
            this.upBody.TabIndex = 4;
            // 
            // upSeparator2
            // 
            this.upSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.upSeparator2.Location = new System.Drawing.Point(0, 0);
            this.upSeparator2.Name = "upSeparator2";
            this.upSeparator2.Size = new System.Drawing.Size(287, 2);
            this.upSeparator2.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(0, 2);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(287, 20);
            this.txtName.TabIndex = 6;
            // 
            // SamsaraTenderControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upBody);
            this.Controls.Add(this.upSeparator1);
            this.Controls.Add(this.button1);
            this.Name = "SamsaraTenderControl";
            this.Size = new System.Drawing.Size(329, 22);
            this.SizeChanged += new System.EventHandler(this.SamsaraTenderControl_SizeChanged);
            this.upSeparator1.ResumeLayout(false);
            this.upBody.ClientArea.ResumeLayout(false);
            this.upBody.ClientArea.PerformLayout();
            this.upBody.ResumeLayout(false);
            this.upSeparator2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Infragistics.Win.Misc.UltraPanel upSeparator1;
        private Infragistics.Win.Misc.UltraPanel upBody;
        private System.Windows.Forms.TextBox txtName;
        private Infragistics.Win.Misc.UltraPanel upSeparator2;
    }
}
