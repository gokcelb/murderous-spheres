using System;

namespace Utilities
{
    class PrefabUtility
    {
        public static string GetOriginalPrefabName(string name)
        {
            return name.Replace("(Clone)", "");
        }
    }
}
