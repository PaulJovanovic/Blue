using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {
	
	public int maxHealth = 100;
	public int curHealth = 100;
	public int maxMana = 40;
	public int curMana = 40;

	
	private float healthBarWidth;
	private float manaBarWidth;
	
	// Use this for initialization
	void Start () {
		healthBarWidth = Screen.width / 2;
		manaBarWidth = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		GUI.Box (new Rect(10, 10, Screen.width/2 - 20, 20), "");
		GUI.Box (new Rect(10, 10, healthBarWidth, 20), curHealth + "/" + maxHealth);
		GUI.Box (new Rect(10, 40, Screen.width/2 - 20, 20), "");
		GUI.Box (new Rect(10, 40, manaBarWidth - 10, 20), curMana + "/" + maxMana);
	}
	
	public void adjustHealth(int adj) {
		curHealth += adj;
		
		healthBarWidth = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
	
	public void adjustMana(int adj) {
		curMana += adj;
		
		manaBarWidth = (Screen.width / 2) * (curHealth / (float)maxHealth);
	}
}
