   M S B A M L   `   `   `  ����F  BPractica1EF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Practica1EFPractica1EF  5   	       Practica1EF.Window3   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Practica1EF     5   	     � Title$  Window3��5   	   $	��450��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MastersDataGrid��5   /      AutoGenerateColumns .  $��2��6I   $��2��6Z      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ FullName��6B   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *
FullName+6B     5      $	 Day��6M    6%   �� *Schedule.Day_OfWeek+6M     5      $ Hours��6O    6%   �� *Schedule.WorkingHours+6O   5      �� 5   
   -   5         ��Name$
 Name��5      $��ФИО мастера��6    $��0��63   $��2��6C   �� 5   
   -   5        	 ��Name$	 CmbNumberOfDay��5      $��1��6+   $��2��6;   
 �� DisplayMemberPath$
 
ScheduleID��6H   �� 5   
   -   5         ��Name$ Change��5      $��Изменить��6!   $��3��64   $��2��6A   6U   �� 5    
   -   5        $	 Add��5       $��Добавить��6   $��4��61   $��2��6>   6R   �� 5!   
   -   5        $ Delete��5!      $��Удалить��6!   $��5��63   $��2��6@   6T   5"      5#      