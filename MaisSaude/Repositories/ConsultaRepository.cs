using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class ConsultaRepository : IConsultaRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public ConsultaRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Consulta consulta)
        {
            throw new System.NotImplementedException();
        }

        public Consulta BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(Consulta consulta)
        {
            throw new System.NotImplementedException();
        }

        public Consulta Inserir(Consulta consulta)
        {
            // Faz a comunicação com o banco
            // Recebe a consulta como argumento e adiciona no banco
            ctx.Consultas.Add(consulta);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna a consulta
            return consulta;
        }

        public ICollection<Consulta> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
