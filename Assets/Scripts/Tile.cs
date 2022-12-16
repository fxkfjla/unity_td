using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public Material glowMaterial;

    public Vector3 positionOffset = new Vector3(0, 0.2f, 0);
    
    [Header("Optional")]
    public GameObject turret;

    private MeshRenderer meshRenderer;
    private Material[] defaultMaterials;

    private BuildManager buildManager;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterials = meshRenderer.materials;

        buildManager = BuildManager.instance;
    }

    void OnMouseEnter()
    {
        if(buildManager.CanBuildOn(this))
            MakeGlow();
    }

    void OnMouseExit()
    {
        MakeNotGlow();   
    }

    void OnMouseDown()
    {
        if(buildManager.CanBuildOn(this))
            buildManager.BuildTurretOn(this);
        else
        {
            Debug.Log("Can't build here!");
            buildManager.SetTurretToBuild(null);
        }
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    public void MakeGlow()
    {
        Material[] materials = meshRenderer.materials;
        materials[1] = glowMaterial;
        meshRenderer.materials = materials;  
    }

    public void MakeNotGlow()
    {
        meshRenderer.materials = defaultMaterials;
    }
}