using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Paging
{
	public class Pagination<T>
	{
		readonly IList<T> items;

		public int Page { get; private set; }
		public int PageSize { get; private set; }
		public int TotalItems { get; private set; }

		public IEnumerable<T> Items
		{
			get { return items; }
		}

		public int TotalPages
		{
			get { return (int)Math.Ceiling(((double)TotalItems) / PageSize); }
		}

		public int FirstItem
		{
			get { return ((Page - 1) * PageSize) + 1; }
		}

		public int LastItem
		{
			get { return FirstItem + items.Count - 1; }
		}

		public bool HasPreviousPage
		{
			get { return Page > 1; }
		}

		public bool HasNextPage
		{
			get { return Page < TotalPages; }
		}

		public Pagination()
			: this(new T[0], 1, 1, 0) { }

		[JsonConstructor]
		public Pagination(IEnumerable<T> items, int page, int pageSize, int totalItems)
		{
			if (items == null)
				throw new ArgumentNullException("items");

			if (page < 1)
				throw new ArgumentOutOfRangeException("page", page, "Value must be greater than zero.");

			if (pageSize < 1)
				throw new ArgumentOutOfRangeException("page", page, "Value must be greater than zero.");

			if (totalItems < 0)
				throw new ArgumentOutOfRangeException("page", page, "Value cannot be less than zero.");

			this.items = items.ToList();
			this.Page = page;
			this.PageSize = pageSize;
			this.TotalItems = totalItems;
		}

		public override string ToString()
		{
			return String.Format("{0} Item(s)", TotalItems);
		}
	}
}