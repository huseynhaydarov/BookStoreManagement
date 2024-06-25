﻿using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
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
    public class OrderService(IOrderRepository orderRepository, IMapper mapper) : IOrderService
    {
        public async Task<OrderResponse> CreateAsync(CreateOrderRequestModel request,
            CancellationToken token = default)
        {
            var order = mapper.Map<OrderEnitity>(request);
            var response = await orderRepository.CreateAsync(order, token);
            return mapper.Map<OrderResponse>(response);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var order = await orderRepository.GetAsync(id, token);

            if (order is null)
            {
                throw new NotFoundException(nameof(order), id);
            }
            return await orderRepository.DeleteAsync(order, token);
        }

  

        public async Task<List<OrderResponse>> GetAllAsync(int pageSize, int pageNumber, CancellationToken token = default)
        {
            var response = await orderRepository.GetAllAsync(pageSize, pageNumber, token);
            return mapper.Map<List<OrderResponse>>(response);
        }

        public async Task<OrderResponse?> GetAsync(int id, CancellationToken token = default)
        {
            var response = await orderRepository.GetAsync(id, token);

            if (response is null)
            {
                throw new NotFoundException(nameof(OrderEnitity), id);
            }

            return mapper.Map<OrderResponse>(response);
        }

        public async Task UpdateAsync(int id, UpdateOrderRequestModel request, CancellationToken token = default)
        {
            var order = await orderRepository.GetAsync(id, token);

            if (order is null)
            {
                throw new Exception($"Not found entity with the following id: {id}");
            }
            mapper.Map(request, order);
            await orderRepository.UpdateAsync(order, token);
        }
    }
}
