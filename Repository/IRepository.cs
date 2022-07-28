namespace Task_Interview.Repository
{
    public interface IRepository<T1,T2> where T1 :class
    {
        public ICollection<T1> GetAll();
        public T1 GetById(T2 id);
        int Edit(T2 id, T1 entity);

    }
}
