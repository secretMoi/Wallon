using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestServer.Models
{
	public class Locataire
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(50)]
		[Column(TypeName = "varchar(50)")]
		public string Nom { get; set; }

		[Required]
		[MaxLength(50)]
		[Column(TypeName = "varbinary(max)")]
		public byte[] Password { get; set; }

		[DefaultValue(true)]
		public bool Actif { get; set; }
	}
}
