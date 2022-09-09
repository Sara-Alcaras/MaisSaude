using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public EspecialidadeRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public Especialidade BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public Especialidade Inserir(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Especialidade> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
