using System.Collections.Generic;
using csharp_contractors.Models;
using csharp_contractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_contractors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorsController : ControllerBase
  {
    private readonly ContractorsService _contractorsService;
    public ContractorsController(ContractorsService contractorsService)
    {
      _contractorsService = contractorsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Contractor>> GetAll()
    {
      try
      {
        return Ok(_contractorsService.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Contractor> GetById(int id)
    {
      try
      {
        return Ok(_contractorsService.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Contractor> Create([FromBody] Contractor newContractor)
    {
      try
      {
        return Ok(_contractorsService.Create(newContractor));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Contractor> Edit(int id, [FromBody] Contractor editedContractor)
    {
      try
      {
        return Ok(_contractorsService.Edit(id, editedContractor));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      try
      {
        return Ok(_contractorsService.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}