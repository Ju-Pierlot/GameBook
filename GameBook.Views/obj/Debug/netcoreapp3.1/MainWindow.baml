   M S B A M L   `   `   `  ����I  EGameBook.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:GameBook.ViewsGameBook.Views  5   	   E'clr-namespace:GameBook.Views.ViewModelsGameBook.Views.ViewModels  5   	   I)clr-namespace:GameBook.Views.UserControlsGameBook.Views.UserControls  5   	       GameBook.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:GameBook.Views     5   	   >
viewmodels'clr-namespace:GameBook.Views.ViewModels     5   	   ;views)clr-namespace:GameBook.Views.UserControls     5   	     � WindowStyle$
  None=�5	   	    � AllowsTransparency$
 True��5
   	   
������  � 
ResizeMode$ NoResize=�5   	    � Title$ GameBook��5   	   $	��540��6   $	��860��6'   +   %GameBook.Views.ExitEventToCommandPipe   Command 5   	   �� *Exit+ � DataContext 5   	   ��    Locator �� Source# [   �� Path$ WindowVM�'  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
   	   CaptionHeight$	 35Q�6   .��5      � $��5q�6   
 � UseLayoutRounding$

 True��6    J� SnapsToDevicePixels$
 True��6/    J� Effect 5   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 5Q�6      	Direction$	 -90Q�6.      RenderingBias$ Quality=�6>      ShadowDepth$ 0Q�6V    � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $
��Auto �6   .+�5   
   � $��0��6   ���#ffffff � ColumnDefinitions 5      �� 5      $��50 �6#   �� 5      $	��225 �6#   �� 5       $	��300 �6#   �� 5!      $��* �6#   .+�5#      �� $��0��6   $��18��6$   $��18��60   $��Center=�6;   $��Center=�6V   $��/Rsc/icon.png��6s   6�   �� 5$      $��1��6   $��Center=�6%   $��Charger un livre��6@      IsHitTestVisibleInChrome$
 True��6[   $��Cambria)�6�   $��14(�6�   
������ 
������ $	��150��6�   $
��Left=�6�    � Cursor$
 Hand��6  ��6  �� *
LoadFile+�� 5%      $��2��6   $��GameBook��6(   $��Center=�68   $��Center=�6U   $��15(�6p   $��Cambria)�6~   �� 5&       �� Orientation$ 
Horizontal=�6   $��3��62   $��Right=�6B   $��Center=�6^   .+�5'      �� -   5        $��Minimize��5'   n   $
 True��6     ButtonMinimize#��[ 6F   6n   �� 5(      -   5        $
��Quit��5(   j   $
 True��6     
ButtonQuit#��[ 6F   6j   5)      5*      (   "GameBook.Views.UserControls.UCMain  5+   
   $��1��6   5,      5-      