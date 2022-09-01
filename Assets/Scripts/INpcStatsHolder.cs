using System.Collections.Generic;

/// <summary>
/// Интерфекс объекта (npc) имеющего hp, и на которого можно накладывать
/// бафы.
/// </summary>
public interface INpcStatsHolder
{
    /// <summary>
    /// Количество здоровья npc.
    /// </summary>
    int HealthPoints { get; set; }

    /// <summary>
    /// Бафы, наложенные на данного npc
    /// </summary>
    public LinkedList<IBuff> Buffs { get; }
}
