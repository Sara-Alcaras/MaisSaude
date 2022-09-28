using MaisSaude.Models;
using Xunit;

namespace MaisSaudeTests.Models
{
    public class UsuarioTests
    {
        [Fact]
        public void TestUsuarioNotNull()
        {
            // Preparação
            Usuario usuario;

            // Execução
            usuario = new Usuario();

            usuario.Id = 01;

            // Retorno esperado
            Assert.NotNull(usuario);
        }

        public void TestValoresClasse()
        {
            // Preparação
            Usuario usuario;

            // Execução
            usuario = new Usuario();

            usuario.Id = 01;
            usuario.Nome = "Sara";
            usuario.Email = "sara@gmail.com";
            usuario.IdTipoUsuario = 01;

            // Retorno esperado
            Assert.Equal(01, usuario.Id);
            Assert.Equal("Sara", usuario.Nome);
            Assert.Equal("sara@gmail.com", usuario.Email);
            Assert.Equal(01, usuario.IdTipoUsuario);
        }

    }
}

//public class UsuariosControllerTests
//{
//    // Preparação
//    private readonly Mock<ITbUsuarioRepository> _mockRepo;
//    private readonly TbUsuariosController _controller;
//    public UsuariosControllerTests()
//    {
//        _mockRepo = new Mock<ITbUsuarioRepository>();
//        _controller = new TbUsuariosController(_mockRepo.Object);
//    }

//    [Fact]
//    public void TestActionResultReturnOk()
//    {

//        // Execução
//        var result = _controller.GetAllUsuarios();
//        // Retorno
//        Assert.IsType<OkObjectResult>(result);
//    }

//    [Fact]
//    public void TestGetAllUsuario()
//    {
//        // Execução - Act
//        var actionResult = _controller.GetAllUsuarios();
//        var okObjectResult = actionResult as OkObjectResult;
//        okObjectResult.Value = new List<TbUsuario>();
//        // Retorno
//        Assert.IsAssignableFrom<List<TbUsuario>>(okObjectResult.Value);

//    }

//    [Fact]
//    public void TestStatusCodeSuccess()
//    {
//        // Execução - Act
//        var actionResult = _controller.GetAllUsuarios();
//        var result = actionResult as OkObjectResult;
//        // Retorno
//        Assert.Equal(200, result.StatusCode);
//    }

//    [Fact]
//    public void TestActionResultNotNull()
//    {
//        // Execução - Act
//        var actionResult = _controller.GetAllUsuarios();
//        // Retorno
//        Assert.NotNull(actionResult);
//    }
//}