   M S B A M L   `   `   `  ????H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   I EwpfTheResearch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:viewModelWpfTheResearchviewModelWpfTheResearch 5   	   (   "viewModelWpfTheResearch.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:viewModelWpfTheResearch     5   	     ? Title$  
MainWindow??5	   	   $	??450??6   $	??800??6)   .??5
      ?  ? ColumnDefinitions 5   
   ?? 5      6"   ?? 5      $
??auto ?6   6.   .+?5   
   !   HamburgerMenu.HamburgerMenu  -   5          Name$ MyMenu??5   &      MenuIconColor
 ?????   SelectionIndicatorColor
 ?????   MenuItemForeground
 ?????$??Right=?6?   
?????_?$??Right=?6?   $??RightToLeft=?6?   $??1??6?   $	??180??6
  $??90??6     Content. 5      %   HamburgerMenu.HamburgerMenuItem  -   5          Name$ Dummy??5   .      Text$ Dummy??6=   $y?	Collapsed=?6K     5      -   5        $??hmiHomePage??5   .   	   Icon$!	 icons/homeIcon-modified.png??6A   $ דף הבית??6e   $??10(?6?   $??Georgia Pro Cond Semibold)?6?   
   SelectionCommand
 6t   ??  ?? ElementName$ this_??6?     5      -   5        $??hmiShowUsers??5   .   $!	 icons/userIcon-modified.png??6B   $ משתמשים??6e   
 6t   ?? $ this_??6?     5      -   5        $??hmiFormula1Game??5   .   $ 	 icons/carIcon-modified.png??6E   $ פורמולה1??6g   
 6w   ?? $ this_??6?     5      -   5        $??	hmilogOut??5   .   $#	 icons/logoutIcon-modified.png??6?   $ 
ניתוק??6d   
 6q   ?? $ this_??6?     5      -   5        $??hmiabout??5   .   $"	 icons/aboutIcon-modified.png??6>   $ 
אודות??6b   
 6o   ?? $ this_??6?   5       ? 5   
   -   5          ?Name$ currentFrame??5      $??0??6&     ? Source$ homePage.xaml??66   5      5      