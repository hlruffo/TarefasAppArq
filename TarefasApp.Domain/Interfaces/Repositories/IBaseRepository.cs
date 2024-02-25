using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarefasApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TEntity"> Representa o tipo de entidade que herdará base</typeparam>
    /// <typeparam name="TKey">Representa o tipo  da chave(Guid, Id ... ) da entitdade que herdará base</typeparam>
    public interface IBaseRepository<TEntity, TKey> : IDisposable
       where TEntity : class      
    {   
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);

        Task<List<TEntity>> GetAll();
        Task<TEntity>? GetById(TKey id);
    }
}
