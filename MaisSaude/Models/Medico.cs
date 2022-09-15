using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MaisSaude.Models
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int Id { get; set; }
        public string Crm { get; set; }
        public int? IdEspecialidade { get; set; }
        public int? IdUsuario { get; set; }

        [JsonIgnore]
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        [JsonIgnore]
        public virtual Usuario IdUsuarioNavigation { get; set; }

        [JsonIgnore]
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
