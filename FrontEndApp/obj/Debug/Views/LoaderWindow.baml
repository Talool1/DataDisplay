   M S B A M L   `   `   `  ����F  BFrontEndApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:FrontEndAppFrontEndApp  5   	   O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5   	       FrontEndApp.LoaderWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:FrontEndApp     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	     � Title$  LoaderWindow��5	   	   $��405.882��6   $��706.723��6/    � 
ResizeMode$ NoResize=�6?    � WindowStartupLocation$ CenterScreen=�6U   .��5
      � .+�5   
   �� -   5         ��Name$ Filepath_Textbox��5      $
��Left=�6y   $��23��6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��540��6�   $��	29,36,0,0q�6�   ��6,   �� *
FilePath+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=�6�   �� 5   
   -   5         ��Name$ 
Browse_Btn��5      $��Browse��6R   $
��Left=�6c   $	��Top=�6~   $��95��6�   $��
574,36,0,0q�6�   $��23��6�   ��6%   �� *LaunchFileBrowserCommand+6�   �� 5   
   -   5        $ OK_Btn��5      $��OK��6E   $
��Left=�6R   $��35��6m   $��426,316,0,0q�6y   $	��Top=�6�   $	��113��6�    �� 	IsDefault . ��6!   �� *LoadFileCommand+6�   �� 5   
   -   5        $ 
Cancel_Btn��5      $��Cancel��6J   $
��Left=�6[   $��35��6v   $��556,316,0,0q�6�   $	��Top=�6�   $	��113��6�   	 �� IsCancel	 . ��6%   �� *CloseViewCommand+6�   �� 5   
   $
��Left=�6   $��32��6-   $��
161,95,0,0q�69   $
 Wrap=�6M   $	��Top=�6�   $��19��6�   
 �� 	MaxLength$
 1��6�   ��6a   ��  �� Path$ SeparatorChar�$ PropertyChanged=�6�   �� 5   
   $��Separation Character��6   $
��Left=�6/   $��32��6J   $��	29,95,0,0q�6V   $	��Top=�6i   $	��132��6�   � 5   
    � DataContext 6   �� *metadataDefinitionVM+.+�5      �� $��
Field Name��6   $
��Left=�6)   $��32��6D   $��
29,165,0,0q�6P   $	��Top=�6d   $��85��6|   �� 5      -   5        $ FieldNameTextBox��5      $
��Left=�6u   $��32��6�   $��119,165,0,0q�6�   $
 Wrap=�6�   $	��Top=�6�   $	��149��6�   ��60   �� $ 	FieldName�$ PropertyChanged=�6�   �� 5      $��	Data Type��6   $
��Left=�6(   $��32��6C   $��
29,202,0,0q�6O   $	��Top=�6c   $��85��6{   �� 5      -   5         ��Name$ DataTypePropBox��5      $
��Left=�6�   $��31��6�   $��119,203,0,0q�6�   $	��Top=�6�   $	��149��6�    �� SelectedItem 60   �� *	FieldType+��6S   �� $ AvailableFieldTypes�6�   �� 5      -   5        $ AddBtn��5      $	��Add��6B   $
��Left=�6P   $��23��6k   $��284,172,0,0q�6w   $	��Top=�6�   $��76��6�   ��6%   �� $	 Add�6�   �� 5      -   5        $ 	RemoveBtn��5      $��Remove��6(   $
��Left=�6�   $��23��6�   $��284,203,0,0q�6�   $	��Top=�6�   $��76��6   ��69   �� *Remove+��6T   ��  �� ElementName$  MetadataConfigurationTable��$ SelectedIndex�6   �� 5      -	   5         ��Name$  MetadataConfigurationTable��5      $
��Left=�6f   $	��201��6�   $��
374,80,0,0q�6�   $	��Top=�6�   $	��295��6�   ��6;   �� *MetadataCollection+ �� View 5       �� 5!      .P�5"      �� $��	Data Name��6)    �� DisplayMemberBinding 6<   �� $ 
ColumnName��� 5#      $��	Data Type��6)    6<   �� $ ColumnDataType�5$      5&      5(      5)      5*      