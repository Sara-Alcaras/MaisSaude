using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace MaisSaude.Models
{
    public abstract class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        // [Required] = O campo não pode ser vazio
        // [RegularExpression] = Válida se tem ponto no meio e o @
        // [MinLength(6)] = Define um tamanho minímo

        public int Id { get; set; }
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        [MinLength(6)]
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
