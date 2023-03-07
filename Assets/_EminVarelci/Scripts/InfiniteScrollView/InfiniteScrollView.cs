//Referans Row objesini ve hesaplanan ekran çözünürlüðünü baz alarak bu ekrana maximum kaç tane satýr sýðacaðýný hesaplar.
//Sýðacak satýr sayýsýný bulduktan sonra, satýrlarý üretir.


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SingletonGeneric;

namespace InfiniteScrollView
{
    public class InfiniteScrollView : Singleton<InfiniteScrollView>
    {
        RectTransform rectTransform; 

        [SerializeField] GameObject goRow; 

        public RectTransform rectTransformGoRow { get; private set; }

        [SerializeField] RectTransform rectTransformContent; 
        [SerializeField] int poolSize;

        float scrollViewScreenHeight;
        int scrollViewCapacity;
        float scrollViewHeight;

        void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            SetRectTransformSize();
            CreateContentRows(); 
        }

        void SetRectTransformSize()
        {
            rectTransformGoRow = goRow.GetComponent<RectTransform>();

            scrollViewScreenHeight = RectTransformSizer.Instance.ScreenSize.y + rectTransform.anchoredPosition.y;  
            scrollViewCapacity = ((int)(scrollViewScreenHeight / rectTransformGoRow.rect.height));  
            scrollViewHeight = rectTransformGoRow.rect.height * (scrollViewCapacity); 

            rectTransform.sizeDelta = new Vector2(rectTransform.sizeDelta.x, scrollViewHeight);
        }

        void CreateContentRows()
        {
            GameObject _createdObject;

            for (int i = 0; i < scrollViewCapacity + 1; i++)
            {
                _createdObject = Instantiate(goRow, rectTransformContent.transform);
                _createdObject.name = "Row_" + i;
                _createdObject.transform.localPosition -= new Vector3(0, i * rectTransformGoRow.rect.height, 0);
            }

            rectTransformContent.sizeDelta = new Vector2(rectTransform.sizeDelta.x, ((rectTransformGoRow.rect.height * poolSize) / 2)); 
        }

      

   
    }
}
