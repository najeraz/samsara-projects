﻿namespace Samsara.ProjectsAndTendering.Forms.Forms
{
    partial class MainForm
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiMainMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.licitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licitanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dependenciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioFinalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fabricanteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asesorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estatusDeLaLicitaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiMainMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(811, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiMainMenu
            // 
            this.tsmiMainMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.licitaciónToolStripMenuItem,
            this.licitanteToolStripMenuItem,
            this.dependenciaToolStripMenuItem,
            this.usuarioFinalToolStripMenuItem,
            this.fabricanteToolStripMenuItem,
            this.asesorToolStripMenuItem,
            this.estatusDeLaLicitaciónToolStripMenuItem});
            this.tsmiMainMenu.Name = "tsmiMainMenu";
            this.tsmiMainMenu.Size = new System.Drawing.Size(72, 20);
            this.tsmiMainMenu.Text = "Catálogos";
            // 
            // licitaciónToolStripMenuItem
            // 
            this.licitaciónToolStripMenuItem.Name = "licitaciónToolStripMenuItem";
            this.licitaciónToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.licitaciónToolStripMenuItem.Text = "Licitación";
            this.licitaciónToolStripMenuItem.Click += new System.EventHandler(this.licitaciónToolStripMenuItem_Click);
            // 
            // licitanteToolStripMenuItem
            // 
            this.licitanteToolStripMenuItem.Name = "licitanteToolStripMenuItem";
            this.licitanteToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.licitanteToolStripMenuItem.Text = "Licitante";
            // 
            // dependenciaToolStripMenuItem
            // 
            this.dependenciaToolStripMenuItem.Name = "dependenciaToolStripMenuItem";
            this.dependenciaToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.dependenciaToolStripMenuItem.Text = "Dependencia";
            // 
            // usuarioFinalToolStripMenuItem
            // 
            this.usuarioFinalToolStripMenuItem.Name = "usuarioFinalToolStripMenuItem";
            this.usuarioFinalToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.usuarioFinalToolStripMenuItem.Text = "Usuario Final";
            // 
            // fabricanteToolStripMenuItem
            // 
            this.fabricanteToolStripMenuItem.Name = "fabricanteToolStripMenuItem";
            this.fabricanteToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.fabricanteToolStripMenuItem.Text = "Fabricante";
            // 
            // asesorToolStripMenuItem
            // 
            this.asesorToolStripMenuItem.Name = "asesorToolStripMenuItem";
            this.asesorToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.asesorToolStripMenuItem.Text = "Asesor";
            // 
            // estatusDeLaLicitaciónToolStripMenuItem
            // 
            this.estatusDeLaLicitaciónToolStripMenuItem.Name = "estatusDeLaLicitaciónToolStripMenuItem";
            this.estatusDeLaLicitaciónToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.estatusDeLaLicitaciónToolStripMenuItem.Text = "Estatus de la Licitación";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(811, 351);
            this.panel1.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 375);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Oportunidades y Licitaciones";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiMainMenu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem licitaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem licitanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dependenciaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuarioFinalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fabricanteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asesorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estatusDeLaLicitaciónToolStripMenuItem;
    }
}

