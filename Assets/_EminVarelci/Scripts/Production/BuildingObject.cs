using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Building Object")]
public class BuildingObject : ScriptableObject
{
    public string ItemName;
    public Sprite ItemSprite;
    public string ItemDescription;
    public Vector2 ItemSizeGrid;

    public int ItemHP;

    public GameObject ItemGameboardObject; 
}
