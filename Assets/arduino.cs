using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;

public class arduino : MonoBehaviour {

	//public Text valText;
	public TextMesh val3DText;
	public TextMesh valNum3DText;
	SerialPort stream = new SerialPort("\\\\.\\COM15", 9600);
	string value ="";
	public int SteerVal;
	// Use this for initialization
	
	void Start () {
		stream.Open();
	}
	
	// Update is called once per frame
	void Update () {

		string value = stream.ReadLine();
		//valText.text=value;
		val3DText.text =value;
		
		string numVal = value.Substring(3);
		//valNum3DText.text=numVal;
		SteerVal=int.Parse(numVal);
		
		valNum3DText.text=SteerVal.ToString();
	
	}

}
