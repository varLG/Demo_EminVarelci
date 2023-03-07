using Buildings;
using GridSystem;
using PathFinding;
using InfiniteScrollView;
using Information;
using System.Collections;
using System.Collections.Generic; 
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq.Expressions;

public class Soldier : Building, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    SoldierObject soldierObject;
    public override void Start()
    {
        base.Start();

        if (scrBuildingObject.GetType() == typeof(SoldierObject))
        {
            soldierObject = (SoldierObject)scrBuildingObject;
        }

        objectDamage = soldierObject.ItemDamage;
    }
    public override void OnPointerClick(PointerEventData eventData)
    {
        base.OnPointerClick(eventData);

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            PathManager.Instance.SetPoint(ReturnItemGridPointsArea(), this);
            EventManager.ClickObject(this, true);
        }
    }
    public override void OnPointerEnter(PointerEventData eventData)
    {
        InformationUI.Instance.SetInformationPanel(soldierObject.ItemName, soldierObject.ItemSprite, objectHP.ToString(), soldierObject.ItemDamage.ToString(), soldierObject.ItemDescription);
    }


    public void SetSelectedColor(SelectedType _selectedType)
    {
        switch (_selectedType)
        {
            case SelectedType.Selected:
                imgBuilding.color = Color.blue;
                break;

            case SelectedType.Free:
                imgBuilding.color = Color.white;
                break;

            default:
                break;
        }
    }
     


}

