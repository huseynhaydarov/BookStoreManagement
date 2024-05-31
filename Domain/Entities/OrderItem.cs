using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class OrderItem : BaseEntity
{
    public int Quantity { get; set; }
    public decimal Price { get; set; }


    public Order Order { get; set; }
    public int OrderId { get; set; }
    public Book Book { get; set; }
    public int BookId { get; set; }
}
