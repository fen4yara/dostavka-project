   M S B A M L   `   `   `  ����C  ?dostavka, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:dostavka.pagesdostavka.pages  5          dostavka.pages.Catalog   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .localclr-namespace:dostavka.pages     5        N� Title$  Catalog��5	      .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ��  �� Orientation$ 
Horizontal=�6   $��0��6.   $��0,0,0,10q�6;   .+�5      �� -   5         ��Name$ CategoryFilter��5      $	��150��6/   .@�5      �� $��Все категории��6    �� 
IsSelected . 67   �� 5      $'��!Молочные продукты��6   �� 5      $��
Овощи��6   �� 5      $��Фрукты��6   5      �� 5      -   5        $ 
SortFilter��5      $	��150��6+   $��10,0,0,0q�67   .@�5      �� $!��Без сортировки��6    . 68   �� 5      $,��&По цене (возрастание)��6   �� 5      $&�� По цене (убывание)��6   5      5      �� 5    
   -   5         ��Name$ ProductList��5       $��1��6(    �� View 5!      �� 5"      .P�5#      ��  �� Width$	 200��6%   $��Название��61    �� DisplayMemberBinding 6C   �� *Name+�� 5$      $	 200��6%   $��Категория��61    6D   �� *
Category+�� 5%      $	 200��6%   $��Цена��61    6?   �� *Price+�� 5&      $	 200��6%   $��Наличие��61    6B   �� *Quantity_Sklad+5'      5)      �� 5,   
   -   5        $(��"Добавить в корзину��5,      $��Right=�6.   $��Bottom=�6J   $��10q�6e   6q   �� 5-   
   -   5        $��
Назад��5-      $��	537,0,0,0q�6!   64   5.      5/      