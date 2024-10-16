using System;
using System.Collections.Generic;
using UnityEngine;
using VG;

public class TaskManager : MonoBehaviour
{
    private static TaskManager _instance;

    [SerializeField] private TaskConfig _taskConfig;

    public static List<Task> CurrentTasks { get; private set; } = new List<Task>();


    private void Awake()
    {
        _instance = this;
        GenerateTaskList();
    }


    private void GenerateTaskList()
    {
        CurrentTasks = new List<Task>();

        for (int slot = 0; slot < Saves.maxTaskAmount; slot++)
        {
            if (Saves.String[Key_Save.task_data(slot)].Value != string.Empty)
                CreateTask(Saves.GetTaskIndex(slot));
        }

        if (Saves.String[Key_Save.task_data(0)].Value == string.Empty)
            CreateTask(index: 0);
    }


    private void CreateTask(int index)
    {
        TaskData taskData = _taskConfig.GetTaskData(index);

        Task task = null;

        switch (taskData.taskType)
        {
            case TaskType.CollectItems:
                task = new CollectItems_Task(index, taskData.reward, taskData.parameters);
                break;
        }

        task.Subscribe();
        CurrentTasks.Add(task);
    }


    public static void CompleteTask(Task task)
    {
        int slot = Saves.GetTaskSlotByIndex(task.Index);

        int maxIndex = 0;
        for (int taskSlot = 0; taskSlot < Saves.maxTaskAmount; taskSlot++)
            if (Saves.String[Key_Save.task_data(taskSlot)].Value != string.Empty)
            {
                int taskIndex = Saves.GetTaskIndex(taskSlot);
                if (taskIndex > maxIndex) maxIndex = taskIndex;
            }

        Saves.Int[Key_Save.gears].Value += task.Reward;
        CurrentTasks.Remove(task);
        Saves.String[Key_Save.task_data(slot)].Value = string.Empty;
        

        _instance.CreateTask(maxIndex + 1);

        if (maxIndex + 1 == _instance._taskConfig.SecondTaskAvailableFromIndex 
            || maxIndex + 1 == _instance._taskConfig.ThirdTaskAvailableFromIndex)
            _instance.CreateTask(maxIndex + 2);
    }



}
