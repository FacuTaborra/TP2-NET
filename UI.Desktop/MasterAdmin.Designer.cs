
namespace UI.Desktop
{
    partial class MasterAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterAdmin));
            this.MenuToolScript = new System.Windows.Forms.ToolStrip();
            this.tsPlanes = new System.Windows.Forms.ToolStripSplitButton();
            this.gestionarPlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionarEspecializacionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUsuarios = new System.Windows.Forms.ToolStripSplitButton();
            this.tsProfesores = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAdministrativos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCursos = new System.Windows.Forms.ToolStripSplitButton();
            this.tsMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.tsComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuToolScript.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuToolScript
            // 
            this.MenuToolScript.BackColor = System.Drawing.Color.MintCream;
            this.MenuToolScript.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPlanes,
            this.tsUsuarios,
            this.tsCursos});
            this.MenuToolScript.Location = new System.Drawing.Point(0, 0);
            this.MenuToolScript.Name = "MenuToolScript";
            this.MenuToolScript.Size = new System.Drawing.Size(600, 25);
            this.MenuToolScript.TabIndex = 0;
            this.MenuToolScript.Text = "toolStrip1";
            // 
            // tsPlanes
            // 
            this.tsPlanes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsPlanes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionarPlanesToolStripMenuItem,
            this.gestionarEspecializacionesToolStripMenuItem});
            this.tsPlanes.Image = ((System.Drawing.Image)(resources.GetObject("tsPlanes.Image")));
            this.tsPlanes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPlanes.Name = "tsPlanes";
            this.tsPlanes.Size = new System.Drawing.Size(57, 22);
            this.tsPlanes.Text = "Planes";
            // 
            // gestionarPlanesToolStripMenuItem
            // 
            this.gestionarPlanesToolStripMenuItem.Name = "gestionarPlanesToolStripMenuItem";
            this.gestionarPlanesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.gestionarPlanesToolStripMenuItem.Text = "Gestionar Planes";
            this.gestionarPlanesToolStripMenuItem.Click += new System.EventHandler(this.gestionarPlanesToolStripMenuItem_Click);
            // 
            // gestionarEspecializacionesToolStripMenuItem
            // 
            this.gestionarEspecializacionesToolStripMenuItem.Name = "gestionarEspecializacionesToolStripMenuItem";
            this.gestionarEspecializacionesToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.gestionarEspecializacionesToolStripMenuItem.Text = "Gestionar Especializaciones";
            this.gestionarEspecializacionesToolStripMenuItem.Click += new System.EventHandler(this.gestionarEspecializacionesToolStripMenuItem_Click);
            // 
            // tsUsuarios
            // 
            this.tsUsuarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsProfesores,
            this.tsAlumnos,
            this.tsAdministrativos});
            this.tsUsuarios.Image = ((System.Drawing.Image)(resources.GetObject("tsUsuarios.Image")));
            this.tsUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsUsuarios.Name = "tsUsuarios";
            this.tsUsuarios.Size = new System.Drawing.Size(68, 22);
            this.tsUsuarios.Text = "Usuarios";
            this.tsUsuarios.ButtonClick += new System.EventHandler(this.tsUsuarios_ButtonClick);
            // 
            // tsProfesores
            // 
            this.tsProfesores.Name = "tsProfesores";
            this.tsProfesores.Size = new System.Drawing.Size(157, 22);
            this.tsProfesores.Text = "Profesores";
            this.tsProfesores.Click += new System.EventHandler(this.tsProfesores_Click);
            // 
            // tsAlumnos
            // 
            this.tsAlumnos.Name = "tsAlumnos";
            this.tsAlumnos.Size = new System.Drawing.Size(157, 22);
            this.tsAlumnos.Text = "Alumnos";
            this.tsAlumnos.Click += new System.EventHandler(this.tsAlumnos_Click);
            // 
            // tsAdministrativos
            // 
            this.tsAdministrativos.Name = "tsAdministrativos";
            this.tsAdministrativos.Size = new System.Drawing.Size(157, 22);
            this.tsAdministrativos.Text = "Administrativos";
            this.tsAdministrativos.Click += new System.EventHandler(this.tsAdministrativos_Click);
            // 
            // tsCursos
            // 
            this.tsCursos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMaterias,
            this.tsComisiones});
            this.tsCursos.Image = ((System.Drawing.Image)(resources.GetObject("tsCursos.Image")));
            this.tsCursos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsCursos.Name = "tsCursos";
            this.tsCursos.Size = new System.Drawing.Size(59, 22);
            this.tsCursos.Text = "Cursos";
            this.tsCursos.ButtonClick += new System.EventHandler(this.tsCursos_ButtonClick);
            // 
            // tsMaterias
            // 
            this.tsMaterias.Name = "tsMaterias";
            this.tsMaterias.Size = new System.Drawing.Size(189, 22);
            this.tsMaterias.Text = "Gestionar Materias";
            this.tsMaterias.Click += new System.EventHandler(this.tsMaterias_Click);
            // 
            // tsComisiones
            // 
            this.tsComisiones.Name = "tsComisiones";
            this.tsComisiones.Size = new System.Drawing.Size(189, 22);
            this.tsComisiones.Text = "Gestionar Comisiones";
            this.tsComisiones.Click += new System.EventHandler(this.tsComisiones_Click);
            // 
            // Master
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 354);
            this.Controls.Add(this.MenuToolScript);
            this.Name = "Master";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Master";
            this.MenuToolScript.ResumeLayout(false);
            this.MenuToolScript.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip MenuToolScript;
        private System.Windows.Forms.ToolStripSplitButton tsPlanes;
        private System.Windows.Forms.ToolStripMenuItem gestionarPlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionarEspecializacionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton tsUsuarios;
        private System.Windows.Forms.ToolStripMenuItem tsProfesores;
        private System.Windows.Forms.ToolStripMenuItem tsAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsAdministrativos;
        private System.Windows.Forms.ToolStripSplitButton tsCursos;
        private System.Windows.Forms.ToolStripMenuItem tsMaterias;
        private System.Windows.Forms.ToolStripMenuItem tsComisiones;
    }
}