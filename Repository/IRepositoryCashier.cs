using Task_Interview.Models;

namespace Task_Interview.Repository
{
    public interface IRepositoryCashier:IRepository<Cashier,int>
    {
        int Delete(int id);
        int Edit(int id, Cashier entity);
        int Insert(Cashier entity);
    }
}
