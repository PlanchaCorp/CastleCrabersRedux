using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using CastleCrabers.ScriptableObjects;


namespace CastleCrabers.World {
    [RequireComponent(typeof(Grid))]
    public class IslandBuilder : MonoBehaviour
    {
        [SerializeField]
        private IslandGenerator islandGenerator;
        [SerializeField]
        private GeneratedMapData generatedMapData;
        [SerializeField]
        private Tilemap terrainTilemap;
        [SerializeField]
        private Tilemap waterTilemap;

        public void Start() {
            generatedMapData.tiles = islandGenerator.Generate(terrainTilemap, waterTilemap);
        }

    }
}
