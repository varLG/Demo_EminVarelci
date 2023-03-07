using GridSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PathFinding
{
    public class PathManager : SingletonGeneric.Singleton<PathManager>
    {
        [SerializeField] GridPoint pointStart;
        [SerializeField] GridPoint pointTarget;

        bool waitTarget = false;

        Soldier soldier;

        public bool WaitPointTarget
        {
            get
            {
                if (waitTarget && pointStart != null)
                    return true;
                else return false;
            }
        }

        void CalculatePath()
        {
            List<GridPoint> path = FindPath.CalculatePath(pointStart, pointTarget);

            if (path != null)
            {

                pointStart.Available = true;
                pointTarget.Available = false;
                StartCoroutine(MoveObjectToTarget(path));
            }
            else
            {
                ResetValues();
                Debug.Log("Oluþabilecek bir rota yok!");
            }
            FightManager.Instance.ResetValues();
        }

        public void SetPoint(GridPoint _gridPoint, Soldier _soldier = null)
        {
            if (_soldier == soldier || (soldier != null && _soldier != null))
            {
                ResetValues();
                return;
            }

            if (pointStart == null)
            {
                pointStart = _gridPoint;
                pointTarget = null;
                waitTarget = true;

                if (_soldier != null)
                {
                    soldier = _soldier;
                    _soldier.SetSelectedColor(SelectedType.Selected);
                }
            }
            else if (pointStart != null
                && pointTarget == null
                && pointStart != pointTarget)
            {

                pointTarget = _gridPoint;
                CalculatePath();
            }
        }

        public void SetPoint(Vector2 _gridPointArrayValues)
        {
            SetPoint(GridManager.Instance.GridPointsArray[((int)_gridPointArrayValues.x), ((int)_gridPointArrayValues.y)]);
        }

        public void ResetValues()
        {
            pointStart = null;
            pointTarget = null;
            waitTarget = false;

            if (soldier != null)
            {
                soldier.SetSelectedColor(SelectedType.Free);
                soldier = null;
            }


        }


        IEnumerator MoveObjectToTarget(List<GridPoint> _GridPoint)
        {
            Soldier _soldier = soldier;
            while (_GridPoint.Count > 0)
            {
                _soldier.transform.position = _GridPoint[0].transform.position;
                _GridPoint.Remove(_GridPoint[0]);
                yield return new WaitForSeconds(0.1f);
            }
            ResetValues();
        }
    }
}

