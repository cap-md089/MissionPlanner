﻿using GMap.NET;
using GMap.NET.WindowsForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace MissionPlanner.Maps
{
    public class GMapMarkerElevation : GMapMarker
    {
        Bitmap elevation;

        private RectLatLng rect;

        public GMapMarkerElevation(byte [,] imageData, RectLatLng rect, PointLatLng currentloc)
        : base(currentloc)
        {
            this.rect = rect;

            IsHitTestVisible = false;

            //create a new Bitmap
            Bitmap bmp = new Bitmap(imageData.GetLength(0), imageData.GetLength(1), System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            System.Drawing.Imaging.ColorPalette pal = bmp.Palette;
            
            //create grayscale palette
            for (int i = 0; i < 256; i++)
            {
                pal.Entries[i] = Color.FromArgb((int)100, bmp.Palette.Entries[i].R, bmp.Palette.Entries[i].G, bmp.Palette.Entries[i].B);
            }

            //assign to bmp
            bmp.Palette = pal;
            
            //lock it to get the BitmapData Object
            System.Drawing.Imaging.BitmapData bmData =
                bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), System.Drawing.Imaging.ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format8bppIndexed);

            //now we have to convert the 2 dimensional array into a one dimensional byte-array for use with 8bpp bitmaps
            // use stride and height to prevent stride mod 4 issues
            byte[] pixels = new byte[bmData.Stride * bmData.Height];
            for (int y = 0; y < imageData.GetLength(1); y++)
            {
                for (int x = 0; x < imageData.GetLength(0); x++)
                {
                    pixels[y * bmData.Stride + x] = imageData[x, y];
                }
            }

            //copy the bytes
            System.Runtime.InteropServices.Marshal.Copy(pixels, 0, bmData.Scan0, bmData.Stride * bmData.Height);            

            //never forget to unlock the bitmap
            bmp.UnlockBits(bmData);

            //display
            elevation = bmp;

            elevation.MakeTransparent();
        }

        public override void OnRender(Graphics g)
        {
            base.OnRender(g);

            var tlll = Overlay.Control.FromLatLngToLocal(rect.LocationTopLeft);
            var brll = Overlay.Control.FromLatLngToLocal(rect.LocationRightBottom);

            var old = g.Transform;

            g.ResetTransform();

            g.DrawImage(elevation, tlll.X, tlll.Y, brll.X - tlll.X, brll.Y - tlll.Y);

            g.Transform = old;
        }
    }
}
