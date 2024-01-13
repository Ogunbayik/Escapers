using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    [SerializeField] private Color floorColor;

    private float changeMaxTimer = 0.1f;
    private float changeTimer = 0;

    private bool isActive;
    private bool isColorChanged;
    
    private void Awake()
    {
        isColorChanged = false;
        isActive = false;

        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        UpdateFloorColor();
    }

    private void UpdateFloorColor()
    {
        if (isColorChanged == false)
        {
            changeTimer += Time.deltaTime;

            if (changeTimer >= changeMaxTimer)
            {
                floorColor = meshRenderer.material.color;
                isColorChanged = true;
            }
        }
    }

    public Color GetColor()
    {
        return floorColor;
    }

    public void ChangeActivate(bool isActive)
    {
        this.isActive = isActive;
    }

    public bool IsActive()
    {
        return isActive;
    }

}
