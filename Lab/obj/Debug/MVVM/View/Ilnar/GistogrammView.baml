   M S B A M L   `   `   `  ����>  :Lab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:Lab.MVVM.ViewModel.IlnarLab.MVVM.ViewModel.Ilnar  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      (    "Lab.MVVM.View.Ilnar.GistogrammView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <	viewModel&clr-namespace:Lab.MVVM.ViewModel.Ilnar     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5         
Page_Style#��[  5      
������   � DataContext  5      2   ,Lab.MVVM.ViewModel.Ilnar.GistogrammViewModel  5   
   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $	��400 �6   �� 5      $	��100 �6   �� 5      $	��400 �6   .+�5   
   �� $��0��6>   $��0��5      
������ 
������ $��0q�5   ,   ��5      �� *PseudoRandomNumbers+5   ,   �� 5   
   $��Generate Numbers��6   $	��150��5      $��35��6     ButtonStyle#��[ 6)   $��0��5       $��1��6!   $��Center=�6.    � Cursor$
 Hand��6I   ��5   ,   �� *GenerateNumbersCommand+5    I   5"      5#      