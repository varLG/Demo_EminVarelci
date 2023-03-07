using InfiniteScrollView;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Buildings
{

    public class CommandCenter : Building
    {  
        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);

            if (eventData.button == PointerEventData.InputButton.Left)
                ItemValueChanger.ItemValueChange(Content.Instance.ListRows, Content.Instance.BuildingSetObject);
        }
    }

}