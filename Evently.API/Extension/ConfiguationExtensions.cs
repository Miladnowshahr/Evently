namespace Evently.API.Extension;

internal static class ConfiguationExtensions
{
    internal static void AddModuleConfiguration(this IConfigurationBuilder configurationBuilder, string[] modules)
    {
        foreach (var module in modules)
        {
            configurationBuilder.AddJsonFile($"modules.{module}.json",false,true);
            configurationBuilder.AddJsonFile($"module,{module}.development.json" ,false,true);
        }
    }

}
