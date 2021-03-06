using System.Drawing;
using System.Linq;

namespace Galereum
{
	public class Row : PictureCollectionBase
	{
		public override float GetRatio()
		{
			return _pictures.Sum(x => x.GetRatio());
		}

        protected override Bitmap GetCollectionBitmap(int width, int height, Padding padding)
        {
            ResizeImages(height);

            CorrectImagesToFitArea(width);

            return DrawPictures(width, height, padding);
        }

        protected override int GetStartCoord(Padding padding)
        {
            return padding.Left;
        }

        protected override void DrawImage(Graphics g, Bitmap resizedImage, int localCoord, Padding padding)
        {
            g.DrawImage(resizedImage, localCoord, padding.Top);
        }

        protected override int ChangeCoord(Bitmap resizedImage, int localCoord, Padding padding)
        {
            return localCoord += resizedImage.Width + padding.Right + padding.Left;
        }

        private void CorrectImagesToFitArea(int width)
        {
            var sumWidth = _pictures.Sum(x => x.GetResizedWidth());
            var differencePix = width - sumWidth;
            var i = 0;
            while (differencePix != 0)
            {
                var resizedWidth = _pictures[i].GetResizedWidth();
                _pictures[i].SetResizedWidth(++resizedWidth);
                differencePix--;

                if (++i == _pictures.Count)
                {
                    i = 0;
                }
            }
        }

        private void ResizeImages(int height)
        {
            foreach (var picture in _pictures)
            {
                picture.ResizeWithHeight(height);
            }
        }

        public override int GetResizedHeight()
        {
            return _pictures.First().GetResizedHeight();
        }

        public override int GetResizedWidth()
        {
            return _pictures.Sum(x => x.GetResizedWidth());
        }

        public override void ResizeWithHeight(int height)
        {
            var width = GetWidthByHeight(height);
            ResizeImages(height);
            CorrectImagesToFitArea(width);
        }

        public override void ResizeWithWidth(int width)
        {
            var height = GetHeightByWidth(width);
            ResizeImages(height);
            CorrectImagesToFitArea(width);
        }

        public override void SetResizedHeight(int height)
        {
            var width = GetWidthByHeight(height);
            ResizeImages(height);
            CorrectImagesToFitArea(width);
        }

        public override void SetResizedWidth(int width)
        {
            var height = GetHeightByWidth(width);
            ResizeImages(height);
            CorrectImagesToFitArea(width);
        }
    }
}
