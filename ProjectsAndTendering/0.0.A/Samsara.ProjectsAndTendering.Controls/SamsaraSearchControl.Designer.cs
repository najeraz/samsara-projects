namespace Samsara.ProjectsAndTendering.Controls
{
    partial class SamsaraSearchControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SamsaraSearchControl));
            this.btnSearch = new System.Windows.Forms.Button();
            this.upSeparator1 = new Infragistics.Win.Misc.UltraPanel();
            this.upBody = new Infragistics.Win.Misc.UltraPanel();
            this.txtName = new System.Windows.Forms.TextBox();
            this.upSeparator2 = new Infragistics.Win.Misc.UltraPanel();
            this.upSeparator1.SuspendLayout();
            this.upBody.ClientArea.SuspendLayout();
            this.upBody.SuspendLayout();
            this.upSeparator2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(0, 0);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(32, 24);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // upSeparator1
            // 
            this.upSeparator1.Dock = System.Windows.Forms.DockStyle.Left;
            this.upSeparator1.Location = new System.Drawing.Point(32, 0);
            this.upSeparator1.Name = "upSeparator1";
            this.upSeparator1.Size = new System.Drawing.Size(10, 24);
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
            this.upBody.Size = new System.Drawing.Size(287, 24);
            this.upBody.TabIndex = 4;
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
            // upSeparator2
            // 
            this.upSeparator2.Dock = System.Windows.Forms.DockStyle.Top;
            this.upSeparator2.Location = new System.Drawing.Point(0, 0);
            this.upSeparator2.Name = "upSeparator2";
            this.upSeparator2.Size = new System.Drawing.Size(287, 2);
            this.upSeparator2.TabIndex = 5;
            // 
            // SamsaraSearchControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upBody);
            this.Controls.Add(this.upSeparator1);
            this.Controls.Add(this.btnSearch);
            this.Name = "SamsaraSearchControl";
            this.Size = new System.Drawing.Size(329, 24);
            this.upSeparator1.ResumeLayout(false);
            this.upBody.ClientArea.ResumeLayout(false);
            this.upBody.ClientArea.PerformLayout();
            this.upBody.ResumeLayout(false);
            this.upSeparator2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private Infragistics.Win.Misc.UltraPanel upSeparator1;
        private Infragistics.Win.Misc.UltraPanel upBody;
        private System.Windows.Forms.TextBox txtName;
        private Infragistics.Win.Misc.UltraPanel upSeparator2;
    }
}
