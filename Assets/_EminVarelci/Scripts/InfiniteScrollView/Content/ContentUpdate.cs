//Kaydýrýlmada hesaplanan index deðiþince bütün satýrlarýn indexlerini düzenliyor ve pozisyonlarýný güncellemek için EventManager'ý kullanarak haber gönderiyor.
using InfiniteScrollView;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace InfiniteScrollView
{
    public static class ContentUpdate
    {
        static int firstPos, firstIndex, firstIndexOld, firstPosOld, listRowsCount;
        static RectTransform rectTransform;
        static float rowHeight;
        static List<Row> listRows;

        public static int rowIndex = 0;
        public static bool rowTekSayi = false;

        public static void ResetClass()
        {
            firstPos = 0;
            firstIndex = 0;
            firstIndexOld = 0;
            firstPosOld = 0;
            listRowsCount = 0;
            rowHeight = 0;

            rectTransform = null;
            listRows = null;

            rowIndex = 0;
            rowTekSayi = false;


            ItemValueChanger.nextSetIndex = 0;
            ItemValueChanger.objectsCount = 0;
            ItemValueChanger.tekSayiDizdirildi = false;

        }
        public static void UpdateContent(RectTransform _rectTransform, float _rowHeight, int _listRowsCount, List<Row> _ListRows)
        {
            rectTransform = _rectTransform;
            rowHeight = _rowHeight;
            listRowsCount = _listRowsCount;
            listRows = _ListRows;

            //Debug.Log(rowIndex);
            ItemValueChanger.ItemValueChange(listRows,Content.Instance.BuildingSetObject);
            UpdateRows(); 
        }

        public static void UpdateRows()
        {
            firstPos = (int)(rectTransform.anchoredPosition.y);
            firstIndex = (((int)(rectTransform.anchoredPosition.y) / (int)rowHeight)) % listRowsCount;


            if (firstIndex != firstIndexOld)
            {
                if (firstPos > firstPosOld)
                {
                    SetRowIndexs(true);
                    rowIndex++;
                }

                else
                {
                    SetRowIndexs(false);
                    rowIndex--;
                }
                EventManager.ScrollChange(rectTransform.anchoredPosition.y);

                //Debug.Log(rowIndex);


                ItemValueChanger.SetValueChanger(  ); 
            }


           
            firstPosOld = firstPos;
            firstIndexOld = firstIndex; 
        }
        static void SetRowIndexs(bool MoveOrBack)
        {

            if (MoveOrBack)
            {
                listRows.Add(listRows[0]);
                listRows.RemoveAt(0);
            }
            else
            {
                listRows.Insert(0, listRows[listRowsCount - 1]);
                listRows.RemoveAt(listRowsCount);
            }
            for (int i = 0; i < listRowsCount; i++)
            {
                listRows[i].SetRowIndex(i);
            }
        }
    }

}
