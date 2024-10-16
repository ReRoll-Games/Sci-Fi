using System;

public abstract class Task
{

    public int Index { get; protected set; }
    public int Reward { get; protected set; }

    public int CurrentPoints { get; protected set; }
    public int MaxPoints { get; protected set; }

    public bool IsCompleted => CurrentPoints == MaxPoints;


    public abstract string Description { get; }
    public abstract void Subscribe();
    public abstract void Unsubscribe();

    public string ToSaveString() => $"{Index}/{CurrentPoints}";


}

namespace VG
{
    public partial class Saves
    {
        public const int maxTaskAmount = 3;

        public static int GetTaskPoints(int slot)
            => int.Parse(String[Key_Save.task_data(slot)].Value.Split('/')[1]);

        public static int GetTaskIndex(int slot)
            => int.Parse(String[Key_Save.task_data(slot)].Value.Split('/')[0]);

        public static int GetTaskSlotByIndex(int index)
        {
            for (int slot = 0; slot < maxTaskAmount; slot++)
                if (String[Key_Save.task_data(slot)].Value != string.Empty 
                    && GetTaskIndex(slot) == index) return slot;

            for (int slot = 0; slot < maxTaskAmount; slot++)
                if (String[Key_Save.task_data(slot)].Value == string.Empty) return slot;

            throw new Exception($"Wrong task index: {index}");
        }

    }
}








