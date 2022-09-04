using System.Collections.Generic;
using Buff;

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

    /// <summary>
    /// Метод, который используется для применения бафа к npc.
    /// </summary>
    /// <param name="newBuff"></param>
    public void ApplyBuff(IBuff newBuff);
}
