﻿using System;
namespace FastFood.Models
{
	public class OrderDetail
	{
		public int Id { get; set; }

		public int OrderHeaderId { get; set; }

		public OrderHeader OrderHeader { get; set; }

		public int ItemId { get; set; }

		public Item Item { get; set; }

		public int Count { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public double Price { get; set; }
	}
}
