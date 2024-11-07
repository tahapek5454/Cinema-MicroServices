using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Domain.Entities;
using Cinema.Services.CategoryAPI.Infrastructure.Services.Concrete;
using MassTransit;
using MediatR;
using SharedLibrary.Events.CategoryChangeEvent;
using SharedLibrary.Events.MovieChangeEvents;
using SharedLibrary.Settings;

namespace Cinema.Services.CategoryAPI.Application.Commands.Categories.UpdateGategory
{
    public class UpdateGategoryRequestHandler(ICategoryService _categoryService, CategoryUnitOfWork _categoryUnitOfWork, ISendEndpointProvider _sendEndpointProvider) : IRequestHandler<UpdateGategoryRequest, UpdateGategoryResponse>
    {
        public async Task<UpdateGategoryResponse> Handle(UpdateGategoryRequest request, CancellationToken cancellationToken)
        {
            var updatedCategory = ObjectMapper.Mapper.Map<Category>(request);

            _categoryService.Table.Update(updatedCategory);

            await _categoryUnitOfWork.SaveChangesAsync();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint
                (new Uri($"queue:{RabbitMQSettings.CategoryChangeStateMachineQueue}"));

            await sendEndpoint.Send(new CategoryChangeStartedEvent()
            {
                CategoryId = updatedCategory.Id,
                CreatedTime = DateTime.Now,
                CategorySharedVM = new SharedLibrary.Models.SharedModels.Categories.CategorySharedVM 
                {
                    Id = updatedCategory.Id,
                    Name = updatedCategory.Name,
                }
            });

            return new();
        }
    }
}
