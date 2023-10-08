using alpha_api.Models;

namespace alpha_api.Core
{
    public static class Extensions
    {
        // pick every nth of values
        public static IEnumerable<T> Every<T>(this IEnumerable<T> values, int nth)
        {
            return values.Where((v, i) => i % nth == 0);
        }
    }
}
