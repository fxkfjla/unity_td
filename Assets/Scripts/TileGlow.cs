using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileGlow : MonoBehaviour
{
    public Material glowMaterial;

    public Vector3 positionOffset = new Vector3(0, 0.2f, 0);

    private GameObject turret;

    private MeshRenderer meshRenderer;
    private Material[] defaultMaterials;
    
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        defaultMaterials = meshRenderer.materials;
    }

    void OnMouseEnter()
    {
        if(gameObject.tag == "Buildable")
        {
            Material[] materials = meshRenderer.materials;
            materials[1] = glowMaterial;
            meshRenderer.materials = materials;   
        }
    }

    void OnMouseExit()
    {
        if(gameObject.tag == "Buildable")
            meshRenderer.materials = defaultMaterials;  
    }

    void OnMouseDown()
    {
        if(gameObject.tag == "Buildable")
        {
            // Build a turret
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);
            gameObject.tag = "NotBuildable";
            meshRenderer.materials = defaultMaterials;  
        }
        else
        {
            Debug.Log("Can't build here!");
        }
    }
}
