using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerTrigger : MonoBehaviour
{
    public event EventHandler OnRightFloor;

    private SkinnedMeshRenderer meshRenderer;

    private Floor floor;

    private Color playerColor;
    private Color floorColor;

    private float maxChangeTimer = 0.1f;
    private float changeTimer = 0f;

    private bool isChanged = false;
    private void Awake()
    {
        meshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
    }
    void Start()
    {
        playerColor = meshRenderer.material.color;
    }

    void Update()
    {
        if(isChanged == false)
        {
            changeTimer += Time.deltaTime;
            if(changeTimer >= maxChangeTimer)
            {
                playerColor = meshRenderer.material.color;
                isChanged = true;
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        floor = other.gameObject.GetComponent<Floor>();
        floorColor = floor.GetColor();

        if (playerColor == floorColor)
        {
            floor.ChangeActivate(true);
            OnRightFloor(this, EventArgs.Empty);
        }
        else
        {
            Debug.Log("Find true Player");
        }

    }

    private void OnTriggerExit(Collider other)
    {
        floor.ChangeActivate(false);
        floor = null;
    }

}
