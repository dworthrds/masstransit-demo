﻿using Contract;

namespace OrderService
{
    public class Order : IOrder
    {
        public int OrderNumber { get; set; }
        public int PrenoteFileNumber { get; set; }
    }
}