   M S B A M L   `   `   `  ����?  ;Typo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Typo.View	Typo.View  5          Typo.View.CourseView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      )localclr-namespace:Typo.View     5      $
��1280��5   #   .��5	      � $��	0,0,-47,0q�6   .+�5
   
   &   System.Windows.Controls.DataGrid  -   5        $��CoursesGrid��5
      "    VerticalScrollBarVisibility$
  Auto=�6&      CanUserAddRows .     AutoGenerateColumns .  $��
108,0,0,10q�5   /      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Width5  /System.Windows.Controls.DataGridLengthConverter$ 2* 6%      Header$ Title��60      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6Q   �� *Title+  5      $ 1* 6%   $ 	StartDate��60    .  6U   �� *	StartDate+  5      $ 1* 6%   $ 	StartDate��60    .  6U   �� *	EndDate+4  .System.Windows.Controls.DataGridCheckBoxColumn  5      $ 1* 6)   $ Official��64    .  6X   �� *
Official+ � 	Resources 5      )  #System.Windows.Controls.DataGridRow	 �� 
TargetType��%E   '        �� 5      "	  6   .�5      -   5        5      5      5      �� 5   
   -   5        $��Create Course��5      $
��Left=�6)   $��	10,10,0,0q�6D   $	��Top=�6W   $��87��5      $��60��67   �� 5   
   -   5        $��Edit Course��5      $
��Left=�6'   $��	10,89,0,0q�6B   $	��Top=�6U   $��87��6m   $��64��5   &   �� 5   
   -   5        $��Delete Course��5      $
��Left=�6)   $��
10,175,0,0q�6D   $	��Top=�6X   $��87��5      $��61��61   5      5      