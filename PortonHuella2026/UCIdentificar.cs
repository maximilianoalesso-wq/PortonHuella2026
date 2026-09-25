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
using System.Diagnostics.Eventing.Reader;

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
        private Timer _tCapturando = new Timer();
        private Timer _tHuella = new Timer();

        private int _anchoOriginalHuella;
        private int _altoOriginalHuella;
        private int _xOriginalHuella;
        private int _yOriginalHuella;
        private int _radianes = 0;

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
            _tCapturando.Interval = 500;
            _tCapturando.Tick += this._eventoTickTimerCapturando;
            _tCapturando.Start();
            _tHuella.Interval = 30;
            _tHuella.Tick += this._eventoTickTimerHuella;
            _tHuella.Start();
            _anchoOriginalHuella = pbHuella.Width;
            _altoOriginalHuella = pbHuella.Height;
            _xOriginalHuella = pbHuella.Location.X;
            _yOriginalHuella = pbHuella.Location.Y;
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

        private void _eventoTickTimerHuella(object sender, EventArgs e)
        {
            double factor = 1f + 0.03f * Math.Sin(_radianes * 2f * Math.PI / 20);
            pbHuella.Width = (int)(_anchoOriginalHuella * factor);
            pbHuella.Height = (int)(_altoOriginalHuella * factor);
            int x = (int)(_anchoOriginalHuella - pbHuella.Width) / 2;
            int y = (int)(_altoOriginalHuella - pbHuella.Height) / 2;
            pbHuella.Location = new Point(x, y);

            if (_radianes == 20)
                _radianes = 0;
            else
                _radianes++;
        }   

            private void _eventoTickTimerCapturando(object sender, EventArgs e)
        {
            if (lbTitulo.Text.StartsWith("CAPTURANDO"))
            {
                char[] titulo = lbTitulo.Text.ToCharArray();
                char[] puntos = titulo.Where(x => x == '.').ToArray();
                int cantPuntos = puntos.Length;
                if (cantPuntos >= 3)
                {
                    lbTitulo.Text = "CAPTURANDO";
                    pbIcon.Image = null;

                }
                else
                {
                    lbTitulo.Text += ".";
                }
            }

        }

        public void FinalizarLectorUC()
        {
            LectorHuella.HuellaEscaneadaIdentificacionEvent -= this.HuellaEscaneadaIdentificacion; // se dispara al identificar huella y envía id del usuario identificado
            LectorHuella.ErrorCapturaHuellaEvent -= this.ErrorCapturaHuella; //se dispara al ocurrir cualquier error y envía como parámetro tipo string
            LectorHuella.Finalizar();
        }

        private void _eventoTickTimerContador(object sender, EventArgs e)
        {
            _contador++;
            if (_contador == 9)
            {
                lbTemp.Text = "";
                _tContador.Stop();
                CerrarPorton();
                lbNombre.Text = "";
                lbTitulo.Text = "CAPTURANDO";
                _contador = 0;
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
            string path = Application.StartupPath + "\\x-circle.png";
            Image image = Image.FromFile(path);
            pbIcon.Image = image;
            Action _errorF = ErrorCaptura;
            this.Invoke(_errorF);

        }

        void ErrorCaptura()
        {
            lbTitulo.Text = "ACCESO DENEGADO";
            lbNombre.Text = "Regístrese, por favor.";
            string path = Application.StartupPath + "\\x-circle.png";
            Image image = Image.FromFile(path);
            pbIcon.Image = image;
            Application.DoEvents();
            System.Threading.Thread.Sleep(3000);
            lbTitulo.Text = "CAPTURANDO";
            lbNombre.Text = "";
            pbIcon.Image = null;

        }

        private void HuellaEscaneadaIdentificacion(int id)
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer("beep1.wav");
            player.Play();
            if (id != -1)
            {
                _usuario = _repUsuarios.GetById(id);
                Action _acceso = setTitulosAccesoConcedido;
                this.Invoke(_acceso);
                Action _abrir = AbrirPorton;
                this.Invoke(_abrir);

            }
            else
            {
                Action _error = ErrorCaptura;
                this.Invoke(_error);
            }
        }

        void setTitulosAccesoConcedido()
        {
            string path = Application.StartupPath + "\\check-circle.png";
            Image image = Image.FromFile(path);
            pbIcon.Image = image;
            lbTitulo.Text = "ACCESO CONCEDIDO!!!";
            lbNombre.Text = "Bienvenido" + _usuario.Nombre;
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