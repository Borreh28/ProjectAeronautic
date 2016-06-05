﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Entities;
using System.Data.Entity;

namespace App.DAL
{
    public class RequisicionLineaRepository
    {
        Contexto db;

        public RequisicionLineaRepository()
        {
            db = new Contexto();
        }

        public IEnumerable<RequisicionLinea> GetAll()
        {
            return db.Lineas.ToList();
        }

        public IEnumerable<RequisicionLinea> GetByIdRequisicion(int id)
        {
            return db.Lineas.Where(w => w.RequisicionId == id).ToList();
        }

        public void Add(RequisicionLinea data)
        {
            db.Lineas.Add(data);
            db.SaveChanges();
        }

        public void Update(RequisicionLinea data)
        {
            db.Entry(data).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            RequisicionLinea data = db.Lineas.Find(id);
            db.Lineas.Remove(data);
            db.SaveChanges();
        }
    }
}
