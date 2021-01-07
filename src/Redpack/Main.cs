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
            // 红包总个数
            int totalCount = (int)numTotalCount.Value;
            // 每个红包可领取个数
            int perCount = (int)numPerCount.Value;
            // 每个红包总金额
            decimal perAmount = numPerAmount.Value;



            List<decimal[]> redpacks = new List<decimal[]>();
            for (int i = 0; i < totalCount; i++)
            {
                // 生成一个随机金额红包
                var items = RandomAmount(perCount, perAmount);
                // 加入到红包列表
                redpacks.Add(items);
                
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
        // 最大值计算
        private decimal Max(List<decimal> items)
        {
            decimal max = 0m;
            foreach (var item in items)
            {
                if (item > max)
                    max = item;
            }
            return max;
        }
        // 最小值
        private decimal Min(List<decimal> items)
        {
            decimal min = 0m;
            foreach (var item in items)
            {
                if (item < min)
                    min = item;
            }
            return min;
        }
        //中位数计算
        private static decimal Middle(List<decimal> items)
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
