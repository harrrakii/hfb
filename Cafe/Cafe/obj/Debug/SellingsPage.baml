   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.SellingsPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  SellingsPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 
DgSellings��5         
IsReadOnly .    AutoGenerateColumns .  $��0��6U   $��2��6e   $��6��6y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6C   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	SellingID+6C     5      $ SaleDate��6B    6%   �� *
SaleDate+6B     5      $ Address��6L    6%   �� *CafeShops.Address_+6L     5       $ Customer��6K    6%   �� *Customers.Surname+6K     5!      $ EndDate��6G    6%   �� *Sales.EndDate+6G     5"      $ TotalAmount��6E    6%   �� *TotalAmount+6E   5$      �� 5%   
   -   5        $��3��5%      $��3��6!   $��Добавить��6.   6A   �� 5&   
   -   5        $��3��5&      $��4��6!   $��Изменить��6.   6A   �� 5'   
   -   5        $��3��5'      $��5��6!   $��Удалить��6.   6@   �� 5(   
   -   5        	 ��Name$	 TbTotalAmount��5(      $��2��6)   $��1��69   
 �� 	MaxLength$
 50��6F   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$@ :Введите сумму(десятичное число)��6U    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5)   
   -   5        $	 
TbSaleDate��5)      $��2��6&   $��2��66   $
 50��6C   $6 0Введите дату заказа: yyyy-mm-dd��6R   #��[  6�   �� 5*   
   -   5         ��Name$ CbCafeID��5*      $��2��6%   $��3��65    �� DisplayMemberPath$ Address_��6B   $# Выберите адресс��6_    & "MaterialDesignFloatingHintComboBox#��[ 6�   �� 5+   
   -   5        $ CbCustomerID��5+      $��2��6)   $��4��69   $ Surname��6F   $% Выберите Фамилию��6b   #��[ 6�   �� 5,   
   -	   5        $ CbSaleID��5,      $��2��6%   $��5��65   $ EndDate��6B   $' !Дата конца скидки:��6^   #��[ 6�   5-      5.      