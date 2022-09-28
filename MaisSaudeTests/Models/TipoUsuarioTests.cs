using MaisSaude.Models;
using Xunit;

namespace MaisSaudeTests.Models
{
    public class TipoUsuarioTests
    {
        [Fact]
        public void TestUsuarioNotNull()
        {
            // Preparação
            TipoUsuario tipoUsuario;

            //// Execução
            tipoUsuario = new TipoUsuario();

            // Retorno esperado
            Assert.NotNull(tipoUsuario);

        }
        public void TestValoresClasse()
        {
            // Preparação
            TipoUsuario tipoUsuario;

            //// Execução
            tipoUsuario = new TipoUsuario();

            tipoUsuario.Id = 01;
            tipoUsuario.Tipo = "Paciente";

            // Retorno esperado
            Assert.Equal(01, tipoUsuario.Id);
            Assert.Equal("Paciente", tipoUsuario.Tipo);

        }
    }
}