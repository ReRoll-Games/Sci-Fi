using TMPro;
using UnityEngine;

public class TaskWidget : MonoBehaviour
{
    [Header("Not Completed:")]
    [SerializeField] private GameObject _notCompleted;
    [SerializeField] private TextMeshProUGUI _descriptionText;
    [SerializeField] private TextMeshProUGUI _rewardText;

    [Header("Completed:")]
    [SerializeField] private GameObject _completed;
    [SerializeField] private TextMeshProUGUI _completedDescriptionText;
    [SerializeField] private TextMeshProUGUI _completedRewardText;

    public Task Task { get; private set; }

    public void UpdateTask(Task task)
    {
        Task = task;
        bool taskCompleted = task.IsCompleted;

        _completed.SetActive(taskCompleted);
        _notCompleted.SetActive(!taskCompleted);

        if (taskCompleted)
        {
            _completedDescriptionText.text = task.Description;
            _completedRewardText.text = $"Забрать: <sprite=0>{task.Reward}";
        }
        else
        {
            _descriptionText.text = $"{task.Description} ({task.CurrentPoints}/{task.MaxPoints})";
            _rewardText.text = $"Награда: <sprite=0>{task.Reward}";
        }
        
    }


}
