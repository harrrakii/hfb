   M S B A M L   `   `   `  ����?  ;Cafe, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CafeCafe  5          Cafe.UsersPage   5      _ [MaterialDesignThemes.Wpf, Version=5.0.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:Cafe     5        N� Title$  	UsersPage��5
      .��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ DgUsers��5         
IsReadOnly .    AutoGenerateColumns .  $��0��6R   $��2��6b   $��6��6v      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6@   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *UserID+6@     5      $ Login��6@    6%   �� *Login_+6@     5      $ Password��6C    6%   �� *	Password_+6C     5       $ RoleID��6H    6%   �� *UserRoles.Role+6H   5"      �� 5#   
   -   5        $��3��5#      $��3��6!   $��Добавить��6.   6A   �� 5$   
   -   5        $��3��5$      $��4��6!   $��Изменить��6.   6A   �� 5%   
   -   5        $��3��5%      $��5��6!   $��Удалить��6.   6@   �� 5&   
   -   5        	 ��Name$	 TbLogin��5&      $��2��6#   $��3��63   
 �� 	MaxLength$
 50��6@   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Введите логин��6O    %  !MaterialDesignFloatingHintTextBox#��[  6~   �� 5'   
   -   5        $	 
TbPassword��5'      $��2��6&   $��4��66   $
 70��6C   $! Введите пароль��6R   #��[  6�   �� 5(   
   -   5         ��Name$ CbRoleID��5(      $��2��6%   $��5��65    �� DisplayMemberPath$
 Role��6B   $C =Выберите позицию роли сотрудника��6[    & "MaterialDesignFloatingHintComboBox#��[ 6�   5)      5*      