using Shared.Interface.Entity;

namespace Shared.Entity
{
    public abstract class Entity<TEntity, TTYpe> : IEntity<TEntity, TTYpe> where TEntity : class
    {
        public TTYpe Id { get; set; }
    }
}
