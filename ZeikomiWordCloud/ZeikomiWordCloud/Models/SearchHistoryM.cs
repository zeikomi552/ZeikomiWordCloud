using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeikomiWordCloud.Models
{
    public class SearchHistoryM : ModelBase
    {
		#region コンストラクタ
		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="query">検索クエリ(検索キーワード)</param>
		/// <param name="time">検索日時</param>
		public SearchHistoryM(string query, DateTimeOffset time)
        {
			this.Query = query;
			this.SearchTime = time;
        }
		#endregion

		#region 検索キーワード[Query]プロパティ
		/// <summary>
		/// 検索キーワード[Query]プロパティ用変数
		/// </summary>
		string _Query = string.Empty;
		/// <summary>
		/// 検索キーワード[Query]プロパティ
		/// </summary>
		public string Query
		{
			get
			{
				return _Query;
			}
			set
			{
				if (_Query == null || !_Query.Equals(value))
				{
					_Query = value;
					NotifyPropertyChanged("Query");
				}
			}
		}
		#endregion

		#region 検索日時[SearchTime]プロパティ
		/// <summary>
		/// 検索日時[SearchTime]プロパティ用変数
		/// </summary>
		DateTimeOffset _SearchTime = new DateTimeOffset();
		/// <summary>
		/// 検索日時[SearchTime]プロパティ
		/// </summary>
		public DateTimeOffset SearchTime
		{
			get
			{
				return _SearchTime;
			}
			set
			{
				if (!_SearchTime.Equals(value))
				{
					_SearchTime = value;
					NotifyPropertyChanged("SearchTime");
				}
			}
		}
		#endregion


	}
}
