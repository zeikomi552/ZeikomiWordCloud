using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZeikomiWordCloud.Models
{
    internal class FontfileManagerM
    {
        public static string FileOpenDialog()
        {
			// ダイアログのインスタンスを生成
			var dialog = new OpenFileDialog();

			// ファイルの種類を設定
			dialog.Filter = "テキストファイル (*.ttf)|*.ttf";

			// ダイアログを表示する
			if (dialog.ShowDialog() == true)
			{
				// 選択されたファイル名 (ファイルパス) をメッセージボックスに表示
				return dialog.FileName;
			}
			else
            {
				return string.Empty;
            }
		}
    }
}
