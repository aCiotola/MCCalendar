   M S B A M L   `   `   `  ����  
MCCalendar'    !MCCalendar.Controls.ClientControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      .��5      � -   5        $��clientWindow��5      
�������  � RowDefinitions  5	   
   �� 5
      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $	��200 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6   $��Name:��6-   $
��Bold"�6=   �� 5   
   -   5        $��nameText��5      $�� ��6"   $��1��6*   $��0��6:   $��3q�6G   �� 5   
   $��1��6   $��0��6   $��Phone:��6-   $
��Bold"�6>   �� 5   
   -   5         ��Name$ 	phoneText��5      $�� ��6%   $��1��6-   $��1��6=   $��3q�6J   �� 5   
   -   5        $��clearBtn��5      $��Clear Fields��6!   $��0��68   $��2��6E   $��5,2,0,2q�6U   $	��120��6f   $
��Left=�6r   ���	#FF5C99D6
�������6�   �� 5   
   -   5        $��saveBtn��5      $��Save Client��6    $��1��66   $��2��6C   $��5,2,0,2q�6S   $	��120��6d   $
��Left=�6p   ���	#FF5C99D6
�������6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��dataGrid��5      $��8��6#   $��3��60   $��5,5,5,5q�6D      AutoGenerateColumns$ False��6U      CanUserAddRows$ False��6q      HeadersVisibility$ Column=�5   7   $��16(�6R      Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5       ,  &System.Windows.Controls.DataGridColumn   
IsReadOnly$
 True��6)      CellTemplate 5!      �� 5"      .R�5#   "   �� $��/Images/trash.png��6(   $��30��6C   5$      5&      0  *System.Windows.Controls.DataGridTextColumn  5(      	   Header$
	 Name��6B   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 auto 6P   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6)   �� *name+6P     5)      $	 Phone��6?   $
 * 6N    6%   �� *phone+6N   5+      5-      5.      