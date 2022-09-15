using Newtonsoft.Json;
using System;
using System.Collections.Generic;

#nullable disable

namespace MaisSaude.Models
{
    public partial class Especialidade
    {
        public Especialidade()
        {
            Medicos = new HashSet<Medico>();
        }

        public int Id { get; set; }
        public string Categoria { get; set; }

        [JsonIgnore]
        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
