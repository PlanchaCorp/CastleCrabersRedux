using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using CastleCrabers.ScriptableObjects;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Island Generator")]
    public class IslandGenerator : ScriptableObject
    {
        [SerializeField]
        private HeightMapGenerator heightMapGenerator;
        [SerializeField]
        private MapInfo mapInfo;
        [SerializeField]
        private TilesVariable sandTiles;
        [SerializeField]
        private TilesVariable stoneTiles;
        [SerializeField]
        private AnimatedTile waterTile;

        public float seed;

        public TileInfo[,] Generate(Tilemap terrainTilemap, Tilemap waterTilemap) {
            seed = Random.Range(0, 9999);
            int[,] heightMap = heightMapGenerator.Generate(mapInfo, seed);
            TileInfo[,] tiles = new TileInfo[mapInfo.mapSize.x, mapInfo.mapSize.y];

            Vector2Int vectorPosition = Vector2Int.zero;
            for (int i = 0; i < mapInfo.mapSize.x; i++)
            {
                for (int j = 0; j < mapInfo.mapSize.y; j++)
                {
                    vectorPosition.x = mapInfo.mapSize.x / 2 - i;
                    vectorPosition.y = mapInfo.mapSize.y / 2 - j;

                    float xCoord = (i / (float) mapInfo.mapSize.x) * 17;
                    float yCoord = (j / (float) mapInfo.mapSize.y) * 17;

                    // Create a sand or a rock tile
                    Tile tile;
                    TileType tileType;
                    if (Mathf.PerlinNoise(xCoord + seed, yCoord + seed) > mapInfo.rockChance)
                    {
                        tile = sandTiles.tiles[heightMap[i, j]];
                        tileType = TileType.SAND;
                    }
                    else
                    {
                        tile = stoneTiles.tiles[heightMap[i, j]];
                        tileType = TileType.ROCK;
                    }

                    // Filling tilemaps and tile data
                    terrainTilemap.SetTile((Vector3Int)vectorPosition, tile);
                    if (heightMap[i, j] <= mapInfo.waterInitialLevel) {
                        waterTilemap.SetTile((Vector3Int)vectorPosition, waterTile);
                    }
                    tiles[i, j] = new TileInfo(tileType, heightMap[i, j], heightMap[i, j] <= mapInfo.waterInitialLevel);


                    // Create a decoration
                    // float rng = Random.Range(0, 20);
                    // if (rng < 1)
                    // {
                    //     List<Decoration> deco = decorations.Where(x => x.MinHeigth < map[i, j]).ToList();
                    //     if ( deco.Count > 0 )
                    //     {
                    //         decorationTileMap.SetTile(vectorPosition, deco[Random.Range(0, deco.Count - 1)].tile);
                    //     }
                    // }              
                }
            }

            return tiles;
        }
    }
}
