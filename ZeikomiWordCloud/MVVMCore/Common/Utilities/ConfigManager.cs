using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMCore.Common.Utilities
{
    public class ConfigManager
    {
        #region コンフィグディレクトリ
        /// <summary>
        /// コンフィグディレクトリ
        /// </summary>
        string ConfigDirectory = "Config";
        #endregion

        #region コンフィグファイル名
        /// <summary>
        /// コンフィグファイル名
        /// </summary>
        string ConfigFileName = "Setting.conf";
        #endregion

        #region コンストラクタ
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="config_dir">コンフィグディレクトリ</param>
        /// <param name="config_file_name">コンフィグファイル名</param>
        public ConfigManager(string config_dir, string config_file_name)
        {
            this.ConfigDirectory = config_dir;
            this.ConfigFileName = config_file_name;
        }
        #endregion

        #region Configファイル用フォルダパス
        /// <summary>
        /// Configファイル用フォルダパス
        /// </summary>
        public string ConfigDir
        {
            get
            {
                string path = PathManager.GetApplicationFolder();
                string config_dir = Path.Combine(path, ConfigDirectory);
                PathManager.CreateDirectory(config_dir);
                return config_dir;
            }
        }
        #endregion

        #region コンフィグファイルパス
        /// <summary>
        /// コンフィグファイルパス
        /// </summary>
        public string ConfigFile
        {
            get
            {
                return Path.Combine(ConfigDir, ConfigFileName);
            }
        }
        #endregion
    }

}
