using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Galereum
{
	public class Column : PictureBase, IStackable
	{
		private List<IPicture> _pictures = new List<IPicture>();

		public override float GetRatio()
		{
			return 1 / _pictures.Sum(x => 1 / x.GetRatio());
		}

		public void Add(IPicture picture)
		{
			_pictures.Add(picture);
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			throw new System.NotImplementedException();
		}

		public override Bitmap GetBitmapWithWidth(int width)
		{
			var ovarallHeight = (int)(width / GetRatio());

			var bitmap = new Bitmap(width, ovarallHeight);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localHeight = 0;
				foreach (var picture in _pictures)
				{
					var resizedImage = picture.GetBitmapWithWidth(width);
					g.DrawImage(resizedImage, 0, localHeight);
					localHeight += resizedImage.Height;
				}
			}

			return bitmap;
		}
	}
}
