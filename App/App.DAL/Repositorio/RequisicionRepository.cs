﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using System.Data.Entity;

namespace App.DAL
{
    public class RequisicionRepository
    {
        Contexto db;

        public RequisicionRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<Requisicion> GetAll()
        {
            return db.Requisiciones.ToList();
        }

        public IEnumerable<Requisicion> GetById(int id)
        {
            return db.Requisiciones.Where(w => w.Id == id).ToList();
        }

        public void Add(Requisicion data)
        {
            db.Requisiciones.Add(data);
            db.SaveChanges();
        }

        public void Update(Requisicion data)
        {
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Requisicion data = db.Requisiciones.Find(id);
            db.Requisiciones.Remove(data);
            db.SaveChanges();
        }
    }
}
