   M S B A M L   `   `   `  ����H  DColorSelector, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:ColorSelectorColorSelector  5   	   7 clr-namespace:ColorSelector.UtilColorSelector.Util  5   	       ColorSelector.ColorPicker   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:ColorSelector     5   	   1util clr-namespace:ColorSelector.Util     5   	   -   5          � Title$  ColorPicker��5	   	   $��522.82��6   $��317.373��6-    � 	Resources 5         myDataSource S� 
ObjectType!   ColorSelector.Util.Bindings S� 
MethodName  HexagonTemplate �� 
TargetType �� Property �� Value��%M  &	        &	 7     S� 5   
   "  5      $ GetInstance��5      �� 5   
   " F�6(   .�5      ��  � ��$ 14��6&   �� 5       � ��$ 15��6'   �� 5       � ��F ����j     �`�� �g5 �`�� �y� ���j ��� �    �y� �    �g5 ���j     	6%   �� 5       � ��
 ���� 6%   -   5        5      5       � DataContext 5      �� 5   
    �� Source# [  6   	 J� CommandBindings	 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           ColorSelector.Commands
   ColorPickerCommand   Command# Z
 5      6P   .��5      � -   5        $��ColorSelectorGrid��5   #   $	��Top=�6    5    
     NotifyIconContextMenu �� 	Placement m� Icon �� Path��%u  &	       �� 5!      $ 
MousePoint=�68   .@�5"      m� -   5        $��_Open��5"      6*   m� 5#      -   5        $��_Pick color��5#       5$      �� 5%      $��ContextMenuSelectedColor��6$   $��10��6D   $��10��6O   ��5&   $   �� $ SelectedColor�5(      �� 5)      m� 5*      -   5        $��_Exit��5*      6*   5+      5,      .+�5-   
   �� $��Center=�6    J� RenderTransformOrigin$ 0.5,0.5&�62   $��0,20,0,0q�6R   .+�5.      �� $	��186��6   $	��158��6!   .+�5/      �� -   5        $	��Top=�5/      $	��186��60   $	��158��6<   $ ��Resources/img_colormap.gif��6I   50   ?   F� 51       �� Left$ 43��6   
 �� Top$ 0��6(   
 � Tag$ #003366��67   #��[ 6E   F� 52      $
 57.5��6   $ 0��6*   $ #336699��69   #��[ 6G   F� 53      $ 72��6   $ 0��6(   $ #3366cc��67   #��[ 6E   F� 54      $ 36��6   $ 12��6(   $ #006666��68   #��[ 6F   55      �� 56      -	   5        $��SelectedColorDisplay��56      $	��100��64   $��30��6@   $��0,10,0,0q�6L   $��2��57      
���   ���6;   �� $ SelectedColor�58      59      5:      