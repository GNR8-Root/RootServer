using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Linq;


namespace RootServer.Shared.Airtable
{
	public static class AirtableVarAsStringExtention
	{
        public static object? GetProperty<T>(this T obj, string name) where T : class
        {
            Type t = typeof(T);

            if (t.GetProperty(name) != null)
            {
                var a = t.GetProperty(name).GetValue(obj, null);

                if (a != null)
                    return a;
            }
            
            return null;
        }
    }
}

