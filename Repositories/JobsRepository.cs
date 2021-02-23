using System;
using System.Collections.Generic;
using System.Data;
using csharp_contractors.Models;
using Dapper;

namespace csharp_contractors.Repositories
{
  public class JobsRepository
  {
    private readonly IDbConnection _db;

    public JobsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal IEnumerable<Job> GetAll()
    {
      string sql = "SELECT * FROM jobs;";
      return _db.Query<Job>(sql);
    }

    internal Job GetById(int id)
    {
      string sql = "SELECT * FROM jobs WHERE id = @id;";
      return _db.QueryFirstOrDefault<Job>(sql, new { id });
    }

    internal int Create(Job newJob)
    {
      string sql = @"
      INSERT INTO jobs
      (name, description, pay)
      VALUES
      (@Name, @Description, @Pay);
      SELECT LAST_INSERT_ID;";
      return _db.ExecuteScalar<int>(sql, newJob);
    }

    internal void Delete(int id)
    {
      string sql = "DELETE FROM jobs where id = @id;";
      _db.Execute(sql, new { id });
    }
  }
}