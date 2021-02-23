using System;
using System.Collections.Generic;
using csharp_contractors.Models;
using csharp_contractors.Repositories;

namespace csharp_contractors.Services
{
  public class JobsService
  {
    private readonly JobsRepository _jobsRepository;

    public JobsService(JobsRepository jobsRepository)
    {
      _jobsRepository = jobsRepository;
    }

    internal IEnumerable<Job> GetAll()
    {
      return _jobsRepository.GetAll();
    }

    internal Job GetById(int id)
    {
      Job job = _jobsRepository.GetById(id);
      if (job == null)
      {
        throw new Exception("Invalid Id");
      }
      return job;
    }

    internal Job Create(Job newJob)
    {
      int id = _jobsRepository.Create(newJob);
      newJob.Id = id;
      return newJob;
    }

    internal Job Edit(int id, Job editedJob)
    {
      throw new NotImplementedException();
    }

    internal string Delete(int id)
    {
      GetById(id);
      _jobsRepository.Delete(id);
      return "Successfully Deleted";
    }
  }
}