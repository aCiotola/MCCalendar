   M S B A M L   `   `   `  ����E  AMCCalendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MCCalendar.PopupMCCalendar.Popup  5   	   "    MCCalendar.Popup.Appointment   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:MCCalendar.Popup     5   	     � Title$  Appointment��5   	   $	��350��6   $	��400��6*    � 
ResizeMode$ NoResize=�66   .��5	      � .+�5
   
   �� -   5         ��Name$ dateLbl��5
      $��Date:��6!   $
��Left=�61   $��	30,50,0,0q�6L   $	��Top=�6_   �� 5   
   -   5         ��Name$ dateBox��5      $
��Left=�6#   $��
150,55,0,0q�6>    �� TextWrapping$
 Wrap=�6R   $	��Top=�6f   $	��200��6~   �� 5   
   -   5        $ timeLbl��5      $��Time:��6!   $
��Left=�61   $��	30,80,0,0q�6L   $	��Top=�6_   �� 5   
   -   5        $ timeBox��5      $
��Left=�6#   $��
150,85,0,0q�6>   $
 Wrap=�6R   $	��Top=�6f   $	��200��6~   �� 5   
   -   5        $ empLbl��5      $��Employee Name:��6    $
��Left=�69   $��
30,110,0,0q�6T   $	��Top=�6h   �� 5   
   -   5         ��Name$ empBox��5      $
��Left=�6#   $��150,115,0,0q�6>   $	��Top=�6S   $	��200��6k   .@�5      �� $��Moira��6   6-   �� 5      $��George��6   6.   �� 5      $
��Dina��6   6,   5      �� 5   
   -   5        $ custLbl��5      $��Customer Name:��6!   $
��Left=�6:   $��
30,140,0,0q�6U   $	��Top=�6i   �� 5   
   -   5        $ custBox��5      $
��Left=�6$   $��150,145,0,0q�6?   $	��Top=�6T   $	��200��6l    �� 
IsEditable$
 True��6x   �� 5   
   -	   5        $ noteLbl��5      $��Notes:��6!   $
��Left=�62   $��
30,170,0,0q�6M   $	��Top=�6a   �� 5   
   -
   5        $ noteBox��5      $
��Left=�6#   $��150,175,0,0q�6>   $
 Wrap=�6S   $	��Top=�6g   $	��200��6   $��80��6�   �� 5   
   -   5         ��Name$ saveBtn��5      $
��Save��6"   $��Center=�61   $��0,0,0,20q�6N   $��Bottom=�6`   5      5      