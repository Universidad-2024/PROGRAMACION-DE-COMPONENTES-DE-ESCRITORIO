   M S B A M L   `   `   `  ����M  IFootballManagement, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:FootballManagementFootballManagement  5   	   #    FootballManagement.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:FootballManagement     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5	      � $��10q�6   .+�5   
   �� $��Lista de Equipos��6   $��20(�6,   $
��Bold"�6:   $��Center=�6L   �� 5   
   $	��Top=�6   $
��Left=�6-   $��10q�6H   .+�5      �� $��Equipos Masculinos:��6   �� 5      -   5         ��Name$ TotalMasculinosTextBlock��5      $��0��6:   $��55��6C   5      �� 5   
   $��Right=�6   $��10q�61   $	��Top=�6=    �� Orientation$ Vertical=�6U   .+�5      �� $��Equipos Femeninos:��6   �� 5      -   5        $ TotalFemeninosTextBlock��5      $��0��69   $��55��6B   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EquiposDataGrid��5         AutoGenerateColumns .  $��	0,91,0,80q�6H      
IsReadOnly .    SelectionMode$ Single=�6m      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$	 50 6N   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 61   �� *
EquipoId+6N     5      $ Nombre��6%   $		 150 6V   
 65   �� *NombreEquipo+6V     5      $ DT��6%   $		 150 6N   
 61   �� *
NombreDT+6N     5      $
 Tipo��6%   $		 100 6R   
 63   �� *
TipoEquipo+6R   5       �� 5$   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   $��0,0,0,20q�6f   .+�5%      �� -   5        $��Agregar��5%      $��75��6'   62   �� 5&      -   5        $��	Modificar��5&      $��75��6)   64   �� 5'      -   5        $��Eliminar��5'      $��75��6(   63   �� 5(      -   5        $��Ver Detalles��5(      6,   5)      5*      5+      