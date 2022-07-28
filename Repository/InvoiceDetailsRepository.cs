﻿using Microsoft.EntityFrameworkCore;
using Task_Interview.Models;

namespace Task_Interview.Repository
{
    public class InvoiceDetailsRepository : IRepositoryInvoiceDetails
    {
        private readonly ArmyTechTaskContext db;

        public InvoiceDetailsRepository(ArmyTechTaskContext db)
        {
            this.db = db;
        }
        public ICollection<InvoiceDetail> GetAll()
        {
            var data = db.InvoiceDetails.ToList();
            return (data);
        }

        public InvoiceDetail GetById(int id)
        {
            var data = db.InvoiceDetails.FirstOrDefault(i => i.Id == id);
            return (data);
        }
    }
}
