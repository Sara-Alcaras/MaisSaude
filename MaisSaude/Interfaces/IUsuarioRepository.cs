using MaisSaude.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface IUsuarioRepository
    {
        //CRUD
        Usuario Inserir(Usuario usuario);

        // Coleção de usuário - listar
        ICollection<Usuario> ListarTodos();

        // Retornar usuário quando buscar por id
        Usuario BuscarPorId(int id);

        // Não retornar nada(void) quando alterar um usuário
        void Alterar(Usuario usuario);

        void Excluir(Usuario usuario);
        void AlterarParcialmente(JsonPatchDocument patchUsuario, Usuario usuario);
    }
}
