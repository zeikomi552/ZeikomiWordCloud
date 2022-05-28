using MVVMCore.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeikomiWordCloud.Common.Enums;

namespace ZeikomiWordCloud.Models
{
    public class WordCloudM : ModelBase
    {
		#region WordCloud用Pythonファイルパス[WordCloudPythonPath]プロパティ
		/// <summary>
		/// WordCloud用Pythonファイルパス[WordCloudPythonPath]プロパティ用変数
		/// </summary>
		string _WordCloudPythonPath = @"Common\Python\exec_wordcloud.py";
		/// <summary>
		/// WordCloud用Pythonファイルパス[WordCloudPythonPath]プロパティ
		/// </summary>
		public string WordCloudPythonPath
		{
			get
			{
				return _WordCloudPythonPath;
			}
			set
			{
				if (_WordCloudPythonPath == null || !_WordCloudPythonPath.Equals(value))
				{
					_WordCloudPythonPath = value;
					NotifyPropertyChanged("WordCloudPythonPath");
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
