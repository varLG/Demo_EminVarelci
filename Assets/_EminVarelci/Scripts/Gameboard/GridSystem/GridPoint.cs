using System.Collections;
using System.Collections.Generic;
using TMPro; 
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

namespace GridSystem
{
    public class GridPoint : MonoBehaviour
    {
        public int GridX,GridY;
        public TextMeshProUGUI TxtGridPoint;
        public RectTransform RectTransform;

        public bool Available;



        public int CostG;  
        public int CostH;    
        public int CostF { get { return CostG + CostH; } }
        public GridPoint PointBefore;


    }
}