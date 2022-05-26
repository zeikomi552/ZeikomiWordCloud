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
        public GBLValues CommonValues
        { 
            get
            {
                return GBLValues.GetInstance();
            }
        }


        public override void Init(object sender, EventArgs e)
        {
            this.CommonValues.TwitterAPIConfig.LoadXML();
        }

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

        public override void Close(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }
    }
}
