using System.Net.Http.Headers;
using System.Text.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PresShare.DataModel.Lib;
using PresShare.Website.Api;

namespace PresShare.Website.Authentication;


public class MyAuthenticationService : IMyAuthenticationService
{
    private readonly AuthenticationStateProvider _authStateProvider;
    private readonly ProtectedLocalStorage _localStorage;
    public MyAuthenticationService(AuthenticationStateProvider authStateProvider, ProtectedLocalStorage localStorage)
    {
        _authStateProvider = authStateProvider;
        _localStorage = localStorage;
    }

    public async Task<AuthorModel> Login(AuthenticatinoAuthorModel userForAuthenticaton, bool remember)
    {
        var data = new FormUrlEncodedContent(new[]{
            new KeyValuePair<string,string>("grant_type", "password"),
            new KeyValuePair<string,string>("pseudo", userForAuthenticaton.pseudo),
            new KeyValuePair<string,string>("password", userForAuthenticaton.password)
        });

        var authResult = await ApiHelper.AppClient.PostAsJsonAsync("https://localhost:7244/authors/token", userForAuthenticaton);
        var authContent = await authResult.Content.ReadAsStringAsync();

        if (authResult.IsSuccessStatusCode is false)
        {
            return null;
        }

        var result = JsonSerializer.Deserialize<AuthorModel>(authContent,
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        if (remember)
            await _localStorage.SetAsync("authToken", result.access_token);

        ((AuthStateProvider)_authStateProvider).NotifyUserAuthentication(result.access_token);
        ApiHelper.AppClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.access_token);
        return result;
    }

    public async Task Logout()
    {
        await _localStorage.DeleteAsync("authToken");
        ((AuthStateProvider)_authStateProvider).NotifyLogout();
        ApiHelper.AppClient.DefaultRequestHeaders.Authorization = null;
    }
}