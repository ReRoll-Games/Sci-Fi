using UnityEngine;
using VG;


public class TakeProducedItems_Button : ButtonHandler
{
    [SerializeField] private Window _window;

    protected override void OnClick()
    {
        var production = Saves.GetProduction(_window.building.index);
        var recipe = Saves.GetCurrentRecipe(_window.building.index);

        Saves.Int[Key_Save.item_quantity(recipe.outputItem)].Value += production.produced;
        production.produced = 0;

        Saves.SetProduction(_window.building.index, production);
    }
    
}