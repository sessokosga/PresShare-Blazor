namespace PresShare.Website.Api;
using System.Net.Http.Headers;
public static class ApiHelper{
    public static HttpClient? AppClient{get;set;}

    public static void InitializeClient(){
        AppClient = new HttpClient();
        AppClient.DefaultRequestHeaders.Accept.Clear();
        AppClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}