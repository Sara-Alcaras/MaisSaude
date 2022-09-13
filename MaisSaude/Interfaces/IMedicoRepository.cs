using MaisSaude.Models;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface IMedicoRepository
    {
        //CRUD
        Medico Inserir(Medico medico);

        // Coleção de medico - listar
        ICollection<Medico> ListarTodos();

        // Retornar medico quando buscar por id
        Medico BuscarPorId(int id);

        // Não retornar nada(void) quando alterar os dados de um medico
        void Alterar(Medico medico);

        void Excluir(Medico medico);
        void AlterarParcialmente(JsonPatchDocument patchMedico, Medico medico);
    }
}
