using ClosedXML.Excel;
using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Globalization;
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
		DateTimeOffset _CreatedAt = DateTimeOffset.MinValue;
		/// <summary>
		/// 作成日時[CreatedAt]プロパティ
		/// </summary>
		public DateTimeOffset CreatedAt
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

		#region 言語[Lang]プロパティ
		/// <summary>
		/// 言語[Lang]プロパティ用変数
		/// </summary>
		string _Lang = string.Empty;
		/// <summary>
		/// 言語[Lang]プロパティ
		/// </summary>
		public string Lang
		{
			get
			{
				return _Lang;
			}
			set
			{
				if (_Lang == null || !_Lang.Equals(value))
				{
					_Lang = value;
					NotifyPropertyChanged("Lang");
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
		DateTimeOffset _CreatedAtAutor = DateTimeOffset.MinValue;
		/// <summary>
		/// 作者作成日[CreatedAtAutor]プロパティ
		/// </summary>
		public DateTimeOffset CreatedAtAutor
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

		#region ユーザー名[UserName]プロパティ
		/// <summary>
		/// ユーザー名[UserName]プロパティ用変数
		/// </summary>
		string _UserName = string.Empty;
		/// <summary>
		/// ユーザー名[UserName]プロパティ
		/// </summary>
		public string UserName
		{
			get
			{
				return _UserName;
			}
			set
			{
				if (_UserName == null || !_UserName.Equals(value))
				{
					_UserName = value;
					NotifyPropertyChanged("UserName");
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

		private object AdjustValue(object cell_value, int type)
        {
            switch (type)
            {
				case 0:	// string
                    {
						if (cell_value == null)
						{
							return string.Empty;
						}
						else
                        {
							return cell_value.ToString()!;
                        }
                    }
					case 1:	// int
                    {
						if (cell_value == null)
						{
							return (int)0;
						}
						else
						{
							int num = 0;
							int.TryParse(cell_value.ToString()!, out num);
							return num;
						}
                    }
				case 2: // DateTimeOffset
					{
						if (cell_value == null)
						{
							return DateTimeOffset.MinValue;
						}
						else
						{
							try
							{
								DateTime datetime = DateTime.MinValue;
								string date_txt = cell_value.ToString()!;
								DateTime.TryParseExact(date_txt, "yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out datetime);
								DateTimeOffset dt_ofset = datetime;
								return dt_ofset;
							}
							catch
							{ 
								return DateTimeOffset.MinValue;
							}
						}
					}
				default:
                    {
						return cell_value;
                    }
			}

        }

		public TweetDataM()
		{
		}
		public TweetDataM(IXLRow row)
		{
			SetCellData(row);
		}

		public void SetCellData(IXLRow row)
        {
			string column = "B";
			var b_cell = row.Cell(column).Value == null ? string.Empty : row.Cell(column).Value;
			this.Id_X = (string)AdjustValue(row.Cell("B").Value, 0);
			this.CreatedAt = (DateTimeOffset)AdjustValue(row.Cell("C").Value, 2);
			this.Text = (string)AdjustValue(row.Cell("D").Value, 0);
			this.Lang = (string)AdjustValue(row.Cell("E").Value, 0);
			this.Autor_Id = (string)AdjustValue(row.Cell("F").Value, 0);
			this.Retweet_Count = (int)AdjustValue(row.Cell("G").Value, 1);
			this.Replay_Count = (int)AdjustValue(row.Cell("H").Value, 1);
			this.Like_Count = (int)AdjustValue(row.Cell("I").Value, 1);
			this.Quate_Count = (int)AdjustValue(row.Cell("J").Value, 1);
			//this.Text = (string)AdjustValue(row.Cell("K").Value, 0);
			this.UserName = (string)AdjustValue(row.Cell("L").Value, 0);
			this.Name = (string)AdjustValue(row.Cell("M").Value, 0);
			this.CreatedAtAutor = (DateTimeOffset)AdjustValue(row.Cell("N").Value, 2);
			this.Description = (string)AdjustValue(row.Cell("O").Value, 0);
			this.Follower_Count = (int)AdjustValue(row.Cell("P").Value, 1);
			this.Follow_Count = (int)AdjustValue(row.Cell("Q").Value, 1);
			this.Tweet_Count = (int)AdjustValue(row.Cell("R").Value, 1);
			this.Listed_Count = (int)AdjustValue(row.Cell("S").Value, 1);
		}
	}
}
