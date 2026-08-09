using Application.IServices;
using Microsoft.AspNetCore.DataProtection;

namespace Infrastructure.Services;

public class DataProtectionService : IDataProtectionService
{
    private readonly IDataProtector _protector;

    public DataProtectionService(IDataProtectionProvider provider)
    {
        _protector = provider.CreateProtector("Voltra");
    }

    public string Encrypt(string value) => _protector.Protect(value);
    public string Decrypt(string value) => _protector.Unprotect(value);
}
