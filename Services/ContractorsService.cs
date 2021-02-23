using System;
using System.Collections.Generic;
using csharp_contractors.Models;
using csharp_contractors.Repositories;

namespace csharp_contractors.Services
{
  public class ContractorsService
  {
    private readonly ContractorsRepository _contractorsRepository;

    public ContractorsService(ContractorsRepository contractorsRepository)
    {
      _contractorsRepository = contractorsRepository;
    }

    internal IEnumerable<Contractor> GetAll()
    {
      return _contractorsRepository.GetAll();
    }

    internal Contractor GetById(int id)
    {
      Contractor contractor = _contractorsRepository.GetById(id);
      if (contractor == null)
      {
        throw new Exception("Invalid Id");
      }
      return contractor;
    }

    internal Contractor Create(Contractor newContractor)
    {
      int id = _contractorsRepository.Create(newContractor);
      newContractor.Id = id;
      return newContractor;
    }

    internal Contractor Edit(int id, Contractor editedContractor)
    {
      throw new NotImplementedException();
    }

    internal string Delete(int id)
    {
      GetById(id);
      _contractorsRepository.Delete(id);
      return "Successfully Deleted";
    }
  }
}