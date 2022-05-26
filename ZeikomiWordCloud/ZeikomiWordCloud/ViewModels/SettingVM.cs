using MVVMCore.BaseClass;
using MVVMCore.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZeikomiWordCloud.Common;
using ZeikomiWordCloud.Models;

namespace ZeikomiWordCloud.ViewModels
{
    internal class SettingVM : ViewModelBase
    {
        #region 共通変数
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
        #endregion

        #region 初期化処理
        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Init(object sender, EventArgs e)
        {
            this.CommonValues.TwitterAPIConfig.LoadXML();
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void Save()
        {
            try
            {
                if (ShowMessage.ShowQuestionYesNo("保存した後に画面を閉じます。よろしいですか？", "確認") == System.Windows.MessageBoxResult.Yes)
                {
                    this.CommonValues.TwitterAPIConfig.SaveXML();
                    this.DialogResult = true;
                }
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region キャンセル
        /// <summary>
        /// キャンセル
        /// </summary>
        public void Cancel()
        {
            try
            {
                if (ShowMessage.ShowQuestionYesNo("保存せず画面を閉じます。よろしいですか？", "確認") == System.Windows.MessageBoxResult.Yes)
                {
                    this.DialogResult = false;
                }
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region クローズ
        /// <summary>
        /// クローズ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Close(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
        #endregion
    }
}
