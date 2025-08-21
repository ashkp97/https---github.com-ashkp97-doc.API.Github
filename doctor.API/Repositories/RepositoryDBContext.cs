using doctor.API.Interfaces;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;

public abstract class RepositoryDBContext<K, T> : IRepository<K, T>
{
    protected readonly ClinicContext _context;

    public RepositoryDBContext(ClinicContext context)
    {
        _context = context;
    }

    public abstract Task<IEnumerable<T>> GetAll();    
    public abstract Task<T> GetByKey(K Key);
    public virtual Task<T> GetByName(string name)
    {
        throw new NotImplementedException(); 
    }
    public async Task<T> Add(T item)
    {
        await _context.AddAsync(item);
        await _context.SaveChangesAsync();
        return item;
    }

    public async Task<T> Delete(K key)
    {
        var item = await GetByKey(key);
        if (item != null)
        {            
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
        throw new Exception($"No item found with key {key}"); 
    }

    public async Task<T> Update(K key, T item)
    {
        var itemToUpdate = await GetByKey(key);
        if (itemToUpdate != null)
        {
            _context.Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
        throw new Exception($"No item found with key {key}"); 
    }
}