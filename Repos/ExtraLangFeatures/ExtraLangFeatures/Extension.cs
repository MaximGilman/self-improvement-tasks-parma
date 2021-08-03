using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ExtraLangFeatures
{
    public static class Extension
    {
        public static int GetLettersCount(this string str) => str.Count(x => !string.IsNullOrWhiteSpace(x.ToString()));
    }
}