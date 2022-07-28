using Task_Interview.Models;

namespace Task_Interview.Repository
{
    public class CashierRepository : IRepositoryCashier
    {
        private readonly ArmyTechTaskContext db;

        public CashierRepository(ArmyTechTaskContext db)
        {
            this.db = db;
        }
        public int Delete(int id)
        {
            var data = GetById(id);
            if(data != null)
            {
                db.Cashiers.Remove(data);
                return db.SaveChanges();
            }
            return 0;
        }

        public int Edit(int id, Cashier entity)
        {
            var data = GetById(id);
            if(data !=null)
            {
                data.CashierName = entity.CashierName;
                data.BranchId = entity.BranchId;
                return (db.SaveChanges());
            }
            return 0;
        }

        public ICollection<Cashier> GetAll()
        {
            return (db.Cashiers.ToList());
        }

        public Cashier GetById(int id)
        {
            return (db.Cashiers.FirstOrDefault(c => c.Id == id));
        }

        public int Insert(Cashier entity)
        {
            if (entity != null)
            {
                db.Cashiers.Add(entity);
                return (db.SaveChanges());

            }
            return 0;
        }
    }
}
