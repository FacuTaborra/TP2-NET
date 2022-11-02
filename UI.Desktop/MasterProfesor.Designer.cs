
namespace UI.Desktop
{
    partial class MasterProfesor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MasterProfesor));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbComisiones = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbComisiones});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(577, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbComisiones
            // 
            this.tsbComisiones.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbComisiones.Image = ((System.Drawing.Image)(resources.GetObject("tsbComisiones.Image")));
            this.tsbComisiones.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbComisiones.Name = "tsbComisiones";
            this.tsbComisiones.Size = new System.Drawing.Size(73, 22);
            this.tsbComisiones.Text = "Comisiones";
            this.tsbComisiones.Click += new System.EventHandler(this.tsbComisiones_Click);
            // 
            // MasterProfesor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(577, 346);
            this.Controls.Add(this.toolStrip1);
            this.Name = "MasterProfesor";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbComisiones;
    }
}
