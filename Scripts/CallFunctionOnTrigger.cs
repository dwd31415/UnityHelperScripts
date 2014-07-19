using UnityEngine;
using System.Collections;

//Copyright (c) 2014 Adrian Dawid
//This file is part of the collection of usefull unity scripts that is available on github.

//NOTE:
//To work well this file needs the CallFunctionOnTriggerEnterEditor.cs script that is located in the Editor folder. It has to be 
//in the Editor folder of your project too.

public class CallFunctionOnTrigger : MonoBehaviour {
	public string MethodName;
	public CallObject ObjectToCall;
	GameObject callingObject;
	
	void OnTriggerEnter(Collider other){
		if (ObjectToCall == CallObject.THIS) {
			gameObject.SendMessage(MethodName);
		}
		if (ObjectToCall == CallObject.ALL_CHILDREN) {
			for(int index=0;index<transform.childCount;index++)
			{
				gameObject.transform.GetChild(index).SendMessage(MethodName);
			}
		}
		if (ObjectToCall == CallObject.ENTERED_OBJECT) {
			other.gameObject.SendMessage(MethodName);
		}
		if (ObjectToCall == CallObject.OTHER) {
			if(callingObject.activeInHierarchy)
			{
				callingObject.SendMessage(MethodName);
			}
		}
	}

	public void SetObject(GameObject newObject)
	{
		callingObject = newObject;
	}

	public GameObject GetObject()
	{
		return callingObject;
	}
}

public enum CallObject{
	THIS,
	ENTERED_OBJECT,
	ALL_CHILDREN,
	OTHER
}