using StockDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockDemo.BackgroundWork
{
    public class BackgroundUpdateStock
    {
        public CancellationTokenSource tokenSource;
        public CancellationToken token;

        public bool closethread = false;

        List<BasicStockClass> _basicFakeData = new List<BasicStockClass>();
        List<BasicStockClass> _pastData = new List<BasicStockClass>();

        //初始化
        public BackgroundUpdateStock()
        {
            FakeData.FakeDataList = CreateBasicData(200);
            StoreFakeData(FakeData.FakeDataList);
            UpdateUITask();
        }

        //新增200筆隨機資料
        public List<BasicStockClass> CreateBasicData(int count)
        {
            double basicPrice;
            for (int i = 0; i < count; i++)
            {
                basicPrice = new Random(Guid.NewGuid().GetHashCode()).Next(1, 2000) + new Random(Guid.NewGuid().GetHashCode()).NextDouble();
               
                _basicFakeData.Add(new BasicStockClass
                {
                    Name = "Stock-" + (i + 1),
                    TradingVolume = basicPrice,
                    OpeningPrice = basicPrice           
                });
            }

            return _basicFakeData;
        }


        //儲存資料FakeData - 更新資料用
        public void StoreFakeData(List<BasicStockClass> inputData)
        {
            _pastData = inputData;
        }

        int i = 0;
        //10ms更新一次資料
        private  void UpdateUITask()
        {
            Task.Run(async () =>
             {
                 while (true)
                 {
                     if (closethread)
                     {
                         break;
                     }

                     //用舊資料更新
                     FakeData.FakeDataList = UpdateData(_pastData);

                     StoreFakeData(FakeData.FakeDataList);

                    await Task.Delay(1);
                 }
             }, token);
        }

        //更新資料 更新方式-模擬-2.0~2.0之間的漲跌幅
        public List<BasicStockClass> UpdateData(List<BasicStockClass> pastlist)
        {
            foreach (var item in pastlist)
            {
                var value = NextDouble(-2.0, 2.0);
                item.TradingVolume += value;
            }
            return _basicFakeData;
        }

        //隨機min~max之間的浮點數
        private double NextDouble(double RanomMiniDouble, double RanomMaxiDouble)
        {
            double randonUpDownValue = Math.Round(new Random(Guid.NewGuid().GetHashCode()).NextDouble() * (RanomMaxiDouble - RanomMiniDouble) + RanomMiniDouble, 2);
            return randonUpDownValue;
        }
    }
}
