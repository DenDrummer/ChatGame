using System.Collections;
using System.Linq;

namespace ChatGame.Resources
{
    public static class ExtensionMethods
    {
        public static string GetResourceKey(string resourceValue)
        {
            DictionaryEntry entry = Resources.ResourceManager.GetResourceSet(Resources.Culture, true, true)
                                .OfType<DictionaryEntry>()
                                .FirstOrDefault(e => e.Value.Equals(resourceValue));
            return entry.Key.ToString();
        }
    }
}
