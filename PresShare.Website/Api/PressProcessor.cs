namespace PresShare.Website.Api;
using PresShare.DataModel.Lib;
public class PressProcessor
{

    public async Task<PressModel> LoadPress(int id = 0)
    {
        string url = "";
        if (id == 0)
        {
            url = "https://localhost:7244/press/1";
        }
        else
        {
            url = $"https://localhost:7244/press/{id}";
        }

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                PressModel press = await response.Content.ReadAsAsync<PressModel>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

    public async Task<IEnumerable<PressModel>> LoadPresses()
    {
        string url = "https://localhost:7244/press";
        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<PressModel> press = await response.Content.ReadAsAsync<IEnumerable<PressModel>>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
    public async Task<IEnumerable<PressModel>> LoadPressesByGenre(string genre, int limit=0)
    {
        string url = "";
        if (limit > 0)
            url = $"https://localhost:7244/press/{genre}/{limit}";
        else
            url = $"https://localhost:7244/press/{genre}";

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<PressModel> press = await response.Content.ReadAsAsync<IEnumerable<PressModel>>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }public async Task<IEnumerable<PressModel>> Find(string key)
    {
        string url = $"https://localhost:7244/press/find/{key}";

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<PressModel> press = await response.Content.ReadAsAsync<IEnumerable<PressModel>>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

    public async Task<IEnumerable<PressModel>> LoadLatest(int limit)
    {
        string url =  $"https://localhost:7244/press/latest/{limit}";

        using (HttpResponseMessage response = await ApiHelper.AppClient.GetAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                IEnumerable<PressModel> press = await response.Content.ReadAsAsync<IEnumerable<PressModel>>();
                return press;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

  public async Task<bool> Update(PressModel press)
    {
        string url =  "https://localhost:7244/press";

        using (HttpResponseMessage response = await ApiHelper.AppClient.PutAsJsonAsync<PressModel>(url,press))
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

    public async Task<bool> Add(PressModel press)
    {
        string url =  "https://localhost:7244/press";

        using (HttpResponseMessage response = await ApiHelper.AppClient.PostAsJsonAsync<PressModel>(url,press))
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

    
    public async Task<int> DeletePress(int id)
    {
        string url = $"https://localhost:7244/press/{id}";
        

        using (HttpResponseMessage response = await ApiHelper.AppClient.DeleteAsync(url))
        {
            if (response.IsSuccessStatusCode)
            {
                return id;
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }

    

}