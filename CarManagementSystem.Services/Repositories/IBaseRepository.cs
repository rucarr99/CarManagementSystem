namespace CarManagementSystem.Services.Repositories
{
    public interface IBaseRepository <T>
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task CreateAsync(T entity, CancellationToken cancellationToken = default);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);

    }
}
