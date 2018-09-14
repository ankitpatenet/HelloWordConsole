
using HelloWord.API.Client.Core;

namespace HelloWord.API.Client.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //call core method.
           CallApi.GetHelloWord();
        }
    }
}