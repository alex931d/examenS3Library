   M S B A M L   `   `   `  ����F  BlibaryAppV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:libaryAppV3libaryAppV3  5          libaryAppV3.userReturns   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:libaryAppV3     5      .��5	      � .+�5
   
   �� $��17(�6   $��10,51,543,348.6q�6   .��67   return books6E   &   System.Windows.Controls.DataGrid  5   
   -   5           Name$  returnBooksData��5   �      AutoGenerateColumns .     
IsReadOnly . 
���   �$��2q�6z   $
��Left=�6�   $	��220��6�   $��	10,96,0,0q�6�   $	��Top=�6�   $	��651��6�   ��6   �� *UserLendings+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 User��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *User.UsernameId+6Y     5      $
 Book��6%    63   �� *
Book.Title+6T     5      $ Count��6%    64   �� *Count+6P   5      �� 5   
   -   5        $��return��5      $
��Left=�6"   $��581,321,0,0q�6=   $	��Top=�6R   $��80��6j   $��21��6�   5      5      