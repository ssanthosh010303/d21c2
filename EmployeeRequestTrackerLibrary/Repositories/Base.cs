/*
 * Author: Sakthi Santhosh
 * Created on: 10/05/2024
 */
namespace EmployeeRequestTrackerLibrary.Repositories;

public interface IRepository<K, T> where T : class
{
    T Add(T entity);
    T Update(T entity);
    T Delete(K key);
    T Get(K key);
    IList<T> GetAll();
}
