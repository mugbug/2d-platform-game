using UnityEngine;
using System.Collections;

public abstract class Character : MonoBehaviour {

	[SerializeField]
	private float speed;
	
	protected Vector2 direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	protected virtual void Update () {
		Move ();
	}
	
	public void Move(){
		transform.Translate (direction*speed*Time.deltaTime);
	}
}
