   M S B A M L   `   `   `  ����  LogistTr    LogistTr.VehiclesPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5        N� Title$  VehiclesPage��5      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��Транспорт��6   $��18(�5      $
��Bold"�5      $��10q�5      $
��Left=�5      �� 5   
   -   5         ��Name$ 	TxtSearch��5      $	��200��5      $��25��5      $
��10,5q�5      $
��Left=�5      5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ DGridVehicle��5         AutoGenerateColumns .     
IsReadOnly . $��1��5       $��10q�5!         Columns 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn   Header$ Гос. номер��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6Y   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 69   �� *PlateNumber+6Y     5$      $ Объем кузова��6%   $ * 6^   	 6;   �� *CapacityVolume+6^     5%      $ Водитель��6%   $ * 6R   	 67   �� *Driver+6R     5&      $ Состояние��6%   $ * 6T   	 68   �� *	Status_+6T   5(      �� 5+   
   $��2��6   
 �� Orientation$
 Vertical=�6"   $��10q�69   $
��Left=�6E   .+�5,      �� -   5        $ TxtPlateNumber��5,      $	��150��6.   $��25��6:   $��5q�6F   �� 5-      -   5        $ TxtCapacityVolume��5-      $	��100��61   $��25��6=   $��5q�6I   �� 5.      -   5        $ 	TxtDriver��5.      $	��150��6)   $��25��65   $��5q�6A   �� 5/      -   5         ��Name$ CbStatus��5/      $	��150��6)   $��25��65   $��5q�6A   �� 51      -   5        $��Добавить��51      $��80��6(   $��30��63   $��5q�6?   6J   �� 52      -   5        $ ��Редактировать��52      $	��100��6-   $��30��69   $��5q�6E   6P   �� 53      -	   5        $��Удалить��53      $��80��6'   $��30��62   $��5q�6>   6I   54      55      56      