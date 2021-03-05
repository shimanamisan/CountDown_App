using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading; // クラスを読み込んでおく


namespace CountDown_App
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// 時刻表示タイマー用の変数を宣言
        /// </summary>
        private DispatcherTimer timer;

        /// <summary>
        /// タイマー監視用フラグ
        /// </summary>
        private bool timer_flg = false;

        public MainWindow()
        {
            // コンストラクター：初期化時に実行される
            InitializeComponent();

            // タイマー生成
            timer = CreateTimer();

        }

        /// <summary>
        /// タイマー生成処理
        /// </summary>
        /// <returns></returns>
        private DispatcherTimer CreateTimer()
        {
            // タイマーインスタンスを生成
            // 引数にはアイドル時を渡しており、これが優先時間になる
            var t = new DispatcherTimer(DispatcherPriority.SystemIdle);

            // タイマーイベントの発生時間を300ミリ秒に設定
            t.Interval = TimeSpan.FromMilliseconds(300);

            // タイマーイベントの定義
            // Tickイベント：タイマー間隔が経過したときに発火する
            t.Tick += (sender, e) =>
            {
                // タイマーイベントの発生時の処理をここに書く

                // 現在の時分秒をテキストに設定
                // TextBoxkタグ内に x:Name 属性がなければ x:Name="textBlock" を追加して現在の時刻を表示できるようにする
                textBlock.Text = DateTime.Now.ToString("HH:mm:ss");
            };

            return t;
        }

        private void Button_Click_Start(object sender, RoutedEventArgs e)
        {
            timer.Start();

            timer_flg = true;
        }

        private void Button_Click_Stop(object sender, RoutedEventArgs e)
        {
            if (timer_flg == false)
            {
                MessageBox.Show("タイマーが動いていません！");

                return;
            }

            if (MessageBox.Show("タイマーを停止しますか？", "Information", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            { 
                return; 
            }
            else
            {
                timer.Stop();

                MessageBox.Show("タイマーを停止しました！");

            }
                
        }
    }
}
