using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Information
{
    public class InformationUI : SingletonGeneric.Singleton<InformationUI>
    {
        [SerializeField] GameObject goPanelItemInformation;
        [SerializeField] GameObject goPanelProductable;
        [SerializeField] GameObject goPanelUnitInformation;

        [SerializeField] Image imgProduction;

        [SerializeField] TextMeshProUGUI txtItemName;
        [SerializeField] TextMeshProUGUI txtItemDescription;
        [SerializeField] Image imgItem;

        [SerializeField] TextMeshProUGUI txtUnitHP;
        [SerializeField] TextMeshProUGUI txtUnitDamage;

        private void Start()
        {
            ClosePanels();
        }

        public void ClosePanels()
        {
            goPanelItemInformation.SetActive(false);
            goPanelProductable.SetActive(false);
            goPanelUnitInformation.SetActive(false);
        }

        //Productable olmayanlar için
        public void SetInformationPanel(string _itemName, Sprite _itemSprite, string _itemDescription)
        {
            goPanelItemInformation.SetActive(true);
            goPanelProductable.SetActive(false);
            goPanelUnitInformation.SetActive(false);

            txtItemName.text = _itemName;
            imgItem.sprite = _itemSprite;
            txtItemDescription.text = _itemDescription;
        }

        //Productable olanlar için
        public void SetInformationPanel(string _itemName, Sprite _itemSprite, Sprite _productionSprite, string _itemDescription)
        {
            goPanelProductable.SetActive(true);
            goPanelItemInformation.SetActive(true);
            goPanelUnitInformation.SetActive(false);

            imgProduction.sprite = _productionSprite;
            txtItemName.text = _itemName;
            imgItem.sprite = _itemSprite;
            txtItemDescription.text = _itemDescription;
        }

        //Unit olanlar için
        public void SetInformationPanel(string _itemName, Sprite _itemSprite, string _unitHP, string _unitDamage, string _itemDescription)
        {
            goPanelItemInformation.SetActive(true);
            goPanelUnitInformation.SetActive(true);
            goPanelProductable.SetActive(false);

            txtItemName.text = _itemName;
            imgItem.sprite = _itemSprite;
            txtItemDescription.text = _itemDescription;
            txtUnitHP.text = "HP: " + _unitHP;
            txtUnitDamage.text = "Damage: " + _unitDamage;
        }
    }

}