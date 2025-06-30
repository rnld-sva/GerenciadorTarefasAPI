using GerenciadorTarefasAPI.DataContext;
using GerenciadorTarefasAPI.Enums;
using GerenciadorTarefasAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefasAPI.Services.TarefasService
{
    public class TarefasService : ITarefasInterface
    {
        private readonly AppDbContext _context;

        public TarefasService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<TarefasModel>>> CreateTarefas(TarefasModel novaTarefa)
        {
            ServiceResponse<List<TarefasModel>> serviceResponse = new ServiceResponse<List<TarefasModel>>();

            try
            {

                if (novaTarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informe os dados";
                    serviceResponse.Sucesso = false;

                }
                _context.Add(novaTarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();
            } 
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefasModel>>> DeleteTarefas(int id)
        {
            ServiceResponse<List<TarefasModel>> serviceResponse = new ServiceResponse<List<TarefasModel>>();

            TarefasModel tarefa = await _context.Tarefas.FirstOrDefaultAsync(t => t.Id == id);
            try
            {
                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhuma Tarefa Encontrada";
                    serviceResponse.Sucesso = false;

                    return serviceResponse;
                }

                _context.Tarefas.Remove(tarefa);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Tarefas.ToList();

            } catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefasModel>>> GetTarefasByStatus(StatusTarefasEnum status)
        {
            ServiceResponse<List<TarefasModel>> serviceResponse = new ServiceResponse<List<TarefasModel>>();

            try
            {
                serviceResponse.Dados = await _context.Tarefas.Where(t => t.Status == status).ToListAsync();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<TarefasModel>>> GetTarefas()
        {
            ServiceResponse<List<TarefasModel>> serviceResponse = new ServiceResponse<List<TarefasModel>>();
            try
            {
                serviceResponse.Dados = _context.Tarefas.ToList();
                if(serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhuma Tarefa Encontrada";
                }

            } catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<TarefasModel>> UpdateStatusTarefas(int id, StatusTarefasEnum status)
        {

            ServiceResponse<TarefasModel> serviceResponse = new ServiceResponse<TarefasModel>();

            try
            {
                TarefasModel tarefa = _context.Tarefas.FirstOrDefault(t => t.Id == id);
                if (tarefa == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhuma Tarefa Encontrada";
                    serviceResponse.Sucesso = false;
                }

                tarefa.Status = status;

                _context.Tarefas.Update(tarefa);
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }
    }
}
