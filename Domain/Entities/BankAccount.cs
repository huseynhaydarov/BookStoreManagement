﻿using Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class BankAccount : BaseEntity
{
    public int AccountNumber { get; set; }

    public Customer Customer { get; set; }
    public int CustomerId { get; set; }
}
