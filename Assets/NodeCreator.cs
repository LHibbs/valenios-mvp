using UnityEngine;
using System.Collections;
using System.Collections.Generic; 

public class NodeCreator : MonoBehaviour {

	public GameObject node; 
	private GameObject[,] nodes;
	private static int WIDTH; 
	private static int HEIGHT; 

	public GameObject edgeObj;

	Point[,] points;

	// Use this for initialization
	void Start () {
		WIDTH = 5; 
		HEIGHT = 5; 
		CreateGraph (); 
		foreach (Point p in points) 
		{
			Instantiate (node, new Vector2 (p.getX (), p.getY ()), Quaternion.identity); 
		}

		CreateEdges ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*
	 * Creates a grid with all points and all edges
	 */ 
	void CreateGraph()
	{
		points = new Point[WIDTH,HEIGHT]; 
		for (int i = 0; i < points.GetLength(0); i++) 
		{
			for (int z = 0; z < points.GetLength (1); z++) 
			{
				points [i, z] = new Point (i, z);
			}
		}

		for (int i = 0; i < points.GetLength(0); i++) 
		{
			for (int z = 0; z < points.GetLength(1); z++) 
			{

				for (int j = i - 1; j <= i+1; j++)
				{
					for (int w = z - 1; w <= z + 1; w++)
					{
						if (j >= 0 && j < points.GetLength (0) && w >= 0 && w < points.GetLength (0))
						{
							if(!(i == j && z == w))
							{
								points [i, z].addNeighbor (points [j, w]);
							}
						}
							
					}
				}

			}
		}
	}

	void CreateEdges()
	{
		HashSet<Edge> edgeSet = new HashSet<Edge>(); 

		foreach (Point initial in points)
		{
			foreach (Point terminal in initial.getNeighbors()) 
			{
				Edge e = new Edge (initial, terminal); 
				if (!edgeSet.Contains (e)) 
				{
					edgeSet.Add (e); 
					GameObject thisEdge = Instantiate (edgeObj, new Vector2(0,0), Quaternion.identity) as GameObject;
					thisEdge.GetComponent<LineRenderer>().SetPosition (0, new Vector3(initial.getX(), initial.getY(), 0f));
					thisEdge.GetComponent<LineRenderer>().SetPosition (1, new Vector3(terminal.getX(), terminal.getY(), 0f));
				}
			}

		}
	}

	class Edge {
		public Point start;
		public Point end; 

		public Edge(Point start, Point end) 
		{
			this.start = start; 
			this.end = end; 
		}

		public override bool Equals(System.Object obj)
		{
			// If parameter is null return false.
			if (obj == null)
			{
				return false;
			}

			// If parameter cannot be cast to Edge return false.
			Edge e = obj as Edge;
			if ((System.Object)e == null)
			{
				return false;
			}

			// Return true if the fields match:
			return e.start == start && e.end == end ||
				e.end == start && e.start == end; 
		}
			
		public bool Equals(Edge other){
			return other.start == start && other.end == end ||
			other.end == start && other.start == end; 
		}

		public override int GetHashCode()
		{
			return start.getX() ^ end.getX();
		}
	}
}
