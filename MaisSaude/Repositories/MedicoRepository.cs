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
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(medico).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchMedico, Medico medico)
        {
            // Pega apenas o que foi alterado
            patchMedico.ApplyTo(medico);
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(medico).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public Medico BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Medicos.Find(id);
        }

        public void Excluir(Medico medico)
        {
            // Utiliza o linq para pegar o id
            var medicoConstraints = ctx.Medicos.Where(m => m.Id == medico.Id).Include(c => c.Consulta).First();
            var medicoConstraintsConstraintss = ctx.Medicos.Where(m => m.Id == medico.Id);

            ctx.Remove(medicoConstraints);
            ctx.SaveChanges();
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
            // Converte para Lista de medicos utilizando o LINQ
            return ctx.Medicos.ToList();
        }
    }
}
