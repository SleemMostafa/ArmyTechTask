using Task_Interview.Models;

namespace Task_Interview.Repository
{
    public class BranchRepository : IRepositoryBranch
    {
        private readonly ArmyTechTaskContext db;

        public BranchRepository(ArmyTechTaskContext db)
        {
            this.db = db;
        }
        public ICollection<Branch> GetAll()
        {
            return (db.Branches.ToList());
        }

        public Branch GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
