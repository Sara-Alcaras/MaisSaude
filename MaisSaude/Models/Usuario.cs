using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace MaisSaude.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int? IdTipoUsuario { get; set; }

        [JsonIgnore]
        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        [JsonIgnore]
        public virtual ICollection<Medico> Medicos { get; set; }
        [JsonIgnore]
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
