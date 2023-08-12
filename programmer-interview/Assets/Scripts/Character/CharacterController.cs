using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Input;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float walkingSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody;

    private void Update()
    {
        var movementInput = InputManager.character.Controls.Move.ReadValue<Vector2>();

        var isMoving = movementInput.magnitude > 0;

        //If is walking diagonally, we should adjust the input
        //if(Mathf.Abs(movementInput.x) == 1 && Mathf.Abs(movementInput.y) == 1)
        //{
        //    //The diagonal velocity should be the hyponetuse of the input
        //    //Since the input is always +-1, the value will always be the sqrt of 2
        //    //In the end we just multiply the input by the sqrt of 2 to keep the signal

        //    movementInput *= Mathf.Sqrt(2);
        //}

        rigidbody.velocity = movementInput.normalized * walkingSpeed;

        if(isMoving)
        {
            animator.SetFloat("x", movementInput.x);
            animator.SetFloat("y", movementInput.y);
        }

        animator.SetBool("isMoving", isMoving);

    }

}
