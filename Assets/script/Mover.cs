using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
	public float speed;
	public GameObject explosion;

	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	void OnTriggerEnter(Collider other) {
		if(other.tag == "dynamiccollider"){
			Instantiate(explosion, transform.position, transform.rotation); 
    		Destroy(other.gameObject); 
  		  	Destroy(gameObject); 
}
		}
    
}
