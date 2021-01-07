using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Redpack
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lstRedpack.Items.Clear();
            lstProbability.Items.Clear();
            // 红包总个数
            int totalCount = (int)numTotalCount.Value;
            // 每个红包可领取个数
            int perCount = (int)numPerCount.Value;
            // 每个红包总金额
            decimal perAmount = numPerAmount.Value;

            // 取值列表
            Dictionary<string, int> seeds = new Dictionary<string, int>();
            // 红包数据列表
            List<decimal[]> redpacks = new List<decimal[]>();
            // 生成红包数据
            for (int i = 0; i < totalCount; i++)
            {
                // 生成一个随机金额红包
                var items = RandomAmount(perCount, perAmount);
                // 加入到红包列表
                redpacks.Add(items);
                var middle = Middle(items).ToString("f2");
                var value = middle.Substring(middle.Length - 1);
                lstRedpack.Items.Add($"序号{i}:金额分别为{ string.Join(',', items)} 中位数为{middle} 取值{value}");

                // 存储取值
                if (seeds.ContainsKey(value))
                    seeds[value] += 1;
                else
                    seeds.Add(value, 1);
            }
            Dictionary<string, decimal> probability = new Dictionary<string, decimal>();
            // 计算概率
            foreach (var key in seeds.Keys)
            {
                var probabilityValue = seeds[key] * 1.0m / totalCount;
                probability.Add(key, probabilityValue); 
            }
            // 排序后展示
            var orderByDictionary = probability.OrderByDescending(o => o.Value);
            foreach (var item in orderByDictionary)
            {
                lstProbability.Items.Add($"值{item.Key}出现的概率为{item.Value}");
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
    }
}
