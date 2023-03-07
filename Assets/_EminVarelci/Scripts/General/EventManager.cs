using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonGeneric;
using System;
using Buildings;
using GridSystem;

public class EventManager : Singleton<EventManager>
{
    public static event Action<float> OnScrollChange;
    public static event Action<Building,bool> OnClickObject;
    public static event Action<Building> OnObjectDead;


    public static void ScrollChange(float _rectAnchorPosY)
    {
        OnScrollChange?.Invoke(_rectAnchorPosY);
    }

    public static void ClickObject(Building _building, bool _leftClick )
    {
        OnClickObject?.Invoke(_building,_leftClick );
    }

    public static void ObjectDead(Building _building)
    {
        OnObjectDead?.Invoke(_building);
    }
}

