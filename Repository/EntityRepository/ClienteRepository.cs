using Domain.Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.EntityRepository
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(BaseContext context) : base(context)
        {
        }
    }
}
