using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerAnimationController animationController;

    private const string HORIZONTAL_INPUT = "Horizontal";
    private const string VERTICAL_INPUT = "Vertical";

    [Header(" Settings ")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform body;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;

    private bool isChoosed;
    private bool isRun;
    private void Awake()
    {
        animationController = GetComponentInChildren<PlayerAnimationController>();
    }
    void Start()
    {
        isRun = false;
    }

    void Update()
    {
        if (isChoosed)
            Movement();
    }

    private void Movement()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL_INPUT);
        verticalInput = Input.GetAxis(VERTICAL_INPUT);

        movementDirection = new Vector3(horizontalInput, 0f, verticalInput);
        movementDirection.Normalize();
        CheckMovement();

        if (isRun)
        {
            animationController.RunningAnimation(true);
            HandleRotate();
            transform.Translate(movementDirection * movementSpeed * Time.deltaTime);
        }
        else
            animationController.RunningAnimation(false);

        body.transform.position = transform.position;
    }

    private void CheckMovement()
    {
        if (movementDirection != Vector3.zero)
            isRun = true;
        else
            isRun = false;
    }

    private void HandleRotate()
    {
        var toRotate = Quaternion.LookRotation(movementDirection, Vector3.up);

        body.transform.rotation = Quaternion.RotateTowards(body.transform.rotation, toRotate, rotateSpeed * Time.deltaTime);
    }

    public void IsChoosedPlayer(bool isChoosed)
    {
        this.isChoosed = isChoosed;
        animationController.SadIdleAnimation(isChoosed);
    }

    public bool IsChoosed()
    {
        return isChoosed;
    }
}
