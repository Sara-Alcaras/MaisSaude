using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface IConsultaRepository
    {
        //CRUD
        Consulta Inserir(Consulta consulta);

        // Coleção de consulta - listar
        ICollection<Consulta> ListarTodos();

        // Retornar consulta quando buscar por id
        Consulta BuscarPorId(int id);

        // Não retornar nada(void) quando alterar uma consulta
        void Alterar(Consulta consulta);

        void Excluir(Consulta consulta);
    }
}
