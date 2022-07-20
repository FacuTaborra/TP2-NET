
namespace UI.Desktop
{
    partial class Login
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
            this.labelLogin1 = new System.Windows.Forms.Label();
            this.labelLogin2 = new System.Windows.Forms.Label();
            this.labelLogin3 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.linkOlvidaPass = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelLogin1
            // 
            this.labelLogin1.AutoSize = true;
            this.labelLogin1.Location = new System.Drawing.Point(110, 40);
            this.labelLogin1.Name = "labelLogin1";
            this.labelLogin1.Size = new System.Drawing.Size(204, 26);
            this.labelLogin1.TabIndex = 0;
            this.labelLogin1.Text = "¡Bienvenido al sistema!\r\nPor favor, digite su información de ingreso\r\n";
            this.labelLogin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelLogin2
            // 
            this.labelLogin2.AutoSize = true;
            this.labelLogin2.Location = new System.Drawing.Point(31, 99);
            this.labelLogin2.Name = "labelLogin2";
            this.labelLogin2.Size = new System.Drawing.Size(101, 13);
            this.labelLogin2.TabIndex = 1;
            this.labelLogin2.Text = "Nombre de Usuario:";
            this.labelLogin2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // labelLogin3
            // 
            this.labelLogin3.AutoSize = true;
            this.labelLogin3.Location = new System.Drawing.Point(68, 132);
            this.labelLogin3.Name = "labelLogin3";
            this.labelLogin3.Size = new System.Drawing.Size(64, 13);
            this.labelLogin3.TabIndex = 2;
            this.labelLogin3.Text = "Contraseña:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(151, 96);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(220, 20);
            this.txtUsuario.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(151, 129);
            this.txtPass.Name = "txtPass";
            this.txtPass.PasswordChar = '*';
            this.txtPass.Size = new System.Drawing.Size(220, 20);
            this.txtPass.TabIndex = 4;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Location = new System.Drawing.Point(296, 184);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(75, 23);
            this.btnIngresar.TabIndex = 5;
            this.btnIngresar.Text = "Ingresar";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // linkOlvidaPass
            // 
            this.linkOlvidaPass.AutoSize = true;
            this.linkOlvidaPass.Location = new System.Drawing.Point(13, 215);
            this.linkOlvidaPass.Name = "linkOlvidaPass";
            this.linkOlvidaPass.Size = new System.Drawing.Size(106, 13);
            this.linkOlvidaPass.TabIndex = 6;
            this.linkOlvidaPass.TabStop = true;
            this.linkOlvidaPass.Text = "Olvidé mi contraseña";
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 240);
            this.Controls.Add(this.linkOlvidaPass);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.labelLogin3);
            this.Controls.Add(this.labelLogin2);
            this.Controls.Add(this.labelLogin1);
            this.Name = "login";
            this.Text = "Iniciar sesión";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelLogin1;
        private System.Windows.Forms.Label labelLogin2;
        private System.Windows.Forms.Label labelLogin3;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.LinkLabel linkOlvidaPass;
    }
}