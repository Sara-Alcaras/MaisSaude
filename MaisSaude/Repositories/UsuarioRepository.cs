using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class UsuarioRepository : IUsuarioRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public UsuarioRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public void Alterar(Usuario usuario)
        {
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(usuario).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public void AlterarParcialmente(JsonPatchDocument patchUsuario, Usuario usuario)
        {
            // Pega apenas o que foi alterado
            patchUsuario.ApplyTo(usuario);
            // Verifica se existe modificação utilizando a biblioteca do entity
            ctx.Entry(usuario).State = EntityState.Modified;
            // Salva as alterações
            ctx.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Usuarios.Find(id);
        }

        public void Excluir(Usuario usuario)
        {
            // Utiliza o linq para pegar o id do usuário e do paciente
            var usuarioConstraints = ctx.Usuarios.Where(u => u.Id == usuario.Id).Include(p => p.Pacientes).First();
            var usuarioConstraintss = ctx.Usuarios.Where(u => u.Id == usuario.Id);

            ctx.Remove(usuarioConstraints);
            ctx.SaveChanges();
        }

        public Usuario Inserir(Usuario usuario)
        {
            // Faz a comunicação com o banco
            // Recebe o usuário como argumento e adiciona no banco
            ctx.Usuarios.Add(usuario);

            // Salva as alterações no banco
            ctx.SaveChanges();

            // Retorna o usuário
            return usuario;
        }

        public ICollection<Usuario> ListarTodos()
        {
            // Converte para Lista de usuários utilizando o LINQ
            return ctx.Usuarios.ToList();
        }
    }
}
