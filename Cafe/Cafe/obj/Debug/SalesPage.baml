   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.SalesPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  	SalesPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgSales��5         AutoGenerateColumns .  $��0��6@   $��2��6P   $��6��6d      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *SaleID+6@     5      $ 	StartDate��6C    6%   �� *	StartDate+6C     5      $ EndDate��6A    6%   �� *	EndDate+6A     5       $ Amount��6@    6%   �� *Amount+6@   5"      �� 5#   
   -   5        $��3��5#      $��3��6!   $��Добавить��6.   6A   �� 5$   
   -   5        $��3��5$      $��4��6!   $��Изменить��6.   6A   �� 5%   
   -   5        $��3��5%      $��5��6!   $��Удалить��6.   6@   �� 5&   
   -   5         ��Name$ TbStartDate��5&      $��2��6'   $��3��67   	 �� 	MaxLength$	 50��6D   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$4
 .Дата начала скидки: yyyy-mm-dd��6S    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5'   
   -   5        $ 	TbEndDate��5'      $��2��6%   $��4��65   $	 50��6B   $4
 .Дата начала скидки: yyyy-mm-dd��6Q   #��[  6�   �� 5(   
   -   5        $ TbAmount��5(      $��2��6$   $��5��64   $	 50��6A    �� 
IsReadOnly . $M
 GВведите сумму скидки(десятичное число)��6b   #��[  6�   5)      5*      