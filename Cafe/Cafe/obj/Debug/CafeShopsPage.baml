   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.CafeShopsPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  CafeShopsPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgCafeShops��5         AutoGenerateColumns .  $��0��6D   $��2��6T   $��6��6i      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *CafeID+6@     5      $ Address��6B    6%   �� *
Address_+6B   5       �� 5!   
   -   5        $��3��5!      $��3��6!   $��Добавить��6.   6A   �� 5"   
   -   5        $��3��5"      $��4��6!   $��Изменить��6.   6A   �� 5#   
   -   5        $��3��5#      $��5��6!   $��Удалить��6.   6@   �� 5$   
   -   5        $��3��5$      $��2��6!   $ ��Импортировать��6.   6F   �� 5%   
   -   5        	 ��Name$	 	TbAddress��5%      
 �� 	MaxLength$	
 100��6%   $��2��66   $��3��6F   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$0 *Введите адресс кофейни��6S    %  !MaterialDesignFloatingHintTextBox#��[  6�   5&      5'      