using Microsoft.AspNetCore.Mvc;

namespace PresShare.DataAccess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PressController : ControllerBase
{
    private readonly ILogger<PressController> _logger;

    public PressController(ILogger<PressController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IResult> GetPresses(IPressData data)
    {
        try
        {
            return Results.Ok(await data.GetPresses());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetAuthor(IPressData data, int id)
    {
        try
        {
            var results = await data.GetPress(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IResult> InsertPress(PressModel press, IPressData data)
    {
        try
        {
            await data.InsertPress(press);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdatePress(PressModel press, IPressData data)
    {
        try
        {            
            await data.UpdatePress(press);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    
    [HttpDelete]
    public async Task<IResult> DeletePress(IPressData data, int id)
    {
        try
        {
            await data.DeletePress(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}