using System;
using System.Linq;
using Newtonsoft.Json;
using Xunit;

namespace Paging.Tests
{
	public class SerializationTests
	{
		Pagination<string> page;

		public SerializationTests()
		{
			page = new Pagination<string>(new[] { "one", "two", "three", "four", "five" }, 1, 5, 15);
		}

		[Fact]
		public void can_serialize_to_json()
		{
			string json = JsonConvert.SerializeObject(page);

			Assert.Contains("\"Items\":[\"one\",", json);
			Assert.Contains("\"TotalItems\":15", json);
			Assert.Contains("\"TotalPages\":3", json);
		}

		[Fact]
		public void can_deserialize_from_json()
		{
			string json = JsonConvert.SerializeObject(page);

			var deserialized = JsonConvert.DeserializeObject<Pagination<string>>(json);

			Assert.NotNull(deserialized);
			Assert.Equal(1, deserialized.Page);
			Assert.Equal(5, deserialized.PageSize);
			Assert.Equal(15, deserialized.TotalItems);

			Assert.Equal(5, deserialized.Items.Count());
			Assert.Contains("three", deserialized.Items);
		}
	}
}