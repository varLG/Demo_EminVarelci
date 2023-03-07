using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PathFinding { 
public static class CalculateValues
{
    public static List<GridPoint> CalculateNeighbours(GridPoint _gridPoint)
    {
        List<GridPoint> listNeighbours = new List<GridPoint>();

        //Dört yönü kontrol et!
         

        int x = _gridPoint.GridX;
        int y = _gridPoint.GridY;

        if (x > 0) // Sol
        {
            listNeighbours.Add(GridManager.Instance.GridPointsArray[x - 1, y]);
        }

        if (x < GridManager.Instance.GridPointsArray.GetLength(0) - 1) // Sað
        {
            listNeighbours.Add(GridManager.Instance.GridPointsArray[x + 1, y]);
        }

        if (y > 0) // Aþaðý
        {
            listNeighbours.Add(GridManager.Instance.GridPointsArray[x, y - 1]);
        }

        if (y < GridManager.Instance.GridPointsArray.GetLength(1) - 1) // Yukarý
        {
            listNeighbours.Add(GridManager.Instance.GridPointsArray[x, y + 1]);
        }

        return listNeighbours;
    }



    public static int CalculateCostH(GridPoint _pointA, GridPoint _pointB)
    {
        //Noktalar arasý h maliyeti
               

        int distanceX = Mathf.Abs(_pointA.GridX - _pointB.GridX);
        int distanceY = Mathf.Abs(_pointA.GridY - _pointB.GridY);

        int distanceMin = Mathf.Min(distanceX, distanceY);
        int distanceMax = Mathf.Max(distanceX, distanceY) ;

        int hValue = (14 * distanceMin) + (distanceMax - distanceMin); 
        
        return hValue;
    }
}
}