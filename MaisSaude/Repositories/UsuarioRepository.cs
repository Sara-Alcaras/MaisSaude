﻿using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
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
            throw new System.NotImplementedException();
        }

        public Usuario BuscarPorId(int id)
        {
            // Retorna utilizando linq com a expressão lambda 
            return ctx.Usuarios.Find(id);
        }

        public void Excluir(Usuario usuario)
        {
            throw new System.NotImplementedException();
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
