using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;


namespace PortonHuella2026
{
    public partial class UCAjustes : UserControl
    {
        PrincipalForm formPrincipal;
        SerialPort puertoArduino;
        public UCAjustes(PrincipalForm fp)
        {
            InitializeComponent();
            formPrincipal = fp;
            foreach (string puerto in SerialPort.GetPortNames()) {
                cbPuertos.Items.Add(puerto);
            }
            if (cbPuertos.Items.Count > 0)
            {
                cbPuertos.SelectedIndex = 0;
            }
        }

        ~UCAjustes() //destructor
        {
            MessageBox.Show("Destructor"); //borrar esta linea
            if (puertoArduino.IsOpen) 
                puertoArduino.Close();
        }
            
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            formPrincipal.PuertoArduino = cbPuertos.SelectedItem.ToString();
        }

        private void btnAbrirPuerto_Click(object sender, EventArgs e)
        {
            puertoArduino = new SerialPort(cbPuertos.SelectedItem.ToString());
            puertoArduino.BaudRate = 9600;
            puertoArduino.Parity = Parity.None;
            puertoArduino.StopBits = StopBits.One;
            puertoArduino.DataBits = 8;
            puertoArduino.Handshake = Handshake.None;
            puertoArduino.RtsEnable = true;

            try
            {
                puertoArduino.Open();
                lbEstadoPuerto.Text = "Puerto abierto";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnCerrarPuerto_Click(object sender, EventArgs e)
        {
            puertoArduino.Close();
            lbEstadoPuerto.Text = "Puerto cerrado";
        }

        private void btnAbrirPorton_Click(object sender, EventArgs e)
        {
            puertoArduino.WriteLine("open");
        }

        private void btnCerrarPorton_Click(object sender, EventArgs e)
        {
            puertoArduino.WriteLine("close");
        }
    }
}
