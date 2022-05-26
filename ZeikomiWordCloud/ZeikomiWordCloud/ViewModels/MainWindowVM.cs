using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeikomiWordCloud.Common;
using ZeikomiWordCloud.Models;
using ZeikomiWordCloud.Views;

namespace ZeikomiWordCloud.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        /// <summary>
        /// 共通変数
        /// </summary>
        public GBLValues CommonValues
        {
            get
            {
                return GBLValues.GetInstance();
            }
        }

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

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Init(object sender, EventArgs e)
        {
            try
            {
                this.CommonValues.TwitterAPIConfig.LoadXML();
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }

        /// <summary>
        /// 実行
        /// </summary>
        public void Execute()
        {
            try
            {
                var config = this.CommonValues.TwitterAPIConfig.Item;

                string command = config.GettweetPythonPath + string.Format(" {0} {1} {2} {3} {4} {5} ",
                        config.BearerToken,
                        config.Outdir,
                        config.FontFilePath,
                        this.Query,
                        config.Language,
                        config.MaxgetCount);

                var myProcess = new Process
                {
                    StartInfo = new ProcessStartInfo(this.CommonValues.PythonPath)
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        Arguments = command
                    }
                };

                myProcess.Start();
                StreamReader myStreamReader = myProcess.StandardOutput;

                string? myString = myStreamReader.ReadLine();
                myProcess.WaitForExit();
                myProcess.Close();
                Console.WriteLine(myString);
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }

        public void OpenSetting()
        {
            var wm = new SettingV();

            if (wm.ShowDialog() == true)
            {
                

            }

        }
        public override void Close(object sender, EventArgs e)
        {
            //string path = this.TwitterAPIConfig.ConfigDir;
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

            //XMLUtil.Seialize<GetTweetPyArgsM>(this.TwitterAPIConfig.ConfigFile, this.GettweetpyArgs);
        }
    }
}
