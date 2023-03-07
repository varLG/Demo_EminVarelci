using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SingletonGeneric;
using Unity.VisualScripting;
using Buildings;

namespace GridSystem
{
    public class GridManager : SingletonGeneric.Singleton<GridManager>
    {
        [SerializeField] int gridSizeX;
        [SerializeField] int gridSizeY;

        [SerializeField] GridPoint[,] gridPointsArray;
        [SerializeField] GameObject goGridPoint;


        public Vector2 GridPointSize
        {
            get
            {
                return goGridPoint.GetComponent<RectTransform>().rect.size;
            }
        }

        public GridPoint[,] GridPointsArray { get { return gridPointsArray; } }

        private void Start()
        {
            gridPointsArray = GridGenerator.Instance.CreateGridPoints(gridPointsArray, gridSizeX, gridSizeY, goGridPoint, transform);

        }

        public bool CalculateGridAvailable(Vector2 _gridPointPos, Vector2 _objectGridSize, Building _building)
        {
            if (AvailableCalculate.CalculateGridAvailable(_gridPointPos, gridPointsArray, _objectGridSize) == true)
            {
                _building.SetupState(true);
                return true;
            }
            else
            {
                _building.SetupState(false);
                return false;
            }
        }
        public void SetGridAvailableClose(Building _building, Vector2 _buildingPos)
        {
            _building.SetupBuilding(_buildingPos);
            AvailableCalculate.SetAvailableClosed(_buildingPos, gridPointsArray, _building.objectGridSize);
        }
        public void SetGridAvailableOpen(Building _building, Vector2 _buildingPos)
        {
            _building.SetupBuilding(_buildingPos);
            AvailableCalculate.SetAvailableOpen(_buildingPos, gridPointsArray, _building.objectGridSize);
        }
    }

}

