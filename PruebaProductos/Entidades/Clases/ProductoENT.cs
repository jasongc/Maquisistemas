﻿using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entidades.Clases
{
    public class ProductoENT : IProductoENT
	{

		public int ProductId { get => InternalProductId; }
		public string Name { get; set; } = string.Empty;
		public short Status { get; set; }
		public string StatusName { get => InternalStatusName; }
		public decimal Stock { get; set; }
		public string Description { get; set; } = string.Empty;
		public decimal Price { get; set; }
		public DateTime CreateDate { get => InternalCreateDate; }
		public DateTime UpdateDate { get => InternalUpdateDate; }

		#region EXTRAS

		public string Discount { get => InternalDiscount.ToString() + "%"; }

		public decimal FinalPrice { get => Price * ((100 - InternalDiscount) / 100); }

        [JsonIgnore]
		public int InternalProductId { get; set; }
		[JsonIgnore]
		public decimal InternalDiscount { get; set; }
		[JsonIgnore]
		public string InternalStatusName { get; set; } = string.Empty;
		[JsonIgnore]
		public DateTime InternalCreateDate { get; set; }
		[JsonIgnore]
		public DateTime InternalUpdateDate { get; set; }

		#endregion
	}
}
