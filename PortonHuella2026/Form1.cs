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
            FinalizarLector();
            UCAjustes uCAjustes = new UCAjustes(this);
            int x = (panelPrincipal.Width - uCAjustes.Width) / 2;
            int y = (panelPrincipal.Height - uCAjustes.Height) / 2;
            uCAjustes.Location = new Point(x, y);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(uCAjustes);
        }

        private void FinalizarLector()
        {
            if (panelPrincipal.Controls.Count > 0) {

                UserControl uc = (UserControl)panelPrincipal.Controls[0];
                if (uc is UCIdentificar)
                {
                    UCIdentificar uci = (UCIdentificar)uc;
                    uci.FinalizarLectorUC();
                }
                if (uc is UCRegistrar)
                {
                    UCRegistrar uci = (UCRegistrar)uc;
                    uci.FinalizarLectorUC();
                }

            }
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
            if (_puertoArduino == "")
            {
                MessageBox.Show("Seleccione el puerto de arduino");
                return;
            }
            FinalizarLector();
            UCRegistrar uCRegistrar = new UCRegistrar();
            int x = (panelPrincipal.Width - uCRegistrar.Width) / 2;
            int y = (panelPrincipal.Height - uCRegistrar.Height) / 2;
            uCRegistrar.Location = new Point(x, y);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(uCRegistrar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_puertoArduino == "")
            {
                MessageBox.Show("Seleccione el puerto de arduino");
                return;
            }
            FinalizarLector();
            UCIdentificar uCIdentificar = new UCIdentificar(_puertoArduino);
            int x = (panelPrincipal.Width - uCIdentificar.Width) / 2;
            int y = (panelPrincipal.Height - uCIdentificar.Height) / 2;
            uCIdentificar.Location = new Point(x, y);
            this.panelPrincipal.Controls.Clear();
            this.panelPrincipal.Controls.Add(uCIdentificar);

        }
    }
}
