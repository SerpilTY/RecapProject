using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{   
    //Core katmanı başka hiçbir katmanı referans almaz.
    //add generic constraint to IEntityRepository
    //T class:may only be a referance type
    //T IEntity: may only be an entity from IEntity Absract
    //T new(): mustn't be an interface( interfaces are un-(new)-able)
    
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        T Get(Expression<Func<T,bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> exp);

    }
}
