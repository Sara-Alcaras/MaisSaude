using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;
using System.Linq;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class MedicoRepository : IMedicoRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public MedicoRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Medico medico)
        {
            throw new System.NotImplementedException();
        }

        public Medico BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Medicos.Find(id);
        }

        public void Excluir(Medico medico)
        {
            throw new System.NotImplementedException();
        }

        public Medico Inserir(Medico medico)
        {
            // Faz a comunicação com o banco
            // Recebe o medico como argumento e adiciona no banco
            ctx.Medicos.Add(medico);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna o medico
            return medico;
        }

        public ICollection<Medico> ListarTodos()
        {
            // Converte para Lista de medicos utilizando o LINQ
            return ctx.Medicos.ToList();
        }
    }
}
