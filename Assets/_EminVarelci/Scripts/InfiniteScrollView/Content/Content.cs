//Startta referans Row'un satýr yüksekliðini alýyor, ScrollView'ýn deðiþkenini çekip kaydýrmaya listener ekliyor.

using InfiniteScrollView;
using SingletonGeneric;
using System;
using System.Collections;
using System.Collections.Generic;  
using UnityEngine;
using UnityEngine.UI; 


namespace InfiniteScrollView
{
    public class Content : Singleton<Content>
    {
        RectTransform rectTransform;
        ScrollRect scrollRect;

        public float RowHeight { get; private set; }
        public List<Row> ListRows;
        public BuildingSetObject BuildingSetObject;

        int listRowsCount, firstIndex, firstIndexOld, firstPos, firstPosOld;
         
        void Start()
        {
            GetRects();
            GetRowList();
            SetBuildingsToItem();
        }

        void GetRects()
        {
            rectTransform = GetComponent<RectTransform>();
            scrollRect = InfiniteScrollView.Instance.GetComponent<ScrollRect>();
            scrollRect.onValueChanged.AddListener(OnScrollChange);
            RowHeight = InfiniteScrollView.Instance.rectTransformGoRow.rect.height;
        }

        void GetRowList()
        {
            GetComponentsInChildren<Row>(ListRows);
            listRowsCount = ListRows.Count;
            for (int i = 0; i < ListRows.Count; i++)
            {
                ListRows[i].GetStartRowValues(i, RowHeight);
            }

            EventManager.ScrollChange(rectTransform.anchoredPosition.y);

            ContentUpdate.ResetClass();

            ItemValueChanger.totalCapacity =  GetComponentsInChildren<ItemInsideRow>(transform).Length; 
        }


        void SetBuildingsToItem()
        { 
            ContentUpdate.UpdateContent(rectTransform, RowHeight, listRowsCount, ListRows);
        }

        void OnScrollChange(Vector2 vec)
        {
            ContentUpdate.UpdateRows();

        }

    }
}
