using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    //Generic constraint
    //class : referans tip olabilir
    //IEntity: IEntity ya da IEntity implemente olan bir nesne olabilir.
    //new() : new'lenebilir olmalı
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //Get'i kategorize etmek için Expression kullandık.
        T Get(Expression<Func<T, bool>> filter); //Burada filtre vermek zorunda olduğumuz için filter kısmını null yapmadık
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
