using Microsoft.AspNetCore.Mvc;
using GerenciadorTarefasAPI.Services.TarefasService;
using GerenciadorTarefasAPI.Models;
using GerenciadorTarefasAPI.Enums;

namespace GerenciadorTarefasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasInterface _tarefasInterface;

        public TarefasController(ITarefasInterface tarefasInterface)
        {
            _tarefasInterface = tarefasInterface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<TarefasModel>>>> Get()
        {
            return Ok(await _tarefasInterface.GetTarefas());
        }
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<TarefasModel>>>> CreateTarefas(TarefasModel novaTarefa)
        {
            return Ok(await _tarefasInterface.CreateTarefas(novaTarefa));
        }
        [HttpGet("{status}")]
        public async Task<ActionResult<ServiceResponse<List<TarefasModel>>>> GetTarefasByStatus(StatusTarefasEnum status)
        {
            return Ok(await _tarefasInterface.GetTarefasByStatus(status));
        }
        [HttpPut("{id}, {status}")]
        public async Task<ActionResult<ServiceResponse<TarefasModel>>> UpdateStatusTarefas(int id, StatusTarefasEnum status)
        {
            return Ok(await _tarefasInterface.UpdateStatusTarefas(id, status));
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<TarefasModel>>> DeleteTarefas(int id)
        {
            return Ok(await _tarefasInterface.DeleteTarefas(id));
        }
    }
}
    