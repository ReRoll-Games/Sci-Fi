using UnityEngine;
using VG;


public class TakeProducedItems_Button : ButtonHandler
{
    [SerializeField] private Window _window;

    protected override void OnClick()
    {
        var production = Saves.GetProduction(_window.Building.Index);
        var recipe = Saves.GetCurrentRecipe(_window.Building.Index);

        Saves.Int[Key_Save.item_amount(recipe.outputItem)].Value += production.produced;
        production.produced = 0;

        Saves.SetProduction(_window.Building.Index, production);
    }
    
}