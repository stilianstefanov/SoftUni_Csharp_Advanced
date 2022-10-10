using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }

        public int Count { get { return this.Portfolio.Count; } }

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000)
            {
                if (this.MoneyToInvest - stock.PricePerShare >= 0)
                {
                    this.MoneyToInvest -= stock.PricePerShare;
                    this.Portfolio.Add(stock);
                }
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!this.Portfolio.Any(s => s.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }
            Stock stockToSell = this.Portfolio.Find(s => s.CompanyName == companyName);
            if (sellPrice < stockToSell.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }
            else
            {
                this.MoneyToInvest += sellPrice;
                this.Portfolio.Remove(stockToSell);

                return $"{companyName} was sold.";
            }
        }

        public Stock FindStock(string companyName)
        {
            Stock stock = this.Portfolio.FirstOrDefault(s => s.CompanyName == companyName);

            return stock;
        }

        public Stock FindBiggestCompany()
        {
            if (this.Count == 0)
            {
                return null;
            }
            else
            {
                return this.Portfolio.OrderByDescending(s => s.MarketCapitalization).First();
            }
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in this.Portfolio)
            {
                sb.AppendLine($"{stock.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
