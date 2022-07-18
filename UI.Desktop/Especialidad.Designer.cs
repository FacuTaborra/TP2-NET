
namespace UI.Desktop
{
    partial class Especialidad
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
            this.tcEspecialidad = new System.Windows.Forms.ToolStripContainer();
            this.tsEspecialidad = new System.Windows.Forms.ToolStrip();
            this.tlEspecialidad = new System.Windows.Forms.TableLayoutPanel();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tcEspecialidad.ContentPanel.SuspendLayout();
            this.tcEspecialidad.TopToolStripPanel.SuspendLayout();
            this.tcEspecialidad.SuspendLayout();
            this.tlEspecialidad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // tcEspecialidad
            // 
            // 
            // tcEspecialidad.ContentPanel
            // 
            this.tcEspecialidad.ContentPanel.Controls.Add(this.tlEspecialidad);
            this.tcEspecialidad.ContentPanel.Size = new System.Drawing.Size(794, 418);
            this.tcEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEspecialidad.Location = new System.Drawing.Point(0, 0);
            this.tcEspecialidad.Name = "tcEspecialidad";
            this.tcEspecialidad.Size = new System.Drawing.Size(794, 443);
            this.tcEspecialidad.TabIndex = 0;
            this.tcEspecialidad.Text = "toolStripContainer1";
            // 
            // tcEspecialidad.TopToolStripPanel
            // 
            this.tcEspecialidad.TopToolStripPanel.Controls.Add(this.tsEspecialidad);
            // 
            // tsEspecialidad
            // 
            this.tsEspecialidad.Dock = System.Windows.Forms.DockStyle.None;
            this.tsEspecialidad.Location = new System.Drawing.Point(3, 0);
            this.tsEspecialidad.Name = "tsEspecialidad";
            this.tsEspecialidad.Size = new System.Drawing.Size(111, 25);
            this.tsEspecialidad.TabIndex = 0;
            // 
            // tlEspecialidad
            // 
            this.tlEspecialidad.ColumnCount = 2;
            this.tlEspecialidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEspecialidad.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlEspecialidad.Controls.Add(this.dgvUsuarios, 0, 0);
            this.tlEspecialidad.Controls.Add(this.btnSalir, 1, 1);
            this.tlEspecialidad.Controls.Add(this.btnActualizar, 0, 1);
            this.tlEspecialidad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlEspecialidad.Location = new System.Drawing.Point(0, 0);
            this.tlEspecialidad.Name = "tlEspecialidad";
            this.tlEspecialidad.RowCount = 2;
            this.tlEspecialidad.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlEspecialidad.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlEspecialidad.Size = new System.Drawing.Size(794, 418);
            this.tlEspecialidad.TabIndex = 0;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tlEspecialidad.SetColumnSpan(this.dgvUsuarios, 2);
            this.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsuarios.Location = new System.Drawing.Point(3, 3);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.Size = new System.Drawing.Size(788, 383);
            this.dgvUsuarios.TabIndex = 0;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.Location = new System.Drawing.Point(635, 392);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 1;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(716, 392);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            // 
            // Especialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 443);
            this.Controls.Add(this.tcEspecialidad);
            this.Name = "Especialidad";
            this.Text = "Form1";
            this.tcEspecialidad.ContentPanel.ResumeLayout(false);
            this.tcEspecialidad.TopToolStripPanel.ResumeLayout(false);
            this.tcEspecialidad.TopToolStripPanel.PerformLayout();
            this.tcEspecialidad.ResumeLayout(false);
            this.tcEspecialidad.PerformLayout();
            this.tlEspecialidad.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tcEspecialidad;
        private System.Windows.Forms.ToolStrip tsEspecialidad;
        private System.Windows.Forms.TableLayoutPanel tlEspecialidad;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
    }
}