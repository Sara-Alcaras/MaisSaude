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
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(tipoUsuario).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchTipoUsuario, TipoUsuario tipoUsuario)
        {
            // Pega apenas o que foi alterado
            patchTipoUsuario.ApplyTo(tipoUsuario);
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(tipoUsuario).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public TipoUsuario BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.TipoUsuarios.Find(id);
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
            // Converte para Lista de tipo de usuário utilizando o LINQ
            return ctx.TipoUsuarios.ToList();
        }
    }
}
