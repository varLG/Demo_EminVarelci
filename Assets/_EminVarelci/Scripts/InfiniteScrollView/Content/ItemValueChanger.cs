using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UnityEngine;

namespace InfiniteScrollView
{
    public static class ItemValueChanger
    {
        public static int nextSetIndex = 0;
        public static int totalCapacity = 0;
        public static int objectsCount = 0;
        public static bool tekSayiDizdirildi = false;

        public static BuildingSetObject buildingsSet;
        public static List<SoldierObject> soldiersSet;
        public static List<Row> contentRows;


        public static void ItemValueChange(List<Row> _listContentRows, BuildingSetObject _productionBuildingsSet)
        {
            buildingsSet = _productionBuildingsSet;
            contentRows = _listContentRows;
            soldiersSet = null;
             
            SetValueChanger();
        }

        public static void ItemValueChange(List<Row> _listContentRows, List<SoldierObject> _listProductableUnits)
        {
            contentRows = _listContentRows;
            soldiersSet = _listProductableUnits;
            buildingsSet = null;

            SetValueChanger();
        }
         
        public static void SetValueChanger()
        {
            //Itemlarýn row sýrasýný hesaplamak için. 
            CalculateSetRows();

            //Item yuvalarýna bilgileri girmek için.
            RowInsideSet(); 
        }


        static void RowInsideSet()
        {
            for (int i = 0; i < contentRows.Count; i++)
            {
                for (int j = 0; j < contentRows[i].listItemInsideRows.Count; j++)
                {
                    if (nextSetIndex >= objectsCount)
                    {
                        nextSetIndex = 0;
                    }

                    if(buildingsSet!=null)
                    {
                        contentRows[i].listItemInsideRows[j]
                    .SetItemValues(buildingsSet.ListBuildingObjects[nextSetIndex]);
                    }
                    else if(soldiersSet!=null)
                    {
                        contentRows[i].listItemInsideRows[j]
                    .SetItemValues(soldiersSet[nextSetIndex]);
                    }
                    

                    nextSetIndex++;
                }
            }
        }

        static void CalculateSetRows()
        {
         

            if (buildingsSet != null)
                objectsCount = buildingsSet.ListBuildingObjects.Count;
            else if (soldiersSet != null)
                objectsCount = soldiersSet.Count;


            if (objectsCount % 2 == 0)
            {
                //UnityEngine.Debug.Log("Çift sayýlýk set var.");

                if (ContentUpdate.rowIndex >= (objectsCount / 2))
                {
                    //UnityEngine.Debug.Log("Rowlar itemleri tamamen dizdirdi, rowIndex sýfýrlanacak.");
                    ContentUpdate.rowIndex = 0;
                }
                if (ContentUpdate.rowIndex < 0)
                {
                    //UnityEngine.Debug.Log("Rowlar geriye dönerken sýfýr altýna düþtü. rowIndex son item kademesinin bir öncesine getirilecek.");
                    ContentUpdate.rowIndex = (objectsCount / 2) - 1;
                }

                nextSetIndex = ContentUpdate.rowIndex * 2;

            }
            else if (objectsCount % 2 == 1)
            {
                //UnityEngine.Debug.Log("Tek sayýlýk set var.");
                if (ContentUpdate.rowIndex > (objectsCount / 2))
                {
                    //UnityEngine.Debug.Log("Rowlar itemleri tamamen dizdirdi. Ama tek sayýlýk set olduðu için:");
                    if (!tekSayiDizdirildi)
                    {
                        //UnityEngine.Debug.Log("Tek sayý dizdirilmemiþ, rowIndex sýfýrlanacak. Dizilim bir eleman atlayarak baþlayacak.");
                        ContentUpdate.rowIndex = 0;
                        tekSayiDizdirildi = true;
                    }
                    else
                    {
                        //UnityEngine.Debug.Log("Tek sayý dizdirmiþ, rowIndex sýfýrlanacak. Dizilim bir sýra atlayarak baþlayacak.");
                        ContentUpdate.rowIndex = 1;
                        tekSayiDizdirildi = false;
                    }
                }
                if (ContentUpdate.rowIndex < 0)
                {
                    //UnityEngine.Debug.Log("Rowlar geriye dönerken sýfýr altýna düþtü. rowIndex son item kademesinin bir öncesine getirilecek.");


                    if (!tekSayiDizdirildi)
                    {
                        //UnityEngine.Debug.Log("Tek sayý dizdirilmemiþ, rowIndex sýfýrlanacak. Dizilim bir eleman atlayarak baþlayacak.");
                        ContentUpdate.rowIndex = (objectsCount / 2) - 1;
                        tekSayiDizdirildi = true;
                    }
                    else
                    {
                        //UnityEngine.Debug.Log("Tek sayý dizdirmiþ, rowIndex sýfýrlanacak. Dizilim bir sýra atlayarak baþlayacak.");
                        ContentUpdate.rowIndex = (objectsCount / 2);
                        tekSayiDizdirildi = false;
                    }

                }

                if (!tekSayiDizdirildi)
                    nextSetIndex = (ContentUpdate.rowIndex * 2);
                else
                    nextSetIndex = (ContentUpdate.rowIndex * 2) + 1;


            }
             
        }

    }
}