using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class TipoUsiarioRepository : ITipoUsuarioRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public TipoUsiarioRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Excluir(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
        }

        public TipoUsuario Inserir(TipoUsuario tipoUsuario)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<TipoUsuario> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
