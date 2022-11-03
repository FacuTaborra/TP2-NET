
namespace UI.Desktop
{
    partial class ReportCursos
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.CursoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rvCursos = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.CursoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // CursoBindingSource
            // 
            this.CursoBindingSource.DataSource = typeof(Business.Entities.Curso);
            // 
            // rvCursos
            // 
            this.rvCursos.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReportCursos";
            reportDataSource1.Value = this.CursoBindingSource;
            this.rvCursos.LocalReport.DataSources.Add(reportDataSource1);
            this.rvCursos.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportCursos.rdlc";
            this.rvCursos.Location = new System.Drawing.Point(0, 0);
            this.rvCursos.Name = "rvCursos";
            this.rvCursos.ServerReport.BearerToken = null;
            this.rvCursos.Size = new System.Drawing.Size(800, 894);
            this.rvCursos.TabIndex = 0;
            // 
            // ReportCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 894);
            this.Controls.Add(this.rvCursos);
            this.Name = "ReportCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportCursos";
            this.Load += new System.EventHandler(this.ReportCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CursoBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvCursos;
        private System.Windows.Forms.BindingSource CursoBindingSource;
    }
}