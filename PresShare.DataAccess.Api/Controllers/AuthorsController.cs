using Microsoft.AspNetCore.Mvc;

namespace PresShare.DataAccess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ILogger<AuthorsController> _logger;

    public AuthorsController(ILogger<AuthorsController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IResult> GetAuthors(IAuthorData data)
    {
        try
        {
            return Results.Ok(await data.GetAuthors());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetAuthor(IAuthorData data, int id)
    {
        try
        {
            var results = await data.GetAuhtor(id);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet("email/{email}")]
    public async Task<IResult> GetAuthorByEmail(IAuthorData data, string email)
    {
        try
        {
            var results = await data.GetAuhtorByEmail(email);
            if (results == null)
                return Results.NotFound();
            return Results.Ok(results);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpGet("pseudo/{pseudo}")]
    public async Task<IResult> GetAuthorByPseudo(IAuthorData data, string pseudo)
    {
        try
        {
            var results = await data.GetAuhtorByPseudo(pseudo);
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
    public async Task<IResult> InsertAuthor(AuthorModel author, IAuthorData data)
    {
        try
        {
            await data.InsertAuthor(author);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut()]
    public async Task<IResult> UpdateAuthorProfile(AuthorModel author, IAuthorData data)
    {
        try
        {            
            await data.UpdateAuthor(author);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IResult> DeleteAuthor(IAuthorData data, int id)
    {
        try
        {
            await data.DeleteAuthor(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }


}