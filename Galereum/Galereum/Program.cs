using System.Drawing;

namespace Galereum
{
	partial class Program
	{
		static void Main(string[] args)
		{
			var row = new Row();
			row.Add(Image.FromFile("Images\\1.jpg"));
			row.Add(Image.FromFile("Images\\2.jpg"));
			row.Add(Image.FromFile("Images\\3.jpg"));
			row.Add(Image.FromFile("Images\\4.jpg"));
			row.Add(Image.FromFile("Images\\5.jpg"));
			row.DrawStoryboard(600);
		}
	}
}
