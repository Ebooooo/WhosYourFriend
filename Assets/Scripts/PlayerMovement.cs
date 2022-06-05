using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private float horizontal;
    private float speedLimit = 0.7f;

    private Transform body;
    void Start()
    {
        body = transform;
    }

    // Update is called once per frame
    void Update()
    {
        InputCollection();
        Movement();
    }

    private void InputCollection()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void Movement()
    {
        float horizontalSpeed = horizontal * moveSpeed;
        if(horizontal != 0)
        {
            body.position += new Vector3(horizontalSpeed * Time.deltaTime, 0f, 0f);
        }
    }
}
