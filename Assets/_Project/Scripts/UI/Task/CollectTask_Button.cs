using UnityEngine;
using VG;


public class CollectTask_Button : ButtonHandler
{
    [SerializeField] private TaskWidget _taskWidget;

    protected override void OnClick()
    {
        TaskManager.CompleteTask(_taskWidget.Task);
    }
    

}