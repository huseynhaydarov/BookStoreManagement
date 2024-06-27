using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;

namespace Infrastructure.Persistence.Repositories;

public class CustomerRepository : BaseRepository<CustomerEntity>, ICustomerRepository
{
    public CustomerRepository(EFContext context) : base(context)
    {
    }
}