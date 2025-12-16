using System;
namespace RootServer.Shared._Sites
{
	public static class PagesStatic
	{
		public static Dictionary<string, BasePage> pages = new();


		public static void ChangeState()
		{
			foreach (KeyValuePair<string, BasePage> p in pages)
				p.Value.ChangeState();
        }
	}
}