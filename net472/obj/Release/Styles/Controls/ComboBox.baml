   M S B A M L   `   `   `  ���� >  :XUi, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XUiXUi  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   XUi_ComboBox  �� 
TargetType �� Property �� Value  	FontBrush  FlatOverBrush �� 
TargetType  ComboBoxToggleButton �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource	 J� IsHitTestVisible
 �� SelectionBoxItem �� SelectionBoxItemTemplate �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight  CornerRadiusBottom �� CornerRadius J� OpacityMask !� Visual �� ElementName K� IsItemsHost-   'System.Windows.Input.KeyboardNavigation    DirectionalNavigation �� Triggers P� Property P� Value �� 
TargetName  XUi_ComboBoxLight  FlatPressBrush � ColumnDefinitions ��Name  CornerRadius F�Name  J� RenderTransformOrigin! �� Angle  CornerRadiusTop" N� EnterActions# �� 
TargetName$ �� TargetProperty9  3System.Windows.Media.Animation.EasingDoubleKeyFrame% O� KeyTime& O� Value'   EasingFunction-  'System.Windows.Media.Animation.SineEase7  1System.Windows.Media.Animation.EasingFunctionBase(   
EasingMode) N� ExitActions 	 ComboBoxTextBox 
 
PopupStyle* �� Triggers+ �� Padding'  !System.Windows.VisualStateManager,   VisualStateGroups%  System.Windows.VisualStateGroup-   Name.   States   System.Windows.VisualState/   Name0   
Storyboard  	BaseColor	1 �� To2 g� Duration  	DarkColor�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     localclr-namespace:XUi  %T  &	        7  &	 �    7  &	 �	    &		 �    &	
 �    '�� o    �� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$	 120����  � ��$ 20����  � ��# �  ��  � ��# �  ��  � ��$ 14(���  � �� �� " ��.R�� #��z��.+�d� $��ToggleButton��8��  $��2��|�.  #��z��$ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite��	 .  #��z
 #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $��PART_EditableTextBox��$
��Left=�$��Center=�$��3,3,23,3q�$��3q�|�. #��z��$y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $��DropDown�� . #��z $��10q�#��z .+��� $��DropDownBorder��#��z��# �  �� $��
MaskBorder��#��z��# �  ��  .  !�  �� $ 
MaskBorder��.����  . $ 	Contained=� P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 0��P�  � {� .  . ���  �@J�Opacity$	 0.5Q�P�  �@��
IsGrouping . . ���  � �� .  P�  �@��
IsEditable . . ���  � �� .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=��� "  ��.���  �@J�SnapsToDevicePixels . ��  �@�OverridesDefaultStyle . ��  � ��$
 Auto=���  � ��$
 Auto=���  � �� . ��  � ��$	 120����  � ��$ 20����  � ��# �  ��  � ��# �  ��  � ��$ 14(���  � �� �� " ��.R�� #��z��.+�d� $��ToggleButton��8��  $��2��|�.  #��z��$ Press=� �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+�� $��ContentSite��	 .  #��z
 #��z #��z��$��3,3,23,3q�$��Center=�$
��Left=��� $��PART_EditableTextBox��$
��Left=�$��Center=�$��3,3,23,3q�$��3q�|�. #��z��$y�Hidden=�# z ��Z� � $��Popup��$��Bottom=�#��z  . |�.  $��Slide=�.��� $��DropDown�� . #��z $��10q�#��z .+��� $��DropDownBorder��#��z��# �  �� $��
MaskBorder��#��z��# �  ��  .  !�  �� $ 
MaskBorder��.����  . $ 	Contained=� P�  �@��HasItems .  . ��� $ DropDownBorder�� � ��$ 0��P�  � {� .  . ���  �@J�Opacity$	 0.5Q�P�  �@��
IsGrouping . . ���  � �� .  P�  �@��
IsEditable . . ���  � �� .  �� $ PART_EditableTextBox�� � y�$ Visible=��� $ ContentSite�� � y�$ Hidden=��� " d�.R��  �� �� $��20 �.+��� $ Border��$��2��#��z��# �  �� $��0��$��1q�#��z��# �  F� $ Arrow��$��1��#���  $��Center=�$��Center=�=����        �    �� � 	= ��[ � z �� � z     � 	=  	= 	$  0.5,0.5&�z��� ArrowTransform��$! 0Q� P�  �@d�	IsChecked$
 TrueY�. ��� $ Border��# �   �@��CornerRadius" �� .���� .��U� $# ArrowTransform��$$ (RotateTransform.Angle)�.\�  $% 0��& 0  $% 0:0:0.25��& 180'   $( 	EaseInOut=�) �� .���� .��U� $# ArrowTransform��$$ (RotateTransform.Angle)�.\�  $% 0��& 180  $% 0:0:0.25��& 360'   $( 	EaseInOut=��� " ��.R��� $ PART_ContentHost��|�.  �� "  �* P�  � �� . " �� .���� .��U� $ $ (FrameworkElement.Opacity)�.\�  $% 0��& 0  $% 0:0:0.25��& 1'   $( 	EaseInOut=��� "  ��.���  �@J�SnapsToDevicePixels . ��  � ��# �  ��  �@�OverridesDefaultStyle . ��  � ��# �  ��  � �� �� " ��.R��� $��Border��$+ 3q�
������  . ,   $- SelectionStates��..   $/ 	MouseOver��.0 �� .���� $# Border��$1$ +(Border.Background).(SolidColorBrush.Color)�#1 �  $2 0:0:0D�  $/ Normal��.0 �� .���� $# Border��$1$ +(Border.Background).(SolidColorBrush.Color)�$1 TransparentX�$2 0:0:0D�  $/ Selected��.0 �� .���� $# Border��$1$ +(Border.Background).(SolidColorBrush.Color)�#1 �  $2 0:0:0.25D�._���  P�  � {� .  . ���  � �� �#888888