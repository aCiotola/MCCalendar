   M S B A M L   `   `   `  ����E  AMCCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:MCCalendar
MCCalendar  5   	       MCCalendar.Schedule   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:MCCalendar     5   	     � Title$  Schedule��5   	   $	��800��6   $	��600��6'    � 
ResizeMode$ NoResize=�63   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ dateLbl��5      $
��Date��6!   $��0��60   $��Center=�6=   $��0,20,0,0q�6Z   $	��Top=�6l   �� 5   
   $��0��6   $	��Top=�6!   $��0,50,0,0q�69   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��1��6%      GridLinesVisibility$	 All=�62      AutoGenerateColumns$ False��6L      CanUserSortColumns$ False��6h      
IsReadOnly$
 True��5      	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Time��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$
 time�6T     5      $
 
Employee 1��6%   $	 150 6Z      
Visibility$ Hidden=�6f    6:   �� $
 emp1�6f     5      $
 
Employee 2��6%   $	 150 6Z   $ Hidden=�6f    6:   �� $
 emp2�6f     5      $
 
Employee 3��6%   $	 150 6Z   $ Hidden=�6f    6:   �� $
 emp3�6f     5      $
 
Customer 1��6%   $	 150 6[    6:   �� $ cust1�6[     5      $
 
Customer 2��6%   $	 150 6[    6:   �� $ cust2�6[     5      $
 
Customer 3��6%   $	 150 6[    6:   �� $ cust3�6[   5      5      5      