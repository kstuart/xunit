using System;
using System.Reflection;

internal static class AssemblyExtensions
{
    public static string GetLocalCodeBase(this Assembly assembly)
    {
        string codeBase = assembly.CodeBase;
        if (codeBase == null)
            return null;

        if (!codeBase.StartsWith("file:///"))
            throw new ArgumentException(String.Format("Code base {0} in wrong format; must start with file:///", codeBase), "assembly");

        codeBase = codeBase.Substring(8);
        if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            return "/" + codeBase;


        return codeBase.Replace('/', '\\');
    }
}
