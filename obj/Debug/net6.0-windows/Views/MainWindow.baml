   M S B A M L   `   `   `  ����L  HStockPredictorApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:StockPredictorAppStockPredictorApp  5   	   "    StockPredictorApp.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:StockPredictorApp     5   	     � Title$  Stock Wizard��5   	   $	��500��6   $	��500��6+    � WindowStartupLocation$ CenterScreen=�5	   	   
�������.��5      �  � RowDefinitions 5   
   �� 5      $��2* �6   �� 5      $��4* �6   �� 5      $��1* �6   �� 5      $��4* �6   �� 5      $��2* �6    � ColumnDefinitions 5   
   �� 5      $��5* �6   �� 5      $��9* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ btnLoadModel��5      $��1��5      $��1��5      $��20q�5      $��Load a Model��5      $��30(�5      
�������
������ 5!   &   �� 5#   
   -   5        $ btnTrainModel��5$      $��3��5%      $��1��5&      $��20q�5'      $��Train a Model��5(      $��30(�5)      
�������
������ 5+   &   �� 5-   
   $��1��5.      $��0��5/      $��20q�50         	load_logo#��[  51      �� 53   
   $��3��54      $��0��55      $��20q�56        
train_logo#��[ 57      58      59      