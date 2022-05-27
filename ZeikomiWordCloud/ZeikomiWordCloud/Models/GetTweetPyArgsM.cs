using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeikomiWordCloud.Common.Enums;

namespace ZeikomiWordCloud.Models
{
    public class GetTweetPyArgsM : ModelBase
	{
		#region gettweet.pyのパス[GettweetPythonPath]プロパティ
		/// <summary>
		/// gettweet.pyのパス[GettweetPythonPath]プロパティ用変数
		/// </summary>
		string _GettweetPythonPath = @"Common\Python\gettweet.py";
		/// <summary>
		/// gettweet.pyのパス[GettweetPythonPath]プロパティ
		/// </summary>
		public string GettweetPythonPath
		{
			get
			{
				string path = Path.Combine(Directory.GetParent(System.Reflection.Assembly.GetEntryAssembly()!.Location)!.FullName, _GettweetPythonPath);
				return _GettweetPythonPath;
			}
			set
			{
				if (_GettweetPythonPath == null || !_GettweetPythonPath.Equals(value))
				{
					_GettweetPythonPath = value;
					NotifyPropertyChanged("GettweetPythonPath");
				}
			}
		}
		#endregion

		#region TwitterAPI用トークン[BearerToken]プロパティ
		/// <summary>
		/// TwitterAPI用トークン[BearerToken]プロパティ用変数
		/// </summary>
		string _BearerToken = string.Empty;
		/// <summary>
		/// TwitterAPI用トークン[BearerToken]プロパティ
		/// </summary>
		public string BearerToken
		{
			get
			{
				return _BearerToken;
			}
			set
			{
				if (_BearerToken == null || !_BearerToken.Equals(value))
				{
					_BearerToken = value;
					NotifyPropertyChanged("BearerToken");
				}
			}
		}
		#endregion

		#region 出力先ディレクトリ[Outdir]プロパティ
		/// <summary>
		/// 出力先ディレクトリ[Outdir]プロパティ用変数
		/// </summary>
		string _Outdir = string.Empty;
		/// <summary>
		/// 出力先ディレクトリ[Outdir]プロパティ
		/// </summary>
		public string Outdir
		{
			get
			{
				return _Outdir;
			}
			set
			{
				if (_Outdir == null || !_Outdir.Equals(value))
				{
					_Outdir = value;
					NotifyPropertyChanged("Outdir");
				}
			}
		}
		#endregion

		#region フォントファイルパス(.ttf)[FontFilePath]プロパティ
		/// <summary>
		/// フォントファイルパス(.ttf)[FontFilePath]プロパティ用変数
		/// </summary>
		string _FontFilePath = string.Empty;
		/// <summary>
		/// フォントファイルパス(.ttf)[FontFilePath]プロパティ
		/// </summary>
		public string FontFilePath
		{
			get
			{
				return _FontFilePath;
			}
			set
			{
				if (_FontFilePath == null || !_FontFilePath.Equals(value))
				{
					_FontFilePath = value;
					NotifyPropertyChanged("FontFilePath");
				}
			}
		}
		#endregion

		#region 言語(all, jp, en..)[Language]プロパティ
		/// <summary>
		/// 言語(all, jp, en..)[Language]プロパティ用変数
		/// </summary>
		string _Language = string.Empty;
		/// <summary>
		/// 言語(all, jp, en..)[Language]プロパティ
		/// </summary>
		public string Language
		{
			get
			{
				return _Language;
			}
			set
			{
				if (_Language == null || !_Language.Equals(value))
				{
					_Language = value;
					NotifyPropertyChanged("Language");
				}
			}
		}
		#endregion

		#region 最大出力数(何回APIを実行するか)[MaxgetCount]プロパティ
		/// <summary>
		/// 最大出力数(何回APIを実行するか)[MaxgetCount]プロパティ用変数
		/// </summary>
		int _MaxgetCount = 0;
		/// <summary>
		/// 最大出力数(何回APIを実行するか)[MaxgetCount]プロパティ
		/// </summary>
		public int MaxgetCount
		{
			get
			{
				return _MaxgetCount;
			}
			set
			{
				if (!_MaxgetCount.Equals(value))
				{
					_MaxgetCount = value;
					NotifyPropertyChanged("MaxgetCount");
				}
			}
		}
		#endregion

		#region カラーマップ[ColorMap]プロパティ
		/// <summary>
		/// カラーマップ[ColorMap]プロパティ用変数
		/// </summary>
		enumColormap _ColorMap = enumColormap.flag;
		/// <summary>
		/// カラーマップ[ColorMap]プロパティ
		/// </summary>
		public enumColormap ColorMap
		{
			get
			{
				return _ColorMap;
			}
			set
			{
				if (!_ColorMap.Equals(value))
				{
					_ColorMap = value;
					NotifyPropertyChanged("ColorMap");
				}
			}
		}
		#endregion

		#region 背景色[Background]プロパティ
		/// <summary>
		/// 背景色[Background]プロパティ用変数
		/// </summary>
		string _Background = "white";
		/// <summary>
		/// 背景色[Background]プロパティ
		/// </summary>
		public string Background
		{
			get
			{
				return _Background;
			}
			set
			{
				if (_Background == null || !_Background.Equals(value))
				{
					_Background = value;
					NotifyPropertyChanged("Background");
				}
			}
		}
		#endregion


	}
}
