using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface ITipoUsuarioRepository
    {

        //CRUD
        TipoUsuario Inserir(TipoUsuario tipoUsuario);
        
        // Coleção de tipo de usuarios
        ICollection<TipoUsuario> ListarTodos();

        // Retornar o tipo de usuário quando buscar por id
        TipoUsuario BuscarPorId(int id);

        // Não retornar nada(void quando alterar um tipo de usuário)
        void Alterar(TipoUsuario tipoUsuario);

        void Excluir(TipoUsuario tipoUsuario);
    }
}
