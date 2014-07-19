using UnityEngine;
using UnityEditor;
using System.Collections;

//Copyright (c) 2014 Adrian Dawid
//This file is part of the collection of usefull unity scripts that is available on github.
//It us useless without the CallFunctionOnTrigger script.

[CustomEditor(typeof(CallFunctionOnTrigger))]
public class CallFunctionOnTriggerEnterEditor : Editor {

	public override void OnInspectorGUI()
	{

		DrawDefaultInspector ();

		CallFunctionOnTrigger tar=target as CallFunctionOnTrigger;
		if (tar.ObjectToCall == CallObject.OTHER) {
			tar.SetObject(EditorGUILayout.ObjectField("Other:",tar.GetObject(),typeof(GameObject),true) as GameObject);
		}

	
	}
}
