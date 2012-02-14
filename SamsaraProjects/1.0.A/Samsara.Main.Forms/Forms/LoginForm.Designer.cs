namespace Samsara.Main.Forms.Forms
{
    partial class LoginForm
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
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.txtUsername = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ulblUsername = new Infragistics.Win.Misc.UltraLabel();
            this.txtPassword = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ulblPassword = new Infragistics.Win.Misc.UltraLabel();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.ubtnLogin = new Samsara.Base.Controls.Controls.SamsaraUltraButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUsername.Location = new System.Drawing.Point(92, 7);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(129, 21);
            this.txtUsername.TabIndex = 0;
            // 
            // ulblUsername
            // 
            this.ulblUsername.AutoSize = true;
            this.ulblUsername.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblUsername.Location = new System.Drawing.Point(9, 9);
            this.ulblUsername.Name = "ulblUsername";
            this.ulblUsername.Size = new System.Drawing.Size(53, 16);
            this.ulblUsername.TabIndex = 1;
            this.ulblUsername.Text = "Usuario:";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(92, 34);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(129, 21);
            this.txtPassword.TabIndex = 2;
            // 
            // ulblPassword
            // 
            this.ulblPassword.AutoSize = true;
            this.ulblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ulblPassword.Location = new System.Drawing.Point(9, 36);
            this.ulblPassword.Name = "ulblPassword";
            this.ulblPassword.Size = new System.Drawing.Size(74, 16);
            this.ulblPassword.TabIndex = 1;
            this.ulblPassword.Text = "Contraseña:";
            // 
            // ultraGroupBox1
            // 
            appearance1.AlphaLevel = ((short)(80));
            appearance1.BackColor = System.Drawing.Color.White;
            this.ultraGroupBox1.Appearance = appearance1;
            this.ultraGroupBox1.Controls.Add(this.txtUsername);
            this.ultraGroupBox1.Controls.Add(this.txtPassword);
            this.ultraGroupBox1.Controls.Add(this.ulblUsername);
            this.ultraGroupBox1.Controls.Add(this.ulblPassword);
            this.ultraGroupBox1.Location = new System.Drawing.Point(107, 54);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(227, 63);
            this.ultraGroupBox1.TabIndex = 3;
            // 
            // ubtnLogin
            // 
            this.ubtnLogin.Location = new System.Drawing.Point(199, 137);
            this.ubtnLogin.Name = "ubtnLogin";
            this.ubtnLogin.Size = new System.Drawing.Size(135, 23);
            this.ubtnLogin.TabIndex = 4;
            this.ubtnLogin.Text = "Iniciar sesión";
            this.ubtnLogin.Click += new System.EventHandler(this.ubtnLogin_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(355, 182);
            this.Controls.Add(this.ubtnLogin);
            this.Controls.Add(this.ultraGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.Text = "Samsara Projects - Iniciar sesión";
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            this.ultraGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtUsername;
        private Infragistics.Win.Misc.UltraLabel ulblUsername;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor txtPassword;
        private Infragistics.Win.Misc.UltraLabel ulblPassword;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private Base.Controls.Controls.SamsaraUltraButton ubtnLogin;
    }
}