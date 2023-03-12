
using System.Collections.Generic;

public interface IWarehouseComponent
{
    public void TakeResource(Ingredients Type, int Amount);

    public void GiveResource(Recipe recipe, Dictionary<Ingredients, WarehouseCollector> resourcesDictionary);
}
