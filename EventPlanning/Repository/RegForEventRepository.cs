using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Repository
{
    public class RegForEventRepository : IRepository<RegForEvent>
    {
        ApplicationDbContext context;
        public RegForEventRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(RegForEvent t)
        {
            context.RegForEvents.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegForEvent> Find(Func<RegForEvent, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public RegForEvent Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RegForEvent> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(RegForEvent t)
        {
            throw new NotImplementedException();
        }
    }
}