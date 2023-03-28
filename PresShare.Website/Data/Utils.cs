namespace PresShare.Website.Api;
public static class Utils{
    private static Random rand = new Random();

    public static string RandomString(int length){
        string result="";
        string letters="1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
        while(result.Length<length)
            result+=letters.ElementAt<char>(rand.Next(0,letters.Length-1));
        return result;
    }

}