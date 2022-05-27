using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeikomiWordCloud.Models
{
    public class TweetDataM : ModelBase
    {
		#region 作者ID[Autor_Id]プロパティ
		/// <summary>
		/// 作者ID[Autor_Id]プロパティ用変数
		/// </summary>
		string _Autor_Id = string.Empty;
		/// <summary>
		/// 作者ID[Autor_Id]プロパティ
		/// </summary>
		public string Autor_Id
		{
			get
			{
				return _Autor_Id;
			}
			set
			{
				if (_Autor_Id == null || !_Autor_Id.Equals(value))
				{
					_Autor_Id = value;
					NotifyPropertyChanged("Autor_Id");
				}
			}
		}
		#endregion

		#region ツイートID[Id_X]プロパティ
		/// <summary>
		/// ツイートID[Id_X]プロパティ用変数
		/// </summary>
		string _Id_X = string.Empty;
		/// <summary>
		/// ツイートID[Id_X]プロパティ
		/// </summary>
		public string Id_X
		{
			get
			{
				return _Id_X;
			}
			set
			{
				if (_Id_X == null || !_Id_X.Equals(value))
				{
					_Id_X = value;
					NotifyPropertyChanged("Id_X");
				}
			}
		}
		#endregion

		#region 作成日時[CreatedAt]プロパティ
		/// <summary>
		/// 作成日時[CreatedAt]プロパティ用変数
		/// </summary>
		DateTime _CreatedAt = DateTime.MinValue;
		/// <summary>
		/// 作成日時[CreatedAt]プロパティ
		/// </summary>
		public DateTime CreatedAt
		{
			get
			{
				return _CreatedAt;
			}
			set
			{
				if (!_CreatedAt.Equals(value))
				{
					_CreatedAt = value;
					NotifyPropertyChanged("CreatedAt");
				}
			}
		}
		#endregion

		#region 言語[lang]プロパティ
		/// <summary>
		/// 言語[lang]プロパティ用変数
		/// </summary>
		string _lang = string.Empty;
		/// <summary>
		/// 言語[lang]プロパティ
		/// </summary>
		public string lang
		{
			get
			{
				return _lang;
			}
			set
			{
				if (_lang == null || !_lang.Equals(value))
				{
					_lang = value;
					NotifyPropertyChanged("lang");
				}
			}
		}
		#endregion

		#region ツイート内容[Text]プロパティ
		/// <summary>
		/// ツイート内容[Text]プロパティ用変数
		/// </summary>
		string _Text = string.Empty;
		/// <summary>
		/// ツイート内容[Text]プロパティ
		/// </summary>
		public string Text
		{
			get
			{
				return _Text;
			}
			set
			{
				if (_Text == null || !_Text.Equals(value))
				{
					_Text = value;
					NotifyPropertyChanged("Text");
				}
			}
		}
		#endregion

		#region リツイート数[Retweet_Count]プロパティ
		/// <summary>
		/// リツイート数[Retweet_Count]プロパティ用変数
		/// </summary>
		int _Retweet_Count = 0;
		/// <summary>
		/// リツイート数[Retweet_Count]プロパティ
		/// </summary>
		public int Retweet_Count
		{
			get
			{
				return _Retweet_Count;
			}
			set
			{
				if (!_Retweet_Count.Equals(value))
				{
					_Retweet_Count = value;
					NotifyPropertyChanged("Retweet_Count");
				}
			}
		}
		#endregion

		#region リプライ数[Replay_Count]プロパティ
		/// <summary>
		/// リプライ数[Replay_Count]プロパティ用変数
		/// </summary>
		int _Replay_Count = 0;
		/// <summary>
		/// リプライ数[Replay_Count]プロパティ
		/// </summary>
		public int Replay_Count
		{
			get
			{
				return _Replay_Count;
			}
			set
			{
				if (!_Replay_Count.Equals(value))
				{
					_Replay_Count = value;
					NotifyPropertyChanged("Replay_Count");
				}
			}
		}
		#endregion

		#region いいね数[Like_Count]プロパティ
		/// <summary>
		/// いいね数[Like_Count]プロパティ用変数
		/// </summary>
		int _Like_Count = 0;
		/// <summary>
		/// いいね数[Like_Count]プロパティ
		/// </summary>
		public int Like_Count
		{
			get
			{
				return _Like_Count;
			}
			set
			{
				if (!_Like_Count.Equals(value))
				{
					_Like_Count = value;
					NotifyPropertyChanged("Like_Count");
				}
			}
		}
		#endregion

		#region 投票数[Quate_Count]プロパティ
		/// <summary>
		/// 投票数[Quate_Count]プロパティ用変数
		/// </summary>
		int _Quate_Count = 0;
		/// <summary>
		/// 投票数[Quate_Count]プロパティ
		/// </summary>
		public int Quate_Count
		{
			get
			{
				return _Quate_Count;
			}
			set
			{
				if (!_Quate_Count.Equals(value))
				{
					_Quate_Count = value;
					NotifyPropertyChanged("Quate_Count");
				}
			}
		}
		#endregion

		#region 作者作成日[CreatedAtAutor]プロパティ
		/// <summary>
		/// 作者作成日[CreatedAtAutor]プロパティ用変数
		/// </summary>
		DateTime _CreatedAtAutor = DateTime.MinValue;
		/// <summary>
		/// 作者作成日[CreatedAtAutor]プロパティ
		/// </summary>
		public DateTime CreatedAtAutor
		{
			get
			{
				return _CreatedAtAutor;
			}
			set
			{
				if (!_CreatedAtAutor.Equals(value))
				{
					_CreatedAtAutor = value;
					NotifyPropertyChanged("CreatedAtAutor");
				}
			}
		}
		#endregion

		#region 作者名[Name]プロパティ
		/// <summary>
		/// 作者名[Name]プロパティ用変数
		/// </summary>
		string _Name = string.Empty;
		/// <summary>
		/// 作者名[Name]プロパティ
		/// </summary>
		public string Name
		{
			get
			{
				return _Name;
			}
			set
			{
				if (_Name == null || !_Name.Equals(value))
				{
					_Name = value;
					NotifyPropertyChanged("Name");
				}
			}
		}
		#endregion

		#region 作者説明[Description]プロパティ
		/// <summary>
		/// 作者説明[Description]プロパティ用変数
		/// </summary>
		string _Description = string.Empty;
		/// <summary>
		/// 作者説明[Description]プロパティ
		/// </summary>
		public string Description
		{
			get
			{
				return _Description;
			}
			set
			{
				if (_Description == null || !_Description.Equals(value))
				{
					_Description = value;
					NotifyPropertyChanged("Description");
				}
			}
		}
		#endregion

		#region フォロー数[Follow_Count]プロパティ
		/// <summary>
		/// フォロー数[Follow_Count]プロパティ用変数
		/// </summary>
		int _Follow_Count = 0;
		/// <summary>
		/// フォロー数[Follow_Count]プロパティ
		/// </summary>
		public int Follow_Count
		{
			get
			{
				return _Follow_Count;
			}
			set
			{
				if (!_Follow_Count.Equals(value))
				{
					_Follow_Count = value;
					NotifyPropertyChanged("Follow_Count");
				}
			}
		}
		#endregion

		#region フォロワー数[Follower_Count]プロパティ
		/// <summary>
		/// フォロワー数[Follower_Count]プロパティ用変数
		/// </summary>
		int _Follower_Count = 0;
		/// <summary>
		/// フォロワー数[Follower_Count]プロパティ
		/// </summary>
		public int Follower_Count
		{
			get
			{
				return _Follower_Count;
			}
			set
			{
				if (!_Follower_Count.Equals(value))
				{
					_Follower_Count = value;
					NotifyPropertyChanged("Follower_Count");
				}
			}
		}
		#endregion

		#region ツイート数[Tweet_Count]プロパティ
		/// <summary>
		/// ツイート数[Tweet_Count]プロパティ用変数
		/// </summary>
		int _Tweet_Count = 0;
		/// <summary>
		/// ツイート数[Tweet_Count]プロパティ
		/// </summary>
		public int Tweet_Count
		{
			get
			{
				return _Tweet_Count;
			}
			set
			{
				if (!_Tweet_Count.Equals(value))
				{
					_Tweet_Count = value;
					NotifyPropertyChanged("Tweet_Count");
				}
			}
		}
		#endregion

		#region リスト登録され数[Listed_Count]プロパティ
		/// <summary>
		/// リスト登録され数[Listed_Count]プロパティ用変数
		/// </summary>
		int _Listed_Count = 0;
		/// <summary>
		/// リスト登録され数[Listed_Count]プロパティ
		/// </summary>
		public int Listed_Count
		{
			get
			{
				return _Listed_Count;
			}
			set
			{
				if (!_Listed_Count.Equals(value))
				{
					_Listed_Count = value;
					NotifyPropertyChanged("Listed_Count");
				}
			}
		}
		#endregion


	}
}
