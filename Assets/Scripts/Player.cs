using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] public float movingSpeed = 6f;
    private Rigidbody2D rb;
    private float minMovingSpeed = 0.1f;
    private bool isRun = false;

    [SerializeField] DataContainer dataContainer;

    private void Awake()
    {
        Instance = this;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        float movingSpeedUpgradeLevel = dataContainer.GetUpgradeLevel(PlayerPersistentUpgrades.—коростьѕередвижени€);
        movingSpeed += movingSpeedUpgradeLevel * 0.5f;
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        Vector2 inputVector = GameInput.Instance.GetMovementVector();
        rb.MovePosition(rb.position + inputVector * (movingSpeed * Time.fixedDeltaTime));

        if (Mathf.Abs(inputVector.x) > minMovingSpeed || Mathf.Abs(inputVector.y) > minMovingSpeed) {
            isRun= true;
        } else
        {
            isRun= false;
        }
    }

    public bool IsRun()
    {
        return isRun;
    }
    
}
