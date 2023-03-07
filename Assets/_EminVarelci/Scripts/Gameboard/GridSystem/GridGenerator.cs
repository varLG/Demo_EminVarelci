using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace GridSystem
{

    public class GridGenerator : SingletonGeneric.Singleton<GridGenerator>
    {
        GameObject goCreatedObject;
        GridPoint gridPoint;
        float gridPointRectSize;

        public GridPoint[,] CreateGridPoints(GridPoint[,] arrayGridPoints, int gridSizeX, int gridSizeY, GameObject goGridPoint, Transform parent)
        {
            arrayGridPoints = new GridPoint[gridSizeX, gridSizeY];

            for (int x = 0; x < gridSizeX; x++)
            {
                for (int y = 0; y < gridSizeY; y++)
                {
                    //Create GridPoint
                    goCreatedObject = Instantiate(goGridPoint, parent);
                    gridPoint = goCreatedObject.GetComponent<GridPoint>();
                    arrayGridPoints[x, y] = gridPoint;

                    //GridPoint Position
                    gridPoint.GridX = x;
                    gridPoint.GridY = y;
                    gridPointRectSize = gridPoint.RectTransform.sizeDelta.x;
                    gridPoint.RectTransform.anchoredPosition = new Vector2(x * gridPointRectSize, -y * gridPointRectSize);


                    //GridPoint Name
                    goCreatedObject.name = "x" + x + "," + "y" + y;
                    gridPoint.TxtGridPoint.text = goCreatedObject.name;
                }
            }

            return arrayGridPoints;
        }

    }

}