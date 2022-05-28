using ClosedXML.Excel;
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

        #region ワードクラウド画像パス[ImagePath]プロパティ
        /// <summary>
        /// ワードクラウド画像パス[ImagePath]プロパティ用変数
        /// </summary>
        string _ImagePath = string.Empty;
        /// <summary>
        /// ワードクラウド画像パス[ImagePath]プロパティ
        /// </summary>
        public string ImagePath
        {
            get
            {
                return _ImagePath;
            }
            set
            {
                _ImagePath = value;
                NotifyPropertyChanged("ImagePath");
            }
        }
        #endregion

        #region 検索履歴[SearchHistory]プロパティ
        /// <summary>
        /// 検索履歴[SearchHistory]プロパティ用変数
        /// </summary>
        ModelList<SearchHistoryM> _SearchHistory = new ModelList<SearchHistoryM>();
        /// <summary>
        /// 検索履歴[SearchHistory]プロパティ
        /// </summary>
        public ModelList<SearchHistoryM> SearchHistory
        {
            get
            {
                return _SearchHistory;
            }
            set
            {
                if (_SearchHistory == null || !_SearchHistory.Equals(value))
                {
                    _SearchHistory = value;
                    NotifyPropertyChanged("SearchHistory");
                }
            }
        }
        #endregion

        #region 名詞リスト[NounLists]プロパティ
        /// <summary>
        /// 名詞リスト[NounLists]プロパティ用変数
        /// </summary>
        ModelList<NounCountM> _NounLists = new ModelList<NounCountM>();
        /// <summary>
        /// 名詞リスト[NounLists]プロパティ
        /// </summary>
        public ModelList<NounCountM> NounLists
        {
            get
            {
                return _NounLists;
            }
            set
            {
                if (_NounLists == null || !_NounLists.Equals(value))
                {
                    _NounLists = value;
                    NotifyPropertyChanged("NounLists");
                }
            }
        }
        #endregion

        #region ツイートデータ[TweetItems]プロパティ
        /// <summary>
        /// ツイートデータ[TweetItems]プロパティ用変数
        /// </summary>
        ModelList<TweetDataM> _TweetItems = new ModelList<TweetDataM>();
        /// <summary>
        /// ツイートデータ[TweetItems]プロパティ
        /// </summary>
        public ModelList<TweetDataM> TweetItems
        {
            get
            {
                return _TweetItems;
            }
            set
            {
                if (_TweetItems == null || !_TweetItems.Equals(value))
                {
                    _TweetItems = value;
                    NotifyPropertyChanged("TweetItems");
                }
            }
        }
        #endregion

        #region フィルター後のツイッター検索結果[TwitterItemsFilter]プロパティ
        /// <summary>
        /// フィルター後のツイッター検索結果[TwitterItemsFilter]プロパティ用変数
        /// </summary>
        ModelList<TweetDataM> _TwitterItemsFilter = new ModelList<TweetDataM>();
        /// <summary>
        /// フィルター後のツイッター検索結果[TwitterItemsFilter]プロパティ
        /// </summary>
        public ModelList<TweetDataM> TwitterItemsFilter
        {
            get
            {
                return _TwitterItemsFilter;
            }
            set
            {
                if (_TwitterItemsFilter == null || !_TwitterItemsFilter.Equals(value))
                {
                    _TwitterItemsFilter = value;
                    NotifyPropertyChanged("TwitterItemsFilter");
                }
            }
        }
        #endregion

        #region 検索結果のフィルター[Filter]プロパティ
        /// <summary>
        /// 検索結果のフィルター[Filter]プロパティ用変数
        /// </summary>
        string _Filter = string.Empty;
        /// <summary>
        /// 検索結果のフィルター[Filter]プロパティ
        /// </summary>
        public string Filter
        {
            get
            {
                return _Filter;
            }
            set
            {
                if (_Filter == null || !_Filter.Equals(value))
                {
                    _Filter = value;
                    NotifyPropertyChanged("Filter");
                }
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
            try
            {
                this.CommonValues.TwitterAPIConfig.LoadXML();
                this.CommonValues.WordCloudConfig.LoadXML();
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region 実行
        /// <summary>
        /// 実行
        /// </summary>
        public void Execute()
        {
            try
            {
                var config = this.CommonValues.TwitterAPIConfig.Item;

                string command = config.GettweetPythonPath + string.Format(" {0} {1} {2} {3} {4}",
                        "\"" + config.BearerToken + "\"",
                        "\"" + config.Outdir + "\"",
                        "\"" + this.Query + "\"",
                        "\"" + config.Language + "\"",
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

                // 検索履歴に追加
                this.SearchHistory.Items.Insert(0, new SearchHistoryM(this.Query, new DateTimeOffset(DateTime.Now)));

                // ツイートデータの読み込み
                OpenTweetData(this.Query);

                // WordCloudによる画像ファイルの作成
                ExecuteWordCloud(Path.Combine(config.Outdir, "planetext", $"{this.Query}_tweet.txt"), this.Query);
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region WordCloudのPython実行処理
        /// <summary>
        /// WordCloudのPython実行処理
        /// </summary>
        /// <param name="input_file_path">入力ファイルパス</param>
        /// <param name="keyword">キーワード</param>
        public void ExecuteWordCloud(string input_file_path, string keyword)
        {
            try
            {
                var config = this.CommonValues.WordCloudConfig.Item;
                var config2 = this.CommonValues.TwitterAPIConfig.Item;

                string command = config.WordCloudPythonPath + string.Format(" {0} {1} {2} {3} {4} {5}",
                                    "\"" + input_file_path + "\"",
                                    "\"" + config.FontFilePath + "\"",
                                    "\"" + config.Background + "\"",
                                    "\"" + config.ColorMap.ToString() + "\"",
                                    "\"" + Path.Combine(config2.Outdir, keyword + "_wordcloud.png") + "\"",
                                    "\"" + Path.Combine(config2.Outdir, "tweetdata", keyword + "_result.xlsx") + "\"");

                // Pythonの実行
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
                //Console.WriteLine(myString);

                string image_path = Path.Combine(config2.Outdir, String.Format("{0}_wordcloud.png", keyword));
                // 画像ファイルのセット
                this.ImagePath = image_path;


                // 名詞リストの読み込み
                OpenNounCount(keyword);

                this.Filter = String.Empty;
                FilterChanged();
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region フィルタが変更された際の処理
        /// <summary>
        /// フィルタが変更された際の処理
        /// </summary>
        public void FilterChanged()
        {
            try
            {
                if (this.NounLists != null && this.NounLists.SelectedItem != null)
                {
                    this.Filter = this.NounLists.SelectedItem.Noun!;

                    var tmp = (from x in this.TweetItems.Items
                               where x.Text.Contains(this.Filter) || x.Description.Contains(this.Filter)
                               select x).ToList<TweetDataM>();

                    this.TwitterItemsFilter.Items = new System.Collections.ObjectModel.ObservableCollection<TweetDataM>(tmp);
                }
                else
                {
                    this.Filter = String.Empty;
                    this.TwitterItemsFilter.Items = new System.Collections.ObjectModel.ObservableCollection<TweetDataM>(this.TweetItems.Items);
                }
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region 設定画面を開く処理
        /// <summary>
        /// 設定画面を開く処理
        /// </summary>
        public void OpenSetting()
        {
            try
            {
                var wm = new SettingV();

                if (wm.ShowDialog() == true)
                {


                }

                // 設定ファイルの読み込み
                this.CommonValues.TwitterAPIConfig.LoadXML();
                this.CommonValues.WordCloudConfig.LoadXML();
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region ツイートデータ(Excel)を開く
        /// <summary>
        /// ツイートデータ(Excel)を開く
        /// </summary>
        /// <param name="query">クエリ(検索キーワード)</param>
        private void OpenTweetData(string query)
        {
            try
            {
                var config = this.CommonValues.TwitterAPIConfig.Item;
                string noun_result_xlsx = Path.Combine(config.Outdir, String.Format(@"tweetdata\{0}_merge.xlsx", query));

                // ファイルストリームで開く（他のプロセスで握られている時用）
                using (FileStream fs = new FileStream(noun_result_xlsx, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var workbook = new XLWorkbook(fs, XLEventTracking.Disabled);

                    List<TweetDataM> list = new List<TweetDataM>();
                    foreach (var worksheet in workbook.Worksheets)
                    {
                        if (worksheet.Name.Equals("data"))
                        {
                            int row = 2;

                            while(true)
                            {
                                // nullチェック
                                if (worksheet.Cell("B" + row.ToString()).Value == null ||
                                    worksheet.Cell("B" + row.ToString()).Value.ToString() == String.Empty)
                                {
                                    break;
                                }

                                // 行データを登録
                                var twdata = new TweetDataM(worksheet.Row(row));
                                list.Add(twdata);
                                row++;  // 次の行へ
                            }
                        }
                    }

                    // 画面上に描画
                    this.TweetItems.Items = new System.Collections.ObjectModel.ObservableCollection<TweetDataM>(list);
                }
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region 行のダブルクリック処理
        /// <summary>
        /// 行のダブルクリック処理
        /// </summary>
        public void NounCountRowDoubleClick()
        {
            try
            {
                if (this.NounLists != null && this.NounLists.SelectedItem != null)
                {
                    this.Query = this.Query + " " + this.NounLists.SelectedItem.Noun;
                }
            }
            catch (Exception e)
            {
                ShowMessage.ShowErrorOK(e.Message, "Error");
            }
        }
        #endregion

        #region ツイッター行クリック
        /// <summary>
        /// ツイッター行クリック
        /// </summary>
        public void TwitterRowDoubleClick()
        {
            try
            {
                if (this.TwitterItemsFilter != null && this.TwitterItemsFilter.SelectedItem != null)
                {
                    string url = String.Format("https://twitter.com/{0}/status/{1}",
                        this.TwitterItemsFilter.SelectedItem.UserName, this.TwitterItemsFilter.SelectedItem.Id_X);

                    ProcessStartInfo pi = new ProcessStartInfo()
                    {
                        FileName = url,
                        UseShellExecute = true,
                    };

                    Process.Start(pi);
                }
            }
            catch (Exception e)
            {
                ShowMessage.ShowErrorOK(e.Message, "Error");
            }
        }
        #endregion

        #region 名詞リストを開いて画面に表示する
        /// <summary>
        /// 名詞リストを開いて画面に表示する
        /// </summary>
        /// <param name="query">クエリ(検索キーワード)</param>
        private void OpenNounCount(string query)
        {
            try
            {
                var config = this.CommonValues.TwitterAPIConfig.Item;
                string noun_result_xlsx = Path.Combine(config.Outdir, String.Format(@"tweetdata\{0}_result.xlsx", query));

                // ファイルストリームで開く（他のプロセスで握られている時用）
                using (FileStream fs = new FileStream(noun_result_xlsx, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    var workbook = new XLWorkbook(fs, XLEventTracking.Disabled);

                    foreach (var worksheet in workbook.Worksheets)
                    {
                        if (worksheet.Name.Equals("data"))
                        {
                            int row = 2;
                            List<NounCountM> list = new List<NounCountM>();
                            while (true)
                            {
                                NounCountM tmp = new NounCountM();
                                var cell = worksheet.Cell("B" + row).Value;

                                // 値を持っていなければ終了
                                if (cell == null || cell.ToString() == String.Empty)
                                    break;

                                // 名詞をリストにセット
                                tmp.Noun = cell.ToString();

                                // カウントを取得
                                int count = 0;
                                tmp.Count = int.TryParse(worksheet.Cell("C" + row).Value.ToString(), out count) ? count : 0;

                                // リストに追加
                                list.Add(tmp);
                                row++;
                            }

                            // リストにセット
                            this.NounLists.Items = new System.Collections.ObjectModel.ObservableCollection<NounCountM>(list);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage.ShowErrorOK(ex.Message, "Error");
            }
        }
        #endregion

        #region 検索履歴の選択が変わった際の処理
        /// <summary>
        /// 検索履歴の選択が変わった際の処理
        /// </summary>
        public void HistoryChanged()
        {
            try
            {
                if (this.SearchHistory != null && this.SearchHistory.SelectedItem != null)
                {
                    string query = SearchHistory.SelectedItem.Query;
                    var config = this.CommonValues.TwitterAPIConfig.Item;
                    string image_path = Path.Combine(config.Outdir, String.Format("{0}_wordcloud.png", query));
                    // 画像ファイルのセット
                    this.ImagePath = image_path;

                    // 名詞リストの読み込み
                    OpenNounCount(query);

                    // ツイートデータの読み込み
                    OpenTweetData(query);

                    // 検索キーワードも入れ替える
                    this.Query = query;
                }
            }
            catch (Exception e)
            {
                ShowMessage.ShowErrorOK(e.Message, "Error");
            }
        }
        #endregion

        #region 閉じる処理
        /// <summary>
        /// 閉じる処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void Close(object sender, EventArgs e)
        {
            //string path = this.TwitterAPIConfig.ConfigDir;
            //if (!Directory.Exists(path))
            //{
            //    Directory.CreateDirectory(path);
            //}

            //XMLUtil.Seialize<GetTweetPyArgsM>(this.TwitterAPIConfig.ConfigFile, this.GettweetpyArgs);
        }
        #endregion
    }
}
