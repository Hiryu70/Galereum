using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Galereum
{
	public class Row : PictureBase, IStackable
	{
		private List<IPicture> _pictures = new List<IPicture>();

		public override float GetRatio()
		{
			return _pictures.Sum(x => x.GetRatio());
		}

		public void Add(IPicture picture)
		{
			_pictures.Add(picture);
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			var overallWidth = (int)(height * GetRatio());

			var bitmap = new Bitmap(overallWidth, height);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localWidth = 0;
				foreach (var picture in _pictures)
				{
					var resizedImage = picture.GetBitmapWithHeight(height);
					g.DrawImage(resizedImage, localWidth, 0);
					localWidth += resizedImage.Width;
				}
			}

			return bitmap;
		}

		public override Bitmap GetBitmapWithWidth(int width)
		{
			var overallHeight = (int)(width / GetRatio());

			var bitmap = new Bitmap(width, overallHeight);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localWidth = 0;
				foreach (var picture in _pictures)
				{
					var resizedImage = picture.GetBitmapWithHeight(overallHeight);
					g.DrawImage(resizedImage, localWidth, 0);
					localWidth += resizedImage.Width;
				}
			}

			return bitmap;
		}
	}
}
