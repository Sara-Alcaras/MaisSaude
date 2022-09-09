﻿using System;
using System.Collections.Generic;

#nullable disable

namespace MaisSaude.Models
{
    public partial class Consulta
    {
        public int Id { get; set; }
        public DateTime? DataHora { get; set; }
        public int? IdMedico { get; set; }
        public int? IdPaciente { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
    }
}
