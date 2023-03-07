using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GridSystem
{
    public static class AvailableCalculate
    {
        static bool availableState;
        public static bool CalculateGridAvailable(Vector2 _gridPointPos, GridPoint[,] _gridPointsArray, Vector2 _objectGridSize)
        {
            for (int x = ((int)_gridPointPos.x); x < ((int)_gridPointPos.x) + ((int)_objectGridSize.x); x++)
            {
                for (int y = ((int)_gridPointPos.y); y < ((int)_gridPointPos.y) + ((int)_objectGridSize.y); y++)
                {
                    if (x >= _gridPointsArray.GetLength(0) || y >= _gridPointsArray.GetLength(1))
                    {
                        //Debug.LogWarning("TAÞTI!");
                        return false;
                    }
                    if (!_gridPointsArray[x, y].Available)
                    {
                        //Debug.LogWarning("KURULAMAZ: " + x + "_" + y);
                        return false;
                    }
                }
            }


            //Debug.Log("KURULABÝLÝR");
            return true;
        }

        public static void SetAvailableClosed(Vector2 _gridPointPos, GridPoint[,] _gridPointsArray, Vector2 _objectGridSize)
        {
            for (int x = ((int)_gridPointPos.x); x < ((int)_gridPointPos.x) + ((int)_objectGridSize.x); x++)
            {
                for (int y = ((int)_gridPointPos.y); y < ((int)_gridPointPos.y) + ((int)_objectGridSize.y); y++)
                {
                    _gridPointsArray[x, y].Available = false;
                }
            }
        }
        public static void SetAvailableOpen(Vector2 _gridPointPos, GridPoint[,] _gridPointsArray, Vector2 _objectGridSize)
        {
            for (int x = ((int)_gridPointPos.x); x < ((int)_gridPointPos.x) + ((int)_objectGridSize.x); x++)
            {
                for (int y = ((int)_gridPointPos.y); y < ((int)_gridPointPos.y) + ((int)_objectGridSize.y); y++)
                { 
                    _gridPointsArray[x, y].Available = true;
                }
            }
        }
    }
}