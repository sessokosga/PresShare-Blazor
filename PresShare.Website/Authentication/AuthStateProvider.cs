using System.Net.Http.Headers;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using PresShare.Website.Api;

namespace PresShare.Website.Authentication;

public class AuthStateProvider : AuthenticationStateProvider{
    private readonly AuthenticationState _anonymous;
    private readonly ProtectedLocalStorage _localstorage;

    public AuthStateProvider(ProtectedLocalStorage localstorage)
    {        
        _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));    
        _localstorage = localstorage;
    }

    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        var result = await _localstorage.GetAsync<string>("authToken");
        var token = result.Value;
        if(string.IsNullOrEmpty(token)){
            return _anonymous;
        }
        ApiHelper.AppClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer",token);
        return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimFromJWT(token),"jwtAuthType")));
    }

    public void NotifyUserAuthentication(string token){
        var authenticatedUser = new ClaimsPrincipal(
            new ClaimsIdentity(JwtParser.ParseClaimFromJWT(token),
            "jwtAuthType"));            
        var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
        NotifyAuthenticationStateChanged(authState);
    }

    public void NotifyLogout(){
        var authState = Task.FromResult(_anonymous);
        NotifyAuthenticationStateChanged(authState);
    }
}