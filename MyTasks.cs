using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MyTasks
    {
        public async Task<int> Calculate(int millisecondsDelay)
        {
            await Task.Delay(millisecondsDelay);
            return new Random(new Random().Next()).Next(0, 20000);
        }
        public async Task<string> CalculateStr()
        {
            await Task.Delay(2000);
            return new Random(new Random().Next()).Next(0, 20000).ToString();
        }
    }
}