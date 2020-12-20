﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Variable/Integer Variable")]
public class IntegerVariable : ScriptableObject, ISerializationCallbackReceiver
{
	public int InitialValue;

	[NonSerialized]
	public int RuntimeValue;

public void OnAfterDeserialize()
{
		RuntimeValue = InitialValue;
}

public void OnBeforeSerialize() { }
}
