using MaisSaude.Models;
using Xunit;

namespace MaisSaudeTests.Models
{
    public class EspecialidadeTests
    {
        [Fact]
        public void TestEspecialidadeNotNull()
        {
            // Preparação
            Especialidade especialidade;

            // Execução
            especialidade = new Especialidade();

            // Retorno esperado
            Assert.NotNull(especialidade);

        }
        public void TestValoresClasse()
        {
            // Preparação
            Especialidade especialidade;

            // Execução
            especialidade = new Especialidade();
            especialidade.Id = 1;
            especialidade.Categoria = "Ginecologista";

            // Retorno esperado
            Assert.Equal(1, especialidade.Id);
            Assert.Equal("Ginecologista", especialidade.Categoria);


        }
    }
}