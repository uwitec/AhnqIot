using NewLife.Log;

namespace SmartIot.Tool.Container
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            XTrace.UseConsole();

            MainContainer.ServiceMain();
        }
    }
}