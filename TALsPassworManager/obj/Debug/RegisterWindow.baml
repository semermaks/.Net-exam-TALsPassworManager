   M S B A M L   `   `   `  ����M  ITALsPassworManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:TALsPassworManagerTALsPassworManager  5   	   '    !TALsPassworManager.RegisterWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:TALsPassworManager     5   	   $	��550��5   
   $	��474��6   $	��550��6)   $	��474��69     � Icon$  /TALs ico.png��6H   $	��550��6]    � 
ResizeMode$ NoResize=�6j    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � .+�5
   
   �� $��/background.jpg��6   $��UniformToFill=�6)   �� 5   
   
���   � J� Opacity$	 0.4Q�6!   �� 5   
   $��Register window��6   $��Center=�6*   $��0,18,0,0q�6H   $	��Top=�6Z   
�������$��35(�6�   $%��Segoe UI Variable Text Semibold)�6�   � 5   
   $��0,0,0,56q�6   .+�5      �� $��Your name: ��6   $��Center=�6*   $
��Left=�6E   $��20,102,10,266q�6`   
�������$��25(�6�   $%��Segoe UI Variable Text Semibold)�6�   �� 5      -   5         ��Name$ TbName��5      $��Center=�6&   $
��Left=�6A   $��160,102,10,276q�6\   $	��200��6t   $	 0.7Q�6�   $
��Name��6�   $��26(�6�    �� TextAlignment$ Center=�6�   6�   �� 5      $��Your surname: ��6   $��Center=�6-   $
��Left=�6H   $��20,102,10,176q�6c   
�������$��25(�6�   $%��Segoe UI Variable Text Semibold)�6�   �� 5      -   5        $ 	TbSurname��5      $��Center=�6)   $
��Left=�6D   $��200,102,10,176q�6_   $	��200��6w   $	 0.7Q�6�   $��Surname��6�   $��26(�6�   $ Center=�6�   6�   �� 5      $��Your father name: ��6   $��Center=�61   $
��Left=�6L   $��20,102,10,86q�6g   
�������$��25(�6�   $%��Segoe UI Variable Text Semibold)�6�   �� 5      -   5        $ TbFatherName��5      $��Center=�6,   $
��Left=�6G   $��240,102,10,86q�6b   $	��200��6y   $	 0.7Q�6�   $��Father name��6�   $��26(�6�   $ Center=�6�   6�   �� 5      $��Date of Birthday: ��6   $��Center=�61   $
��Left=�6L   $��20,102,10,0q�6g   
�������$��25(�6�   $%��Segoe UI Variable Text Semibold)�6�   (  "System.Windows.Controls.DatePicker  5      -   5        $��DateOFBirth��5      $
��Left=�6,   $��240,268,0,0q�6G   $	��Top=�6\   $	��200��6t   $��18(�6�   
�������$	 0.7Q�6�   6�   �� 5      $��Your Logn: ��6   $��Center=�6*   $
��Left=�6E   $��20,102,10,-90q�6`   
�������$��25(�6�   $%��Segoe UI Variable Text Semibold)�6�   �� 5      -   5        $ TbLogin��5      $��Center=�6'   $
��Left=�6B   $��160,102,10,-90q�6]   $	��200��6u   $	 0.7Q�6�   $��Login��6�   $��26(�6�   $ Center=�6�   6�   �� 5      $��Your Password: ��6   $��Center=�6.   $
��Left=�6I   $��20,102,10,-180q�6d   
�������$��25(�6�   $%��Segoe UI Variable Text Semibold)�6�   G� 5      -   5         G�Name$ Password��5      $��Center=�6,   $
��Left=�6G   $��210,102,10,-180q�6b   $	��200��6{   $	 0.7Q�6�   $��26(�6�   5      �� 5    
   -   5        $
��Back��5       $��26(�6    $��Center=�6.   $��	0,405,0,0q�6K   $	��Top=�6^   $��42��6v   $	��137��6�   $%��Segoe UI Variable Text Semibold)�6�   
�������
�������$��4q�6�   ��6�   Z� 6  �� 5!   
   -   5         ��Name$	 btn��5!      $��Register new account��6   $��26(�6=   $
��Left=�6K   $��
63,455,0,0q�6f   $	��Top=�6z   $��46��6�   $	��337��6�   $%��Segoe UI Variable Text Semibold)�6�   
�������
�������$��4q�6  ��6�   Z� 6)  5"      5#      