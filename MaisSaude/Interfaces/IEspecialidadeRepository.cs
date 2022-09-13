using MaisSaude.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface IEspecialidadeRepository
    {
        //CRUD
         Especialidade Inserir(Especialidade especialidade);

        // Coleção de especialidade - listar
        ICollection<Especialidade> ListarTodos();

        // Retornar especialidade quando buscar por id
        Especialidade BuscarPorId(int id);

        // Não retornar nada(void) quando alterar uma especialidade
        void Alterar(Especialidade especialidade);

        void Excluir(Especialidade especialidade);

        void AlterarParcialmente(JsonPatchDocument patchEspecialidade, Especialidade especialidade);
    }
}
