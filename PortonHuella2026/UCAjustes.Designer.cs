namespace PortonHuella2026
{
    partial class UCAjustes
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
            this.label1 = new System.Windows.Forms.Label();
            this.cbPuertos = new System.Windows.Forms.ComboBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.lbEstadoPuerto = new System.Windows.Forms.Label();
            this.btnAbrirPuerto = new System.Windows.Forms.Button();
            this.btnCerrarPuerto = new System.Windows.Forms.Button();
            this.btnAbrirPorton = new System.Windows.Forms.Button();
            this.btnCerrarPorton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Puerto Arduino";
            // 
            // cbPuertos
            // 
            this.cbPuertos.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPuertos.FormattingEnabled = true;
            this.cbPuertos.Location = new System.Drawing.Point(30, 50);
            this.cbPuertos.Name = "cbPuertos";
            this.cbPuertos.Size = new System.Drawing.Size(156, 32);
            this.cbPuertos.TabIndex = 1;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnSeleccionar.FlatAppearance.BorderSize = 3;
            this.btnSeleccionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeleccionar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.Location = new System.Drawing.Point(213, 45);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(150, 43);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // lbEstadoPuerto
            // 
            this.lbEstadoPuerto.AutoSize = true;
            this.lbEstadoPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstadoPuerto.Location = new System.Drawing.Point(31, 100);
            this.lbEstadoPuerto.Name = "lbEstadoPuerto";
            this.lbEstadoPuerto.Size = new System.Drawing.Size(143, 24);
            this.lbEstadoPuerto.TabIndex = 3;
            this.lbEstadoPuerto.Text = "Puerto: Cerrado";
            // 
            // btnAbrirPuerto
            // 
            this.btnAbrirPuerto.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAbrirPuerto.FlatAppearance.BorderSize = 3;
            this.btnAbrirPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPuerto.Location = new System.Drawing.Point(34, 140);
            this.btnAbrirPuerto.Name = "btnAbrirPuerto";
            this.btnAbrirPuerto.Size = new System.Drawing.Size(150, 43);
            this.btnAbrirPuerto.TabIndex = 4;
            this.btnAbrirPuerto.Text = "Abrir Puerto";
            this.btnAbrirPuerto.UseVisualStyleBackColor = true;
            this.btnAbrirPuerto.Click += new System.EventHandler(this.btnAbrirPuerto_Click);
            // 
            // btnCerrarPuerto
            // 
            this.btnCerrarPuerto.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCerrarPuerto.FlatAppearance.BorderSize = 3;
            this.btnCerrarPuerto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPuerto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPuerto.Location = new System.Drawing.Point(213, 140);
            this.btnCerrarPuerto.Name = "btnCerrarPuerto";
            this.btnCerrarPuerto.Size = new System.Drawing.Size(150, 43);
            this.btnCerrarPuerto.TabIndex = 5;
            this.btnCerrarPuerto.Text = "Cerrar Puerto";
            this.btnCerrarPuerto.UseVisualStyleBackColor = true;
            this.btnCerrarPuerto.Click += new System.EventHandler(this.btnCerrarPuerto_Click);
            // 
            // btnAbrirPorton
            // 
            this.btnAbrirPorton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnAbrirPorton.FlatAppearance.BorderSize = 3;
            this.btnAbrirPorton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbrirPorton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbrirPorton.Location = new System.Drawing.Point(34, 205);
            this.btnAbrirPorton.Name = "btnAbrirPorton";
            this.btnAbrirPorton.Size = new System.Drawing.Size(150, 43);
            this.btnAbrirPorton.TabIndex = 6;
            this.btnAbrirPorton.Text = "Abrir Porton";
            this.btnAbrirPorton.UseVisualStyleBackColor = true;
            this.btnAbrirPorton.Click += new System.EventHandler(this.btnAbrirPorton_Click);
            // 
            // btnCerrarPorton
            // 
            this.btnCerrarPorton.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnCerrarPorton.FlatAppearance.BorderSize = 3;
            this.btnCerrarPorton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarPorton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarPorton.Location = new System.Drawing.Point(213, 205);
            this.btnCerrarPorton.Name = "btnCerrarPorton";
            this.btnCerrarPorton.Size = new System.Drawing.Size(150, 43);
            this.btnCerrarPorton.TabIndex = 7;
            this.btnCerrarPorton.Text = "Cerrar Porton";
            this.btnCerrarPorton.UseVisualStyleBackColor = true;
            this.btnCerrarPorton.Click += new System.EventHandler(this.btnCerrarPorton_Click);
            // 
            // UCAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnCerrarPorton);
            this.Controls.Add(this.btnAbrirPorton);
            this.Controls.Add(this.btnCerrarPuerto);
            this.Controls.Add(this.btnAbrirPuerto);
            this.Controls.Add(this.lbEstadoPuerto);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.cbPuertos);
            this.Controls.Add(this.label1);
            this.Name = "UCAjustes";
            this.Size = new System.Drawing.Size(631, 330);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPuertos;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Label lbEstadoPuerto;
        private System.Windows.Forms.Button btnAbrirPuerto;
        private System.Windows.Forms.Button btnCerrarPuerto;
        private System.Windows.Forms.Button btnAbrirPorton;
        private System.Windows.Forms.Button btnCerrarPorton;
    }
}
