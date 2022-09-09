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
    }
}
