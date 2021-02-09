using System;
using System.Xml.Serialization;

namespace IikoApi.Entities.Documents
{
	[Serializable]
	[XmlRoot(ElementName = "item")]
	public class Item
    {
		[XmlElement(ElementName = "isAdditionalExpense")]
		public bool IsAdditionalExpense { get; set; }

		[XmlElement(ElementName = "actualAmount")]
		public double ActualAmount { get; set; }

		[XmlElement(ElementName = "store")]
		public string Store { get; set; }

		[XmlElement(ElementName = "code")]
		public int Code { get; set; }

		[XmlElement(ElementName = "price")]
		public double Price { get; set; }

		[XmlElement(ElementName = "priceWithoutVat")]
		public double PriceWithoutVat { get; set; }

		[XmlElement(ElementName = "sum")]
		public double Sum { get; set; }

		[XmlElement(ElementName = "vatPercent")]
		public double VatPercent { get; set; }

		[XmlElement(ElementName = "vatSum")]
		public double VatSum { get; set; }

		[XmlElement(ElementName = "discountSum")]
		public double DiscountSum { get; set; }

		[XmlElement(ElementName = "amountUnit")]
		public string AmountUnit { get; set; }

		[XmlElement(ElementName = "num")]
		public int Num { get; set; }

		[XmlElement(ElementName = "product")]
		public string Product { get; set; }

		[XmlElement(ElementName = "productArticle")]
		public int ProductArticle { get; set; }

		[XmlElement(ElementName = "amount")]
		public double Amount { get; set; }

		public Item()
        {

        }

		public Item(string product, double amount)
        {
			Product = product;
			Amount = amount;
        }
	}
}
