using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CheckTerrainTexture : MonoBehaviour
{
    public Transform playerTransform;
    public Terrain t;
    public int posX;
    public int posZ;
    public List<float> textureValues = new List<float>();
    void Start()
    {
        textureValues.Add(0f);
        textureValues.Add(0f);
        textureValues.Add(0f);
        textureValues.Add(0f);
        textureValues.Add(0f);
        textureValues.Add(0f);
        t = Terrain.activeTerrain;
        playerTransform = gameObject.transform;
    }
    //void Update()
    //{
    //    // For better performance, move this out of update 
    //    // and only call it when you need a footstep.
    //    GetTerrainTexture();
    //}
    public void GetTerrainTexture()
    {
        ConvertPosition(playerTransform.position);
        CheckTexture();
    }
    public void ConvertPosition(Vector3 playerPosition)
    {
        Vector3 terrainPosition = playerPosition - t.transform.position;
        Vector3 mapPosition = new Vector3
        (terrainPosition.x / t.terrainData.size.x, 0,
        terrainPosition.z / t.terrainData.size.z);
        float xCoord = mapPosition.x * t.terrainData.alphamapWidth;
        float zCoord = mapPosition.z * t.terrainData.alphamapHeight;
        posX = (int)xCoord;
        posZ = (int)zCoord;
    }
    public void CheckTexture()
    {
        float[,,] aMap = t.terrainData.GetAlphamaps(posX, posZ, 1, 1);
        textureValues[0] = aMap[0, 0, 0];
        textureValues[1] = aMap[0, 0, 1];
        textureValues[2] = aMap[0, 0, 2];
        textureValues[3] = aMap[0, 0, 3];
        textureValues[4] = aMap[0, 0, 4];
        textureValues[5] = aMap[0, 0, 5];
    }
}