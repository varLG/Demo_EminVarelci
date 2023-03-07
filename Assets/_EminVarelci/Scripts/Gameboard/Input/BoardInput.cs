using Buildings;
using PathFinding;
using GridSystem;
using InfiniteScrollView;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class BoardInput : SingletonGeneric.Singleton<BoardInput>, IPointerMoveHandler, IPointerClickHandler
{
    bool canBeFollow = false;
    [SerializeField] GameObject goAttached;
    [SerializeField] GameObject goPointer;

    RectTransform rtGoAttached, rtGoPointer;
    Building buildingGoAttached;
    Vector2 goAttachedGridSize;

    Vector2 newPos;

    int anchoredPosX, anchoredPosY;
    int gridPointSize;
    private void Start()
    {
        gridPointSize = ((int)GridManager.Instance.GridPointSize.x);
        rtGoPointer = goPointer.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && canBeFollow && goAttached != null)
        {
            DeattachObject(true);
        }
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        if (canBeFollow && goAttached != null)
        {
            HelpGridPosition(eventData);
            GridManager.Instance.CalculateGridAvailable(new Vector2(anchoredPosX, -anchoredPosY), goAttachedGridSize, buildingGoAttached);
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        
        if (eventData.button == PointerEventData.InputButton.Left && canBeFollow && goAttached != null)
        {
            if (GridManager.Instance.CalculateGridAvailable(new Vector2(anchoredPosX, -anchoredPosY), goAttachedGridSize, buildingGoAttached))
            {
                GridManager.Instance.SetGridAvailableClose(buildingGoAttached, new Vector2(anchoredPosX, -anchoredPosY));
                DeattachObject(false);

                return;
            }
        }


        if (eventData.button == PointerEventData.InputButton.Right && PathManager.Instance.WaitPointTarget)
        { 
            PathManager.Instance.SetPoint(ReturnClickedGridPointXY(eventData)); 
            return;
        }

    }

    void HelpGridPosition(PointerEventData eventData)
    {
        ReturnClickedGridPointXY(eventData);
        goAttached.transform.position = goPointer.transform.position;
         
    }

    Vector2 ReturnClickedGridPointXY(PointerEventData eventData)
    {
        goPointer.transform.position = eventData.position;

        anchoredPosX = (((int)(rtGoPointer.anchoredPosition.x)) / gridPointSize);
        anchoredPosY = (((int)(rtGoPointer.anchoredPosition.y)) / gridPointSize);

        newPos.x = anchoredPosX;
        newPos.y = anchoredPosY;

        rtGoPointer.anchoredPosition = newPos * gridPointSize;
        return new Vector2 (anchoredPosX,-anchoredPosY);
    }




    public void AttachBoardObject(GameObject _attachObject)
    {
        if (goAttached != null)
            return;

        goAttached = Instantiate(_attachObject);
        canBeFollow = true;
        goAttached.transform.SetParent(transform);

        rtGoAttached = goAttached.GetComponent<RectTransform>();

        buildingGoAttached = goAttached.GetComponent<Building>();
        goAttachedGridSize = buildingGoAttached.objectGridSize;
    }

    void DeattachObject(bool _destroy)
    {
        if (_destroy)
            Destroy(goAttached.gameObject);

        goAttached = null;
        canBeFollow = false;

        rtGoAttached = null;
        buildingGoAttached = null;
        goAttachedGridSize = Vector2.zero;

        anchoredPosX = 0;
        anchoredPosY = 0;

        newPos = Vector2.zero;
    }
}
public enum SelectedType
{
    Selected,
    Free
}