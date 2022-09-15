using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class PacienteRepository : IPacienteRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public PacienteRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Paciente paciente)
        {
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(paciente).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchPaciente, Paciente paciente)
        {
            // Pega apenas o que foi alterado
            patchPaciente.ApplyTo(paciente);
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(paciente).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public Paciente BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Pacientes.Find(id);
        }

        public void Excluir(Paciente paciente)
        {
            // Utiliza o linq para pegar o id
            var pacienteConstraints = ctx.Pacientes.Where(p => p.Id == paciente.Id).Include(c => c.Consulta).First();
            var pacienteConstraintss = ctx.Pacientes.Where(p => p.Id == paciente.Id);

            ctx.Remove(pacienteConstraints);
            ctx.SaveChanges();
        }

        public Paciente Inserir(Paciente paciente)
        {
            // Faz a comunicação com o banco
            // Recebe o paciente como argumento e adiciona no banco
            ctx.Pacientes.Add(paciente);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna o paciente
            return paciente;
        }

        public ICollection<Paciente> ListarTodos()
        {
            // Converte para Lista de paciente utilizando o LINQ
            return ctx.Pacientes.ToList();
        }
    }
}
