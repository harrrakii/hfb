   M S B A M L   `   `   `  ����F  BPractica1EF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Practica1EFPractica1EF  5   	       Practica1EF.Window4   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Practica1EF     5   	     � Title$  Window4��5   	   $	��450��6   $	��800��6&   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MasterServicesDataGrid��5   /      AutoGenerateColumns .  $��2��6O   $��2��6`      Columns 5   
   0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ FullName��6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6!   �� *Masters.FullName+6F     5      $	 Day��6Q    6!   �� *Masters.Schedule.Day_OfWeek+6Q     5      $ Hours��6S    6!   �� *Masters.Schedule.WorkingHours+6S     5      $
 Name��6K    6!   �� *Services_.ServiceName+6K     5      $ Price��6E    6!   �� *Services_.Price+6E   5      �� 5   
   -   5         ��Name$ MasterID��5      $��0��6%   $��2��65   	 �� DisplayMemberPath$	 	Master_ID��6B   �� 5    
   -   5        $ 	ServiceID��5       $��1��6&   $��2��66   $	 
Service_ID��6C   �� 5!   
   -   5        
 ��Name$
 Change��5!      $��Изменить��6!   $��3��64   $��2��6A   6U   �� 5"   
   -   5        $	
 Add��5"      $��Добавить��6   $��4��61   $��2��6>   6R   �� 5#   
   -   5        $
 Delete��5#      $��Удалить��6!   $��5��63   $��2��6@   6T   5%      5&      