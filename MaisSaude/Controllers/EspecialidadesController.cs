using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspecialidadesController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IEspecialidadeRepository repositorio;

        // Método Construtor
        public EspecialidadesController(IEspecialidadeRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra especialidade na aplicação
        /// </summary>
        /// <param name="especialidade">Dados da especialidade</param>
        /// <returns>Dados da especialidade cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade especialidade)
        {
            try
            {
                Especialidade retorno = repositorio.Inserir(especialidade);

                // Retorna a especialidade que foi inserida
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
        /// Lista todas as especialidades cadastradas na aplicação
        /// </summary>
        /// <returns>Lista de especialidades</returns>
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
        /// Busca todas as especialidades cadastradas por id
        /// </summary>
        /// <returns>Lista de especialidades</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarEspecialidadePorID(int id)
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
                        Message = "Especialidade não encontrada"
                    });
                }
                // Retorna a especialidade por id
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
        /// Alterar os dados de uma especialidade
        /// </summary>
        /// <param name="especialidade">Todas as informações da especialidade</param>
        /// <param name="id">Id da especialidade</param>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Especialidade especialidade)
        {
            try
            {
                // Verifica se os ids existem
                if (id != especialidade.Id)
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
                repositorio.Alterar(especialidade);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchEspecialidade)
        {
            // Verifica se o Patch está vazio
            if (patchEspecialidade == null)
            {
                // Retorna erro
                return BadRequest();
            }
            // Busca o objeto
            var especialidade = repositorio.BuscarPorId(id);
            // Se o id for nulo
            if (especialidade == null)
            {
                // Retorna erro informando que não foi encontrado
                return NotFound(new
                {
                    Message = "Especialidade não encontrada"
                });
            }

            // Pega o patch e a especialidade encontrada
            repositorio.AlterarParcialmente(patchEspecialidade, especialidade);
            return Ok(especialidade);
        }

        /// <summary>
        /// Deleta todos dados de uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade</param>
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
                        Message = "Especialidade não encontrada"
                    });
                }
                // Exclui por busca de id
                repositorio.Excluir(busca);

                return Ok(new
                {
                    msg = "Especialidade exlcuída com sucesso!"
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
