   M S B A M L   `   `   `  ����  
MCCalendar*    $MCCalendar.Windows.AppointmentWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  Appointment��5   	   $	��400��6   $	��400��6*    � 
ResizeMode$ NoResize=�66    � WindowStartupLocation$ CenterScreen=�6L   .��5      � .+�5	   
   �� -   5         ��Name$ dateLbl��5	      $��Date:��6!   $
��Left=�61   $��	30,50,0,0q�6L   $	��Top=�6_   �� 5
   
   -   5         ��Name$ dateBox��5
      $
��Left=�6#   $��
150,55,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��200��6~   �� 5   
   $��Start Time:��6   $
��Left=�6&   $��	30,80,0,0q�6A   $	��Top=�6T   �� 5   
   -   5        $ startTimeBox��5      $
��Left=�6(   $��
150,85,0,0q�6C   $
 Wrap=�6W   $	��Top=�6k   $	��200��6�   �� 5   
   $��	End Time:��6   $
��Left=�6$   $��
30,110,0,0q�6?   $	��Top=�6S   �� 5   
   -   5        $ 
endTimeBox��5      $
��Left=�6&   $��150,115,0,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $	��200��6�   �� 5   
   -   5        $ empLbl��5      $��Employee Name:��6    $
��Left=�69   $��
30,140,0,0q�6T   $	��Top=�6h   �� 5   
   -   5         ��Name$ empBox��5      $
��Left=�6#   $��150,145,0,0q�6>   $	��Top=�6S   $	��200��6k   .@�5      �� $��Moira��6   6-   �� 5      $��George��6   6.   �� 5      $
��Dina��6   6,   5      �� 5   
   -   5        $ custLbl��5      $��Customer Name:��6!   $
��Left=�6:   $��
30,170,0,0q�6U   $	��Top=�6i   �� 5   
   -   5        $ 	custCombo��5      $
��Left=�6&   $��150,175,0,0q�6A   $	��Top=�6V   $	��200��6n    �� 
IsEditable$
 True��6z   �� 5   
   -	   5        $ noteLbl��5      $��Notes:��6!   $
��Left=�62   $��
30,200,0,0q�6M   $	��Top=�6a   �� 5   
   -
   5        $ noteBox��5      $
��Left=�6#   $��150,205,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��200��6   $��80��6�   $��2q�6�   �� 5   
   -   5         ��Name$ saveBtn��5      $
��Save��6"   $��Center=�61   $��8q�6N   $��90��6Z   $��0,0,0,10q�6e   $��Bottom=�6w   ���	#FF5C99D6
�������6�   �� 5    
   -   5        $ 	deleteBtn��5       $��Delete��6$   $��Center=�65   $��8q�6R   $��90��6^   $��
200,0,0,10q�6i   $��Bottom=�6}   ���	#FF5C99D6
�������6�   5!      5"      