using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
  public GameObject player;
    // Start is called before the first frame update
  void OnTriggerEnter(Collider collide){
      if(collide.gameObject == player)
      {
        collide.GetComponent<DotProduct> ().enabled = false;
      }
    }
}
