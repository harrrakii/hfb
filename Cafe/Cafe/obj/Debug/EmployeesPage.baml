   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.EmployeesPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  EmployeesPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgEmployees��5         
IsReadOnly .    AutoGenerateColumns .  $��0��6W   $��2��6g   $��6��6{      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6E   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *EmployeesID+6E     5      $ Surname��6A    6%   �� *	Surname+6A     5      $
 Name��6C    6%   �� *	Firstname+6C     5       $ 
Patronymic��6D    6%   �� *
Patronymic+6D     5!      $ Position��6L    6%   �� *Positions.Position+6L     5"      $ Address��6L    6%   �� *CafeShops.Address_+6L     5#      $
 User��6F    6%   �� *Users.UserID+6F   5%      �� 5&   
   -   5        $��3��5&      $��3��6!   $��Добавить��6.   6A   �� 5'   
   -   5        $��3��5'      $��4��6!   $��Изменить��6.   6A   �� 5(   
   -   5        $��3��5(      $��5��6!   $��Удалить��6.   6@   �� 5)   
   -   5        	 ��Name$	 	TbSurname��5)      $��2��6%   $��0��65   
 �� 	MaxLength$
 50��6B   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$# Введите Фамилию��6Q    %  !MaterialDesignFloatingHintTextBox#��[  6�   �� 5*   
   -   5        $	 TbName��5*      $��2��6"   $��1��62   $
 50��6?   $ Введите Имя��6N   #��[  6{   �� 5+   
   -   5        $	 TbPatronymic��5+      $��2��6(   $��2��68   $
 50��6E   $% Введите Отчество��6T   #��[  6�   �� 5,   
   -   5         ��Name$ CbIDPosition��5,      $��2��6)   $��3��69    �� DisplayMemberPath$ Position��6F   $: 4Выберите позицию сотрудника��6c    & "MaterialDesignFloatingHintComboBox#��[ 6�   �� 5-   
   -	   5        $ CbIDCafe��5-      $��2��6%   $��4��65   $ Address_��6B   $# Выберите адресс��6_   #��[ 6�   �� 5.   
   -
   5        $ CbIDUser��5.      $��2��6%   $��5��65   $ UserID��6B   $6 0Выберите номер сотрудника��6]   #��[ 6�   5/      50      