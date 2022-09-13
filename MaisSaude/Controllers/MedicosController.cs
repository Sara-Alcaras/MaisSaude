using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IMedicoRepository repositorio;

        // Método Construtor
        public MedicosController(IMedicoRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra médico na aplicação
        /// </summary>
        /// <param name="medico">Dados do médico</param>
        /// <returns>Dados do médico cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico medico)
        {
            try
            {
                Medico retorno = repositorio.Inserir(medico);

                // Retorna o médico que foi inserido
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                // Se não for inserida da erro
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        /// <summary>
        /// Lista todos os médicos cadastrados na aplicação
        /// </summary>
        /// <returns>Lista de médicos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                // Cria a variável retorno para receber o método de listar
                var retorno = repositorio.ListarTodos();
                // Retorna a variável
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {

                // Se não for inserida da erro
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
        /// <summary>
        /// Busca todos os médicos cadastradas por id
        /// </summary>
        /// <returns>Lista de médicos</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarMedicoPorID(int id)
        {
            try
            {
                var retorno = repositorio.BuscarPorId(id);

                // Se o id for nulo
                if (retorno == null)
                {
                    // Retorna erro informando que não foi encontrado
                    return NotFound(new
                    {
                        Message = "Médico não encontrado"
                    });
                }
                // Retorna o médico por id
                return Ok(retorno);

            }
            catch (System.Exception ex)
            {
                // Se não for inserida da erro
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
    }
}
