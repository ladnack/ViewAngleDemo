using UnityEngine;
using System.Collections;

public class ButtonFunction : MonoBehaviour {

	public void NoArgFunction()
	{
		Debug.Log ("NoArgFunction");
	}

	public void IntArgFunction(int i)
	{
		Debug.Log ("IntArgFunction Called. arg=" + i.ToString ());
	}

	public void FloatArgFunction(float f)
	{
		Debug.Log ("FloatArgFunction Called. arg="+f.ToString());
	}

	public void StringArgFunction(string s)
	{
		Debug.Log ("StringArgFunction Called. arg="+s);
	}

	public void BoolArgFunction(bool b)
	{
		Debug.Log ("BoolArgFunction Called. arg="+b.ToString());
	}

	public void ObjectArgFunction(Object o)
	{
		Debug.Log ("ObjectArgFunction Called. arg="+o.ToString());
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
