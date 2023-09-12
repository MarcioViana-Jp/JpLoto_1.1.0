using Microsoft.Extensions.Localization;
using System.Reflection;

namespace JPLoto.Globalization.Localization;

public class CommonLocalizationService
{
    private IStringLocalizer localizer;
    private readonly IStringLocalizerFactory _factory;
    public CommonLocalizationService(IStringLocalizerFactory factory)
    {
        _factory = factory;
    }

    public void SetResource(Type typeOfResource, string nameOfResource)
    {
        var assemblyName = new AssemblyName(typeOfResource.GetTypeInfo().Assembly.FullName);
        localizer = _factory.Create(nameOfResource, assemblyName.Name);
    }
    public string Get(string key)
    {
        return localizer[key];
    }

    public string GetString(Type typeOfResource, string nameOfResource, string key)
    {
        var assemblyName = new AssemblyName(typeOfResource.GetTypeInfo().Assembly.FullName);
        localizer = _factory.Create(nameOfResource, assemblyName.Name);
        return localizer[key];
    }

}
