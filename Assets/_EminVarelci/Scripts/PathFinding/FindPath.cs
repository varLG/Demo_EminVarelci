using GridSystem;
using System.Collections;
using System.Collections.Generic; 
using UnityEngine; 


namespace PathFinding { 
public static class FindPath
{ 
    public static List<GridPoint> CalculatePath(GridPoint _gridPointStart, GridPoint _gridPointTarget)
    {
        GridPoint startPoint = _gridPointStart;
        GridPoint targetPoint = _gridPointTarget;

        ReturnPath.ListFinalizePath.Clear();
        List<GridPoint> openSet = new List<GridPoint>();
        List<GridPoint> closedSet = new List<GridPoint>();
        openSet.Add(startPoint);

        while (openSet.Count > 0) //Döngü açýk listedeki adamlar bitene kadar sürsün.
        {
            GridPoint currentPoint = openSet[0];

            for (int i = 1; i < openSet.Count; i++) //Açýk listedeki en az maliyetli elemaný, eðer eþiti varsa H maliyeti en az olaný üzerinden devam.
            {
                if (openSet[i].CostF < currentPoint.CostF 
                    || (openSet[i].CostF == currentPoint.CostF 
                    && openSet[i].CostH < currentPoint.CostH))
                {
                    currentPoint = openSet[i];
                }
            }

            openSet.Remove(currentPoint);
            closedSet.Add(currentPoint);

            if (currentPoint == targetPoint) //Hedefe ulaþtýysa döngüyü tamamlýyor.
            { 
                return ReturnPath.GetFinalizePath(startPoint, targetPoint);  
            }

            foreach (GridPoint neighbour in CalculateValues.CalculateNeighbours(currentPoint)) //Pointin komþularýnýn, maliyetlerini hesaplayýp üzerlerine kaydediyor.
            {
                if (!neighbour.Available || closedSet.Contains(neighbour)) //Kullanýlamaz nokta ya da zaten kapalý listedeyse geç.
                {
                    continue;
                }

                int newCostNeighbour = currentPoint.CostG + CalculateValues.CalculateCostH(currentPoint, neighbour); // Eldeki hareket maliyeti ile komþuya h maliyeti toplamý.
                 

                //Döngü içerisnde komþular arasýndaki en ucuzu kaydedip devam et.
                if (newCostNeighbour < neighbour.CostG || !openSet.Contains(neighbour))
                {
                    neighbour.CostG = newCostNeighbour;
                    neighbour.CostH = CalculateValues.CalculateCostH(neighbour, targetPoint);
                    neighbour.PointBefore = currentPoint;

                    if (!openSet.Contains(neighbour))
                    {
                        openSet.Add(neighbour);
                    }
                }
            }
        }
         
        return null; 
    }
  
}
}