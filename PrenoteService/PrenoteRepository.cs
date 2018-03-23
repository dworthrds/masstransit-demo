using System;
using System.Threading;
using Contract;
using Contract.Model;
using PrenoteService.Model;

namespace PrenoteService
{
    public class PrenoteRepository
    {
        public IPrenote DeletePrenote(int prenoteFileNumber)
        {
            Console.WriteLine($"Deleting Prenote...");
            Thread.Sleep(1000);

            return new Prenote(){FileNumber = prenoteFileNumber };
        }
    }
}