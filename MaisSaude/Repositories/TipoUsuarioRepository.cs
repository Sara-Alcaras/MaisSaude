using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public TipoUsuarioRepository(MaisSaudeContext _ctx)
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
            // Faz a comunicação com o banco
            // Recebe o tipo de usuário como argumento e adiciona no banco
            ctx.TipoUsuarios.Add(tipoUsuario);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna o tipo do usuário
            return tipoUsuario;
        }

        public ICollection<TipoUsuario> ListarTodos()
        {
            throw new System.NotImplementedException();
        }
    }
}
