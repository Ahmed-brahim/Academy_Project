namespace Day2_MVC_Task.Repository
{
	public interface IRepository<T>
	{
		public List<T> GetAll();
		public T GetById(int id);
		public void Add(T obj);
		public void Update(T obj);
		public void DeleteById(int id);
		public void Save();
		public int GetCount();
	}
}
