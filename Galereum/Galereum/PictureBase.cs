using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace Galereum
{
	public abstract class PictureBase : IPicture
	{
		public abstract Bitmap GetBitmapWithHeight(int height, Padding padding);

		public abstract Bitmap GetBitmapWithWidth(int width, Padding padding);

		public abstract float GetRatio();

		protected int GetWidthByHeight(int height)
		{
			return (int)(height * GetRatio());
		}

		protected int GetHeightByWidth(int width)
		{
			return (int)(width / GetRatio());
		}

		protected static Bitmap ResizeImage(Image image, int width, int height, Padding padding)
		{
			var destRect = new Rectangle(0, 0, width - padding.Right - padding.Left, height - padding.Top - padding.Bottom);
			var destImage = new Bitmap(width - padding.Right - padding.Left, height - padding.Top - padding.Bottom);

			destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

			using (var graphics = Graphics.FromImage(destImage))
			{
				graphics.CompositingMode = CompositingMode.SourceCopy;
				graphics.CompositingQuality = CompositingQuality.HighQuality;
				graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
				graphics.SmoothingMode = SmoothingMode.HighQuality;
				graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

				using (var wrapMode = new ImageAttributes())
				{
					wrapMode.SetWrapMode(WrapMode.TileFlipXY);
					graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
				}
			}

			return destImage;
		}

		public abstract int GetResizedHeight();

		public abstract int GetResizedWidth();

		public abstract void ResizeWithHeight(int height);

		public abstract void ResizeWithWidth(int width);

		public abstract void SetResizedHeight(int height);

		public abstract void SetResizedWidth(int width);

		public abstract Bitmap GetResizedBitmap(Padding padding);
    }
}
