namespace PresShare.Website.Api;
using PresShare.DataModel.Lib;
public class AuthorProcessor
{

    public async Task<AuthorModel> GetAuthor(int id)
    {
        string url = $"https://localhost:7244/authors/{id}";

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                AuthorModel press = await response.Content.ReadAsAsync<AuthorModel>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

    public async Task<AuthorModel> GetAuthorByPseudo(string pseudo)
    {
        string url = $"https://localhost:7244/authors/pseudo/{pseudo}";

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                AuthorModel press = await response.Content.ReadAsAsync<AuthorModel>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }



    public async Task<AuthorModel> GetAuthorByEmail(string email)
    {
        string url = $"https://localhost:7244/authors/email/{email}";

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                AuthorModel press = await response.Content.ReadAsAsync<AuthorModel>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }


    public async Task<bool> Add(AuthorModel author)
    {
        string url = "https://localhost:7244/authors";

        using (HttpResponseMessage response = await ApiHelper.AppClient.PostAsJsonAsync<AuthorModel>(url, author))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }


    public async Task<bool> CheckEmailExist(string email)
    {
        bool exist = true;
        try
        {
            await GetAuthorByEmail(email);
        }
        catch (System.Exception e)
        {
            exist= false;
        }
        return exist;
    }

    public async Task<bool> CheckPseudoExist(string pseudo)
    {
        bool exist = true;
        try
        {
            await this.GetAuthorByPseudo(pseudo);
        }
        catch (System.Exception e)
        {
            exist = false;
        }
        return exist;
    }

public async Task<bool> Update(AuthorModel press)
    {
        string url =  "https://localhost:7244/authors";

        using (HttpResponseMessage response = await ApiHelper.AppClient.PutAsJsonAsync<AuthorModel>(url,press))
        {
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}