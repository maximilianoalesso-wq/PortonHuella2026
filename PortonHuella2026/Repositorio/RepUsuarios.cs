using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace PortonHuella2026.Repositorio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string TemplateHuella { get; set; }
    }
    public class RepUsuarios
    {
        private List<Usuario> _usuarios;
        private int? _proxID; //primary key
        const string ARCHIVO = "usuarios.json";

        public RepUsuarios()
        {
            if (!File.Exists(ARCHIVO))
                File.WriteAllText(ARCHIVO, "[]");
            string contenido = File.ReadAllText(ARCHIVO);
            _usuarios = JsonSerializer.Deserialize<List<Usuario>>(contenido);
            if  (_usuarios.Count > 0)
            {
                _proxID = _usuarios.Max(u => u.Id);
            }
            if (_proxID == null)
                _proxID = 0;
            _proxID++;
        }

        public List<Usuario> GetAll()
        { 
            return _usuarios; 
        }

        public Usuario GetById(int id) 
        { 
        
            return _usuarios.Where(u => u.Id == id).FirstOrDefault();  
        }

        public void Post(Usuario usuario)
        {
            usuario.Id = _proxID.Value;
            _proxID++;
            _usuarios.Add(usuario);
            guardarDatos();
        }
        void guardarDatos()
        {
            string contenido = JsonSerializer.Serialize(_usuarios);
            File.WriteAllText(ARCHIVO, contenido);
        }

        public void Put(Usuario usuario) 
        {
            guardarDatos();
        }
        public void Delete(Usuario usuario)
        {
            _usuarios.Remove(usuario);
            guardarDatos();
        }
    }
}
