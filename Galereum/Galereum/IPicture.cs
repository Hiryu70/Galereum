using System.Drawing;

namespace Galereum
{
	public interface IPicture
	{
		/// <summary>
		/// Отношение ширины к высоте w(4)/h(2) = 2
		/// </summary>
		/// <returns></returns>
		float GetRatio();

		int GetResizedHeight();
		int GetResizedWidth();
		void SetResizedHeight(int height);
		void SetResizedWidth(int width);
		void ResizeWithHeight(int height);
		void ResizeWithWidth(int width);
		Bitmap GetResizedBitmap();

		/// <summary>
		/// Возвращает Bitmap заданной высоты
		/// </summary>
		/// <param name="height">Высота</param>
		Bitmap GetBitmapWithHeight(int height);

		/// <summary>
		/// Возвращает Bitmap заданной ширины
		/// </summary>
		/// <param name="width">Ширина</param>
		Bitmap GetBitmapWithWidth(int width);
	}
}
