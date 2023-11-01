using System.Reflection;

namespace VoteApp.Backend.Commons.Assemblies
{
    public abstract class LoadAllAssemblies
    {
        public static ICollection<Assembly> Get()
        {
            var returnAssemblies = new List<Assembly>();
            var loadedAssemblies = new HashSet<string>();
            var assemblies = new List<Assembly>();

            assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();

            foreach (var assembly in assemblies)
            {
                foreach (var reference in assembly.GetReferencedAssemblies())
                {
                    if (!loadedAssemblies.Any(x => x.Contains(reference.FullName)))
                    {
                        var assemblyLoaded = Assembly.Load(reference);
                        loadedAssemblies.Add(reference.FullName);
                        returnAssemblies.Add(assemblyLoaded);
                    }
                }
            }

            return returnAssemblies;
        }
    }
}
