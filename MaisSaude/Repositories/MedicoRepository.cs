using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
