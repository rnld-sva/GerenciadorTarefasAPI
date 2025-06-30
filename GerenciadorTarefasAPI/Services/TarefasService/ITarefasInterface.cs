using GerenciadorTarefasAPI.Enums;
using GerenciadorTarefasAPI.Models;

namespace GerenciadorTarefasAPI.Services.TarefasService
{
    public interface ITarefasInterface
    {
        Task<ServiceResponse<List<TarefasModel>>> GetTarefas();
        Task<ServiceResponse<List<TarefasModel>>> GetTarefasByStatus(StatusTarefasEnum status);
        Task<ServiceResponse<List<TarefasModel>>> CreateTarefas(TarefasModel novaTarefa);
        Task<ServiceResponse<TarefasModel>> UpdateStatusTarefas(int id, StatusTarefasEnum status);
        Task <ServiceResponse<List<TarefasModel>>> DeleteTarefas(int id);
    }
}
