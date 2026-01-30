using System.Reflection;

namespace Application
{
    public static class DependencyInjection
    {
        public static readonly Assembly Assembly = typeof(DependencyInjection).Assembly;
    }
}