   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.OrderPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  	OrderPage��5
      .��5      �  � RowDefinitions 5   
   �� 5      $	��61* �6   �� 5      $	��61* �6   �� 5      $	��61* �6   �� 5      $
��389* �6   �� 5      $	��61* �6   �� 5      $	��61* �6   �� 5      $	��61* �6   �� 5      $	��61* �6   �� 5      $	��61* �6    � ColumnDefinitions 5   
   �� 5      $
��360* �6   �� 5      $	��40* �6   �� 5      $
��360* �6   .+�5   
   �� -   5         ��Name$ ForPay��5      $��3��6$   $��Center=�68   $��20(�6U   $��0��6c   �� 5   
   -   5        $��+��5      $��3��6   $��1��6*   $��Center=�6I   $��Center=�6f   $��42��6�   
�������6�   �� 5   
   -   5        $��-��5      $��4��6   $��1��6*   $��Center=�6J   $��42��6g   $��Center=�6r   
�������6�   �� 5    
   -   5         ��Name$ 
CbCustomer��5       $��6��6'   $��0��64    �� DisplayMemberPath$ Surname��6D   6`   �� 5!   
   -   5        $ CbCafe��5!      $��7��6#   $��0��60   $ Address_��6@   6]   �� 5"   
   $��Продукты��6   $��1��6$   $��0��61   $��Center=�6A   $��Center=�6\   $��20(�6y   �� 5#   
   $��Корзина��6   $��1��6#   $��2��60   $��Center=�6@   $��Center=�6[   $��20(�6x   &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ 
DgProducts��5$         AutoGenerateColumns .  $��0��6C   $��2��6S   $��3��6a      Columns 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn	   Header$	 ID��6C   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6%   �� *	ProductID+6C     5'      $	 ProductTypeID��6R   
 6%   �� *ProductTypes.ProductType+6R     5(      $	 Count��6@   
 6%   �� *Count_+6@     5)      $	 Price��6?   
 6%   �� *Price+6?   5+        5,   
   -   5        $ DgSellingDetails��5,       .  $��2��6I   $��2��6Y   $��3��6g    5-        5.      $	 ID��6I   
 6%   �� *SellingDetailID+6I     5/      $	 Selling��6L   
 6%   �� *Sellings.SellingID+6L     50      $	 Product��6[   
 6%   �� *#!Products.ProductTypes.ProductType+6[     51      $	 Count��6@   
 6%   �� *Count_+6@     52      $	 Amount��6@   
 6%   �� *Amount+6@   54      �� 55   
   -   5        $��8��55      $��3��6   
�������$��Сохранить��6R   $��20, 3, 20, 3q�6f   � 56   
   $��6��6   $��2��6    57      �� 58      �� 59      .+�5;      �� $��13(�6   $��Покупатель:��6&   $��Center=�69   $��Center=�6T   $��0��6q   �� 5<      -	   5        $ 
TbCustomer��5<      $��13(�6,   $��Center=�6:   $��Center=�6U   $��1��6r   5=      � 5>   
   $��7��6   $��2��6    5?      �� 5@      �� 5A      .+�5C      �� $��13(�6   $��Адресс:��6&   $��Center=�65   $��Center=�6P   $��0��6m   �� 5D      -
   5        $ TbCafe��5D      $��13(�6(   $��Center=�66   $��Center=�6Q   $��1��6n   5E      �� 5G   
   -   5         ��Name$ Payed��5G      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Сумма: ��6!    %  !MaterialDesignFloatingHintTextBox#��[  5H      $��15(�5I      $��7��6   $��3��6    $��Center=�64   .��6Q   5J      5K      5L      