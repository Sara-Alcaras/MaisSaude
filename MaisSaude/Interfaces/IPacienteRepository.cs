using MaisSaude.Models;
using System.Collections.Generic;

namespace MaisSaude.Interfaces
{
    public interface IPacienteRepository
    {
        //CRUD
        Paciente Inserir(Paciente paciente);

        // Coleção de paciente - listar
        ICollection<Paciente> ListarTodos();

        // Retornar paciente quando buscar por id
        Paciente BuscarPorId(int id);

        // Não retornar nada(void) quando alterar os dados de um paciente
        void Alterar(Paciente paciente);

        void Excluir(Paciente paciente);
    }
}
