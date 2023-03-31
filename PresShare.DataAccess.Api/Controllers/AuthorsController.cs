using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PresShare.DataAccess.Lib.Hasher;

namespace PresShare.DataAccess.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly ILogger<AuthorsController> _logger;
    private IPasswordHasher _passwordHasher;

    public AuthorsController(ILogger<AuthorsController> logger, IPasswordHasher passwordHasher)
    {
        _logger = logger;
        _passwordHasher = passwordHasher;
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


    [HttpPost("token")]
    public async Task<IResult> Login(AuthenticatinoAuthorModel author, IAuthorData data)
    {
        try
        {
            var pseudo = await IsValidPseudoAndPassword(author.pseudo, author.password,data);
            if (pseudo != null)
            {
                return Results.Ok(await GenerateToken(pseudo,data));
            }
            else
            {
                return Results.Ok();
            }

        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private async Task<dynamic> GenerateToken(string pseudo, IAuthorData data)
    {
        var author = await data.GetAuhtorByPseudo(pseudo);
        var claims = new List<Claim>(){
        new Claim(ClaimTypes.Name,pseudo),
        new Claim(ClaimTypes.NameIdentifier,author.id.ToString()),
        new Claim(JwtRegisteredClaimNames.Nbf,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
        new Claim(JwtRegisteredClaimNames.Exp,new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
       };

        var token = new JwtSecurityToken(
         new JwtHeader(
             new SigningCredentials(
                 new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMySecretKeyDonttell")),
                 SecurityAlgorithms.HmacSha256)),
                 new JwtPayload(claims));
        
        var output = new {
            access_token = new JwtSecurityTokenHandler().WriteToken(token),
            pseudo = pseudo
        };

        return output;

    }
    private async Task<string> IsValidPseudoAndPassword(string pseudo, string password, IAuthorData data)
    {
        var author = await data.GetAuhtorByPseudo(pseudo);
        if (author == null)
        {
            var auth = await data.GetAuhtorByEmail(pseudo);
            if (auth == null)
                return null;
            else
            {
                if( _passwordHasher.Verify(auth.password,password))
                    return auth.pseudo;
                else
                    return null;
            }
        }
        else
        {
            if( _passwordHasher.Verify(author.password,password))
                return author.pseudo;
            else
                return null;
        }
    }

    [HttpPost]
    public async Task<IResult> InsertAuthor(AuthorModel author, IAuthorData data)
    {
        try
        {
            author.password = _passwordHasher.Hash(author.password);
            await data.InsertAuthor(author);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    [HttpPut]
    public async Task<IResult> UpdateAuthor(AuthorModel author, IAuthorData data)
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