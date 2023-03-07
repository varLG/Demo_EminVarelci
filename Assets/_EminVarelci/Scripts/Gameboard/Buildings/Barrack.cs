using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InfiniteScrollView;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Information;
using Unity.VisualScripting;

namespace Buildings
{

    public class Barrack : Building
    {
        BuildingCreatableObject _buildingCreatableObject;
        public override void Start()
        {
            base.Start();

            if (scrBuildingObject.GetType() == typeof(BuildingCreatableObject))
            {
                _buildingCreatableObject = (BuildingCreatableObject)scrBuildingObject;
            }
             
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            base.OnPointerClick(eventData);
             
              if (eventData.button == PointerEventData.InputButton.Left)
            {
                ItemValueChanger.ItemValueChange(Content.Instance.ListRows, _buildingCreatableObject.ItemCreatableList);
            }
         
        }
          
    }

}