using System;
using System.Threading;

namespace PrenoteService
{
    public class PrenoteRepository
    {
        public string DeletePrenote(int prenoteFileNumber)
        {
            Console.WriteLine($"Deleting Prenote...");
            Thread.Sleep(1000);

            return prenoteFileNumber.ToString();
        }
    }
}