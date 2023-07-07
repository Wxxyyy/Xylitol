namespace Xy.Core.Utils;

/// <summary>
/// Sm4算法  
/// 对标国际DES算法
/// 加密和解密结构相同，只不过，解密密钥是加密密钥的逆序
/// </summary>
public static class SM4Utils
{
    /// <summary>
    /// 秘钥
    /// 不同的key，加密出来的数据不一样，所以此处设定好key以后，禁止修改
    /// </summary>
    public static string Key = App.Configuration["XyInfo:Sm4Key"] ?? "";

    /// <summary>
    /// 向量
    /// </summary>
    public static string Iv = "0000000000000000";

    /// <summary>
    /// 明文是否是十六进制
    /// </summary>
    public static bool HexString = false;

    /// <summary>
    /// 加密模式(默认ECB)
    /// 统一改为ECB模式
    /// </summary>
    public static Sm4CryptoEnum CryptoMode = Sm4CryptoEnum.ECB;


    #region 加密


    /// <summary>
    /// SM4加密
    /// </summary>
    /// <param name="plainText">明文</param>
    /// <returns>密文</returns>
    public static string 加密(string plainText)
    {
        string cipherText;
        if (CryptoMode == Sm4CryptoEnum.ECB)
        {
            cipherText = Encrypt_ECB(plainText);
        }
        else
        {
             cipherText = Encrypt_CBC(plainText);
        }
        return cipherText;
    }

    /// <summary>
    /// ECB加密
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string Encrypt_ECB(string plainText)
    {
        Sm4Context ctx = new Sm4Context
        {
            IsPadding = true
        };
        byte[] keyBytes = HexString ? Convert.FromHexString(Key) : Encoding.Default.GetBytes(Key);
        SM4 sm4 = new SM4();
        sm4.SetKeyEnc(ctx, keyBytes);
        byte[] encrypted = sm4.Sm4CryptEcb(ctx, Encoding.Default.GetBytes(plainText));
        // return Encoding.Default.GetString(Hex.Encode(encrypted));
        return BitConverter.ToString(encrypted).Replace("-", "");
    }

    /// <summary>
    /// CBC加密
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    public static string Encrypt_CBC(string plainText)
    {
        Sm4Context ctx = new Sm4Context
        {
            IsPadding = true
        };
        byte[] keyBytes = HexString ? Convert.FromHexString(Key) : Encoding.Default.GetBytes(Key);
        byte[] ivBytes = HexString ? Convert.FromHexString(Iv) : Encoding.Default.GetBytes(Iv);
        SM4 sm4 = new SM4();
        sm4.SetKeyEnc(ctx, keyBytes);
        byte[] encrypted = sm4.Sm4CryptCbc(ctx, ivBytes, Encoding.Default.GetBytes(plainText));
        return Convert.ToBase64String(encrypted);
    }

    #endregion


    #region 解密

    /// <summary>
    /// SM4解密
    /// </summary>
    /// <param name="cipherText">密文</param>
    /// <returns>明文</returns>
    public static string 解密(string cipherText)
    {
        string plainText;
        if (CryptoMode == Sm4CryptoEnum.ECB)
        {
            plainText = Decrypt_ECB(cipherText);
        }
        else
        {
            plainText = Decrypt_CBC(cipherText);
        }
        return plainText;
    }

    /// <summary>
    /// ECB解密
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    public static string Decrypt_ECB(string cipherText)
    {
        Sm4Context ctx = new Sm4Context
        {
            IsPadding = true,
            Mode = 0
        };
        byte[] keyBytes = HexString ? Convert.FromHexString(Key) : Encoding.Default.GetBytes(Key);
        SM4 sm4 = new SM4();
        sm4.Sm4SetKeyDec(ctx, keyBytes);
        byte[] decrypted = sm4.Sm4CryptEcb(ctx, Convert.FromHexString(cipherText));
        return Encoding.Default.GetString(decrypted);
    }

    /// <summary>
    /// CBC解密
    /// </summary>
    /// <param name="cipherText"></param>
    /// <returns></returns>
    public static string Decrypt_CBC(string cipherText)
    {
        Sm4Context ctx = new Sm4Context
        {
            IsPadding = true,
            Mode = 0
        };
        byte[] keyBytes = HexString ? Convert.FromHexString(Key) : Encoding.Default.GetBytes(Key);
        byte[] ivBytes = HexString ? Convert.FromHexString(Iv) : Encoding.Default.GetBytes(Iv);
        SM4 sm4 = new SM4();
        sm4.Sm4SetKeyDec(ctx, keyBytes);
        byte[] decrypted = sm4.Sm4CryptCbc(ctx, ivBytes, Convert.FromBase64String(cipherText));
        return Encoding.Default.GetString(decrypted);
    }

    #endregion
    /// <summary>
    /// 加密类型
    /// </summary>
    public enum Sm4CryptoEnum
    {
        /// <summary>
        /// ECB(电码本模式)
        /// </summary>
        [Description("ECB模式")]
        ECB = 0,
        /// <summary>
        /// CBC(密码分组链接模式)
        /// </summary>
        [Description("CBC模式")]
        CBC = 1
    }
}