//Satýrlarý her scroll kaydýðýnda pozisyonlarýný indexlerine göre güncelliyor, düz ve net pozisyonlara eþitliyor.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
namespace InfiniteScrollView
{
    public class Row : MonoBehaviour
    {
        RectTransform rectTransform;
        int netPosY;

        [SerializeField] int rowIndex; 
         
        public List<ItemInsideRow> listItemInsideRows  { get; private set; } 

        private void OnEnable()
        {
            EventManager.OnScrollChange += ScrollChange;
        }

        private void OnDisable()
        {
            EventManager.OnScrollChange -= ScrollChange;
        }

        void ScrollChange(float rectAnchorPosY)
        {
            netPosY = ((int)(rectAnchorPosY / Content.Instance.RowHeight));
            netPosY *= ((int)Content.Instance.RowHeight);

            rectTransform.localPosition = new Vector3(0, ((Content.Instance.RowHeight * -rowIndex) - netPosY), 0);
            transform.SetSiblingIndex(rowIndex);
        }


        public void GetStartRowValues(int _rowIndex, float _rowHeight)
        {
            rowIndex = _rowIndex;
            rectTransform = GetComponent<RectTransform>();

            listItemInsideRows = new List<ItemInsideRow>();
            GetComponentsInChildren<ItemInsideRow>(listItemInsideRows); 
        }
        public void SetRowIndex(int _rowIndex)
        {
            rowIndex = _rowIndex;
        } 

    }
}