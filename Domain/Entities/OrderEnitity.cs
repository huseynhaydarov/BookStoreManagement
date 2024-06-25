using Domain.Abstract;
using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OrderEnitity : BaseEntity
{
    public DateTime OrderDate { get; set; } = DateTime.Now;
    public OrderStatus Status { get; set; }
    public decimal TotalAmount { get; set; }

    public CustomerEntity Customer { get; set; }
    public int CustomerId { get; set; }  

    public virtual ICollection<OrderItemEntity> Items { get; set; }

}
