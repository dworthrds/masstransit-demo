using System;
using Contract;

namespace PrenoteService
{
    public class Prenote : IPrenote
    {
        public int FileNumber { get; set; }
    }
}