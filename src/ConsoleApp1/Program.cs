using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            var items = RandomAmount(5, 1.0m);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }

            var middle = Middle(items);

            Console.WriteLine($"中位数：{middle}");
        }


        // 随机单个红包金额
        private static List<decimal> RandomAmount(int count, decimal amount)
        {
            List<decimal> items = new List<decimal>();
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
                items.Add(realRandomAmount);
            }
            // 将最后不随机金额放入列表
            items.Add(amount - used);
            return items;
        }

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

        private static decimal Middle(List<decimal> items)
        {
            var orderByItems = items.OrderBy(o => o).ToArray();
            // 只支持奇数
            if (orderByItems.Length % 2 == 0)
                throw new ArgumentException("只支持奇数个数的数组。");
            int index = orderByItems.Length / 2;
            return orderByItems[index];
        }

        private static decimal Median(decimal[] arr)
        {
            //为了不修改arr值，对数组的计算和修改在tempArr数组中进行
            decimal[] tempArr = new decimal[arr.Length];
            arr.CopyTo(tempArr, 0);

            //对数组进行排序
            decimal temp;
            for (int i = 0; i < tempArr.Length; i++)
            {
                for (int j = i; j < tempArr.Length; j++)
                {
                    if (tempArr[i] > tempArr[j])
                    {
                        temp = tempArr[i];
                        tempArr[i] = tempArr[j];
                        tempArr[j] = temp;
                    }
                }
            }

            //针对数组元素的奇偶分类讨论
            if (tempArr.Length % 2 != 0)
            {
                return tempArr[arr.Length / 2 + 1];
            }
            else
            {
                return (tempArr[tempArr.Length / 2] +
                    tempArr[tempArr.Length / 2 + 1]) / 2.0m;
            }
        }
    }
}
