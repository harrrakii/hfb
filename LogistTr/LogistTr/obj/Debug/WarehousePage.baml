   M S B A M L   `   `   `  ����C  ?LogistTr, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:LogistTrLogistTr  5          LogistTr.WarehousePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      (localclr-namespace:LogistTr     5        N� Title$  WarehousePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��
Склад��6   $��18(�5      $
��Bold"�5      $
��Left=�5      $	��Top=�5      $��30, 10, 0, 15q�5      �� 5   
   $��45��6   $��14(�6   ���#F5F0F2$��10q�6A   $��1��6N   $��30, 10, 30, 10q�6[   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridClients��5       $��2��6      AutoGenerateColumns .     
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Номер заказа��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6[   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *OrderNumber+6[     5      $ Описание��6%   $ * 6\    67   �� *CargoDescription+6\     5       $ Объем (куб.м)��6%   $ * 6W    6<   �� *Weight+6W     5!      $ Статус��6%   $ * 6Y    65   �� *WarehouseStatus+6Y   5#      �� 5%   
   $��3��6   	 �� Orientation$	 Vertical=�6"   $	��480��69   .+�5&      �� $D��>Загруженность склада: {Binding LoadedSpace}��6   $��14(�6K   $��0, 10q�6Y   �� 5'      $8��2Свободное место: {Binding FreeSpace}��6   $��14(�6D   $��0, 10q�6R   5(      5*      5+      