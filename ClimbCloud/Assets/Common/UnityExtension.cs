using System.Collections;
namespace UnityEngine
{
    public static class UnityExtension
    {
        public static Color ParseHexColorCode(this string colorCode)
        {
            Color color;
            if (ColorUtility.TryParseHtmlString(colorCode, out color))
            {
                return color;
            }
            else
            {
                Debug.LogError("РFВћПoЧЌВ™В≈ВЂВ№ВєВс");
                return Color.magenta;
            }
        }
    }
}