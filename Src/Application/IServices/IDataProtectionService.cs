namespace Application.IServices;

public interface IDataProtectionService
{
    string Encrypt(string value);
    string Decrypt(string value);
}
