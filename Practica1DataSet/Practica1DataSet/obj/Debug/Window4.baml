   M S B A M L   `   `   `  ����K  GPractica1DataSet, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Practica1DataSetPractica1DataSet  5   	       Practica1DataSet.Window4   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Practica1DataSet     5   	   -   5          � Title$  Window4��5	   	   $	��450��6   $	��800��6&   .��5
      �  � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ MasterServicesDataGrid��5      $��2��63   $��2��6D   6X   �� 5   
   -   5         ��Name$ MasterID��5      $��0��6%   $��2��65    �� DisplayMemberPath$ 	Master_ID��6B   �� 5   
   -   5        $ 	ServiceID��5      $��1��6&   $��2��66   $ 
Service_ID��6C   �� 5   
   -   5         ��Name$ Change��5      $��Изменить��6!   $��3��64   $��2��6A   6U   �� 5   
   -   5        $	 Add��5      $��Добавить��6   $��4��61   $��2��6>   6R   �� 5   
   -   5        $ Delete��5      $��Удалить��6!   $��5��63   $��2��6@   6T   �� 5   
   -   5         ��Name$ 	SearchTxt��5      $��0��6%   $��6��65   �� 5    
   -	   5        $ 	CmbSearch��5       $��0��6&   $��7��66   �� 5!   
   -
   5        $ Clear��5!      $��Очистить��6    $��1��63   $��7��6C   �� 5"   
   -   5        $ Search��5"      $��
Поиск��6!   $��1��61   $��6��6A   5#      5$      