using System.Security.Cryptography;


using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
{
    // Export the public key
    string publicKey = rsa.ToXmlString(false);
    // Export the private key
    string privateKey = rsa.ToXmlString(true);
}



public static byte[] EncryptData(byte[] dataToEncrypt, string publicKey)
{
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    {
        rsa.FromXmlString(publicKey);
        return rsa.Encrypt(dataToEncrypt, false);
    }
}


public static byte[] DecryptData(byte[] dataToDecrypt, string privateKey)
{
    using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
    {
        rsa.FromXmlString(privateKey);
        return rsa.Decrypt(dataToDecrypt, false);
    }
}


