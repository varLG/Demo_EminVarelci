//CanvasScaler'�n ekran� di�er ��z�n�rl�klerde s��d�rmas� i�in kulland��� referans ratio oran�n� �ekiyor
////ve kullan�lan ekran ��z�n�rl���ne oranlayarak Canvas�n oyun a��l���ndaki boyutunu hesapl�yor.

using UnityEngine;
using UnityEngine.UI;
using SingletonGeneric;


namespace InfiniteScrollView
{

    public class RectTransformSizer : Singleton<RectTransformSizer>
    {
        CanvasScaler canvasScaler;

        float ratioReference;
        float ratioScreen;

        public Vector2 ScreenSize { get; private set; }

        private void Awake()
        {
            canvasScaler = GetComponent<CanvasScaler>();
            ScreenRectTransformSize();
        }

        private void ScreenRectTransformSize()
        {
            float referenceWidth = canvasScaler.referenceResolution.x;
            float referenceHeight = canvasScaler.referenceResolution.y;

            ratioReference = referenceWidth / referenceHeight;
            ratioScreen = (Screen.width + 0f) / (Screen.height + 0f);


            if (ratioScreen > ratioReference)
            {
                ScreenSize = new Vector2(referenceHeight * ratioScreen, referenceHeight);
            }
            else if (ratioScreen < ratioReference)
            {
                ScreenSize = new Vector2(referenceWidth, referenceWidth / ratioScreen);
            }
            else
            {
                ScreenSize = new Vector2(referenceWidth, referenceHeight);
            }

        }
    }

}