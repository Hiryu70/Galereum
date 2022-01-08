using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Galereum
{
	partial class Program
	{
		static void Main(string[] args)
		{
			Test1();
			Test2();
			Test3();
		}

		private static void Test3()
        {
			var column = new Column();
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));
			column.Add(new Picture(Image.FromFile("Images\\2-1.jpg")));

			for (int i = 1000; i <= 1020; i++)
			{
				column.GetBitmapWithHeight(i, new Padding(0, 0, 0, 3)).Save($"col_{i}.jpg", ImageFormat.Jpeg);
			}
		}

		private static void Test2()
        {
			var row = new Row();
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));
			row.Add(new Picture(Image.FromFile("Images\\1-2.jpg")));

			for (int i = 1000; i <= 1020; i++)
			{
				row.GetBitmapWithWidth(i, new Padding(0, 0, 0, 3)).Save($"row_{i}.jpg", ImageFormat.Jpeg);
			}
		}

		private static void Test1()
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

			var row2 = new Row();
			row2.Add(picture2);
			row2.Add(column2);
			row2.Add(picture3);

			var column3 = new Column();
			column3.Add(row);
			column3.Add(row2);

			column3.GetBitmapWithWidth(1500, new Padding(0, 0, 0, 3)).Save("result.jpg", ImageFormat.Jpeg);
		}
	}
}
