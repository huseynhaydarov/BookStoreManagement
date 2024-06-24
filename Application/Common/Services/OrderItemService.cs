using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.OrderItemRequestsModel;
using Contracts.Requests.OrderRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public class OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper) : IOrderItemService
    {
        public async Task<OrderItemResponse> CreateAsync(CreateOrderItemRequestModel request,
            CancellationToken token = default)
        {
            var orderItem = mapper.Map<OrderItemEntity>(request);
            var response = await orderItemRepository.CreateAsync(orderItem, token);
            return mapper.Map<OrderItemResponse>(response);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var orderItem = await orderItemRepository.GetAsync(id, token);
            if (orderItem is null)
            {
                throw new NotFoundException(nameof(OrderItemEntity), id);
            }

            return await orderItemRepository.DeleteAsync(orderItem, token);
        }

        public async Task<List<OrderItemResponse>> GetAllAsync(CancellationToken token = default)
        {

            var response = await orderItemRepository.GetAllAsync(token);
            return mapper.Map<List<OrderItemResponse>>(response);
        }

        public async Task<OrderItemResponse?> GetAsync(int id, CancellationToken token = default)
        {
            var response = await orderItemRepository.GetAsync(id, token);

            if (response is null)
            {
                throw new NotFoundException(nameof(OrderItemEntity), id);
            }

            return mapper.Map<OrderItemResponse>(response);
        }

        public async Task UpdateAsync(int id, UpdateOrderItemRequestModel request, CancellationToken token = default)
        {
            var orderItem = await orderItemRepository.GetAsync(id, token);

            if (orderItem is null)
            {
                throw new Exception($"Not found entity with the following id: {id}");
            }
            mapper.Map(request, orderItem);
            await orderItemRepository.UpdateAsync(orderItem, token);
        }
    }
}