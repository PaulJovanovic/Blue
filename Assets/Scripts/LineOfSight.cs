using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LineOfSight : MonoBehaviour {
	
	public Transform origin;
	
	void Start(){
		origin = transform;
	}
	
	public List<GameObject> GameObjectsInSight(int deg, int dist){
		List<GameObject> gameObjectsReturn = new List<GameObject>();
		GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Enemy");
		
		for(int i = 0; i < gameObjects.Length; i++){
			//TODO, check if object is infront of the camera instead of just seen
			if(Vector3.Angle(gameObjects[i].transform.position - origin.transform.position, origin.transform.forward) <= deg && gameObjects[i].renderer.isVisible){
				gameObjectsReturn.Add(gameObjects[i]);
			}
		}
		return gameObjectsReturn;
	}
}
