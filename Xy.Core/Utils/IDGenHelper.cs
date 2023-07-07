namespace Xy.Core.Utils;

public static class IDGenHelper
{
    /// <summary>
    /// 短 ID 生成器期初数据
    /// </summary>
    private static Random _random = new();

    private const string Bigs = "ABCDEFGHIJKLMNPQRSTUVWXY";
    private const string Smalls = "abcdefghjklmnopqrstuvwxyz";
    private const string Numbers = "0123456789";
    private const string Specials = "_-";
    private static string _pool = $"{Smalls}{Bigs}";

    /// <summary>
    /// 线程安全锁
    /// </summary>
    private static readonly object ThreadLock = new();

    /// <summary>
    /// 生成8位的纯数字ID(可改长)
    /// </summary>
    /// <returns></returns>
    public static string NextId(int length = 8)
    {
        return GenerateId(length, true, false, false);
    }

    /// <summary>
    /// 生成8位的纯字母ID(可改长)
    /// </summary>
    /// <returns></returns>
    public static string NextLetterId(int length = 8)
    {
        return GenerateId(length, false, true, false);
    }

    /// <summary>
    /// 生成8位的字母数字ID(可改长)
    /// </summary>
    /// <returns></returns>
    public static string NextStrNumberId(int length = 8)
    {
        return GenerateId(length, true, true, false);
    }

    /// <summary>
    /// 生成8位的杂交ID(可改长)
    /// 杂交 = 数字 + 字母 + 特殊字符
    /// </summary>
    /// <returns></returns>
    public static string NextHybridizationId()
    {
        return GenerateId(8, true, true, true);
    }


    private static readonly int defaultLength = 8;

    private static readonly int defaultStrLength = 50;


    public static string GenerateId(int length = 8, bool isNumber = true, bool isLetter = true, bool isSpStr = true)
    {
        if (length < defaultLength)
        {
            throw new ArgumentException(
                $"The specified length of {length} is less than the lower limit of {defaultLength} to avoid conflicts.");
        }

        var characterPool = _pool;
        var poolBuilder = new StringBuilder();

        // 如果是否包含字母和数据同时位 false,那么就默认生成纯数字的
        if (!isLetter && !isNumber)
        {
            poolBuilder.Append(Numbers);
        }

        // 是否包含字母
        if (isLetter)
        {
            poolBuilder.Append(characterPool);
        }

        // 是否包含数字
        if (isNumber)
        {
            poolBuilder.Append(Numbers);
        }

        // 是否包含特殊字符
        if (isSpStr)
        {
            poolBuilder.Append(Specials);
        }

        var pool = poolBuilder.ToString();

        // 生成拼接
        var output = new char[length];
        for (var i = 0; i < length; i++)
        {
            lock (ThreadLock)
            {
                var charIndex = _random.Next(0, pool.Length);
                output[i] = pool[charIndex];
            }
        }
        return new string(output);
    }

    /// <summary>
    /// 设置参与运算的字符，最少 50 位
    /// </summary>
    /// <param name="characters"></param>
    public static void SetCharacters(string characters)
    {
        if (string.IsNullOrWhiteSpace(characters))
        {
            throw new ArgumentException("The replacement characters must not be null or empty.");
        }

        var charSet = characters
            .ToCharArray()
            .Where(x => !char.IsWhiteSpace(x))
            .Distinct()
            .ToArray();

        if (charSet.Length < defaultStrLength)
        {
            throw new InvalidOperationException(
                $"The replacement characters must be at least {defaultStrLength} letters in length and without whitespace.");
        }

        lock (ThreadLock)
        {
            _pool = new string(charSet);
        }
    }

    /// <summary>
    /// 设置种子ID
    /// </summary>
    /// <param name="seed"></param>
    public static void SetSeed(int seed)
    {
        lock (ThreadLock)
        {
            _random = new Random(seed);
        }
    }

    /// <summary>
    /// 重置所有配置
    /// </summary>
    public static void Reset()
    {
        lock (ThreadLock)
        {
            _random = new Random();
            _pool = $"{Numbers}";
        }
    }
}