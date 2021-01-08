using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Redpack.Wpf
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // 红包总个数  
        protected int TotalCount
        {
            get
            {
                int _totalCount;
                if (!int.TryParse(TxtTotalCount.Text, out _totalCount))
                    throw new ArgumentException("红包总个数格式不正确！");
                return _totalCount;
            }
        }
        // 每个红包可领取个数 
        protected int PerCount
        {
            get
            {
                int _perCount;
                if (!int.TryParse(TxtPerCount.Text, out _perCount))
                    throw new ArgumentException("每个红包可领取个数格式不正确！");
                return _perCount;
            }
        }
        // 每个红包总金额 
        protected decimal PerAmount
        {
            get
            {
                decimal _perAmount;
                if (!decimal.TryParse(TxtPerAmount.Text, out _perAmount))
                    throw new ArgumentException("每个红包总金额格式不正确！");
                return _perAmount;
            }
        }

        private void Validation()
        {
            if (TotalCount > 1000 || TotalCount < 100)
                throw new ArgumentException("红包总个数可设置范围[100 - 1000]！");
        }
        // 随机方式
        public enum RandomType
        {
            /// <summary>
            /// 中位数
            /// </summary>
            Middle
        }

        protected RandomType RandomAmountType
        {
            get
            {
                if (RbRandomType.IsChecked.HasValue && RbRandomType.IsChecked.Value)
                    return RandomType.Middle;
                return RandomType.Middle;
            }
        }

        private void ClearDisplay()
        {
            LstRedpack.Items.Clear();
            probability.Clear();
            GridDashboard.Children.Clear();
            LstRedpack.Visibility = Visibility.Hidden;
            TxtRunning.Visibility = Visibility.Visible;
        }
        Dictionary<string, decimal> probability = new Dictionary<string, decimal>();
        /// <summary>
        /// 红包生成及概率计算
        /// </summary>
        private void Calculate()
        {
            // 取值列表
            Dictionary<string, int> seeds = new Dictionary<string, int>();
            // 红包数据列表
            List<decimal[]> redpacks = new List<decimal[]>();
            // 生成红包数据
            for (int i = 0; i < TotalCount; i++)
            {
                // 生成一个随机金额红包
                var items = RandomAmount(PerCount, PerAmount);
                // 加入到红包列表
                redpacks.Add(items);

                // 取值
                var value = string.Empty;
                switch (RandomAmountType)
                {
                    case RandomType.Middle:
                        var middle = Middle(items).ToString("f2");
                        value = middle.Substring(middle.Length - 1);
                        LstRedpack.Items.Add($"序号{i}:金额为{ string.Join(",", items)}");
                        break;
                }

                // 存储取值
                if (seeds.ContainsKey(value))
                    seeds[value] += 1;
                else
                    seeds.Add(value, 1);
            }
            // 计算概率
            foreach (var key in seeds.Keys)
            {
                var probabilityValue = seeds[key] * 1.0m / TotalCount;
                probability.Add(key, probabilityValue);
            }
        }
        /// <summary>
        /// 展示概率分布
        /// </summary>
        private void Display()
        {
            Panel.Visibility = Visibility.Hidden;
            Panel.Height = 0;
            LstRedpack.Visibility = Visibility.Visible;
            TxtRunning.Visibility = Visibility.Hidden;
            // 排序后展示
            var orderByDictionary = probability.OrderByDescending(o => o.Value);
            int[,] points = new int[10, 2]
            {
                {0,0 },
                {0,1 },
                {0,2 },
                {0,3 },
                {0,4 },
                {1,0 },
                {1,1 },
                {1,2 },
                {1,3 },
                {1,4 }
            };
            int index = 0;
            foreach (var item in orderByDictionary)
            {
                Card card = new Card()
                {
                    Title = $"{item.Value * 100:f2}%",
                    Num = item.Key
                };
                GridDashboard.Children.Add(card);
                card.SetValue(Grid.RowProperty, points[index, 0]);
                card.SetValue(Grid.ColumnProperty, points[index, 1]);
                index++;
            }
        }
        // 随机单个红包金额
        Random random = new Random();
        private decimal[] RandomAmount(int count, decimal amount)
        {
            decimal[] items = new decimal[count];

            decimal used = 0;//已随机总额 
            // 循环随机 count - 1 
            for (int i = 0; i < count - 1; i++)
            {
                //可随机金额为 总金额 - 已扣除金额 - 还未随机个数*0.01  
                var available = amount - used - (count - i - 1m) * 0.01m;

                // 将可随机金额*100 金额转为整数  98 2
                var randomAmount = random.Next(1, (int)(available * 100));

                // 将实际随机数还原成随机金额
                var realRandomAmount = (decimal)randomAmount / 100;

                // 计算出剩余金额
                used += realRandomAmount;

                // 返回随机金额
                items[i] = realRandomAmount;
            }
            // 将最后不随机金额放入列表
            items[count - 1] = amount - used;
            return items;
        }

        //中位数计算
        private decimal Middle(decimal[] items)
        {
            var orderByItems = items.OrderBy(o => o).ToArray();
            // 只支持奇数
            if (orderByItems.Length % 2 == 0)
                throw new ArgumentException("只支持奇数个数的数组。");
            int index = orderByItems.Length / 2;
            return orderByItems[index];
        }

        // 随机动画
        private void Animation(Action nextCallback)
        {
            Panel.Visibility = Visibility.Hidden;
            Panel.Height = 0;
            int[,] points = new int[10, 2]
            {
                {0,0 },
                {0,1 },
                {0,2 },
                {0,3 },
                {0,4 },
                {1,0 },
                {1,1 },
                {1,2 },
                {1,3 },
                {1,4 }
            };
            int[] items = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Random random = new Random();
            // 定时器
            var now = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += (sender, e) =>
            {
                if (now >= DateTime.Now.AddSeconds(-5))
                {
                    //打乱数组
                    items = Shuffle(items);
                    int index = 0;
                    foreach (var item in items)
                    {
                        Card card = new Card()
                        {
                            Title = $"{random.Next(0, 15) / 100m * 100m:f2}%",
                            Num = item.ToString()
                        };
                        GridDashboard.Children.Add(card);
                        card.SetValue(Grid.RowProperty, points[index, 0]);
                        card.SetValue(Grid.ColumnProperty, points[index, 1]);
                        index++;
                    }
                }
                else
                {
                    timer.Stop();
                    Thread.Sleep(100);
                    nextCallback();
                }

            };
            timer.Start();

        }
        //打乱数组
        public int[] Shuffle(int[] collection)
        {
            for (int i = collection.Length - 1; i > 0; i--)
            {
                Random rand = new Random();
                int p = rand.Next(i);
                var temp = collection[p];
                collection[p] = collection[i];
                collection[i] = temp;
            }
            return collection;
        }
        // 下次可运行时间
        protected DateTime NextStartTime { get; set; }
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            // 5分钟之后可以执行一次
            if (NextStartTime < DateTime.Now)
            {
                Validation();
                ClearDisplay();
                Animation(() =>
                {
                    Calculate();
                    Display();
                });

                NextStartTime = DateTime.Now.AddMinutes(3);

                /*BtnStart.IsEnabled = false;
                // 设置定时器解锁按钮
                DispatcherTimer btnTimer = new DispatcherTimer();
                btnTimer.Interval = new TimeSpan(0, 0, 0, 0, 1);
                btnTimer.Tick += (s, ee) =>
                {
                    if (NextStartTime < DateTime.Now)
                        BtnStart.IsEnabled = true;
                };
                btnTimer.Start();*/
            }
            else
            {
                MessageBox.Show($"下次可执行时间：{NextStartTime}");
            }
        }
    }
}
