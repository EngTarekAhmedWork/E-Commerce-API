﻿using E_Commerce_API.Core.Interfaces;
using E_Commerce_API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace E_Commerce_API.Infrastructure.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly ApplicationDbContex _context;
    private DbSet<T> _dbSet;
    public GenericRepository(ApplicationDbContex context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? perdicate = null, string? includeEntity = null)
    {
        IQueryable<T> query = _dbSet;
        if (perdicate != null)
        {
            query = query.Where(perdicate);
        }
        if (includeEntity != null)
        {
            foreach (var item in includeEntity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>>? perdicate = null, string? includeEntity = null)
    {
        IQueryable<T> query = _dbSet;
        if (perdicate != null)
        {
            query = query.Where(perdicate);
        }
        if (includeEntity != null)
        {
            foreach (var item in includeEntity.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
        }
        return query.SingleOrDefault();
    }
    public void Add(T item)
    {
        _dbSet.Add(item);
    }

    public void Update(T item)
    {
        throw new NotImplementedException();
    }

    public void Delete(T item)
    {
        _dbSet.Remove(item);
    }

    public void DeleteRange(IEnumerable<T> items)
    {
        _dbSet.RemoveRange(items);
    }
}
