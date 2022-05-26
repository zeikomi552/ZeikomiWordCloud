using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeikomiWordCloud.Models;

namespace ZeikomiWordCloud.Common
{
    public class GBLValues : ModelBase
    {
        private GBLValues()
        {
            
        }

        private static GBLValues _SingleInstance = new();

        #region インスタンス
        /// <summary>
        /// インスタンス
        /// </summary>
        /// <returns></returns>
        public static GBLValues GetInstance()
        {
            return _SingleInstance;
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

        #region ツイッターAPIGetCommand用コンフィグ[TwitterAPIConfig]プロパティ
        /// <summary>
        /// ツイッターAPIGetCommand用コンフィグ[TwitterAPIConfig]プロパティ用変数
        /// </summary>
        ConfigManager<GetTweetPyArgsM> _TwitterAPIConfig = new("Config", "TwitterAPI.config", new GetTweetPyArgsM());
        /// <summary>
        /// ツイッターAPIGetCommand用コンフィグ[TwitterAPIConfig]プロパティ
        /// </summary>
        public ConfigManager<GetTweetPyArgsM> TwitterAPIConfig
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


    }
}
