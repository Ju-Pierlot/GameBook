   M S B A M L   `   `   `  ����I  EGameBook.Views, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullI)clr-namespace:GameBook.Views.UserControlsGameBook.Views.UserControls  5      (    "GameBook.Views.UserControls.UCMain   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ;views)clr-namespace:GameBook.Views.UserControls     5      $	��500��5	      $	��850��6     � DataContext  5
      ��    Locator �� Source# [   �� Path$ ParagraphInfosVM� � Triggers 5      :� 5   
    :� RoutedEvent$ Window.DpiChanged��6   [�5      �� 5      .��5      ��  g� RepeatBehavior$ 1x��6!    g� AutoReverse$ False��66   .��5      ��  �� 
TargetName$ 	Main_grid��6*    �� TargetProperty$U O(Canvas.Background).(LinearGradientBrush.GradientStops)[0].(GradientStop.Color)�5   *   	 g� Duration$	 0:0:1D�5   i   
 �� From
 6*   �� *PrecedingColorStart+	 �� To 6O   �� *
ColorStart+6i   �� 5      $ 	Main_grid��6)   $U O(Canvas.Background).(LinearGradientBrush.GradientStops)[1].(GradientStop.Color)�5   )   $	 0:0:1D�5   d   
 6)   �� *PrecedingColorEnd+ 6L   �� *
ColorEnd+6d   5      5      5      .��5      � -   5        $��	Main_grid��5      ��5   
   �� 5       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��5      �  � Offset$
 0.20Q�6   � 5      $
 0.80Q�6   5        � RowDefinitions 5"   
   �� 5#      $
��Auto �6   �� 5$      $��* �6   �� 5%      $��60 �6   �� 5&      $��30 �6   .+�5(   
   �� $��0��6    �� CanHorizontallyScroll$ False��6"    �� CanVerticallyScroll$ False��6@    �� Orientation$ Vertical=�6\   .+�5)      2   ,GameBook.Views.UserControls.UCParagraphInfos  5*      �� 5+   
   $
��Auto=�6   $��1��6:   $��0 15 0 0q�6G   .��5,      4   .GameBook.Views.UserControls.UCParagraphAnswers  5-      �� 5.   
   $��2��6   $��30��6"   .+�5/      �  � ColumnDefinitions 50      �� 51      $
��Auto �6'   �� 52      $��* �6'   .+�54      (   "GameBook.Views.UserControls.UCBack  $��0��6   1   +GameBook.Views.UserControls.UCParagraphsBox  55      $��1��6(   56      57      +   %GameBook.Views.UserControls.UCMessage  58   
   $��3��6   59      5:      