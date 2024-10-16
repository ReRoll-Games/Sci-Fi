using System.Collections.Generic;
using UnityEngine;
using VG;

public class TaskList_Info : Info
{
    [SerializeField] private List<TaskWidget> _taskWidgets;

    protected override void Subscribe()
    {
        for (int i = 0; i < Saves.maxTaskAmount; i++)
            Saves.String[Key_Save.task_data(i)].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        for (int i = 0; i < Saves.maxTaskAmount; i++)
            Saves.String[Key_Save.task_data(i)].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        int i = 0;
        foreach (var task in TaskManager.CurrentTasks)
        {
            _taskWidgets[i].gameObject.SetActive(true);
            _taskWidgets[i].UpdateTask(task);
            i++;
        }
        for (; i < _taskWidgets.Count; i++)
            _taskWidgets[i].gameObject.SetActive(false);
    }
    
}