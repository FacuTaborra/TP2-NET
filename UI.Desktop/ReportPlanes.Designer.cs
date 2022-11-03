
namespace UI.Desktop
{
    partial class ReportPlanes
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
            this.rvPlanes = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PlanBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PlanBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rvPlanes
            // 
            this.rvPlanes.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "ReportPlanes";
            reportDataSource1.Value = this.PlanBindingSource;
            this.rvPlanes.LocalReport.DataSources.Add(reportDataSource1);
            this.rvPlanes.LocalReport.ReportEmbeddedResource = "UI.Desktop.ReportPlanes.rdlc";
            this.rvPlanes.Location = new System.Drawing.Point(0, 0);
            this.rvPlanes.Name = "rvPlanes";
            this.rvPlanes.ServerReport.BearerToken = null;
            this.rvPlanes.Size = new System.Drawing.Size(800, 990);
            this.rvPlanes.TabIndex = 0;
            // 
            // PlanBindingSource
            // 
            this.PlanBindingSource.DataSource = typeof(Business.Entities.Plan);
            // 
            // ReportPlanes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 990);
            this.Controls.Add(this.rvPlanes);
            this.Name = "ReportPlanes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ReportPlanes";
            this.Load += new System.EventHandler(this.ReportPlanes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlanBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rvPlanes;
        private System.Windows.Forms.BindingSource PlanBindingSource;
    }
}