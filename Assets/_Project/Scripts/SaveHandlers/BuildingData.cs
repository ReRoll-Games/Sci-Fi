using System;
using UnityEngine;

public struct BuildingData
{
    public BuildingType buildingType;
    public BuildingState state;
    public int index;
    public Vector3 position;       
    public int level;
    

    public string ToDataString()
    {
        string dataString = string.Empty;

        dataString += buildingType.ToString();
        dataString += $"_{position.x}_{position.z}";
        dataString += $"_{level}_";
        dataString += state.ToString();

        return dataString;
    }


}



namespace VG
{
    public partial class Saves
    { 
        public static void SetBuildingData(BuildingData buildingData) =>
            String[Key_Save.building_data(buildingData.index)].Value = buildingData.ToDataString();

        public static BuildingData GetBuildingData(int buildingIndex)
        {
            string dataString = String[Key_Save.building_data(buildingIndex)].Value;

            var buildingData = new BuildingData();

            string[] dataArray = dataString.Split("_");

            string buildingTypeString = dataArray[0];
            string xPositionString = dataArray[1];
            string zPositionString = dataArray[2];
            string levelString = dataArray[3];
            string buildingStateString = dataArray[4];

            buildingData.buildingType = (BuildingType)Enum.Parse
                (typeof(BuildingType), buildingTypeString);

            buildingData.index = buildingIndex;

            float xPosition = float.Parse(xPositionString);
            float zPosition = float.Parse(zPositionString);

            buildingData.position = new Vector3(xPosition, 0f, zPosition);
            buildingData.level = int.Parse(levelString);
            buildingData.state = (BuildingState)Enum.Parse
                (typeof(BuildingState), buildingStateString);

            return buildingData;
        }
    
    
    }



}

