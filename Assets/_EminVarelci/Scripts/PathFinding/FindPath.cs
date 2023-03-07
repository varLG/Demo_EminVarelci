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

        while (openSet.Count > 0) //D�ng� a��k listedeki adamlar bitene kadar s�rs�n.
        {
            GridPoint currentPoint = openSet[0];

            for (int i = 1; i < openSet.Count; i++) //A��k listedeki en az maliyetli eleman�, e�er e�iti varsa H maliyeti en az olan� �zerinden devam.
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

            if (currentPoint == targetPoint) //Hedefe ula�t�ysa d�ng�y� tamaml�yor.
            { 
                return ReturnPath.GetFinalizePath(startPoint, targetPoint);  
            }

            foreach (GridPoint neighbour in CalculateValues.CalculateNeighbours(currentPoint)) //Pointin kom�ular�n�n, maliyetlerini hesaplay�p �zerlerine kaydediyor.
            {
                if (!neighbour.Available || closedSet.Contains(neighbour)) //Kullan�lamaz nokta ya da zaten kapal� listedeyse ge�.
                {
                    continue;
                }

                int newCostNeighbour = currentPoint.CostG + CalculateValues.CalculateCostH(currentPoint, neighbour); // Eldeki hareket maliyeti ile kom�uya h maliyeti toplam�.
                 

                //D�ng� i�erisnde kom�ular aras�ndaki en ucuzu kaydedip devam et.
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