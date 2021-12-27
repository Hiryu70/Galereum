using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Galereum
{
	partial class Program
	{
		static void Main(string[] args)
		{
			var column1 = new Column();
			column1.Add(new Picture(Image.FromFile("Images\\1.jpg")));
			column1.Add(new Picture(Image.FromFile("Images\\2.jpg")));

			var column2 = new Column();
			column2.Add(new Picture(Image.FromFile("Images\\3.jpg")));
			column2.Add(new Picture(Image.FromFile("Images\\4.jpg")));
			column2.Add(new Picture(Image.FromFile("Images\\5.jpg")));

			var picture1 = new Picture(Image.FromFile("Images\\6.jpg"));
			var picture2 = new Picture(Image.FromFile("Images\\7.jpg"));
			var picture3 = new Picture(Image.FromFile("Images\\8.jpg"));

			var row = new Row();
			row.Add(picture1);
			row.Add(column1);
			row.Add(picture2);
			row.Add(column2);
			row.Add(picture3);
			row.GetBitmapWithWidth(1000).Save("result.jpg", ImageFormat.Jpeg);
		}
	}
}
