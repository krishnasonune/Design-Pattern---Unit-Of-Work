using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer;

[ApiController]
[Route("api/[controller]/[action]")]
public class Movie : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public Movie(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet(Name = "GetAllMovies")]
    public async Task<IActionResult> GetAllMovies()
    {
        return Ok(await unitOfWork.Movies.GetAllEntity());
    }

    [HttpGet(Name = "GetMovieById/{id}")]
    public async Task<IActionResult> GetMovieById(int id)
    {
        return Ok(await unitOfWork.Movies.GetEntityById(id));
    }

    [HttpPost(Name = "AddMovie")]
    [ServiceFilter(typeof(CustomValidations))]
    public async Task<IActionResult> AddMovie([FromBody] Models.Movie movie)
    {
        var result = await unitOfWork.Movies.AddEntity(movie);
        await unitOfWork.commit();
        return Ok(result);
    }

    [HttpPut(Name = "UpdateMovie")]
    [ServiceFilter(typeof(CustomValidations))]
    public async Task<IActionResult> UpdateMovie([FromBody] Models.Movie Movie)
    {
        var result = unitOfWork.Movies.UpdateEntity(Movie);
        await unitOfWork.commit();
        return Ok(result);
    }

    [HttpDelete(Name = "DeleteMovie")]
    [ServiceFilter(typeof(CustomValidations))]
    public async Task<IActionResult> DeleteMovie([FromBody] Models.Movie Movie)
    {
        var result = unitOfWork.Movies.RemoveEntity(Movie);
        await unitOfWork.commit();
        return Ok(result);
    }
}