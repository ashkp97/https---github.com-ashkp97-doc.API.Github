using doctor.API.Interfaces;

public abstract class Repository<K, T> : IRepository<K, T>
{
    protected static List<T> items = new List<T>();

    public async Task<IEnumerable<T>> GetAll(){
        return items;
    }
    public abstract Task<T> GetByKey(K Key);
    public async Task<T> Add(T item)
    {
        items.Add(item);
        return item;
    }

    public async Task<T> Delete(K key)
    {
        var item = await GetByKey(key);
        if (item != null)
        {
            items.Remove(item);
            return item;
        }
        throw new Exception($"No item found with key {key}"); 
    }

    public async Task<T> Update(K key, T item)
    {
        var itemToUpdate = await GetByKey(key);
        if (itemToUpdate != null)
        {
            items.Remove(itemToUpdate);
            items.Add(item);
            return item;
        }
        throw new Exception($"No item found with key {key}"); 
    }

    public virtual Task<T> GetByName(string name)
    {
        throw new NotImplementedException();
    }
}