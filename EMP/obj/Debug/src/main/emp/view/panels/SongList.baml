   M S B A M L   `   `   `  ����  EMP'    !EMP.main.emp.view.panels.SongList   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5        &   System.Windows.Controls.DataGrid   Name$  	GridSongs��5
      $
��Auto��5      $
��Auto��5      
�������
�������   AutoGenerateColumns . $
��Left=�5      $	��Top=�5         RowHeaderWidth$ 0Q�5       � 	Resources 5      =  7System.Windows.Controls.Primitives.DataGridColumnHeader �� 
TargetType �� Property �� Value)  #System.Windows.Controls.DataGridRow��%/  '        '  �     �� 5   
   "  6   .�5      ��  � ��$ SemiBold"�6+   �� 5       � ��
 �OO/�6+   �� 5       � ��$ 0,0,1,2q�60   �� 5       � ��
 �   �6,   5      �� 5   
   "  6   .�5      ��  � ��
 �����6+   -   5        5      5         Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5   
   ,  &System.Windows.Controls.DataGridColumn   Header$ Count��6   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6S   
   MinWidth$
 60Q�6`   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6,   �� *Count+ �� Mode$ OneWay=�6`     5   
   $ Title��6   $
	 Auto 6S   $	
 400Q�6`    6,   �� *Title+$ OneWay=�6`     5    
   $ Duration��6   $
	 Auto 6Y   $
 80Q�6f    6/   �� *
Duration+$ OneWay=�6f     5!   
   $ Genre��6   $
	 Auto 6S   $	
 100Q�6`    6,   �� *Genre+$ OneWay=�6`     5"   
   $ Album��6   $
	 Auto 6S   $	
 100Q�6`    6,   �� *Album+$ OneWay=�6`     5#   
   $ 
Date Added��6   $	 * 6\   $	
 150Q�6f      MaxWidth$	 200Q�5$       5#   1   �� *	DateAdded+$ OneWay=�5$      5&      