using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IProductoENT
    {
		public int ProductId { get; }
		public string Name { get; set; }
		public short Status { get; set; }
		public decimal Stock { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public DateTime CreateDate { get; }
		public DateTime UpdateDate { get; }
	}
}
