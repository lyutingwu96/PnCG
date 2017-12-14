using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LitJson;

public class Json : MonoBehaviour {
	private string jsonString;
	private JsonData jsonData;
	void Start () {
		jsonString = File.ReadAllText (Application.dataPath + "/Resources/myJson.json");//(1)
		jsonData = JsonMapper.ToObject (jsonString);//(2)
		Debug.Log (jsonData["name"]);//(3)
		Debug.Log (jsonData["age"]);
	}
}
