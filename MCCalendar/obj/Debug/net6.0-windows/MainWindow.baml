   M S B A M L   `   `   `  ����  
MCCalendar    MCCalendar.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  6P     � Title$  
MCCalendar��5   	   $	��800��6   $
��1000��6)   $	��600��66   $	��800��6F    � WindowStartupLocation$ CenterScreen=�5   	    � 	Resources 5	         ListViewItemStyle1 �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%%  &	        �� 5
   
   " ��6+    5      P� 5       �@J�IsMouseOver$
 true��61   . �5      ��  � ��
 ��� �63   5      P� 5       �@��
IsSelected$
 true��60   . �5      ��  � ��
 �����63   �� 5       � ��
 ��� �63   5      5      5      .��5      � 	 � RowDefinitions	 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � -   5        
 �Name$
 
mainWindow��5      $��1��6#   
�������$��Stretch=�6C   �� 5   
   $��1��6   $	��Top=�6!   � 5    
   -   5        $
 navMenu��5       $��0��6    
�������$��Stretch=�6@   $��20,0,0,0q�6^   .+�5!      �� $��Center=�6   .+�5"      �� -   5         ��Name$ listViewMenu��5"      ���	#FF5C99D6#��[  5#      ��5$      �� 5%      .R�5&      ��  �� Orientation$ 
Horizontal=�6)   6D   5'      .@�5*      �� -   5         ��Name$ itemCalendar��5*   #   .��5+      �� $ 
Horizontal=�6%   .+�5,      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Calendar=�66   $��35��6F   $��35��6R   �� 5-      $��Calendar��6(   $��Center=�68   $��14(�6S   $��3 0 0 0q�6a   �� 5.      $��0,0,0,0q�6(   5/      50      �� 52      -   5        $ itemAppointments��52   #   .��53      �� $ 
Horizontal=�6%   .+�54        $ BookAccount=�66   $��35��6I   $��35��6U   �� 55      $��Appointments��6(   $��Center=�6<   $��14(�6W   $��3 0 0 0q�6e   56      57      �� 59      -   5        $ itemEmployees��59   #   .��5:      �� $ 
Horizontal=�6%   .+�5;        $ Worker=�66   $��35��6D   $��35��6P   �� 5<      $��	Employees��6(   $��Center=�69   $��14(�6T   $��3 0 0 0q�6b   5=      5>      �� 5@      -   5        $ itemClients��5@   #   .��5A      �� $ 
Horizontal=�6%   .+�5B        $ AccountCircle=�66   $��35��6K   $��35��6W   �� 5C      $��Clients��6(   $��Center=�67   $��14(�6R   $��3 0 0 0q�6`   5D      5E      5G      5H      5I      5J      5K      