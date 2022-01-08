using System.Drawing;
using System.Linq;

namespace Galereum
{
	public class Column : PictureCollectionBase
	{
		public override float GetRatio()
		{
			return 1 / _pictures.Sum(x => 1 / x.GetRatio());
		}

        protected override Bitmap GetCollectionBitmap(int width, int height, Padding padding)
        {
            ResizeImages(width);

            CorrectImagesToFitArea(height);

            return DrawPictures(width, height, padding);
        }

        protected override int GetStartCoord(Padding padding)
        {
            return padding.Top;
        }

        protected override void DrawImage(Graphics g, Bitmap resizedImage, int localCoord, Padding padding)
        {
            g.DrawImage(resizedImage, padding.Left, localCoord);
        }

        protected override int ChangeCoord(Bitmap resizedImage, int localCoord, Padding padding)
        {
            return localCoord += resizedImage.Height + padding.Bottom + padding.Top;
        }

        private void CorrectImagesToFitArea(int height)
        {
            var sumHeight = _pictures.Sum(x => x.GetResizedHeight());
            var differencePix = height - sumHeight;
            var i = 0;
            while (differencePix != 0)
            {
                var resizedHeight = _pictures[i].GetResizedHeight();
                _pictures[i].SetResizedHeight(++resizedHeight);
                differencePix--;

                if (++i == _pictures.Count)
                {
                    i = 0;
                }
            }
        }

        private void ResizeImages(int width)
        {
            foreach (var picture in _pictures)
            {
                picture.ResizeWithWidth(width);
            }
        }

        public override int GetResizedHeight()
        {
			return _pictures.Sum(x => x.GetResizedHeight());
        }

        public override int GetResizedWidth()
        {
			return _pictures.First().GetResizedWidth();
        }

        public override void ResizeWithHeight(int height)
        {
            var width = GetWidthByHeight(height);
            ResizeImages(width);
            CorrectImagesToFitArea(height);
        }

        public override void ResizeWithWidth(int width)
        {
            var height = GetHeightByWidth(width);
            ResizeImages(width);
            CorrectImagesToFitArea(height);
        }

        public override void SetResizedHeight(int height)
        {
            var width = GetWidthByHeight(height);
            ResizeImages(width);
            CorrectImagesToFitArea(height);
        }

        public override void SetResizedWidth(int width)
        {
            var height = GetHeightByWidth(width);
            ResizeImages(width);
            CorrectImagesToFitArea(height);
        }
    }
}
