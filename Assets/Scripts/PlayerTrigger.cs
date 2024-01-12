using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : MonoBehaviour
{
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
            Debug.Log("True");
        else
            Debug.Log("False");

    }

    private void OnTriggerExit(Collider other)
    {
        floor = null;
    }

}
