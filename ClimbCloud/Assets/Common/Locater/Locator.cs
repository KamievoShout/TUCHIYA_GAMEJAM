using System.Collections.Generic;

namespace Utility
{
    public class Locator<T>
    {
        private static Dictionary<int, object> objects = new Dictionary<int, object>();

        public static void Register(T t, int idx = 0)
        {
            if (t != null) 
                objects[idx] = t;
            else
                objects.Add(idx, t);
        }

        public static T Resolve(int idx = 0)
        {
            return (T)objects[idx];
        }
    }
}