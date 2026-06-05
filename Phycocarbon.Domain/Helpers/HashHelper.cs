public static class HashHelper
{
    public static string GenerateHash(
        string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool Verify(
        string password,
        string hash)
    {
        return BCrypt.Net.BCrypt.Verify(
            password,
            hash);
    }
}