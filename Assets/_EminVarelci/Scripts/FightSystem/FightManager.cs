using Buildings;
using GridSystem;
using PathFinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class FightManager : SingletonGeneric.Singleton<FightManager>
{
    [SerializeField] Building attacker;
    [SerializeField] Building defender;

    [SerializeField] List<Building> listFighters;
    private void OnEnable()
    {
        EventManager.OnClickObject += ClickObject;
        EventManager.OnObjectDead += ObjectDead;
    }
    private void OnDisable()
    {
        EventManager.OnClickObject -= ClickObject;
        EventManager.OnObjectDead -= ObjectDead;
    }

    void ClickObject(Building _building, bool _leftClick)
    {
        if (_leftClick)
        {
            if (attacker == null)
            {
                attacker = _building;
            }
            else
            {
                attacker = null;
                defender = null;
            }

        }
        else
        {
            if (attacker != null && (attacker != _building))
            {
                defender = _building;

                attacker.SetEnemy(defender);
                defender.SetEnemy(attacker);

                if (!listFighters.Contains(attacker))
                    listFighters.Add(attacker);

                if (!listFighters.Contains(defender))
                    listFighters.Add(defender);

                MakeFight();
                ResetValues();
            }
        }
    }
    void ObjectDead(Building _object)
    {
        if (listFighters.Contains(_object))
        {
            listFighters.Remove(_object);
        }
    }
    public void ResetValues()
    {
        attacker = null;
        defender = null;
    }
    void MakeFight()
    {
        PathManager.Instance.ResetValues();
        while (listFighters.Count > 0)
        {
            listFighters[0].AttackNow();
            listFighters.RemoveAt(0);
        }
    }


}
