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
    public class ConsultaRepository : IConsultaRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public ConsultaRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Consulta consulta)
        {
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(consulta).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchConsulta, Consulta consulta)
        {
            // Pega apenas o que foi alterado
            patchConsulta.ApplyTo(consulta);
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(consulta).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Consultas.Find(id);
        }

        public void Excluir(Consulta consulta)
        {
            ctx.Consultas.Remove(consulta);
            ctx.SaveChanges();
        }

        public Consulta Inserir(Consulta consulta)
        {
            // Faz a comunicação com o banco
            // Recebe a consulta como argumento e adiciona no banco
            ctx.Consultas.Add(consulta);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna a consulta
            return consulta;
        }

        public ICollection<Consulta> ListarTodos()
        {
            // Converte para Lista de consultas utilizando o LINQ
            return ctx.Consultas.ToList();
        }
    }
}
