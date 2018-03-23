using Contract.Model;

namespace TcpGateway.Model
{
    public class Order : IOrder
    {
        public int OrderNumber { get; set; }
        public int PrenoteFileNumber { get; set; }
    }
}