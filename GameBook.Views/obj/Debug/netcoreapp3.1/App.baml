   M S B A M L   `   `   `  ����I  EGameBook.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GameBook.ViewsGameBook.Views  5      E'clr-namespace:GameBook.Views.ViewModelsGameBook.Views.ViewModels  5          GameBook.Views.App   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      .localclr-namespace:GameBook.Views     5      >
viewModels'clr-namespace:GameBook.Views.ViewModels     5        �� 	Resources  5      0   *GameBook.Views.ViewModels.ViewModelLocator   Locator  ButtonHover �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Padding �� Orientation �� Triggers	 P� Property
 P� Value �� 
TargetName �� 
StartPoint �� EndPoint � Color � Offset  
ButtonBack  
ButtonQuit  ButtonMinimize��%~  &	        &	      &	 �    &	     &	 +	      5   
   6&   �� 5	   
   " ��6$   .�5
      ��  � ��
 ���� 6+   �� 5       � �� �#0006+   �� 5       � ��$ Cambria)�6+   �� 5       �@�Cursor$
 Hand��6'   �� 5       � ��$ 13 pt(�6)   �� 5       � ��$ 6q�6(   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $��border��6!   
������ $��0q�6I   $ 0��6]   $��	30 5 30 5q�6n   $ 6q�6�   ._�5      �� $ 
Horizontal=�6)   .+�5   "   �� $��image��6(   $��/Rsc/arrow_black.png��65   $��15��6S   $��15��6_   $��0 0 10 0q�6j   �� 5   "   $
��Left=�63   $��Center=�6N   5      5       5      P� 5      	 �@J�IsMouseOver$

 True��6=   . �5   "   �� $ image��6)    � ��$ /Rsc/arrow_white.png��6N   �� 5   "   $ border��6)    � �� 5   &   �� 5   *   $	 0,0&�6>   $	 1,1&�6O   .��5    .   � $
 #444��6;   $
 0.00Q�6H   � 5!   .   $ Transparent��6;   $
 1.10Q�6O   5"   +   5$   #   �� 5%   "    � �� �#38f6?   �� 5&   "    � �� �#fff6?   5'      5)      5+      5,      �� 5-   
   " ��6#   .�5.      ��  � ��
 ���� 6+   �� 5/       � �� �#7776+   �� 50       � ��$ Go Back��6(   �� 51       � ��$ Cambria)�6+   �� 52       �@�Cursor$
 Hand��6'   �� 53       � ��$ 14 pt(�6)   �� 54       � ��$ 30��6'   �� 55       � ��
 ���� 6,   �� 56       � ��$ 30 0 0 0q�6'   �� 57       � �� 58      �� 59      " ��6&   .R�5:      �� $
��Left=�6+   $��Center=�6F    5;      P� 5<      	 �@J�IsMouseOver$

 True��6=   . �5=   "   ��  � �� �#0006?   5>      5@      5B      5C      �� 5D   
   " ��6#   .�5E      ��  � ��
 ���� 6+   �� 5F       �@�Cursor$
 Hand��6'   �� 5G       � ��$ 30��6'   �� 5H       � ��$ 45��6&   �� 5I       � ��
 ���� 6,   �� 5J       � �� 5K      �� 5L      " ��6&   .R�5M      �� $��Image��6    $��/Rsc/quit.png��6-   $��20��6D   $��20��6P    5N      P� 5O      	 �@J�IsMouseOver$

 True��6=   . �5P   "   �� $ Image��6)    � ��$ /Rsc/quitHover.png��6N   5Q      5S      5U      5V      �� 5W   
   " ��6'   .�5X      ��  � ��
 ���� 6+   �� 5Y       �@�Cursor$
 Hand��6'   �� 5Z       � ��$ 30��6'   �� 5[       � ��$ 45��6&   �� 5\       � ��
 ���� 6,   �� 5]       � �� 5^      �� 5_      " ��6&   .R�5`      �� $��Image��6    $��/Rsc/minimize.png��6-   $��20��6H   $��20��6T    5a      P� 5b      	 �@J�IsMouseOver$

 True��6=   . �5c   "   �� $ Image��6)    � ��$ /Rsc/minimizeHover.png��6N   5d      5f      5h      5i      5j      5k      