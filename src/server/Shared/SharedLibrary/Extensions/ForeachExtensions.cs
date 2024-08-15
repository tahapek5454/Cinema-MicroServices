
namespace SharedLibrary.Extensions
{
    public static class ForeachExtensions
    {
        public static void ForeachWithIndex<T>(this IEnumerable<T> enumarable, Action<T,int> handler)
        {
            int index = 0;
            foreach (var item in enumarable)
                handler(item, index++);
        }
    }
}
