   M S B A M L   `   `   `  ����N  JLabelTemplateEditor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:LabelTemplateEditorLabelTemplateEditor  5   	   $    LabelTemplateEditor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:LabelTemplateEditor     5   	   -   5          �Name$  LabelTemplateEditorWindow��5	   	    � Title$ Label Template Editor��5   	   $	��500��6'   $	��525��64    � DataContext 5
   	   ��  �� ElementName$ LabelTemplateEditorWindow�� �� Path$  LabelTemplateEditorContext�.��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5      �� 5      $��* �6   �� 5      $
��Auto �6   .+�5      �� $��5q�6   $��Template��5      $��2��5      $��Center=�5      �� 5       $��1��6   $��	15 5 15 5q�5!      $��0��5"      " �� VerticalScrollBarVisibility$
 Auto=�5#      $ �� HorizontalScrollBarVisibility$
 Auto=�5$      	 �� AcceptsReturn	 . 
 �� 
AcceptsTab
 . ��5'      �� *
Template+ �� Mode$ TwoWay=��� 5(      $��1��6   $��1��5)      $��30��5*      $��50��5+      $��Right=�5,      $	��Top=�5-      $��5 5 10 5q�5.      $��Clear��5/      ��50      �� *ClearTemplateCommand+�� 53      $��5q�6   $��2��54      $��0��55      $��2��56      $
��Data��57      $��Center=�58      �� 5:      $��3��6   $��	15 5 15 5q�5;      $��0��5<      $
 Auto=�5=      $
 Auto=�5>      	 . 
 . ��5A      �� *Data+$ TwoWay=��� 5C      $��3��6   $��1��5D      $��30��5E      $��50��5F      $��Right=�5G      $	��Top=�5H      $��5 5 10 5q�5I      $��Clear��5J      ��5K      �� *ClearDataCommand+�� 5M      $��4��6   $��0��5N      $��LeftToRight=�5O       �� Orientation$ 
Horizontal=�5P      $��5q�5Q      .+�5R      �� $��	Filename:��6   �� 5T      $	��300��6   $��5q�5U      ��5V      �� *
Filename+$ TwoWay=�5W   	   �� 5Y      $��0��6   $��2��5Z      $��5��5[      $��30��5\      $	��100��5]      $��5q�5^      $��Generate PDF��5_      ��5`      �� $ GenerateCommand��� 5b      $��0��6   $��6��5c      $��2��5d      .@�5e      �� .��5f      �� ��6   �� *Status+$ OneWay=�5g      5h   	   5k      5l      