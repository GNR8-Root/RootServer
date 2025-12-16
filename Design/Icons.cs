using System;
namespace RootServer.Design
{
	public enum Icons
	{
        home,
        plus,
        volume_high,
        command
    }



    public static class Icon
    {
        public static string Convert(string icon)
        {
            return "oi-" + icon.Replace('_', '-');
        }
    }
}

