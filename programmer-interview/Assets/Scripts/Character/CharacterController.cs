using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private new Rigidbody2D rigidbody;

    private float speed;

    private void Start()
    {
        speed = GameSettings.instance.GameData.characterSpeed;
    }

    private void Update()
    {
        var movementInput = InputManager.character.Controls.Move.ReadValue<Vector2>();

        var isMoving = movementInput.magnitude > 0;

        rigidbody.velocity = movementInput.normalized * speed;

        if(isMoving)
        {
            animator.SetFloat("x", movementInput.x);
            animator.SetFloat("y", movementInput.y);
        }

        animator.SetBool("isMoving", isMoving);

    }

}
