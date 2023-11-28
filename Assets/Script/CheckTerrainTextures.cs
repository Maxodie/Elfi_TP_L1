using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTerrainTextures : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain terrainObject;

    public int posX;
    public int posZ;

    public float[] texturesValues;
    
    void Start()
    {
        playerTransform = gameObject.transform;
        terrainObject = Terrain.activeTerrain;
    }

    public void GetTerrainTextures()
    {
        UpdatePosition();
        CheckTextures();
    }

    void UpdatePosition()
    {
        Vector3 terrainPosition = playerTransform.position - terrainObject.transform.position;
        Vector3 mapPosition = new Vector3(terrainPosition.x / terrainObject.terrainData.size.x, 0,
            terrainPosition.z / terrainObject.terrainData.size.z);
        float xCoord = mapPosition.x * terrainObject.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * terrainObject.terrainData.alphamapHeight;
        posX = (int)xCoord;
        posZ = (int)zCoord;
    }

    void CheckTextures()
    {
        float[,,] splatMap = terrainObject.terrainData.GetAlphamaps(posX, posZ, 1, 1);
        texturesValues[0] = splatMap[0, 0, 0];
        texturesValues[1] = splatMap[0, 0, 1];
        texturesValues[2] = splatMap[0, 0, 2];
    }
}
