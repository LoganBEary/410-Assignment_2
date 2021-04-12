using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotProduct : MonoBehaviour
{
    public Transform player;
    public Transform enemy;
    public GameObject alertTxtObj;
    // Update is called once per frame
    void Start()
    {
      alertTxtObj.SetActive(false);
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
      Vector3 playerForward = player.forward;
      Vector3 playerToEnemy = enemy.position - player.position;
      float dotProduct = Vector3.Dot(playerForward, playerToEnemy);

      showAlert(dotProduct);
    //  print(dotProduct);
    }
    void showAlert(float dotProduct)
    {
      if((dotProduct <= 3.5 && dotProduct > 1))
      {
        alertTxtObj.SetActive(true);
      }
      else
      {
        alertTxtObj.SetActive(false);
      }
    }
}
