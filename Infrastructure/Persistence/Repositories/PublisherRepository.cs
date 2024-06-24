using Application.Common.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.DataBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    public class PublisherRepository : BaseRepository<PublisherEntity>, IPublisherRepository
    {
        public PublisherRepository(EFContext context) : base(context)
        { 
        }
    }
}
