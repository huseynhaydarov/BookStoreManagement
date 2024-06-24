using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using Application.Exceptions;
using AutoMapper;
using Contracts.Requests.AuthorRequests;
using Contracts.Requests.CustomerRequests;
using Contracts.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Services
{
    public class CustomerService(ICustomerRepository customerRepository, IMapper mapper) : ICustomerService
    {
        public async Task<CustomerResponse> CreateAsync(CreateCustomerRequestModel request,
            CancellationToken token = default)
        {
            var customer = mapper.Map<CustomerEntity>(request);
            var response = await customerRepository.CreateAsync(customer, token);
            return mapper.Map<CustomerResponse>(response);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var customer = await customerRepository.GetAsync(id, token);
            if (customer is null)
            {
                throw new NotFoundException(nameof(CustomerEntity), id);
            }

            return await customerRepository.DeleteAsync(customer, token);
        }

        public async Task<List<CustomerResponse>> GetAllAsync(CancellationToken token = default)
        {

            var response = await customerRepository.GetAllAsync(token);
            return mapper.Map<List<CustomerResponse>>(response);
        }

        public async Task<CustomerResponse?> GetAsync(int id, CancellationToken token = default)
        {
            var response = await customerRepository.GetAsync(id, token);

            if (response is null)
            {
                throw new NotFoundException(nameof(CustomerEntity), id);
            }

            return mapper.Map<CustomerResponse>(response);
        }

        public async Task UpdateAsync(int id, UpdateCustomerRequestModel request, CancellationToken token = default)
        {
            var customer = await customerRepository.GetAsync(id, token);

            if (customer is null)
            {
                throw new Exception($"Not found entity with the following id: {id}");
            }
            mapper.Map(request, customer);
            await customerRepository.UpdateAsync(customer, token);
        }
    }
}