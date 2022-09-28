using MaisSaude.Data;
using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace MaisSaude.Repositories
{
    // Recebe a interface
    public class LoginRepository : ILoginRepository
    {
        // Injeção de dependência e Metodo Construtor
        MaisSaudeContext ctx;
        public LoginRepository(MaisSaudeContext _ctx)
        {
            ctx = _ctx;
        }

        // Implementação dos métodos
        public string Logar(string email, string senha)
        {
            // Verifica se existe um usuário com email
            var usuario = ctx.Usuarios
                .Include(u => u.IdTipoUsuarioNavigation)
                .FirstOrDefault(x => x.Email == email);

            // Se existir usuário(for diferente de nulo)
            if (usuario != null && usuario.Senha != null)
            {
                // Confere se a senha do argumento é igual do banco usuario.Senha
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Senha);
                if (validPassword)
                {
                    // Definir as Claims
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, usuario.IdTipoUsuarioNavigation.Tipo.ToString())
                    };

                    // Criar as chaves
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("maisSaude-chave-autenticacao"));

                    // Criar as credencias com JWT
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Gera o token
                    var meuToken = new JwtSecurityToken(
                        issuer: "maisSaude.webAPI",
                        audience: "maisSaude.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );
                    // retorna o token em formato de string
                    return new JwtSecurityTokenHandler().WriteToken(meuToken);
                }
            }
            return null;
        }

    }
}
