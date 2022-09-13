using MaisSaude.Interfaces;
using MaisSaude.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace MaisSaude.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : ControllerBase
    {
        // Injeção de dependência do repositório
        private readonly IConsultaRepository repositorio;

        // Método Construtor
        public ConsultasController(IConsultaRepository _repository)
        {
            repositorio = _repository;
        }

        /// <summary>
        /// Cadastra consultas na aplicação
        /// </summary>
        /// <param name="consulta">Dados da consulta</param>
        /// <returns>Dados da consulta cadastrada</returns>
        [HttpPost]
        public IActionResult Cadastrar(Consulta consulta)
        {
            try
            {
                Consulta retorno = repositorio.Inserir(consulta);

                // Retorna a consulta que foi inserida
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
        /// Lista todas as consultas cadastradas na aplicação
        /// </summary>
        /// <returns>Lista de consultas</returns>
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
        /// Busca todas as consultas cadastradas por id
        /// </summary>
        /// <returns>Lista de consultas</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarConsultaPorID(int id)
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
                        Message = "Consulta não encontrada"
                    });
                }
                // Retorna a consulta por id
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
        /// Alterar os dados de uma consulta
        /// </summary>
        /// <param name="consulta">Todas as informações da consulta</param>
        /// <param name="id">Id da consulta</param>
        [HttpPut("{id}")]
        public IActionResult Alterar(int id, Consulta consulta)
        {
            try
            {
                // Verifica se os ids existem
                if (id != consulta.Id)
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
                repositorio.Alterar(consulta);

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
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument patchConsulta)
        {
            // Verifica se o Patch está vazio
            if (patchConsulta == null)
            {
                // Retorna erro
                return BadRequest();
            }
            // Busca o objeto
            var consulta = repositorio.BuscarPorId(id);
            // Se o id for nulo
            if (consulta == null)
            {
                // Retorna erro informando que não foi encontrado
                return NotFound(new
                {
                    Message = "Consulta não encontrada"
                });
            }

            // Pega o patch e a consulta encontrada
            repositorio.AlterarParcialmente(patchConsulta, consulta);
            return Ok(consulta);
        }
    }
}
