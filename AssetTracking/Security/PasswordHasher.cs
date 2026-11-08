using System.Security.Cryptography;

namespace AssetTracking.Security;

/// <summary>تشفير كلمة المرور (PBKDF2-SHA256) قبل حفظها في الحقلين PasswordHash و PasswordSalt.</summary>
public static class PasswordHasher
{
    private const int Iterations = 100_000;

    public static (byte[] Hash, byte[] Salt) Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        return (Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, 32), salt);
    }

    public static bool Verify(string password, byte[] hash, byte[] salt) =>
        CryptographicOperations.FixedTimeEquals(
            Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA256, hash.Length), hash);

    public static void Validate(string password)
    {
        if (password.Length < 6) throw new AppException("يجب أن تتكون كلمة المرور من 6 أحرف على الأقل.");
    }
}
