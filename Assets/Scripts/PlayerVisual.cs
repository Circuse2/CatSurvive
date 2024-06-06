using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerVisual : MonoBehaviour
{
    private Animator animator;

    private SpriteRenderer spriteRenderer;

    private const string IS_RUN = "IsRun";

    [SerializeField]GameObject AttackPoint;

    public void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void Update()
    {
        animator.SetBool(IS_RUN, Player.Instance.IsRun());
        PlayerAdjust();
    }

    private void PlayerAdjust()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        if (inputVector.x < 0) {
            spriteRenderer.flipX = true;
            AttackPoint.transform.position = this.transform.position + Vector3.left;    
        } else if (inputVector.x > 0) 
        { 
            spriteRenderer.flipX = false;
            AttackPoint.transform.position = this.transform.position + Vector3.right;
        }
    }
}
