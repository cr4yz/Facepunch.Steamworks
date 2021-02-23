using System.Linq;

namespace Steamworks.Data
{
	public struct LeaderboardEntry
	{
		public Friend User;
		public int GlobalRank;
		public int Score;
		public int[] Details;
		public Data.Ugc Ugc;
		// UGCHandle_t m_hUGC

		internal static LeaderboardEntry From( LeaderboardEntry_t e, int[] detailsBuffer )
		{
			var r = new LeaderboardEntry
			{
				User = new Friend( e.SteamIDUser ),
				GlobalRank = e.GlobalRank,
				Score = e.Score,
				Details = null
			};

			r.Ugc = new Ugc();
			r.Ugc.Handle.Value = e.UGC;

			if ( e.CDetails > 0 )
			{
				r.Details = detailsBuffer.Take( e.CDetails ).ToArray();
			}

			return r;
		}
	}
}