﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SQLiteDemo.Abstractions
{
    public interface IBaseRepository<T> : IDisposable
        where T : TableData, new()
    {
        void SaveItem(T item);
        T Getitem(int id);
        T GetItem(Expression<Func<T, bool>> predicate);

        List<T> GetItems();
        List<T> GetItems(Expression<Func<T, bool>> predicate);
        void DeleteItem(T item);
    }
}
