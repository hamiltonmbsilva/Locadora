using Domain.Models;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.EntityRepository
{
    public class ClienteRepository : Repository<Cliente>
    {
        public ClienteRepository(BaseContext context) : base(context)
        {
        }

        public Cliente GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }
    }
}
