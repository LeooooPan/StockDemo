   M S B A M L   `   `   `  ????D  @StockDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:StockDemo.ViewModelsStockDemo.ViewModels  5      1clr-namespace:StockDemo.ViewsStockDemo.Views  5      ;"clr-namespace:StockDemo.ConvertersStockDemo.Converters  5      9!clr-namespace:StockDemo.BehaviorsStockDemo.Behaviors  5	      #    StockDemo.Views.StockListView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1vm"clr-namespace:StockDemo.ViewModels     5      /localclr-namespace:StockDemo.Views     5      8	converter"clr-namespace:StockDemo.Converters     5      6behavior!clr-namespace:StockDemo.Behaviors     5	      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
        ? DataContext  5      -   'StockDemo.ViewModels.StockListViewModel  5   
    ? 	Resources 5       ?? MergedDictionaries ?? Source3   -StockDemo.Converters.ForegroundColorConverter   colorconverter?? 5   
    5      ?? 5      $C =pack://application:,,,/StockDemo;component/Style/UIStyle.xaml??6%   %   &	          5      61   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $??9* ?6   ?? 5      $??1* ?6   .+?5    
   ?? $??18(?6   $??Stretch=?5!      $??Disabled=?5"      $??Visible=?5#      
???   ?
???????$??0??5&   &     ListViewStyle#??[ 5'      $??20,10q?6:   ??5$      ?? *StockSource+ ?? View 5(      ?? 5)      .P?5*      ??  ?? Width$	 150??6%    ?? CellTemplate 5+      ?? 5,      .R?5-   "   ?? $??40??6)   $	??140??65   $??	-10,0,0,0q?6A   $??0,0,0,1q?6T   ???	#7FFFFFFF._?5.   &   ?? $??	30,10,0,0q?60   ???	#FFD1B074??6C   ?? *Name+6Y   5/   #   50      .??52      ?? 
???????$??股票??67   53      ?? 54      $	 180??6%    55      ?? 56      .R?57   "   ?? $??40??6)   $	??200??65   $??	-10,0,0,0q?6A   $??0,0,0,1q?6T   ???	#7FFFFFFF._?58   &   ?? $??	70,10,0,0q?60   ??6C   ?? *TradingVolume+??6b   ?? *UpDownValue+ ?? 	Converter# [  59   #   5:      .??5<      ?? 
???????$??	成交量??67   5=      ?? 5>      $	 180??6%    5?      ?? 5@      .R?5A   "   ?? $??40??6)   $	??200??65   $??	-10,0,0,0q?6A   $??0,0,0,1q?6T   ???	#7FFFFFFF._?5B   &   ?? $??	70,10,0,0q?60   ??6C   ?? *UpDownValue+??6`   ?? *UpDownValue+# [  5C   #   5D      .??5F      ?? 
???????$??漲跌??67   5G      5H      5J      ?? 5L   
   $??更新頻率??6   
???????$??1??62   $??115,10,10,0q?6?   $??20(?6T   ?? 5O   
   $??1q?6   $??1??6%   $??215,10,170,20q?62   	 ?? CornerRadius$	 5??6I   
???   ????	#FFCCE7FD._?5P      ?? -   5        
 ??Name$
 inputdelaytime??5P      $
??1000??6.    ?? IsInputMethodEnabled .  
?????? 
??????  ?? SelectionTextBrush
 ???? $??Right=?6?   $??20(?6?   $??0,5,10,0q?6?   .??6?   .  (System.Windows.Interactivity.Interaction   	Behaviors 5Q      6   0StockDemo.Behaviors.SelectAllTextOnFocusBehavior  5R      1   +StockDemo.Behaviors.LimitZeroToNineBehavior  5S      .??5T   +    J? InputBindings 5U      ?? 5V      
 ?? Key$ Enter??6!    ?? Command 6-   ?? *AcceptChangeDelayTime+ ?? CommandParameter 6W   ??  ?? ElementName$ inputdelaytime?? ?? Path$
 Text?.??5W   )   5X      5Y      ?? 5\   
     CheckButton#??[ 6~   $??1??6?   $??435,10,50,20q?6?   $??確定??6?   ???	#FF3E9C87??6   ?? *AcceptChangeDelayTime+??6<   ?? $ inputdelaytime??$
 Text?6?   5]         Triggers 5^      /  )System.Windows.Interactivity.EventTrigger  5_   
      	EventName$ Loaded??6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5`      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   ?? *LoadedCommand+5a        5b   
   $ Unloaded??6   . 5c         6$   ?? *UnloadedCommand+5d      5f      