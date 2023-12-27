using Aula.Entities.Enums;
using System.Globalization;
using System.Text;

namespace Aula.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order status: ");
            sb.AppendLine(Status.ToString());
            sb.Append("Client: ");
            sb.Append(Client.Name);
            sb.Append(" - ");
            sb.Append(Client.BirthDate.ToString());
            sb.Append(" - ");
            sb.AppendLine(Client.Email);
            sb.AppendLine();
            sb.AppendLine("Order intems: ");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.Product.Name +  ", $" + item.Price + ", Quantity: " + item.Quantity + ", Subtotal: " + item.SubTotal().ToString("F2", CultureInfo.InvariantCulture));
            }
            sb.AppendLine();
            sb.Append("Total price: $");
            sb.AppendLine(Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();

        }
    }
}
