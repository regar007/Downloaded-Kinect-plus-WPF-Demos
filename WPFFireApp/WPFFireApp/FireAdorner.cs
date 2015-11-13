﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Threading;

namespace WPFFireApp
{
    /// <summary>
    /// Adorner that disables all controls that fall under it
    /// </summary>
    public class FireAdorner : Adorner
    {
		private BitmapPalette _pallette = null;
		private const int DPI = 96;
		private FireGenerator _fireGenerator = new FireGenerator(600, 50);

		/// <summary>
        /// Constructor for the adorner
        /// </summary>
        /// <param name="adornerElement">The element to be adorned</param>
		public FireAdorner(UIElement adornerElement)
            : base(adornerElement)
        {			
			CompositionTarget.Rendering += new EventHandler(CompositionTarget_Rendering);		
		}

		void CompositionTarget_Rendering(object sender, EventArgs e)
		{		
			InvalidateVisual();
		}

        /// <summary>
        /// Called to draw on screen
        /// </summary>
        /// <param name="drawingContext">The drawind context in which we can draw</param>
        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
			// only set the pallette once (dont do in constructor as causes odd errors if exception occurs)
			if (_pallette == null)
				_pallette = SetupFirePalette();
			
			_fireGenerator.UpdateFire();			
			
			BitmapSource bs = BitmapSource.Create(_fireGenerator.Width, _fireGenerator.Height, DPI, DPI, 
				PixelFormats.Indexed8, _pallette, _fireGenerator.FireData, _fireGenerator.Width);
			drawingContext.DrawImage(bs, new Rect(0, 0, this.DesiredSize.Width, this.DesiredSize.Height));		
        }

		private BitmapPalette SetupFirePalette()
		{
			List<Color> myList = new List<Color>();

			// seutp the basic array we will modify
			for (int i = 0; i <= 255; i++)
			{
				myList.Add(new Color());
			}

			for (int i = 0; i < 64; i++)
			{				
				Color c1 = new Color();
				c1.R = (byte)(i * 4);
				c1.G = (byte)(0);
				c1.B = (byte)(0);
				c1.A = 255;
				myList[i] = c1;
				
				Color c2 = new Color();
				c2.R = (byte)(255);
				c2.G = (byte)(i * 4);
				c2.B = (byte)(0);
				c2.A = 255;
				myList[i+64] = c2;
				
				Color c3 = new Color();
				c3.R = (byte)(255);
				c3.G = (byte)(255);
				c3.B = (byte)(i * 4);
				c3.A = 255;
				myList[i+128] = c3;
				
				Color c4 = new Color();
				c4.R = (byte)(255);
				c4.G = (byte)(255);
				c4.B = (byte)(255);
				c4.A = 255;
				myList[i + 192] = c4;
			}

			BitmapPalette bp = new BitmapPalette(myList);
			return bp;
		}
    }
}
