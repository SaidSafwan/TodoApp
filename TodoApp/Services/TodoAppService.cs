using TodoApp.Services.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TodoApp.Services;

public class TodoAppService : ApplicationService
{
    private readonly IRepository<Entities.TodoItem, Guid> _todoItemRepository;

    public TodoAppService(IRepository<Entities.TodoItem, Guid> todoItemRepository)
    {
        _todoItemRepository = todoItemRepository;
    }

    // TODO: Implement the methods here...

    public async Task<List<Dtos.TodoItemDto>> GetListAsync()
    {
        var items = await _todoItemRepository.GetListAsync();
        return items
            .Select(item => new TodoItemDto
            {
                Id = item.Id,
                Text = item.Text
            }).ToList();
    }

    public async Task<Dtos.TodoItemDto> abpcreateAsync(string text)
    {
        var todoItem = await _todoItemRepository.InsertAsync(
            new Entities.TodoItem { Text = text }
        );

        return new Dtos.TodoItemDto
        {
            Id = todoItem.Id,
            Text = todoItem.Text
        };
    }

    public async Task DeleteAsync(Guid id)
    {
        await _todoItemRepository.DeleteAsync(id);
    }

}
