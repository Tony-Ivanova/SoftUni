using SIS.MvcFramework;
using System;
using System.Threading.Tasks;

namespace MUSACA
{
    public static class Program
    {
        public static async Task Main()
        {
            await WebHost.StartAsync(new Startup());
        }
    }
}
