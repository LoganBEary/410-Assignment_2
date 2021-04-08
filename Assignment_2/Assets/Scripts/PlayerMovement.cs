using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector3 m_Movement;
    Animator m_Animator;
    public float turnSpeed;
    // Start is called before the first frame update
    void Start()
    {
      m_Animator = GetComponent<Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        m_Movement.Normalize(m_Movement.Set(
        horizontal, 0f, vertical));
        bool hasHorizontalInput = !Mathf.Approximately
        (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately
        (vertical, 0f);
        bool isWalking = hasVerticalInput ||
        hasHorizontalInput;
        m_Animator.SetBool("IsWalking", isWalking);
        Vector3 desiredForward = Vector3.RotateToward(
        transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
    }
}
