using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  
[CreateAssetMenu(fileName = "Building Creatable Object")]
public class BuildingCreatableObject : BuildingObject
{ 
    public Sprite ItemCreatableSprite;
    public List<SoldierObject> ItemCreatableList;
}