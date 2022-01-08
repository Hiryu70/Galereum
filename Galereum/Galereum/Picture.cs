using System.Drawing;

namespace Galereum
{
	public class Picture : PictureBase
	{
		private Image _image;
		private int _resizedHeight;
		private int _resizedWidth;

		public Picture(Image image)
		{
			_image = image;
			_resizedHeight = image.Height;
			_resizedWidth = image.Width;
		}

		public override Bitmap GetBitmapWithHeight(int height)
		{
			var scale = (float)height / _image.Height;
			var resizedHeight = height;
			var resizedWidth = _image.Width * scale;

			return ResizeImage(_image, (int)resizedWidth, resizedHeight);
		}

		public override Bitmap GetBitmapWithWidth(int width)
		{
			var scale = (float)width / _image.Width;
			var resizedHeight = _image.Height * scale;
			var resizedWidth = width;

			return ResizeImage(_image, resizedWidth, (int)resizedHeight);
		}

		public override float GetRatio()
		{
			return (float)_image.Width / _image.Height;
		}

        public override Bitmap GetResizedBitmap()
        {
			return ResizeImage(_image, _resizedWidth, _resizedHeight);
        }

        public override int GetResizedHeight()
        {
			return _resizedHeight;
        }

        public override int GetResizedWidth()
        {
			return _resizedWidth;
        }

        public override void ResizeWithHeight(int height)
        {
			var scale = (float)height / _image.Height;
			_resizedHeight = height;
			_resizedWidth = (int)(_image.Width * scale);
        }

        public override void ResizeWithWidth(int width)
        {
			var scale = (float)width / _image.Width;
			_resizedHeight = (int)(_image.Height * scale);
			_resizedWidth = width;
		}

        public override void SetResizedHeight(int height)
        {
			_resizedHeight = height;
		}

        public override void SetResizedWidth(int width)
        {
			_resizedWidth = width;
		}
    }
}
