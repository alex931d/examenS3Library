   M S B A M L   `   `   `  ����F  BlibaryAppV3, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:libaryAppV3libaryAppV3  5          libaryAppV3.books   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:libaryAppV3     5      .��5	      � .+�5
   
   &   System.Windows.Controls.DataGrid  -   5           Name$  	BooksGrid��5
   D      
IsReadOnly . $
��Left=�6W   $	��185��6s   $	��Top=�6�   $	��642��6�   $��0,2,0,0q�6�   ��6   �� *Books+6�   �� 5   
   -   5        $��create��5      $
��Left=�6"   $��
35,296,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   �� 5   
   -   5        $��update��5      $
��Left=�6"   $��115,296,0,0q�6=   $	��Top=�6R   $��75��6j   6u   �� 5   
   -   5        $��delete��5      $
��Left=�6"   $��
685,10,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   �� 5   
   -   5         ��Name$ 	authorBox��5      $
��Left=�6%   $��23��6@   $��
11,208,0,0q�6L    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   $��author��6   $
��Left=�6!   $��
11,187,0,0q�6<   $	��Top=�6P   �� 5   
   -   5        $ titleBox��5      $
��Left=�6$   $��23��6?   $��136,208,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $	��120��6�   �� 5   
   $��title��6   $
��Left=�6    $��136,187,0,0q�6;   $	��Top=�6P    J� RenderTransformOrigin$ 0.792,3.217&�6h   �� 5   
   -   5        $ publisherBox��5      $
��Left=�6(   $��23��6C   $��
11,259,0,0q�6O   $
 Wrap=�6c   $	��Top=�6w   $	��120��6�   �� 5   
   $��	publisher��6   $
��Left=�6$   $��
11,237,0,0q�6?   $	��Top=�6S   �� 5   
   $
��year��6   $
��Left=�6   $��136,237,0,0q�6:   $	��Top=�6O   �� 5   
   -   5        $ countBox��5      $
��Left=�6$   $��23��6?   $��261,259,0,0q�6K   $
 Wrap=�6`   $	��Top=�6t   $��40��6�   �� 5   
   $��count��6   $
��Left=�6    $��261,237,0,0q�6;   $	��Top=�6P   �� 5   
   -	   5        $ ISBNBox��5      $
��Left=�6#   $��23��6>   $��306,259,0,0q�6J   $
 Wrap=�6_   $	��Top=�6s   $	��175��6�   �� 5   
   $
��ISBN��6   $
��Left=�6   $��306,237,0,0q�6:   $	��Top=�6O   (  "System.Windows.Controls.DatePicker  5   
   -
   5          Name$ datepickerYear��5      $
��Left=�6-   $��136,259,0,0q�6H   $	��Top=�6]   $	��120��6u   5      5      