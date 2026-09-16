using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PortonHuella2026
{
    public partial class PrincipalForm : Form
    {
        private string _puertoArduino = "";
        public PrincipalForm()
        {
            InitializeComponent();
        }

        
        public string PuertoArduino
        {
            get { return _puertoArduino; }
            set
            {
                _puertoArduino = value;
                this.slPuertoArduino.Text = "Puerto Arduino: " + _puertoArduino;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("¿Está seguro que desea salir?", "Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAjuste_Click(object sender, EventArgs e)
        {
            UCAjustes uCAjustes = new UCAjustes(this);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(uCAjustes);
        }

        private void PrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("¿Está seguro que desea salir?", "Seguridad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            UCIdentificar uCIdentificar = new UCIdentificar(_puertoArduino);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(uCIdentificar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UCIdentificar uCRegistrar = new UCIdentificar(_puertoArduino);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(uCRegistrar);

        }
    }
}
