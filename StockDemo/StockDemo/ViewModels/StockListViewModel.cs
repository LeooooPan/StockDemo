using BindingLibrary;
using StockDemo.BackgroundWork;
using StockDemo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace StockDemo.ViewModels
{
    public class StockListViewModel : NotifyPropertyBase
    {
        private CancellationTokenSource tokenSource;
        private CancellationToken token;

        ObservableCollection<StockListItemSource> _buffStockClass = new ObservableCollection<StockListItemSource>();
        List<double> pastTradingVolume = new List<double>();
        BackgroundUpdateStock backgroundUpdate = new BackgroundUpdateStock();

        //預設1秒Delay
        int DelayTime = 1000;

        private ICommand _loadedCommand;
        public ICommand LoadedCommand => _loadedCommand = _loadedCommand ?? new RelayCommand((x) =>
        {
            //以開盤價當作舊的交易量
            pastTradingVolume = FakeData.FakeDataList.Select(s => s.OpeningPrice).ToList();
            RunUpdateUITask();
        });

        private ICommand _unloadedCommand;
        public ICommand UnloadedCommand => _unloadedCommand = _unloadedCommand ?? new RelayCommand((x) =>
        {
            //關閉Thread
            if (tokenSource != null)
            {
                tokenSource.Cancel();
                tokenSource.Dispose();
                tokenSource = null;
            }

            backgroundUpdate.closethread = true;
        });


        private void RunUpdateUITask()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        break;
                    }

                    //更新資料
                    List<StockListItemSource> newSource = updateListItemSource(FakeData.FakeDataList);
                    _buffStockClass = new ObservableCollection<StockListItemSource>(newSource);

                    await Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        //畫面更新
                        StockSource = _buffStockClass;
                    }));

                    //記錄當前交易量
                    pastTradingVolume = StockSource.Select(s => s.TradingVolume).ToList();

                    await Task.Delay(DelayTime);
                }
            }, token);
        }

        private ICommand _acceptChangeDelayTime;
        public ICommand AcceptChangeDelayTime
        {
            get
            {
                _acceptChangeDelayTime = _acceptChangeDelayTime ?? new RelayCommand((x) =>
                {
                    int.TryParse(x.ToString(), out int result);

                    if (result < 30)
                    {
                        DelayTime = 30;
                    }
                    else if (result > 3000)
                    {
                        DelayTime = 3000;
                    }
                    else
                    {
                        DelayTime = result;
                    }
                });
                return _acceptChangeDelayTime;
            }
        }

        private List<StockListItemSource> updateListItemSource(List<BasicStockClass> newlistdata)
        {
            //填入股名與當前交易量
            var createNewSource = newlistdata.Select(s => new StockListItemSource
            {
                Name = s.Name,
                TradingVolume = s.TradingVolume,
            }).ToList();

            //計算漲跌
            int i = 0;
            foreach (var item in createNewSource)
            {
                item.UpDownValue = item.TradingVolume - pastTradingVolume[i];
                i++;
            }

            return createNewSource;
        }

        private ObservableCollection<StockListItemSource> _stockSource;
        public ObservableCollection<StockListItemSource> StockSource
        {
            get => _stockSource = _stockSource ?? new ObservableCollection<StockListItemSource>();
            set { SetProperty(ref _stockSource, value); }
        }
    }

    public class StockListItemSource
    {
        private double upDownValue;

        public string Name { get; set; }
        public double TradingVolume { get; set; }
        public double UpDownValue { get => upDownValue; set => upDownValue = Math.Round(value, 2); }
    }
}
