
namespace UI.Desktop
{
    partial class AlumnosComision
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAlumnosCurso = new System.Windows.Forms.DataGridView();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.Titulo = new System.Windows.Forms.Label();
            this.IDInscripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Legajo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alumno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CargarNota = new System.Windows.Forms.DataGridViewButtonColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosCurso)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvAlumnosCurso, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnSalir, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnActualizar, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 367);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dgvAlumnosCurso
            // 
            this.dgvAlumnosCurso.AllowUserToAddRows = false;
            this.dgvAlumnosCurso.AllowUserToDeleteRows = false;
            this.dgvAlumnosCurso.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.dgvAlumnosCurso.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlumnosCurso.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDInscripcion,
            this.Legajo,
            this.Alumno,
            this.Condicion,
            this.Nota,
            this.CargarNota});
            this.tableLayoutPanel1.SetColumnSpan(this.dgvAlumnosCurso, 2);
            this.dgvAlumnosCurso.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlumnosCurso.Location = new System.Drawing.Point(3, 3);
            this.dgvAlumnosCurso.Name = "dgvAlumnosCurso";
            this.dgvAlumnosCurso.ReadOnly = true;
            this.dgvAlumnosCurso.Size = new System.Drawing.Size(607, 332);
            this.dgvAlumnosCurso.TabIndex = 0;
            this.dgvAlumnosCurso.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlumnosCurso_CellContentClick);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(535, 341);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.Location = new System.Drawing.Point(454, 341);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Times New Roman", 20.25F);
            this.Titulo.Location = new System.Drawing.Point(195, 6);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(226, 31);
            this.Titulo.TabIndex = 4;
            this.Titulo.Text = "Alumnos del Curso";
            // 
            // IDInscripcion
            // 
            this.IDInscripcion.DataPropertyName = "ID";
            this.IDInscripcion.HeaderText = "IDInscripcion";
            this.IDInscripcion.Name = "IDInscripcion";
            this.IDInscripcion.ReadOnly = true;
            this.IDInscripcion.Visible = false;
            // 
            // Legajo
            // 
            this.Legajo.HeaderText = "Legajo";
            this.Legajo.Name = "Legajo";
            this.Legajo.ReadOnly = true;
            // 
            // Alumno
            // 
            this.Alumno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Alumno.HeaderText = "Alumno";
            this.Alumno.Name = "Alumno";
            this.Alumno.ReadOnly = true;
            // 
            // Condicion
            // 
            this.Condicion.HeaderText = "Condición";
            this.Condicion.Name = "Condicion";
            this.Condicion.ReadOnly = true;
            // 
            // Nota
            // 
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            // 
            // CargarNota
            // 
            this.CargarNota.HeaderText = "Cargar Nota";
            this.CargarNota.Name = "CargarNota";
            this.CargarNota.ReadOnly = true;
            // 
            // AlumnosComision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(613, 407);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AlumnosComision";
            this.Text = "Alumnos del curso";
            this.Load += new System.EventHandler(this.AlumnosComision_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlumnosCurso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvAlumnosCurso;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDInscripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Legajo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alumno;
        private System.Windows.Forms.DataGridViewTextBoxColumn Condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.DataGridViewButtonColumn CargarNota;
    }
}
