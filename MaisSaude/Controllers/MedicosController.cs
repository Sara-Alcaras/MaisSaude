using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
        /// <summary>
        /// Alterar os dados de um médico
        /// </summary>
        /// <param name="medico">Todas as informações do médico </param>
        /// <param name="id">Id do médico</param>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Medico medico)
        {
            try
            {
                // Verifica se os ids existem
                if (id != medico.Id)
                {
                    // Retorna erro
                    return BadRequest("Os ids são diferentes");
                }

                // Verifica se o id existe no banco
                var retorno = repositorio.BuscarPorId(id);

                // Se o id for nulo
                if (retorno == null)
                {
                    // Retorna erro informando que não foi encontrado
                    return NotFound(new
                    {
                        Message = "Consulta não encontrada"
                    });
                }
                // Efetiva a alteração
                repositorio.Alterar(medico);

                // Retorna sucesso, não retorna o objeto
                return NoContent();
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
        /// Altera os dados parcialmente
        /// </summary>
        /// <returns>Dados alterados</returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchMedico)
        {
            // Verifica se o Patch está vazio
            if (patchMedico == null)
            {
                // Retorna erro
                return BadRequest();
            }
            // Busca o objeto
            var medico = repositorio.BuscarPorId(id);
            // Se o id for nulo
            if (medico == null)
            {
                // Retorna erro informando que não foi encontrado
                return NotFound(new
                {
                    Message = "Médico não encontrado"
                });
            }

            // Pega o patch e o médico encontrado
            repositorio.AlterarParcialmente(patchMedico, medico);
            return Ok(medico);
        }

        /// <summary>
        /// Deleta todos dados de um médico
        /// </summary>
        /// <param name="id">Id do médico</param>
        /// <returns>Mensagem de exclusão</returns>
        /// 
        [HttpDelete("{id}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                // Busca por id
                var busca = repositorio.BuscarPorId(id);
                // Se busca nulo
                if (busca == null)
                {
                    // Retorna erro informando que não foi encontrado
                    return NotFound(new
                    {
                        Message = "Médico não encontrado"
                    });
                }
                // Exclui por busca de id
                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "Médico exlcuído com sucesso!"
                });


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
