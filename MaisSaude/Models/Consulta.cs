using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace MaisSaude.Models
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public DateTime? DataHora { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }

        [JsonIgnore]
        public virtual Medico IdMedicoNavigation { get; set; }

        [JsonIgnore]
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
