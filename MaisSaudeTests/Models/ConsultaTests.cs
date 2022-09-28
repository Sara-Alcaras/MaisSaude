using MaisSaude.Models;
using Xunit;

namespace MaisSaudeTests.Models
{
    public class ConsultaTests
    {
        [Fact]
        public void TestConsultaNotNull()
        {
            // Preparação
            Consulta consulta;

            // Execução
            consulta = new Consulta();

            // Retorno esperado
            Assert.NotNull(consulta);

        }
        public void TestValoresClasse()
        {
            // Preparação
            Consulta consulta;

            // Execução
            consulta = new Consulta();
            consulta.Id = 01;
            consulta.DataHora = System.DateTime.Now;
            consulta.IdMedico = 02;
            consulta.IdPaciente = 01;

            // Retorno esperado
            Assert.Equal(01, consulta.Id);
            Assert.Equal(System.DateTime.Now, consulta.DataHora);
            Assert.Equal(02, consulta.IdMedico);
            Assert.Equal(01, consulta.IdPaciente);
        }
    }
}