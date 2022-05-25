using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeikomiWordCloud.Models;

namespace ZeikomiWordCloud.ViewModels
{
    public class MainWindowVM : ViewModelBase
    {
        #region Python引数[GettweetpyArgs]プロパティ
        /// <summary>
        /// Python引数[GettweetpyArgs]プロパティ用変数
        /// </summary>
        GetTweetPyArgsM _GettweetpyArgs = new GetTweetPyArgsM();
        /// <summary>
        /// Python引数[GettweetpyArgs]プロパティ
        /// </summary>
        public GetTweetPyArgsM GettweetpyArgs
        {
            get
            {
                return _GettweetpyArgs;
            }
            set
            {
                if (_GettweetpyArgs == null || !_GettweetpyArgs.Equals(value))
                {
                    _GettweetpyArgs = value;
                    NotifyPropertyChanged("GettweetpyArgs");
                }
            }
        }
        #endregion

        #region ツイッターAPIGetCommand用コンフィグ[TwitterAPIConfig]プロパティ
        /// <summary>
        /// ツイッターAPIGetCommand用コンフィグ[TwitterAPIConfig]プロパティ用変数
        /// </summary>
        ConfigManager _TwitterAPIConfig = new ConfigManager("Config", "TwitterAPI.config");
        /// <summary>
        /// ツイッターAPIGetCommand用コンフィグ[TwitterAPIConfig]プロパティ
        /// </summary>
        public ConfigManager TwitterAPIConfig
        {
            get
            {
                return _TwitterAPIConfig;
            }
            set
            {
                if (_TwitterAPIConfig == null || !_TwitterAPIConfig.Equals(value))
                {
                    _TwitterAPIConfig = value;
                    NotifyPropertyChanged("TwitterAPIConfig");
                }
            }
        }
        #endregion

        #region Python.exeのパス[PythonPath]プロパティ
        /// <summary>
        /// Python.exeのパス[PythonPath]プロパティ用変数
        /// </summary>
        string _PythonPath = @"C:\ProgramData\Anaconda3\python.exe";
        /// <summary>
        /// Python.exeのパス[PythonPath]プロパティ
        /// </summary>
        public string PythonPath
        {
            get
            {
                return _PythonPath;
            }
            set
            {
                if (_PythonPath == null || !_PythonPath.Equals(value))
                {
                    _PythonPath = value;
                    NotifyPropertyChanged("PythonPath");
                }
            }
        }
        #endregion




        public override void Init(object sender, EventArgs e)
        {
            var path = this.TwitterAPIConfig.ConfigFile;

            if (File.Exists(path))
            {
                this.GettweetpyArgs = XMLUtil.Deserialize<GetTweetPyArgsM>(path);
            }
        }

        /// <summary>
        /// 実行
        /// </summary>
        public void Execute()
        {
            string command = this.GettweetpyArgs.GettweetPythonPath + string.Format(" {0} {1} {2} {3} {4} {5} ",
                    this.GettweetpyArgs.BearerToken,
                    this.GettweetpyArgs.Outdir,
                    this.GettweetpyArgs.FontFilePath,
                    this.GettweetpyArgs.Query,
                    this.GettweetpyArgs.Language,
                    this.GettweetpyArgs.MaxgetCount);

            var myProcess = new Process
            {
                StartInfo = new ProcessStartInfo(this.PythonPath)
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

        public override void Close(object sender, EventArgs e)
        {
            string path = this.TwitterAPIConfig.ConfigDir;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            XMLUtil.Seialize<GetTweetPyArgsM>(this.TwitterAPIConfig.ConfigFile, this.GettweetpyArgs);
        }
    }
}
