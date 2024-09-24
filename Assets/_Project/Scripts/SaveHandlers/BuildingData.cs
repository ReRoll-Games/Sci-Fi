using System;
using UnityEngine;

public struct BuildingData
{
    public BuildingType buildingType;
    public int index;
    public Vector2Int gridPosition;       
    public int level;

    public Vector3Int gridPosition3D => new Vector3Int(gridPosition.x, gridPosition.y, 0);
    

    public string ToDataString()
    {
        string dataString = string.Empty;

        dataString += buildingType.ToString();
        dataString += $"_{gridPosition.x}_{gridPosition.y}";
        dataString += $"_{level}";

        return dataString;
    }


}



namespace VG
{
    public partial class Saves
    { 
        public static void SetBuildingData(BuildingData buildingData) =>
            String[Key_Save.building_data(buildingData.index)].Value = buildingData.ToDataString();

        public static int GetBuildingQuantity()
        {
            for (int index = 0; index < maxBuildingsQuantity; index++)
                if (String[Key_Save.building_data(index)].Value == string.Empty)
                    return index + 1;

            return maxBuildingsQuantity;
        }

        public static int GetBuildingAmount(BuildingType buildingType)
        {
            int amount = 0;
            for (int index = 0; index < maxBuildingsQuantity; index++)
                if (String[Key_Save.building_data(index)].Value != string.Empty)
                {
                    if (GetBuildingData(index).buildingType == buildingType)
                        amount++;
                }
            return amount;
        }



        public static BuildingData GetBuildingData(int buildingIndex)
        {
            string dataString = String[Key_Save.building_data(buildingIndex)].Value;

            var buildingData = new BuildingData();

            string[] dataArray = dataString.Split("_");

            string buildingTypeString = dataArray[0];
            string xPositionString = dataArray[1];
            string zPositionString = dataArray[2];
            string levelString = dataArray[3];

            buildingData.buildingType = (BuildingType)Enum.Parse
                (typeof(BuildingType), buildingTypeString);

            buildingData.index = buildingIndex;

            int xPosition = int.Parse(xPositionString);
            int yPosition = int.Parse(zPositionString);

            buildingData.gridPosition = new Vector2Int(xPosition, yPosition);
            buildingData.level = int.Parse(levelString);

            return buildingData;
        }
    
    
    }



}

