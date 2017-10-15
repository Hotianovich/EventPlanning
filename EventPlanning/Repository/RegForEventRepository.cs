using EventPlanning.Interfaces;
using EventPlanning.Models;
using EventPlanning.Models.EntitiesModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventPlanning.Repository
{
    public class RegForEventRepository : IRepositoryForReg<RegForEvent>
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

        public IEnumerable<RegForEvent> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Get(string id, int evId)
        {
            var regevents = context.RegForEvents.Where(ev => ev.EventId.Equals(evId) && ev.UserId.Equals(id));
            var regevent = regevents.FirstOrDefault();
            if (regevent == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CountReg(int eventId)
        {
            var countR = context.RegForEvents.Where(r => r.EventId.Equals(eventId));
            var countReg = countR.Count();
            var ev = context.Events.Where(e => e.EventId.Equals(eventId));
            var even = ev.FirstOrDefault();
            var countSeats = even.NamderOfParticipants;
            var res = countSeats - countReg;
            return res;
        }
    }
}