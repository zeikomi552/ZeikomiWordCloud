using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeikomiWordCloud.Models
{
    public class NounCountM : ModelBase
    {
		#region 名詞[Noun]プロパティ
		/// <summary>
		/// 名詞[Noun]プロパティ用変数
		/// </summary>
		string? _Noun = string.Empty;
		/// <summary>
		/// 名詞[Noun]プロパティ
		/// </summary>
		public string? Noun
		{
			get
			{
				return _Noun;
			}
			set
			{
				if (_Noun == null || !_Noun.Equals(value))
				{
					_Noun = value;
					NotifyPropertyChanged("Noun");
				}
			}
		}
		#endregion

		#region 出現回数[Count]プロパティ
		/// <summary>
		/// 出現回数[Count]プロパティ用変数
		/// </summary>
		int _Count = 0;
		/// <summary>
		/// 出現回数[Count]プロパティ
		/// </summary>
		public int Count
		{
			get
			{
				return _Count;
			}
			set
			{
				if (!_Count.Equals(value))
				{
					_Count = value;
					NotifyPropertyChanged("Count");
				}
			}
		}
		#endregion


	}
}
