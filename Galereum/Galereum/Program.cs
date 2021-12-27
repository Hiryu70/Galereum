using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Galereum
{
	partial class Program
	{
		static void Main(string[] args)
		{
			var row = new Row();
			row.Add(new Picture(Image.FromFile("Images\\1.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\3.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\4.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\5.jpg")));

			row.GetBitmapWithWidth(600).Save("result.jpg", ImageFormat.Jpeg);

			var column = new Column();
			column.Add(new Picture(Image.FromFile("Images\\1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\3.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\4.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\5.jpg")));

			column.GetBitmapWithWidth(600).Save("result.jpg", ImageFormat.Jpeg);
		}
	}
}
