
namespace UI.Desktop
{
    partial class CursosDesktop
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.cbComision = new System.Windows.Forms.ComboBox();
            this.nudAnio = new System.Windows.Forms.NumericUpDown();
            this.txtID = new System.Windows.Forms.TextBox();
            this.nudCupo = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCupo)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 48.87893F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.587444F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.53363F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cbMateria, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbComision, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.nudAnio, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.nudCupo, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(305, 355);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(207, 328);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(126, 328);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 65);
            this.label2.TabIndex = 3;
            this.label2.Text = "Materia";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 65);
            this.label3.TabIndex = 4;
            this.label3.Text = "Comision";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 195);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 65);
            this.label4.TabIndex = 5;
            this.label4.Text = "Año Calendario";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 65);
            this.label5.TabIndex = 6;
            this.label5.Text = "Cupo";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbMateria
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbMateria, 2);
            this.cbMateria.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(110, 86);
            this.cbMateria.Margin = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(172, 21);
            this.cbMateria.TabIndex = 7;
            // 
            // cbComision
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbComision, 2);
            this.cbComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(110, 151);
            this.cbComision.Margin = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(172, 21);
            this.cbComision.TabIndex = 8;
            // 
            // nudAnio
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nudAnio, 2);
            this.nudAnio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudAnio.Location = new System.Drawing.Point(110, 216);
            this.nudAnio.Margin = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.nudAnio.Maximum = new decimal(new int[] {
            2040,
            0,
            0,
            0});
            this.nudAnio.Name = "nudAnio";
            this.nudAnio.Size = new System.Drawing.Size(172, 20);
            this.nudAnio.TabIndex = 9;
            // 
            // txtID
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtID, 2);
            this.txtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(110, 21);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(172, 20);
            this.txtID.TabIndex = 10;
            // 
            // nudCupo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.nudCupo, 2);
            this.nudCupo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nudCupo.Location = new System.Drawing.Point(110, 281);
            this.nudCupo.Margin = new System.Windows.Forms.Padding(3, 21, 3, 3);
            this.nudCupo.Name = "nudCupo";
            this.nudCupo.Size = new System.Drawing.Size(172, 20);
            this.nudCupo.TabIndex = 11;
            // 
            // CursosDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 355);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "CursosDesktop";
            this.Text = "CursosDesktop";
            this.Load += new System.EventHandler(this.CursosDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCupo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.ComboBox cbComision;
        private System.Windows.Forms.NumericUpDown nudAnio;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.NumericUpDown nudCupo;
    }
}