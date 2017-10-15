using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Repository
{
    public class EventRepository : IRepository<Event>
    {
        ApplicationDbContext context;
        public EventRepository()
        {
            context = new ApplicationDbContext();
        }

        public void Create(Event t)
        {
            context.Events.Add(t);
            context.SaveChanges();
        }

        public IEnumerable<Event> GetAll()
        {
            return context.Events;
        }

        
    }
}