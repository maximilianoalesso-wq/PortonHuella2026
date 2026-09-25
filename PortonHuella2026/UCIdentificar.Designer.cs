namespace PortonHuella2026
{
    partial class UCIdentificar
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCIdentificar));
            this.lbTemp = new System.Windows.Forms.Label();
            this.lbNombre = new System.Windows.Forms.Label();
            this.lbTitulo = new System.Windows.Forms.Label();
            this.pbIcon = new System.Windows.Forms.PictureBox();
            this.pbHuella = new System.Windows.Forms.PictureBox();
            this.puertoArduino = new System.IO.Ports.SerialPort(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).BeginInit();
            this.SuspendLayout();
            // 
            // lbTemp
            // 
            this.lbTemp.Font = new System.Drawing.Font("Segoe UI", 80F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTemp.Location = new System.Drawing.Point(393, 185);
            this.lbTemp.Name = "lbTemp";
            this.lbTemp.Size = new System.Drawing.Size(97, 156);
            this.lbTemp.TabIndex = 11;
            this.lbTemp.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbNombre
            // 
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(288, 147);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(300, 38);
            this.lbNombre.TabIndex = 10;
            this.lbNombre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTitulo
            // 
            this.lbTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitulo.Location = new System.Drawing.Point(288, 78);
            this.lbTitulo.Name = "lbTitulo";
            this.lbTitulo.Size = new System.Drawing.Size(300, 38);
            this.lbTitulo.TabIndex = 9;
            this.lbTitulo.Text = "CAPTURANDO";
            // 
            // pbIcon
            // 
            this.pbIcon.Location = new System.Drawing.Point(551, 78);
            this.pbIcon.Name = "pbIcon";
            this.pbIcon.Size = new System.Drawing.Size(48, 46);
            this.pbIcon.TabIndex = 7;
            this.pbIcon.TabStop = false;
            // 
            // pbHuella
            // 
            this.pbHuella.Image = ((System.Drawing.Image)(resources.GetObject("pbHuella.Image")));
            this.pbHuella.Location = new System.Drawing.Point(96, 66);
            this.pbHuella.Name = "pbHuella";
            this.pbHuella.Size = new System.Drawing.Size(186, 228);
            this.pbHuella.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbHuella.TabIndex = 6;
            this.pbHuella.TabStop = false;
            // 
            // UCIdentificar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbTemp);
            this.Controls.Add(this.lbNombre);
            this.Controls.Add(this.pbIcon);
            this.Controls.Add(this.pbHuella);
            this.Controls.Add(this.lbTitulo);
            this.Name = "UCIdentificar";
            this.Size = new System.Drawing.Size(653, 408);
            ((System.ComponentModel.ISupportInitialize)(this.pbIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbHuella)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbTemp;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbTitulo;
        private System.Windows.Forms.PictureBox pbIcon;
        private System.Windows.Forms.PictureBox pbHuella;
        private System.IO.Ports.SerialPort puertoArduino;
    }
}
