using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField] private Color floorColor;

    private float changeMaxTimer = 0.1f;
    private float changeTimer = 0;
    private bool isChanged;
    private void Awake()
    {
        isChanged = false;

        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdateFloorColor();
    }

    private void UpdateFloorColor()
    {
        if (isChanged == false)
        {
            changeTimer += Time.deltaTime;

            if (changeTimer >= changeMaxTimer)
            {
                floorColor = meshRenderer.material.color;
                isChanged = true;
            }
        }
    }

    public Color GetColor()
    {
        return floorColor;
    }

}
