using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Интерфейс бафа, где баф - любое воздействие на характеристики npc.
/// </summary>
public interface IBuff
{
	/// <summary>
	/// Продолжительность бафа в секундах.
	/// </summary>
	public int Duration { get; set; }

	/// <summary>
	/// Можно ли удалить баф.
	/// (Закончил ли баф работу).
	/// </summary>
	public bool IsReadyToBeRemoved { get; }

	/// <summary>
	/// Можно ли применить два одинаковых бафа.
	/// </summary>
	public bool IsStackable { get; }

	/// <summary>
	/// Функция вызывается при добавлении нового бафа к npc.
	/// Изменяет добавляемый баф, накладывая на него ограничения,
	/// либо усиливая его.
	/// </summary>
	/// <param name="buff">Баф, который будет добавлен к npc.</param>
	/// <returns>Измененный баф.</returns>
	void ApplyStatChange(ref IBuff buff);

	/// <summary>
	/// Фнукция вызывается в момент удаления бафа
	/// из списка бафов npc.
	/// Накладывает изменения на характеристики npc.
	/// </summary>
	/// <param name="stats">Провайдер характеристик npc.</param>
	void OnTearDown(INpcStatsHolder stats);

	/// <summary>
	/// Функция вызывется в момент добавляния бафа
	/// к списку бафов npc.
	/// Накладывает изменения на характеристики npc.
	/// </summary>
	/// <param name="stats">Провайдер характеристик npc.</param>
	void OnStartUp(INpcStatsHolder stats);

	/// <summary>
	/// Функция вызывается раз в секунду во время пребывания
	/// бафа в списке бафов npc.
	/// Накладывает изменения на характеристики npc.
	/// </summary>
	/// <param name="stats">Провайдер характеристик npc.</param>
	void OnTick(INpcStatsHolder stats);
}
