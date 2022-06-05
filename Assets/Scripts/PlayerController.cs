using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController: MonoBehaviour
{

    [SerializeField] private float moveSpeed = 5f;
    private Animator walkanimation;
    private Vector2 movement;

    void Start()
    {
        walkanimation = GetComponent<Animator>();
    }

    void Update()
    {
        movement = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        walkanimation.SetFloat("Walk", Mathf.Abs(movement.magnitude * moveSpeed));

        bool flipped = movement.x < 0;
        this.transform.rotation = Quaternion.Euler(new Vector3(0f, flipped ? 180f : 0f, 0f));
    }

    private void FixedUpdate() 
    {
        if(movement != Vector2.zero)
        {
            var xMovement = movement.x * moveSpeed * Time.deltaTime;
            this.transform.Translate(new Vector3(xMovement, 0), Space.World);
        }
    }
}
