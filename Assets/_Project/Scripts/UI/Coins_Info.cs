using VG;

public class Coins_Info : Info
{
    
    protected override void Subscribe()
    {
        Saves.Int[Key_Save.gears].onChanged += UpdateValue;
    }
    
    protected override void Unsubscribe()
    {
        Saves.Int[Key_Save.gears].onChanged -= UpdateValue;
    }
    
    protected override void UpdateValue()
    {
        text.text = Saves.Int[Key_Save.gears].Value.ToString();
    }
    
}