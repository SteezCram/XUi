   M S B A M L   `   `   `  ���� >  :XUi, Version=1.1.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:XUiXUi  /clr-namespace:XUi.ConvertersXUi.Converters  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"    XUi.Converters.MathConverter   MathConverter  XUi_ProgressBarDots  �� 
TargetType �� Property �� Value  	BaseBrush �� Orientation A�Name J� Opacity �� 	Converter �� ConverterParameter'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup	   States   System.Windows.VisualState
   
Storyboard g� RepeatBehavior �� 
TargetName �� TargetProperty g� Duration9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� Value O� KeyTime   EasingFunction-  'System.Windows.Media.Animation.SineEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  XUi_ProgressBar  FlatPressBrush �� 
TargetType4  .System.Windows.Media.Animation.ExponentialEase   Exponent $� KeyTime $� Value J� OpacityMask !� Visual �� ElementName ��Name  CornerRadius �� CornerRadius ��Name  CornerRadiusNumber �� RadiusX �� RadiusY �Name  J� RenderTransformOrigin! �� Triggers" P� Property# P� Value$ �� 
TargetName  XUi_ProgressBarBaseAccent  XUi_ProgressBarMidAccent 	 MidBrush 
 XUi_ProgressBarDarkAccent  	DarkBrush�� D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     localclr-namespace:XUi  +
convertersclr-namespace:XUi.Converters  %  &	        &	      7   7   7   7   7   7   &	 E    &	 
    &	 �    &	
 �       �� "  �.���  � ��
 ���� ��  � ��$ 0q���  � ��
 ���� ��  � ��$ 10q���  � ��$ 50����  � ��# �  ��  �@�IsIndeterminate . ��  � ��$ Center=���  � �� �� .R��� $ 
Horizontal=�.+�A� $ Ellipse1��$��0��#��z��#��z��$ 0Q����� *Height+8   $ @VALUE/6������ *Height+8  $ @VALUE/6��A� $ Ellipse2��$��0��#��z��#��z��$ 0Q����� *Height+8  $ @VALUE/6������ *Height+8  $ @VALUE/6��A� $ Ellipse3��$��0��#��z��#��z��$ 0Q����� *Height+8  $ @VALUE/6������ *Height+8  $ @VALUE/6��   CommonStates��.	   Determinate��  Indeterminate��.
 �� $ Forever��.��U� $ Ellipse1��$ (Ellipse.Opacity)�$ 0:0:2D�$ Forever��.\�  $ 0Q�$ 0��  $ 1Q�$ 0:0:0.5��   $ 	EaseInOut=�  $ 0Q�$ 0:0:1��   $ 	EaseInOut=�U� $ Ellipse2��$ (Ellipse.Opacity)�$ 0:0:2D�$ Forever��.\�  $ 0Q�$ 0:0:0.5��  $ 1Q�$ 0:0:1��   $ 	EaseInOut=�  $ 0Q�$ 0:0:1.5��   $ 	EaseInOut=�U� $ Ellipse3��$ (Ellipse.Opacity)�$ 0:0:2D�$ Forever��.\�  $ 0Q�$ 0:0:1��  $ 1Q�$ 0:0:1.5��   $ 	EaseInOut=�  $ 0Q�$ 0:0:2��   $ 	EaseInOut=��� "  �.���  � ��# �  ��  � ��$ 0q���  � ��
 ���� ��  � �� �� " �.R�� #��z��#��z��
������    CommonStates��.	   Determinate��  Indeterminate��.
 �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	Animation��.\�  $ 0��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:0.5��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:2.5��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:3��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:5��$ 0Q�   $ EaseIn=�$ 2Q�*� $' !(UIElement.RenderTransformOrigin)�$ 	Animation��.'�g� $ 0��$	 0,0&�g� $ 0:0:0.5��$	 0,0&�g� $ 0:0:2.5��$	 1,0&�g� $ 0:0:5��$	 1,0&�.+��  !�  �� $
 Mask��.+��� $
 Mask��#��z��# �  �� $ 
PART_Track��
������ # �  # �  � $ PART_Indicator��}�. $
��Left=�.+��� $ 	Indicator��#��z��# �  # �  �� $ 	Animation��#��z��$  0.5,0.5&�# �  # �  z�V� .~��� �� �� T� ! P� " �@�IsIndeterminate# . . ��� $$ 	Indicator�� � y�$ 	Collapsed=�P� " � {�# .  . ���  �@J�Opacity$	 0.5Q��� "  �.���  � ��# �  ��  � ��$ 0q���  � ��
 ���� ��  � �� �� " �.R�� $
 Grid��#��z��#��z��
������    CommonStates��.	   Determinate��  Indeterminate��.
 �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	Animation��.\�  $ 0��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:0.5��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:2.5��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:3��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:5��$ 0Q�   $ EaseIn=�$ 2Q�*� $' !(UIElement.RenderTransformOrigin)�$ 	Animation��.'�g� $ 0��$ 0,0.5&�g� $ 0:0:0.5��$ 0,0.5&�g� $ 0:0:2.5��$ 1,0.5&�g� $ 0:0:5��$ 1,0.5&�.+��  !�  �� $
 Mask��.+��� $
 Mask��#��z��# �  �� $ 
PART_Track��
������ # �  # �  � $ PART_Indicator��}�. $
��Left=�.+��� $ 	Indicator��#���  # �  # �  �� $ 	Animation��#���  $  0.5,0.5&�# �  # �  z�V� .~��� �� �� T� ! P� " �@�IsIndeterminate# . . ��� $$ 	Indicator�� � y�$ 	Collapsed=�P� " � {�# .  . ���  �@J�Opacity$	 0.5Q��� "  �.���  � ��# �  ��  � ��$ 0q���  � ��
 ���� ��  � �� �� " �.R�� #��z��#��z��
������    CommonStates��.	   Determinate��  Indeterminate��.
 �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	Animation��.\�  $ 0��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:0.5��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:2.5��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:3��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:5��$ 0Q�   $ EaseIn=�$ 2Q�*� $' !(UIElement.RenderTransformOrigin)�$ 	Animation��.'�g� $ 0��$ 0,0.5&�g� $ 0:0:0.5��$ 0,0.5&�g� $ 0:0:2.5��$ 1,0.5&�g� $ 0:0:5��$ 1,0.5&�.+��  !�  �� $
 Mask��.+��� $
 Mask��#��z��# �  �� $ 
PART_Track��
������ # �  # �  � $ PART_Indicator��}�. $
��Left=�.+��� $ 	Indicator��#��� 	 # �  # �  �� $ 	Animation��#��� 	 $  0.5,0.5&�# �  # �  z�V� .~��� �� �� T� ! P� " �@�IsIndeterminate# . . ��� $$ 	Indicator�� � y�$ 	Collapsed=�P� " � {�# .  . ���  �@J�Opacity$	 0.5Q��� "  �.���  � ��# �  ��  � ��$ 0q���  � ��
 ���� ��  � �� �� " �.R�� $
 Grid��#��z��#��z��
������    CommonStates��.	   Determinate��  Indeterminate��.
 �� $ Forever��.��U� $V P(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)�$ 	Animation��.\�  $ 0��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:0.5��$ 0Q�   $ EaseIn=�$ 2Q�  $ 0:0:2.5��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:3��$ 1Q�   $ EaseOut=�$ 2Q�  $ 0:0:5��$ 0Q�   $ EaseIn=�$ 2Q�*� $' !(UIElement.RenderTransformOrigin)�$ 	Animation��.'�g� $ 0��$ 0,0.5&�g� $ 0:0:0.5��$ 0,0.5&�g� $ 0:0:2.5��$ 1,0.5&�g� $ 0:0:5��$ 1,0.5&�.+��  !�  �� $
 Mask��.+��� $
 Mask��#��z��# �  �� $ 
PART_Track��
������ # �  # �  � $ PART_Indicator��}�. $
��Left=�.+��� $ 	Indicator��#���  # �  # �  �� $ 	Animation��#���  $  0.5,0.5&�# �  # �  z�V� .~��� �� �� T� ! P� " �@�IsIndeterminate# . . ��� $$ 	Indicator�� � y�$ 	Collapsed=�P� " � {�# .  . ���  �@J�Opacity$	 0.5Q�