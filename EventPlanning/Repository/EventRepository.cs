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

        public void Delete(int id)
        {
            var item = context.Events.Find(id);
            if (item != null)
            {
                context.Events.Remove(item);
            }
            context.SaveChanges();
        }

        public IEnumerable<Event> Find(Func<Event, bool> predicate)
        {
            return context.Events.Where(predicate).ToList();
        }

        public Event Get(int id)
        {
            return context.Events.Find(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return context.Events;
        }

        public void Update(Event t)
        {
            context.Entry<Event>(t).State = System.Data.Entity.EntityState.Modified;
        }
    }
}