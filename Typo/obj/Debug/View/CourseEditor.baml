   M S B A M L   `   `   `  ����?  ;Typo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Typo.View	Typo.View  5          Typo.View.CourseEditor   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      )localclr-namespace:Typo.View     5      X TXceed.Wpf.Toolkit, Version=3.2.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5        � Title$  
New Course��5	      $	��382��5
      $��535.933��5      $��10��5      $	��300��5       � 
ResizeMode$ NoResize=�5       � ShowInTaskbar .   � WindowStartupLocation$ CenterOwner=�5      .��5      � $��0,0,43,0q�6   .+�5   
   �� -   5         ��Name$ CourseTitle��5      $
��Left=�6'   $��22��6B   $��	44,10,0,0q�6N    �� TextWrapping$
 Wrap=�6a   $�� ��5       �� 	MaxLength$ 30��6   $	��Top=�6)   $	��200��6A   �� 5   
   -   5         ��Name$ VisibleCheck��5      $��Official��6)   $
��Left=�6<   $��
182,43,0,0q�6W   $	��Top=�5       J� RenderTransformOrigin$ 4.873,1.133&�6+   &   Xceed.Wpf.Toolkit.DateTimePicker  5   
   -   5        	  Name$	 	StartDate��5      $
��Left=�61   $��276,8,-39.6,0q�6L   $	��Top=�5      $ 0.059,0.375&�66   $	��243��6Z     5   
   -   5        $	 EndDate��5      $
��Left=�6/   $��276,37,-39.6,0q�6J   $	��Top=�5      $	��243��66   �� 5   
   $
��Left=�6   $	��188��61   $��10,79,-29.4,0q�6>   $	��Top=�6U   $	��506��6m   . �5      /� .T�5      J� .*�6   .*�5      �� -   5        
 �Name$
 CourseContent��5      $� ��6/   5      5      5       �� 5!   
   $	��End��6   $
��Left=�6   $��
244,37,0,0q�69   $	��Top=�6M   $��24��6e   $��33��5"      �� 5#   
   $��Start��6   $
��Left=�6    $��	244,5,0,0q�6;   $	��Top=�6N   $��27��6f   $��36��5$      $ 0.5,0.5&�6   �� 5%   
   $��Title��6   $
��Left=�6    $��7,8,0,0q�6;   $	��Top=�6L   $��24��6d   �� 5&   
   $
��Text��6   $
��Left=�6   $��7,55,0,0q�6:   $	��Top=�6L   $��24��6d   $��30��5'      $ 0.378,0.506&�6   �� 5(   
   -   5         ��Name$ okButton��5(       �� 	IsDefault . $
��Save��6I   $��409,291,-13.4,10.8q�6X   $ -0.037,0.182&�5)      �� 5*   
   -   5        $ cancelButton��5*       �� IsCancel . $��Cancel��67   $ 
0.56,0.132&�6H   $��276,291,105.6,9.8q�5+      5-      5.      