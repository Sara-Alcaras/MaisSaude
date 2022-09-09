using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class PacienteRepository : IPacienteRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public PacienteRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Paciente BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public Paciente Inserir(Paciente paciente)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Paciente> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
