   M S B A M L   `   `   `  ????C  ?Lopushok, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:Lopushok.WindowsLopushok.Windows  5   	   &     Lopushok.Windows.EditPriceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:Lopushok.Windows     5   	     ? Title$!  Изменение цены??5   	   $	??200??5	   	   $	??400??6    ? 
ResizeMode$ NoResize=?5
   	   .??5      ?  ? ColumnDefinitions 5   
   ?? 5      ?? 5       ? RowDefinitions 5   
   ?? 5      ?? 5      .+?5   
   ?? $0??*Увеличить стоимость на??6   $
??Wrap=?62   $??20(?6F   ?? 5   
   -   5         ??Name$ tbPrice??5      $??1??6:   $??5q?6J   ??6#   ?? *Price+6U   ?? 5   
   -   5         ??Name$ btnSave??5      $??Изменить??6"   $??2??65   $??Center=?6I   $??2??6f   $??10q?6s   6   5      5      