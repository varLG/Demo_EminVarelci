using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PathFinding { 
public static class ReturnPath  
{
    public static List<GridPoint> ListFinalizePath= new List<GridPoint>();
    public static List<GridPoint> GetFinalizePath(GridPoint _pointA, GridPoint _pointB)
    {
        //Son noktadan geriye do�ru i�indeki "before" de�i�kenleri listeye at�yoruz.

        ListFinalizePath.Clear();
         
        GridPoint currentNode = _pointB;

        while (currentNode != _pointA) //D�ng� ilk pointe ula�ana kadar s�rs�n.
        {
            ListFinalizePath.Add(currentNode);
            currentNode = currentNode.PointBefore;
        }

        ListFinalizePath.Reverse();

        foreach (var item in ListFinalizePath)
        {
            //Debug.Log(item.TxtGridPoint.text);
        }

        return ListFinalizePath ;
    }
}
}