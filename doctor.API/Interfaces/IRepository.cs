namespace doctor.API.Interfaces;
public interface IRepository<K, T>
{
    public Task<IEnumerable<T>> GetAll();
    public Task<T> GetByKey(K Key);
    public Task<T> GetByName(string name);
    public Task<T> Add(T item);
    public Task<T> Delete(K key);
    public Task<T> Update(K key, T item);
}