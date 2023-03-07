//CanvasScaler'ýn ekraný diðer çözünürlüklerde sýðdýrmasý için kullandýðý referans ratio oranýný çekiyor
////ve kullanýlan ekran çözünürlüðüne oranlayarak Canvasýn oyun açýlýþýndaki boyutunu hesaplýyor.

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