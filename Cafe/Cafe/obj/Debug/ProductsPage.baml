   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.ProductsPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  ProductsPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DgProducts��5         
IsReadOnly .    AutoGenerateColumns .  $��0��6U   $��2��6e   $��6��6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	ProductID+6C     5      $ ProductTypeID��6R    6%   �� *ProductTypes.ProductType+6R     5      $ Count��6@    6%   �� *Count_+6@     5       $ Price��6?    6%   �� *Price+6?   5"      �� 5#   
   -   5        $��3��5#      $��3��6!   $��Добавить��6.   6A   �� 5$   
   -   5        $��3��5$      $��4��6!   $��Изменить��6.   6A   �� 5%   
   -   5        $��3��5%      $��5��6!   $��Удалить��6.   6@   �� 5&   
   -   5        	 ��Name$	 TbCount��5&      $��2��6#   $��3��63   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$@
 :Введите количество(целое число)��6@    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5'   
   -   5        $	 TbPrice��5'      $��2��6#   $��4��63   $>
 8Введите цену(десятичное число)��6@   #��[  6�   �� 5(   
   -   5         ��Name$ CbIDProductType��5(      $��2��6,   $��5��6<    �� DisplayMemberPath$ ProductType��6I   $.
 (Выберите тип продукта��6i    & "MaterialDesignFloatingHintComboBox#��[ 6�   5)      5*      