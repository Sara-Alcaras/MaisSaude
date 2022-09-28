using MaisSaude.Models;
using Xunit;

namespace MaisSaudeTests.Models
{
    public class PacienteTests
    {
        [Fact]
        public void TestPacienteNotNull()
        {
            // Preparação
            Paciente paciente;

            // Execução
            paciente = new Paciente();

            // Retorno esperado
            Assert.NotNull(paciente);

        }

        public void TestValoresClasse()
        {
            // Preparação
            Paciente paciente;

            // Execução
            paciente = new Paciente();

            paciente.Id = 1;
            paciente.Carteirinha = "Carteirinha 123";
            paciente.DataNascimento = System.DateTime.Now;
            paciente.Ativo = true;
            paciente.IdUsuario = 01;

            // Retorno esperado
            Assert.Equal(1, paciente.Id);
            Assert.Equal("Carteirinha 123", paciente.Carteirinha);
            Assert.Equal(System.DateTime.Now, paciente.DataNascimento);
            Assert.True(true);
            Assert.Equal(01, paciente.IdUsuario);

        }
    }
}