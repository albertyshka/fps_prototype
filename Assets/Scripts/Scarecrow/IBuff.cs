using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuff
{
	void SetUp();

	void TearDown();

	void Tick();
}
