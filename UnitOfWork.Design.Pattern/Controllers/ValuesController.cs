using Microsoft.AspNetCore.Mvc;
using UnitOfWork.Design.Pattern.BusinessLayer.Interfaces;
using UnitOfWork.Design.Pattern.BusinessLayer.Models;

namespace UnitOfWork.Design.Pattern.BusinessLayer;

[ApiController]
[Route("api/[controller]/[action]")]
public class Values : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;

    public Values(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet(Name = "GetAllUsers")]
    public async Task<IActionResult> GetAllUsers()
    {
        return Ok(await unitOfWork.User.GetAllEntity());
    }

    [HttpGet(Name = "GetUserById/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        return Ok(await unitOfWork.User.GetEntityById(id));
    }

    [HttpPost(Name = "AddUser")]
    [ServiceFilter(typeof(CustomValidations))]
    public async Task<IActionResult> AddUser([FromBody] User user)
    {
        var result = await unitOfWork.User.AddEntity(user);
        await unitOfWork.commit();
        return Ok(result);
    }

    [HttpPut(Name = "UpdateUser")]
    [ServiceFilter(typeof(CustomValidations))]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        var result = unitOfWork.User.UpdateEntity(user);
        await unitOfWork.commit();
        return Ok(result);
    }

    [HttpDelete(Name = "DeleteUser")]
    [ServiceFilter(typeof(CustomValidations))]
    public async Task<IActionResult> DeleteUser([FromBody] User user)
    {
        var result = unitOfWork.User.RemoveEntity(user);
        await unitOfWork.commit();
        return Ok(result);
    }
}
