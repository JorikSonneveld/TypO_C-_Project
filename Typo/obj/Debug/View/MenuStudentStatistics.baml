   M S B A M L   `   `   `  ����?  ;Typo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Typo.View	Typo.View  5      %    Typo.View.MenuStudentStatistics   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Typo.View     5      .��5	      � -   5        $��StatisticsGrid��5	        � RowDefinitions  5
   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��0��6   $
��Left=�6,     5      �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��* �6    �� 5      $��4* �6     � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��* �6#   .+�5      �� $	��ID:��6   $
��Left=�6"   $��0��6=   $��1��6M   $��20(�6Z   �� 5      $
��Left=�6+   $��1��6F   $��1��6V   $��20(�6c   ��6   �� *ID+6c   �� 5      $��Name:��6   $
��Left=�6$   $��0��6?   $��2��6O   $��20(�6\   �� 5      $
��Left=�6-   $��1��6H   $��2��6X   $��20(�6e   ��6   �� *Name+6e   �� 5      $��Surname:��6   $
��Left=�6'   $��0��6B   $��3��6R   $��20(�6_   �� 5       $
��Left=�60   $��1��6K   $��3��6[   $��20(�6h   ��6   �� *	Surname+6h   5!      � 5#   
   $��1��6    5$      �� 5%      $��* �6#   �� 5&      $��* �6#   .+�5(      � $��1��6    5)      �� 5*      $��4* �6'   �� 5+      $	��.6* �6'     5.      �� 5/      $	��39* �6$   �� 50      $	��39* �6$   �� 51      $	��38* �6$   �� 52      $
��Auto �6$   �� 53      $
��155* �6$   .+�55      �� $��Avarage Accuracy:��6   $��Right=�64   $��0��6P   $��1��6`   $��20(�56      �� 57      $
��Left=�60   $��1��6K   $��1��6[   $��20(�6h   ��6   �� *[1]+6h   �� 58      $$��Avarage Keystrokes Per Minute:��6   $��Right=�6A   $��0��6]   $��2��59      $��20(�6%   �� 5:      $
��Left=�60   $��1��6K   $��2��6[   $��20(�6h   ��6   �� *[2]+6h   �� 5;      $��Completed Courses:��6   $��Right=�65   $��0��6Q   $��3��6a   $��20(�5<      �� 5=      $
��Left=�60   $��1��6K   $��3��6[   $��20(�6h   ��6   �� *[3]+6h   �� 5>      $��Completed Exersices:��6   $��Right=�67   $��0��6S   $��4��6c   $��20(�5?      �� 5@      $
��Left=�60   $��1��6K   $��4��6[   $��20(�6h   ��6   �� *[4]+6h   5A      5B      � 5C   
   $��1��6   .+�5D      &   System.Windows.Controls.DataGrid  -   5        $��DataGridResults��5D      "   VerticalScrollBarVisibility$
 Auto=�6.      CanUserAddRows .     AutoGenerateColumns .  $��5,5,5,5q�5E   3      Columns 5F      0  *System.Windows.Controls.DataGridTextColumn  5G      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6)      Header$ Title��63      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6T   �� *Course.Title+  5H      $	 .7* 6)   $ Keystrokes Per Minute��65    . 	 5I   )   �� *
KeyScore+  5J      $	 .3* 6)   $ Accuracy��65   	 6G   �� *
AccScore+
 �� StringFormat$

 {0}%��5L      5N      5O      5P      