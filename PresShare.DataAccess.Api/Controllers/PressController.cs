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

    [HttpGet("latest/{limit}")]
    public async Task<IResult> GetLatest(IPressData data, int limit)
    {
        try
        {
            var results = await data.GetLatest(limit);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet("find/{key}")]
    public async Task<IResult> Find(IPressData data, string key)
    {
        try
        {
            var results = await data.FindPress(key);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    

    [HttpGet("{id}")]
    public async Task<IResult> GetPress(IPressData data, int id)
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


    [HttpGet("text")]
    public async Task<IResult> GetAllPressText(IPressData data)
    {
        try
        {
            var results = await data.GetPressesByGenre("Text");
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [HttpGet("text/{limit}")]
    public async Task<IResult> GetPressText(IPressData data, int limit)
    {
        try
        {
            var results = await data.GetPressByGenre("Text", limit);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet("link")]
    public async Task<IResult> GetAllPressLink(IPressData data)
    {
        try
        {
            var results = await data.GetPressesByGenre("Link");
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    [HttpGet("link/{limit}")]
    public async Task<IResult> GetPressLink(IPressData data, int limit)
    {
        try
        {
            var results = await data.GetPressByGenre("Link", limit);
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


    [HttpDelete("delete/{id}")]
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