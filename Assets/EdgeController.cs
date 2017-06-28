using UnityEngine;
using System.Collections;

public class EdgeController : MonoBehaviour {

	LineRenderer edge;

	// Use this for initialization
	void Start () {
		edge = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setPos(int x1, int y1, int x2, int y2)
	{
		edge.SetPosition (0, new Vector3(x1, y1, 0));
		edge.SetPosition (1, new Vector3(x2, y2, 0));
	}
}
