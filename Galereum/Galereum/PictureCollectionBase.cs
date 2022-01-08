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

		public override Bitmap GetBitmapWithHeight(int height, Padding padding)
		{
			var width = GetWidthByHeight(height);
			return GetCollectionBitmap(width, height, padding);
		}

		public override Bitmap GetBitmapWithWidth(int width, Padding padding)
		{
			var height = GetHeightByWidth(width);
			return GetCollectionBitmap(width, height, padding);
		}

		protected abstract Bitmap GetCollectionBitmap(int width, int height, Padding padding);


		public override Bitmap GetResizedBitmap(Padding padding)
		{
			return DrawPictures(GetResizedWidth(), GetResizedHeight(), padding);
		}

		protected Bitmap DrawPictures(int width, int height, Padding padding)
		{
			var bitmap = new Bitmap(width, height);
			using (var g = Graphics.FromImage(bitmap))
			{
				var localCoord = GetStartCoord(padding);
				foreach (var picture in _pictures)
				{
					var resizedImage = picture.GetResizedBitmap(padding);
					DrawImage(g, resizedImage, localCoord, padding);
					localCoord = ChangeCoord(resizedImage, localCoord, padding);
				}
			}

			return bitmap;
		}

		protected abstract int GetStartCoord(Padding padding);

		protected abstract int ChangeCoord(Bitmap resizedImage, int localCoord, Padding padding);

		protected abstract void DrawImage(Graphics g, Bitmap resizedImage, int localCoord, Padding padding);
    }
}
