   M S B A M L   `   `   `  ����F  BlibaryAppV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:libaryAppV3libaryAppV3  5          libaryAppV3.returnControl   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:libaryAppV3     5      .��5	      � .+�5
   
   �� -   5        $��return book��5
      $
��Left=�6'   $��361,343,0,0q�6B   $	��Top=�6W   $	��161��6o   $��26��6{     J� RenderTransformOrigin$  0.118,0.285&�6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ datagridUsers��5   ^      AutoGenerateColumns .    
IsReadOnly . $
��Left=�6u   $	��133��6�   $��	11,31,0,0q�6�   $	��Top=�6�   $	��511��6�   ��6   �� *Users+6�     5   
   -   5        $ datagridLendings��5   �    .   . 
���   �$��2q�6v   $
��Left=�6�   $	��140��6�   $��
13,195,0,0q�6�   $	��Top=�6�   $	��509��6�   ��6   �� *
Lendings+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$
 User��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 63   �� *User.UsernameId+6Y     5      $
 Book��6%    63   �� *
Book.Title+6T     5      $ Count��6%    64   �� *Count+6P   5      �� 5   
   $%��current lending books to return��6   $
��Left=�6:   $��
16,169,0,0q�6U   $	��Top=�6i   $  1.887,0.747&�6�   �� 5   
   $'��!show user's current book lendings��6   $
��Left=�6<   $��10,0,0,0q�6W   $	��Top=�6i   $  1.887,0.747&�6�   5      5      