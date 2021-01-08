using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
                    MessageBox.Show("红包总个数格式不正确！");
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
                    MessageBox.Show("每个红包可领取个数格式不正确！");
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
                    MessageBox.Show("每个红包总金额格式不正确！");
                return _perAmount;
            }
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

        Dictionary<string, decimal> probability = new Dictionary<string, decimal>();
        /// <summary>
        /// 红包生成及概率计算
        /// </summary>
        private void Calculate()
        {
            LstRedpack.Items.Clear();
            probability.Clear();
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
                        LstRedpack.Items.Add($"序号{i}:金额为{ string.Join(',', items)} 中位数为{middle} 取值为{value}");
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
        private decimal[] RandomAmount(int count, decimal amount)
        {
            decimal[] items = new decimal[count];
            Random random = new Random();
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
        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            Display();
        }
         

        private void LstRedpack_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LabTip.Content = LstRedpack.SelectedValue;
        }
    }
}
