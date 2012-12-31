using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Targetting : MonoBehaviour {
	
	public Transform selectedTarget;
	public List<GameObject> inLoS = new List<GameObject>();
	private int indexOfTarget = -1;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update(){
    	if (Input.GetMouseButtonDown(0)){ // when button clicked...
      		MouseSelect ();
			if(!selectedTarget){
				indexOfTarget = -1;
			}
    	}
		else if(Input.GetKeyDown(KeyCode.Tab)){
			TabSelect();
		}
		else if(Input.GetKeyDown(KeyCode.Escape)){
			DeselectTarget();
			indexOfTarget = -1;
		}
  	}
	
	private void MouseSelect() {
		RaycastHit hit; // cast a ray from mouse pointer:
	  	Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
  		// if enemy hit...
		DeselectTarget(); // deselect previous target (if any)...
		if (Physics.Raycast(ray, out hit) && hit.transform.CompareTag("Enemy")){
    	    selectedTarget = hit.transform; // set the new one...
    	    SelectTarget(); // and select it
  		}
	}
	
	private void TabSelect() {
		LineOfSight LoS = (LineOfSight)transform.GetComponent("LineOfSight");
		inLoS = LoS.GameObjectsInSight(120, 180);
		if (inLoS.Count > 0){
			SortByDistance();
			DeselectTarget();
			if(indexOfTarget == -1 || indexOfTarget >= inLoS.Count - 1){
				indexOfTarget = 0;
				selectedTarget = inLoS[indexOfTarget].transform;
			}
			else{
				indexOfTarget++;
				selectedTarget = inLoS[indexOfTarget].transform;
			}
			SelectTarget();
		}
	}
	
	private void SortByDistance(){
		inLoS.Sort(delegate(GameObject t1, GameObject t2) { 
       		return Vector3.Distance(t1.transform.position, transform.position).CompareTo(Vector3.Distance(t2.transform.position, transform.position));
      	});
	}
	
  	private void SelectTarget(){
		GameObject circle = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
		circle.tag = "TargetCircle";
		circle.renderer.material.color = Color.red;
		circle.transform.position = selectedTarget.transform.position - new Vector3(0,(float)(selectedTarget.transform.position.y - .1), 0);
		circle.transform.parent = selectedTarget.transform;
		circle.transform.localScale = new Vector3(2,.05f,2);
		circle.collider.enabled = false;
	    //PlayerAttack pa = (PlayerAttack)GetComponent("PlayerAttack");
	    //pa.target = selectedTarget.gameObject;
  	}
	
  	private void DeselectTarget(){
	    if (selectedTarget){ // if any guy selected, deselect it
	      	Destroy(GameObject.FindGameObjectWithTag("TargetCircle"));
	      	selectedTarget = null;
	    }
  	}
}
