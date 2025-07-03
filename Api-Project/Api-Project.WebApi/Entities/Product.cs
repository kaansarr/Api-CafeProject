namespace Api_Project.WebApi.Entities
{
	public class Product
	{
		public int ProductId { get; set; }
		public string ProductName { get; set; }

		public string ProductDescription { get; set; }
		public decimal Price { get; set; }
		public decimal ImageUrl { get; set; }
	}
}
