using System.Collections.Generic;
using csharp_contractors.Models;
using csharp_contractors.Services;
using Microsoft.AspNetCore.Mvc;

namespace csharp_contractors.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  class JobsController : ControllerBase
  {
    private readonly JobsService _jobsService;
    public JobsController(JobsService jobsService)
    {
      _jobsService = jobsService;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> GetAll()
    {
      try
      {
        return Ok(_jobsService.GetAll());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> GetById(int id)
    {
      try
      {
        return Ok(_jobsService.GetById(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        return Ok(_jobsService.Create(newJob));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Edit(int id, [FromBody] Job editedJob)
    {
      try
      {
        return Ok(_jobsService.Edit(id, editedJob));
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
        return Ok(_jobsService.Delete(id));
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}