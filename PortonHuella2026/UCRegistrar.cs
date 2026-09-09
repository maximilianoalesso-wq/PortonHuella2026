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
using LectorHuellaZKTeco;

namespace PortonHuella2026
{
    public partial class UCRegistrar : UserControl
    {
        private RepUsuarios _repUsuarios { get; set; }
        private Usuario _usuario { get; set; }
        public UCRegistrar()
        {
            InitializeComponent();
            _repUsuarios = new RepUsuarios();

            //Lector (eventos)
            LectorHuella.HuellaEscaneadaRegistroEvent += this.HuellaEscaneadaRegistro; //se dispara al ir registran las tres capturas de una huella, envía un int indicando cuántas capturas faltan
            LectorHuella.HuellaCapturadaCorrectamenteRegistroEvent += HuellaCatpuradaCorrectamenteRegistro; //se dispara al registrar la huella correctamente luego de 3 capturas, aquí se debe tomar el template
            LectorHuella.HuellaEscaneadaIdentificacionEvent += this.HuellaEscaneadaIdentificacion; // se dispara al identificar huella y envía id del usuario identificado
            LectorHuella.ErrorCapturaHuellaEvent += this.ErrorCapturaHuella; //se dispara al ocurrir cualquier error y envía como parámetro tipo string

            try
            {
                LectorHuella.Inicializar();
            }
            catch 
            {
                MessageBox.Show("No se pudo inicializar el Lector de Huella", "Seguridad de Acceso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<Usuario> usuarios = _repUsuarios.GetAll();
            List<ElementoCache> usuariosCache = new List<ElementoCache>();  
            foreach(Usuario usuario in usuarios)
            {
                if (!string.IsNullOrEmpty(usuario.TemplateHuella))
                    usuariosCache.Add(new ElementoCache() { 
                        id = usuario.Id, 
                        template = usuario.TemplateHuella });
            }
            LectorHuella.CargarCacheLector(usuariosCache);

            LectorHuella.IniciarIdentificacion();
            lbEstadoLector.Text = "Identificando...";
        }

        //manejadores de eventos
        private void HuellaEscaneadaIdentificacion(int id)
        {
            _usuario = _repUsuarios.GetById(id);
            _cargarForm();
        }
        private void ErrorCapturaHuella(string msjError)
        {
            MessageBox.Show("Error", "Se produjo el siguiente error" + msjError);
            LectorHuella.IniciarIdentificacion();
            lbEstadoLector.Text = "Identificando...";
            _limpiarForm();
            this._deshabilitarForm();
        }
        private void HuellaCatpuradaCorrectamenteRegistro(string mensaje)
        {
            //lbEstadoLector.Text = "";
            Action<string> fnEstado = SetEstadoLector;
            this.Invoke(fnEstado, "");
            
            pbHuella.Image = LectorHuella.GetImagenHuella();
            _usuario.TemplateHuella = LectorHuella.GetTemplateHuellaBase64();
            //cbHuella.Checked = true;
            Action<bool> fnCheck = SetCheckHuella;
            this.Invoke(fnCheck, true);

        }

        private void SetCheckHuella(bool val)
        {
            cbHuella.Checked = val;
        }
        public void SetEstadoLector(string estado)
        {
            lbEstadoLector.Text = estado;
        }
        private void HuellaEscaneadaRegistro(int faltan)
        {
            //lbEstadoLector.Text = "Faltan " + faltan + "muestras...";
            string estado = "Faltan " + faltan + "muestras..."; 
            Action<string> fnEstado = SetEstadoLector;
            this.Invoke(fnEstado, estado);
            pbHuella.Image = LectorHuella.GetImagenHuella();
        }


       //botón Nuevo
        private void button1_Click(object sender, EventArgs e)
        {
            _habilitarForm();
            _usuario = new Usuario();
            LectorHuella.IniciarRegistro();
            lbEstadoLector.Text = "Registrando...";
        }

        private void _habilitarForm()
        {
            txtEmail.Enabled = true;
            txtNombre.Enabled = true;
            txtTelefono.Enabled = true;
        }

        private void _deshabilitarForm()
        {
            txtEmail.Enabled = false;
            txtNombre.Enabled = false;
            txtTelefono.Enabled = false;
        }

        private void _limpiarForm()
        {
            txtEmail.Text = "";
            txtNombre.Text = "";
            txtTelefono.Text = "";
            cbHuella.Checked = false;
        }

        private void _cargarForm()
        {
            txtEmail.Text = _usuario.Email;
            txtNombre.Text = _usuario.Nombre;
            txtTelefono.Text = _usuario.Telefono;
            cbHuella.Checked = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!cbHuella.Checked || txtNombre.Text.Trim() == "" || txtEmail.Text.Trim() == "")
            {
                MessageBox.Show("Seguridad de Accesso", "Existen datos obligatorios que deben completarse.");
                return;
            }
            if (_usuario.Id == 0) //usuario nuevo -> POST
            {
                _usuario.Nombre = txtNombre.Text;
                _usuario.Email = txtEmail.Text;
                _usuario.Telefono = txtTelefono.Text;
                _repUsuarios.Post(_usuario);
                MessageBox.Show("Guadado correctamente!");
                _deshabilitarForm();
                _limpiarForm();
                ElementoCache elementoCache = new ElementoCache()
                {
                    id = _usuario.Id,
                    template = _usuario.TemplateHuella
                };
                LectorHuella.AgregarACacheLector(elementoCache);

            }
            else //se está actualizando un usuario existente -> PUT 
            {
                _usuario.Nombre = txtNombre.Text;
                _usuario.Email = txtEmail.Text;
                _usuario.Telefono = txtTelefono.Text;
                _repUsuarios.Put(_usuario);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(_usuario == null || _usuario.Id == 0)
            {
                MessageBox.Show("Debe seleccionar el usuario a eliminar.", "Seguridad de Acceso");
                return; 
            } 
            _repUsuarios.Delete(_usuario);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DialogResult res;
            int idUsuarioSel;
            BuscarUsuarioForm ventBuscar = new BuscarUsuarioForm(_repUsuarios.GetAll());
            res = ventBuscar.ShowDialog();
            if (res == DialogResult.Cancel)
            {
                return;
            }
            //buscar el usuario seleccionado en el repositorio
            //y mostrarlo en el formulario
            idUsuarioSel = ventBuscar.IdUsuarioSeleccionado;
            _usuario = _repUsuarios.GetById(idUsuarioSel);
            _cargarForm();
            _habilitarForm();
        }
    }
}
