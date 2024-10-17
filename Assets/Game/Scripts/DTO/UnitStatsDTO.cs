using System.Collections;
using FPS.Sheets;

namespace DTO
{
	public readonly struct UnitStatsDTO : ISheetDTO
	{
		public readonly float Health;
		public readonly float Armor;
		public readonly float Range;
		public readonly float Attack;
		private readonly string _id;

		public string Id => _id;

		public UnitStatsDTO(IDictionary ht)
		{
			SheetsApi.ParseValue(ht[nameof(Id)], out _id);
			SheetsApi.ParseValue(ht[nameof(Health)], out Health);
			SheetsApi.ParseValue(ht[nameof(Armor)], out Armor);
			SheetsApi.ParseValue(ht[nameof(Range)], out Range);
			SheetsApi.ParseValue(ht[nameof(Attack)], out Attack);
		}
	}
}