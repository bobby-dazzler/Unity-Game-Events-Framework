using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryContent : ScriptableObject {

        public string contentName;

        public GameObject prefab;

        public int factoryIndex;

        //public int materialId;

        //public Material material;

        public int tileSizeX, tileSizeY, tileSizeZ;

        public Vector3 SnapToGridPosition (Vector3 currentPos, float tileSize) {

            float xComp = 0f;
            float yComp = 0f;
            float zComp = 0f;

            if (tileSizeX % 2 != 0) {
                xComp = 0.5f;
            }
            if (tileSizeY % 2 != 0) {
                yComp = 0.5f;
            }
            if (tileSizeZ % 2 != 0) {
                zComp = 0.5f;
            }

            float snapX = tileSize * Mathf.Round(currentPos.x / tileSize) + xComp;
            float snapY = tileSize * Mathf.Round(currentPos.y / tileSize) + yComp;
            float snapZ = tileSize * Mathf.Round(currentPos.z / tileSize) + zComp;

            return new Vector3(snapX, snapY, snapZ);
        }
   
}
