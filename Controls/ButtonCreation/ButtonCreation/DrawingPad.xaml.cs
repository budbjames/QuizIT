﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ButtonCreation
{
	/// <summary>
	/// Interaction logic for DrawingPad.xaml
	/// </summary>
	public partial class DrawingPad : Window
	{
		public DrawingPad()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void InsideShape(object sender, System.Windows.Input.MouseEventArgs e)
		{
			((UIElement)sender).Opacity = .5;
		}
	}
}