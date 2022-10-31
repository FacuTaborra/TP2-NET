
namespace UI.Desktop
{
    partial class MasterAlumno
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterAlumno));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tl = new System.Windows.Forms.ToolStripSplitButton();
            this.materiasDelPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoAcademicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.inscripcionACursadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inscripcionAExamenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tl,
            this.toolStripSplitButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(758, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tl
            // 
            this.tl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tl.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.materiasDelPlanToolStripMenuItem,
            this.estadoAcademicoToolStripMenuItem});
            this.tl.Image = ((System.Drawing.Image)(resources.GetObject("tl.Image")));
            this.tl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tl.Name = "tl";
            this.tl.Size = new System.Drawing.Size(105, 22);
            this.tl.Text = "Plan De Estudio";
            // 
            // materiasDelPlanToolStripMenuItem
            // 
            this.materiasDelPlanToolStripMenuItem.Name = "materiasDelPlanToolStripMenuItem";
            this.materiasDelPlanToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.materiasDelPlanToolStripMenuItem.Text = "Materias Del Plan";
            this.materiasDelPlanToolStripMenuItem.Click += new System.EventHandler(this.materiasDelPlanToolStripMenuItem_Click);
            // 
            // estadoAcademicoToolStripMenuItem
            // 
            this.estadoAcademicoToolStripMenuItem.Name = "estadoAcademicoToolStripMenuItem";
            this.estadoAcademicoToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.estadoAcademicoToolStripMenuItem.Text = "Estado Academico";
            this.estadoAcademicoToolStripMenuItem.Click += new System.EventHandler(this.estadoAcademicoToolStripMenuItem_Click);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inscripcionACursadoToolStripMenuItem,
            this.inscripcionAExamenToolStripMenuItem});
            this.toolStripSplitButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripSplitButton1.Image")));
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(92, 22);
            this.toolStripSplitButton1.Text = "Inscripciones";
            // 
            // inscripcionACursadoToolStripMenuItem
            // 
            this.inscripcionACursadoToolStripMenuItem.Name = "inscripcionACursadoToolStripMenuItem";
            this.inscripcionACursadoToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.inscripcionACursadoToolStripMenuItem.Text = "Inscripcion a Cursado";
            this.inscripcionACursadoToolStripMenuItem.Click += new System.EventHandler(this.inscripcionACursadoToolStripMenuItem_Click);
            // 
            // inscripcionAExamenToolStripMenuItem
            // 
            this.inscripcionAExamenToolStripMenuItem.Name = "inscripcionAExamenToolStripMenuItem";
            this.inscripcionAExamenToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.inscripcionAExamenToolStripMenuItem.Text = "Inscripcion a Examen";
            // 
            // MasterAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 406);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MasterAlumno";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasterAlumno";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSplitButton tl;
        private System.Windows.Forms.ToolStripMenuItem materiasDelPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem estadoAcademicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.Windows.Forms.ToolStripMenuItem inscripcionACursadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inscripcionAExamenToolStripMenuItem;
    }
}