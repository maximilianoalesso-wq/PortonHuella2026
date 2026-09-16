using LectorHuellaZKTeco;
using PortonHuella2026.Repositorio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using System.Threading;
using System.IO.Ports;

namespace PortonHuella2026
{
    public partial class UCIdentificar : UserControl
    {
        private RepUsuarios _repUsuarios { get; set; }
        private Usuario _usuario { get; set; }
        private bool _lectorInicializado = false;
        private string _puertoArduino = "";
        private Timer _tContador = new Timer();
        private int _contador = 0;
        public UCIdentificar(string puertoArduino)
        {
            InitializeComponent();
            _repUsuarios = new RepUsuarios();

            //Lector (eventos)
            LectorHuella.HuellaEscaneadaIdentificacionEvent += this.HuellaEscaneadaIdentificacion; // se dispara al identificar huella y envía id del usuario identificado
            LectorHuella.ErrorCapturaHuellaEvent += this.ErrorCapturaHuella; //se dispara al ocurrir cualquier error y envía como parámetro tipo string
            try
            {
                LectorHuella.Inicializar();
                _lectorInicializado = true;
            }
            catch
            {
                MessageBox.Show("No se pudo inicializar el Lector de Huella", "Seguridad de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _puertoArduino = puertoArduino;
            AbrirPuerto();
            _tContador.Interval = 1000;
            _tContador.Tick += this._eventoTickTimerContador;
            List<Usuario> usuarios = _repUsuarios.GetAll();
            List<ElementoCache> usuariosCache = new List<ElementoCache>();
            foreach (Usuario usuario in usuarios)
            {
                if (!string.IsNullOrEmpty(usuario.TemplateHuella))
                    usuariosCache.Add(new ElementoCache()
                    {
                        id = usuario.Id,
                        template = usuario.TemplateHuella
                    });
            }
            LectorHuella.CargarCacheLector(usuariosCache);

            LectorHuella.IniciarIdentificacion();
        }

        private void _eventoTickTimerContador(object sender, EventArgs e)
        {
            _contador++;
            if (_contador == 0)
            {
                lbTemp.Text = "";
                _tContador.Stop();
                CerrarPorton();
                lbNombre.Text = "";
                lbTitulo.Text = "CAPTURANDO";
            }
            else
            {
                lbTemp.Text = _contador.ToString();
            }
        }

        private void ErrorCapturaHuella(string msjError)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep_error.wav");
            player.Play();
            Action _errorF = ErrorCaptura;
            this.Invoke(_errorF);

        }

        void ErrorCaptura()
        {
            lbTitulo.Text = "ACCESO DENEGADO";
            lbNombre.Text = "Regístrese, por favor.";
            System.Threading.Thread.Sleep(3000);
            lbTitulo.Text = "CAPTURANDO";
            lbNombre.Text = "";

        }

        private void HuellaEscaneadaIdentificacion(int id)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep1.wav");
            player.Play();
            _usuario = _repUsuarios.GetById(id);
            Action _acceso = setTitulosAccesoConcedido;
         this.Invoke(_acceso);
            Action _abrir = AbrirPorton;
            this.Invoke(_abrir);

        }

        void setTitulosAccesoConcedido()
        {
            lbTitulo.Text = "ACCESO CONCEDIDO!!!";
            lbNombre.Text = _usuario.Nombre;
            _tContador.Start();
        }
    void AbrirPorton()
        {
            puertoArduino.WriteLine("open");
            _tContador.Start();
        }

        void CerrarPorton()
        {
            puertoArduino.WriteLine("close");
        }

        void AbrirPuerto()
        {
            puertoArduino = new SerialPort(_puertoArduino);
            puertoArduino.BaudRate = 9600;
            puertoArduino.Parity = Parity.None;
            puertoArduino.StopBits = StopBits.One;
            puertoArduino.DataBits = 8;
            puertoArduino.Handshake = Handshake.None;
            puertoArduino.RtsEnable = true;
            try
            {
                puertoArduino.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir el puerto.");
            }
        }
    }
}