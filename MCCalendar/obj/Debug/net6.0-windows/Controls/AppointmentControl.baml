   M S B A M L   `   `   `  ����E  AMCCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:MCCalendar.DataGridEntitiesMCCalendar.DataGridEntities  5      ,    &MCCalendar.Controls.AppointmentControl   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      <local1)clr-namespace:MCCalendar.DataGridEntities     5        � 	Resources  5	      6   0MCCalendar.DataGridEntities.NameToBrushConverter   NameToBrushConverter��%   &	          5
   
   6&   5      .��5      � ���#333 � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ dateLbl��5      $
��Date��6!   $��0��60   $��Center=�6=   $��0,10,0,0q�6Z   $	��Top=�6l   $
��Bold"�6�   $��16(�6�   
�������6�   �� 5   
   $��0��6   $	��Top=�6!   $��0,40,0,0q�69   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dataGrid��5      $��1��6%      GridLinesVisibility$	 All=�62      AutoGenerateColumns$ False��6L      CanUserSortColumns$ False��6h      
IsReadOnly$
 True��6�   $��100,10,100,10q�5      $	��620��6*      CanUserResizeRows$ False��66   	   HeadersVisibility$	 Column=�6o   $
   HorizontalScrollBarVisibility$
 Hidden=�5   =      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Time��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 150 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   ��  �� Path$
 time�   ElementStyle 5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$ Center=�6D   5      5        5       $ 
Employee 1��6%   $	 150 6]    6:   �� $ client1� 5!      �� 5"      " ��6    .�5#      ��  � �� 6;   �� *	client1+ �� 	Converter# [  �� 5$       �@��TextAlignment$ Center=�6>   �� 5%       � ��$
 Bold"�6;   5&      5(        5)      $ 
Employee 2��6%   $	 150 6]    6:   �� $ client2� 5*      �� 5+      " ��6    .�5,      ��  � �� 6;   �� *	client2+# [  �� 5-       �@��TextAlignment$ Center=�6>   �� 5.       � ��$
 Bold"�6;   5/      51        52      $ 
Employee 3��6%   $	 150 6]    6:   �� $ client3� 53      �� 54      " ��6    .�55      ��  � �� 6;   �� *	client3+# [  �� 56       � ��$ -8,-6,-0,-6q�67   �� 57       �@��TextAlignment$ Center=�6>   �� 58       � ��$ Center=�6B   �� 59       � ��$
 Bold"�6;   5:      5<        5?       �� Triggers P� Property P� Value��%�   '��       �� 5@      " ��6    5A      P� 5B       �@��Orientation$ Vertical=�69   . �5C      ��  � ��$ 20,0,0,0q�67   �� 5D       � ��$ 5��66   �� 5E       � ��$ 5��69   5F      5H      5I      5J      5K      5L      