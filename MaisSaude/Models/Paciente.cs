using System;
using System.Collections.Generic;

#nullable disable

namespace MaisSaude.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Carteirinha { get; set; }
        public DateTime? DataNascimento { get; set; }
        public bool? Ativo { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
