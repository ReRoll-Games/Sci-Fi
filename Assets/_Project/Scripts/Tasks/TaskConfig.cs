using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Project/Configs/Tasks", fileName = "Tasks")]
public class TaskConfig : ScriptableObject
{

    [field: SerializeField] public int SecondTaskAvailableFromIndex { get; private set; }
    [field: SerializeField] public int ThirdTaskAvailableFromIndex { get; private set; }


    [SerializeField] private List<TaskData> _taskData;

    public TaskData GetTaskData(int index) => _taskData[index];

}


