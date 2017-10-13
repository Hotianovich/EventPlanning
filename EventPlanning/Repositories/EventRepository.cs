using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Repositories
{
    public class EventRepository : IRepository<Event>
    {
        ApplicationDbContext db;
        public EventRepository()
        {
            db = new ApplicationDbContext(); 
        }
        public void Create(Event t)
        {
            db.Events.Add(t);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var item = db.Events.Find(id);
            if (item != null)
            {
                db.Events.Remove(item);
            }
            db.SaveChanges();
        }

        public IEnumerable<Event> Find(Func<Event, bool> predicate)
        {
            return db.Events.Where(predicate).ToList();
        }

        public Event Get(int id)
        {
            return db.Events.Find(id);
        }

        public IEnumerable<Event> GetAll()
        {
            return db.Events;
        }

        public void Update(Event t)
        {
            db.Entry<Event>(t).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
    }
}