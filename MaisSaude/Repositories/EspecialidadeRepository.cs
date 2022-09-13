using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;
using System.Linq;

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
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Especialidades.Find(id);
        }

        public void Excluir(Especialidade especialidade)
        {
            throw new System.NotImplementedException();
        }

        public Especialidade Inserir(Especialidade especialidade)
        {
            // Faz a comunicação com o banco
            // Recebe a especialidade como argumento e adiciona no banco
            ctx.Especialidades.Add(especialidade);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna a especialidade
            return especialidade;
        }

        public ICollection<Especialidade> ListarTodos()
        {
            // Converte para Lista de especialidades utilizando o LINQ
            return ctx.Especialidades.ToList();
        }
    }
}
