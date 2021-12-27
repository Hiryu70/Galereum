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
