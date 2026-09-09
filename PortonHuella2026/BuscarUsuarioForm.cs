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

namespace PortonHuella2026
{
    public partial class BuscarUsuarioForm : Form
    {
        private List<Usuario> _usuarios;
        private int _idUsuarioSeleccionado;
        public int IdUsuarioSeleccionado {
            get 
            {
                return _idUsuarioSeleccionado;
            }
            set
            {
                _idUsuarioSeleccionado = value;
            }
        }
        public BuscarUsuarioForm(List<Usuario> usuarios)
        {
            InitializeComponent();
            _usuarios = usuarios;
            dataGridView1.DataSource = _usuarios.Select(u => new {u.Id, u.Nombre, u.Email}).ToList();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            int filaSel = dataGridView1.CurrentRow.Index;
            if (filaSel == -1)
            {
                MessageBox.Show("Debe seleccionar un usuario.", "Seguridad de Acceso");
                return;
            }
            this.IdUsuarioSeleccionado = Convert.ToInt32(dataGridView1.Rows[filaSel].Cells["ColId"].Value);  
            this.DialogResult= DialogResult.OK;
        }
    }
}
