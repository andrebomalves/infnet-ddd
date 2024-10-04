using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infnet.Ecommerce.Usuario.Dominio.Entidades
{
    public class Usuario
    {
		private Guid? usuarioId;

        public Usuario()
        {
            this.UsuarioId = Guid.NewGuid();
        }

        public Usuario(string nome, string email)
        {
            this.UsuarioId = Guid.NewGuid();
        }

        public Usuario(Guid? usuarioId, string nome, string email)
        {
            this.UsuarioId=usuarioId;
            this.Nome=nome;
            this.Email=email;
        }
        public Guid? UsuarioId
		{
			get { return usuarioId; }
			set { usuarioId = string.IsNullOrEmpty(value.ToString()) ? Guid.NewGuid() : value ; }
		}

        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public string UsuarioIdString
        {
            set { this.UsuarioId = Guid.Parse(value); }
            get { return this.UsuarioId.ToString(); }
        }
    }
}
