using System.Collections.Generic;
using System.Drawing;

namespace Galereum
{
	public abstract class PictureCollectionBase : PictureBase
	{
		protected List<IPicture> _pictures = new List<IPicture>();

		public void Add(IPicture picture)
		{
			_pictures.Add(picture);
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			var width = GetWidthByHeight(height);
			return GetCollectionBitmap(width, height);
		}

		public override Bitmap GetBitmapWithWidth(int width)
		{
			var height = GetHeightByWidth(width);
			return GetCollectionBitmap(width, height);
		}

		protected abstract Bitmap GetCollectionBitmap(int width, int height);


		public override Bitmap GetResizedBitmap()
		{
			return DrawPictures(GetResizedWidth(), GetResizedHeight());
		}

		protected Bitmap DrawPictures(int width, int height)
		{
			var bitmap = new Bitmap(width, height);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localCoord = 0;
				foreach (var picture in _pictures)
				{
					var resizedImage = picture.GetResizedBitmap();
					DrawImage(g, resizedImage, localCoord);
					localCoord = ChangeCoord(resizedImage, localCoord);
				}
			}

			return bitmap;
		}

		protected abstract int ChangeCoord(Bitmap resizedImage, int localCoord);

		protected abstract void DrawImage(Graphics g, Bitmap resizedImage, int localCoord);
    }
}
