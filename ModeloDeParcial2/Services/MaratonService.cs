using ModeloDeParcial2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModeloDeParcial2.Services
{
    public class MaratonService
    {
        MaratonEntities ctx = new MaratonEntities();

        public List<Maraton> ObtenerListaMaratones()
        {
            var query = (from m in ctx.Maraton
                         where m.Cantidad_Participante > 10
                         select m).ToList();

            return query;
        }
        public void CrearMaraton(Maraton maraton)
        {
            ctx.Maraton.Add(maraton);
            ctx.SaveChanges();
        }

        public Maraton GetMaratonById(int id)
        {
            Maraton maraton = ctx.Maraton.Find(id);
            return maraton;
        }

        public void EditarMaraton(Maraton maraton)
        {
            Maraton m = GetMaratonById(maraton.id);
            m.nombre = maraton.nombre;
            m.Cantidad_Participante = maraton.Cantidad_Participante;
            ctx.SaveChanges();
        }

        public void EliminarMaraton(int id)
        {
            Maraton maraton = ctx.Maraton.Find(id);
            ctx.Maraton.Remove(maraton);
            ctx.SaveChanges();
        }
    }
}