   M S B A M L   `   `   `  ����  NetworkScanner    NetworkScanner.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   >d2http://schemas.microsoft.com/expression/blend/2008    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -   5          � Title$  Network Scanner��5   	   $	��500��6!   $	��500��6.   .��5	      � .+�5
   
   �� $��10,10,10,25q�6   .@�5      �� $��Scaneris��6   .��5      � ���	#FFE5E5E5 � RowDefinitions 5      �� 5      �� 5      .+�5      �� -   5        $
��Scan��5      $��Right=�6,   $��	0,0,10,10q�6H   $��75��6[   $��20��6{   $��Bottom=�6�   $��1��6�   &   System.Windows.Controls.DataGrid  5      -   5        $��portsToScanDataGrid��5      $��10,31,10,35q�6;      AutoGenerateColumns .  $��1��6l      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 Port��61      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6c   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ��  �� Path$ 
PortNumber�6c   4  .System.Windows.Controls.DataGridComboBoxColumn  5      $ 
Protokolas��65   5      5      �� 5      $
��Left=�6    $��	10,10,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��282��6z   $��Pasirinkite IP:��6�   $��16��6�   �� 5      $
��Left=�6    $��	10,10,0,0q�6;   $
��Wrap=�6N   $	��Top=�6b   $	��332��6z   $��16��6�   $��1��6�   �� 6�   $)�#Įveskite norimus praskanuoti portu��6�   �� 6�   $�s:��6�   6�   �� 5      $��10,31,10,10q�6!   ���	#FFE5E5E5.@�5      �� $��
IP ruožas��6"   .��5       (� $��	0,10,10,0q�6&    (� Stretch$
 Fill=�69   $��54��6H   $	��Top=�6T   $��Right=�6l   $	��164��6�   .��5!   "   � $��53��6'   $	��164��63   .+�5"   &   �� -   5        $��octet1��5"   .   $
��Left=�6<   $��24��6W   $��4,14,0,0q�6c   	 �� TextWrapping$
	 Wrap=�6u   $	��172��6�   $	��Top=�6�   $��30��6�   �� 5#   &   -   5        $��octet2��5#   .   $
��Left=�6<   $��24��6W   $��	48,14,0,0q�6c   $
	 Wrap=�6v   $��16��6�   $	��Top=�6�   $��30��6�   �� 5%   &   -   5        $��	octet3min��5%   .   $
��Left=�6?   $��24��6Z   $��91,0,0,0q�6f   $
	 Wrap=�6x   $��0��6�   $	��Top=�6�   $��30��6�   
 J� RenderTransformOrigin$
 	0.996,0.5&�6�   �� 5&   &   -   5        $��	octet3max��5&   .   $
��Left=�6?   $��24��6Z   $��	91,29,0,0q�6f   $
	 Wrap=�6y   $��4��6�   $	��Top=�6�   $��30��6�   $
 	0.996,0.5&�6�   �� 5(   &   -   5        $��	octet4min��5(   .   $
��Left=�6?   $��24��6Z   $��	134,0,0,0q�6f   $
	 Wrap=�6y   $��0��6�   $	��Top=�6�   $��30��6�   $
 	0.996,0.5&�6�   �� 5)   &   -	   5        $��	octet4max��5)   .   $
��Left=�6?   $��24��6Z   $��
134,29,0,0q�6f   $
	 Wrap=�6z   $	��255��6�   $	��Top=�6�   $��30��6�   $
 	0.996,0.5&�6�   �� 5+   &   $��.��6,   $
��Left=�68   $��121,12,0,15q�6S   �� 5,   &   $��.��6,   $
��Left=�68   $��	78,12,0,0q�6S   $	��Top=�6f   �� 5-   &   $��.��6,   $
��Left=�68   $��	30,12,0,0q�6S   $	��Top=�6f   5.   #   5/      50      �� 51      $��IP sąrašas��6"   .��52      � ���	#FFE5E5E56#   53      �� 54      $��Nmap XML outputas��6"   .��55      � ���	#FFE5E5E56#   56      57      58      59      �� 5:      $"��Įrenginių identifikatorius��6   .��5;      � ���	#FFE5E5E5 � ColumnDefinitions 5<      �� 5=      �� 5>      $	��200 �6+   .+�5@        -
   5          Name$ itemsDataGrid��5@      $��10,10,10,35q�6[   $��2��6p    � DataContext 66   ��  �� Source$ value�� 5A      5C      �� 5D      -   5        $!��Analizuoti analizės failą��5D      $��	0,0,10,10q�6A   $��20��6k   $��Bottom=�6w   $��Right=�6�   $	��180��6�   $��1��6�   5E      5F      5G      �� 5I   
   $��20��6   $��Bottom=�6    .@�5J      �� $
��Wrap=�6   $N��H(C) Tomas Vanagas ISKS7    //    Vilniaus Universitetas Kauno Fakultetas��6,   5K      5L      5M      