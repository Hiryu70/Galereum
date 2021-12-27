using System.Drawing;

namespace Galereum
{
	public interface IPicture
	{
		/// <summary>
		/// Отношение ширины к высоте
		/// +---+---+---+---+
		/// | 1 | 2 | 3 | 4 |
		/// +---+---+---+---+
		/// | 2 |   |   |   |
		/// +---+---+---+---+
		/// Ratio = 2
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
