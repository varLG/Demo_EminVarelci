using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
namespace InfiniteScrollView
{

    public static class SetRowValues
    {
        public static void SetValues(BuildingObject _productableBuilding, ref BuildingObject buildingObject, ref BuildingCreatableObject buildingCreatableObject, ref SoldierObject soldierObject, ref Image ItemImage, ref TextMeshProUGUI ItemText, ref GameObject goCreatable)
        {
            buildingObject = _productableBuilding;

            ItemImage.sprite = buildingObject.ItemSprite;
            ItemText.text = buildingObject.ItemName;

            goCreatable = _productableBuilding.ItemGameboardObject;

            if (_productableBuilding.GetType() == typeof(BuildingCreatableObject))
            {
                buildingObject = null;
                buildingCreatableObject = (BuildingCreatableObject)_productableBuilding;
                soldierObject = null;
            }
            else if (_productableBuilding.GetType() == typeof(SoldierObject))
            {
                buildingObject = null;
                buildingCreatableObject = null;
                soldierObject = (SoldierObject)_productableBuilding;
            }
            else
            {
                buildingCreatableObject = null;
                soldierObject = null;
            }
        }
 
    }

}