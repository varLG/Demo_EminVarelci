using Information;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace InfiniteScrollView
{
    public class ItemInsideRow : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] Button itemButton;
        [SerializeField] Image ItemImage;
        [SerializeField] TextMeshProUGUI ItemText;

        [SerializeField] BuildingObject buildingObject;
        [SerializeField] BuildingCreatableObject buildingCreatableObject;
        [SerializeField] SoldierObject soldierObject;
        [SerializeField] GameObject goCreatable;
         

        private void Start()
        {
            itemButton.onClick.AddListener(OnButtonClick);
        }

        public void SetItemValues(BuildingObject _productableBuilding)
        { 
            SetRowValues.SetValues(_productableBuilding, ref buildingObject, ref buildingCreatableObject, ref soldierObject, ref ItemImage, ref ItemText, ref goCreatable);
        }
        public void SetItemValues(SoldierObject _soldierObject)
        { 
            SetRowValues.SetValues(_soldierObject as SoldierObject, ref buildingObject, ref buildingCreatableObject, ref soldierObject, ref ItemImage, ref ItemText, ref goCreatable);
        }
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (buildingObject != null)
            {
                InformationUI.Instance.SetInformationPanel(buildingObject.ItemName, buildingObject.ItemSprite, buildingObject.ItemDescription);

            }
            else if (buildingCreatableObject != null)
            {
                InformationUI.Instance.SetInformationPanel(buildingCreatableObject.ItemName, buildingCreatableObject.ItemSprite, buildingCreatableObject.ItemCreatableSprite, buildingCreatableObject.ItemDescription);

            }
            else if (soldierObject != null)
            {
                InformationUI.Instance.SetInformationPanel(soldierObject.ItemName, soldierObject.ItemSprite, soldierObject.ItemHP.ToString(), soldierObject.ItemDamage.ToString(), soldierObject.ItemDescription);

            }
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            InformationUI.Instance.ClosePanels();
        }

        void OnButtonClick()
        { 
            BoardInput.Instance.AttachBoardObject(goCreatable);
        }
    }
}
