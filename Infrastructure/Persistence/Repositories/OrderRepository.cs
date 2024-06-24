using Application.Common.Interfaces.Repositories;
using Infrastructure.Persistence.DataBases;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories;

    public class OrderRepository : BaseRepository<OrderEnitity>, IOrderRepository
{
    public OrderRepository(EFContext context) : base(context)
    {
    }
}