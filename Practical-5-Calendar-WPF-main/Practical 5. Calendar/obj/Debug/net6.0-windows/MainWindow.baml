   M S B A M L   `   `   `  ����P  LPractical 5. Calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:Practical_5._CalendarPractical_5._Calendar  5   	   &     Practical_5._Calendar.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5local#clr-namespace:Practical_5._Calendar     5   	     � Title$  Календарь��5   	   $	��480��6   $	��570��6(   $	��480��64   $	��570��6D    � Icon$9 3https://img.icons8.com/emoji/256/calendar-emoji.png��5	   	   ���	#FF1A2126.��5      �  � ColumnDefinitions 5      �� 5      $��60 �6#   �� 5      �� 5      $
��auto �6#   �� 5      $��60 �6#    � RowDefinitions 5      �� 5      $
��auto �6    �� 5      .+�5      �� $��Bottom=�6   $��4��63   $��0,5,0,0q�6G   �� 5      -   5         ��Name$ PreviousMonth_BTN��5      $��45��60   $��<��6<   ���	#FF5EC2C36k   �� 5      -   5        $ NextMonth_BTN��5      $��45��6,   $��>��68   $��3��6D   ���	#FF5EC2C36p   (  "System.Windows.Controls.DatePicker  5      -   5          Name$ 
datePicker��5      $��0��6-   $��0��67   $y�Hidden=�6B   $��2��6V      SelectedDateFormat$
 Long=�6f   �� 5      -   5        $ datePicker_BTN��5      $��30��6-   $��35��68   
������ $��1,0,0,0q�6]   $��0,5,5,5q�6w   $��2��6�   .��5      �� -   5         ��Name$ Calendar_Icon��5      $��/calendar_icon_negate.png��6/   ��5       �� 5!       �� 
TargetType" ��6   .�5"      �� 	 �� Property	 �@�Cursor
 �� Value$

 Hand��63   5#      5%      �� 5'      -   5         ��Name$ 	TXT_Block��5'      $��1��6   $��25(�6�   $��Center=�6�   $��Center=�6�    J� OpacityMask
 �����
���������6+   ��  �� ElementName$ 
datePicker�� �� Path$ SelectedDate� �� StringFormat$ 	MMMM yyyy��6�   �� 5)   
   -   5        $ TXT_Block_2��5)   +   $y�	Collapsed=�6   $��1��6@   $��25(�6P   $��Center=�6^   $��Center=�6y   
�������
 �����6�   � 5+   
   -   5         �Name$ 	WrapPanel��5+      $��1��6'   $��4��64   $��5q�6H    � 5-      -	   5          �Name$ myFrame��5-      $��1��6%   $��4��62     � NavigationUIVisibility$ Hidden=�6F   �� 5/   
   -
   5        $ Back_BTN��5/   %   $y�Hidden=�6   $��45��67   $��<��6C   ���	#FF5EC2C3���	#FF5EC2C36�   51      52      