using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    //Intertace genérica para os serviços
    public interface IService<T>: IGetById<T>, IGetAll<T>, IAdd<T>, IUpdate<T>, IDeleteById<T> where T : BaseEntity
    {
        //Métodos genéricos para os serviços, inclui as interfaces básicas abaixo
    }

    public interface IGetById<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(Guid id);
    }

    public interface IGetAll<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetAllAsync();
    }

    public interface IGetByExpression<T> where T : BaseEntity
    {
        Task<ICollection<T>> GetByExpressionAsync(Func<T, bool> expression);
    }

    public interface IGetSingleByExpression<T> where T : BaseEntity
    {
        Task<T> GetSingleByExpressionAsync(Func<T, bool> expression);
    }

    public interface IAdd<T> where T : BaseEntity
    {
        Task AddAsync(T entity);
    }

    public interface IUpdate<T> where T : BaseEntity
    {
        Task UpdateAsync(T entity);
    }

    public interface IDeleteById<T> where T : BaseEntity
    {
        Task DeleteAsync(Guid id);
    }

    public interface IDelete<T> where T : BaseEntity
    {
        Task DeleteAsync(T entity);
    }
}
