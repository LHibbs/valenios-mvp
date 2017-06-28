using UnityEngine;
using System.Collections;


public class Point{

	private int x;
	private int y;
	private ArrayList neighbors;  

	public Point(int x, int y) {
		this.x = x;
		this.y = y;
		neighbors = new ArrayList();
	}

	public ArrayList getNeighbors() {
		return neighbors;
	}

	public void addNeighbor(Point p){
		
		neighbors.Add(p);
		

	}

	public int getX(){
		return x;
	}

	public int getY(){
		return y;
	}

}
