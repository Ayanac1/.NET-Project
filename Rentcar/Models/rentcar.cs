using System.ComponentModel.DataAnnotations;

namespace Rentcar.Models
{
	public class rentcar
	{
		[Key]
		public int Id { get; set; }

		[Required]

		public string? Model { get; set; }
		
		public int Price { get; set; }

		public int Year { get; set; }


		public DateTime Rentdate { get; set; }

		public DateTime Returndate { get; set; }

		public int IsAvailable { get; set; }





	}
}
