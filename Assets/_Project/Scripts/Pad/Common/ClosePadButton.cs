using System;
using System.Collections.Generic;
using VG;


public class ClosePadButton : ButtonHandler
{
    private static ClosePadButton _instance;

    private Stack<Action> _actionStack = new Stack<Action>();


    private void Awake()
    {
        _instance = this;
    }


    protected override void OnClick()
    {
        if (_actionStack.Count == 0) Pad.Close();
        else _actionStack.Pop()?.Invoke();
    }


    public static void AddAction(Action action) => _instance._actionStack.Push(action);

    
}