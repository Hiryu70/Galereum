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
			var width = GetWidthByHeight(height);
			return GetRowBitmap(width, height);
		}

		public override Bitmap GetBitmapWithWidth(int width)
		{
			var height = GetHeightByWidth(width);
			return GetRowBitmap(width, height);
		}

		private Bitmap GetRowBitmap(int width, int height)
		{
			var bitmap = new Bitmap(width, height);
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
	}
}
