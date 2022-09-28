using MaisSaude.Models;
using Xunit;

namespace MaisSaudeTests.Models
{
    public class MedicoTests
    {
        [Fact]
        public void TestMedicoNotNull()
        {
            // Preparação
            Medico medico;

            // Execução
            medico = new Medico();

            // Retorno esperado
            Assert.NotNull(medico);

        }

        public void TestValoresClasse()
        {
            // Preparação
            Medico medico;

            // Execução
            medico = new Medico();
            medico.Id = 1;
            medico.Crm = "Meu CRM 12345";
            medico.IdEspecialidade = 01;
            medico.IdUsuario = 02;


            // Retorno esperado
            Assert.Equal(1, medico.Id);
            Assert.Equal("Meu CRM 12345", medico.Crm);
            Assert.Equal(01, medico.IdEspecialidade);
            Assert.Equal(02, medico.IdUsuario); 

        }
    }
}