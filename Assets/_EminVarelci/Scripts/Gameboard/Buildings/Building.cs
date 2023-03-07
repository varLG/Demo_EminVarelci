using GridSystem;
using Information;
using PathFinding;
using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Buildings
{
    public class Building : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField] protected BuildingObject scrBuildingObject;
        protected Image imgBuilding;
        protected RectTransform rectTransformBuilding;

        public Vector2 objectGridSize { get { return scrBuildingObject.ItemSizeGrid; } }
        protected int objectHP, objectStartHP, objectDamage;

        [SerializeField] protected List<Building> listEnemies = new List<Building>();

        bool fighting = false;
        protected void OnEnable()
        {
            EventManager.OnObjectDead += ObjectDead;
        }
        protected void OnDisable()
        {
            EventManager.OnObjectDead -= ObjectDead;
        }


        public virtual void Start()
        {
            rectTransformBuilding = GetComponent<RectTransform>();
            imgBuilding = GetComponent<Image>();
            imgBuilding.sprite = scrBuildingObject.ItemSprite;
            imgBuilding.raycastTarget = false;

            objectHP = scrBuildingObject.ItemHP;
            objectStartHP = scrBuildingObject.ItemHP;


            SetBuildingSize();
        }

        protected void ObjectDead(Building _object)
        {
            if (listEnemies.Contains(_object))
            {
                listEnemies.Remove(_object);
            }
        }
        public virtual void OnPointerEnter(PointerEventData eventData)
        {
            InformationUI.Instance.SetInformationPanel(scrBuildingObject.ItemName, scrBuildingObject.ItemSprite, objectHP.ToString(), objectDamage.ToString(), scrBuildingObject.ItemDescription);
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            InformationUI.Instance.ClosePanels();
        }
        public virtual void OnPointerClick(PointerEventData eventData)
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                EventManager.ClickObject(this, false);
            }
            else if (eventData.button == PointerEventData.InputButton.Left)
            {
                //Debug.Log("Left click image");
            }
        }
        void SetBuildingSize()
        {
            rectTransformBuilding.sizeDelta = scrBuildingObject.ItemSizeGrid * GridManager.Instance.GridPointSize;
        }

        public void SetupState(bool _state)
        {
            if (_state)
            {
                imgBuilding.color = Color.green;
            }
            else
            {
                imgBuilding.color = Color.red;
            }
        }

        public void SetupBuilding(Vector2 _setupPos)
        {
            imgBuilding.color = Color.white;
            imgBuilding.raycastTarget = true;
        }

        public virtual GridPoint ReturnItemGridPointsArea()
        {
            Vector2 _gridPointPos =  ReturnGridPosition();

            GridPoint _gridPoint = GridManager.Instance.GridPointsArray[((int)_gridPointPos.x), -((int)_gridPointPos.y)];
            return _gridPoint;
        }

        public void SetEnemy(Building _enemy)
        {
            if (!listEnemies.Contains(_enemy))
                listEnemies.Add(_enemy);
        }

        public void AttackNow()
        {
            if(!fighting)
            StartCoroutine(AttackLoop());
        }
        Vector2 ReturnGridPosition()
        {
            Vector2 _gridPointPos = rectTransformBuilding.anchoredPosition / GridManager.Instance.GridPointSize;  
            return _gridPointPos;
        }

        public void Defend(int damage)
        {
            objectHP -= damage;

            if (objectHP <= 0)
            {

                StopAllCoroutines();
                listEnemies.Clear();

                Vector2 _gridPointPosition = ReturnGridPosition();

                GridManager.Instance.SetGridAvailableOpen(this, new Vector2(_gridPointPosition.x, -_gridPointPosition.y));
                EventManager.ObjectDead(this);
                gameObject.SetActive(false);

            }
            else
            {
                imgBuilding.fillAmount = ((objectHP + 0f) / (objectStartHP + 0f));
                //Debug.Log("Damaged, New Health: " + objectHP);
            }
        }

        IEnumerator AttackLoop()
        {
            fighting = true;
            while (listEnemies.Count > 0)
            {
                listEnemies[0].Defend(objectDamage);
                yield return new WaitForSeconds(.5f);
            }
            fighting = false;
        }
    }

}