namespace DataAccessLayer;

public static class Secrets
{

    public static string GetStorageBlobKey()
    {
        return "Ueex4Fn5zpUWAyov0PrLRClehxinOFpc0zBYSCD9slB2y6b2uhL0QmLKuaBCAQBN6U+gx1+1+zLY+AStKRHrog==";
    }

    public static string GetOdbcStr()
    {
        return "Server=tcp:220926netp2dbs.database.windows.net,1433;Initial Catalog=FlareDB;Persist Security Info=False;User ID=flareadmin;Password=fl@a5z123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30";
    }

    public static string GetImageSalt()
    {

        return "DONTLOOOK@TTTMYYPICTURE$SS";
    }
}