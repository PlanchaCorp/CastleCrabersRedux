using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CastleCrabers.ScriptableObjects;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Height Map Generator")]
    public class HeightMapGenerator : ScriptableObject
    {
        [SerializeField]
        public float coefficient;
        
        private MapInfo mapInfo;
        private float seed;

        public int[,] Generate(MapInfo mapInfo, float seed) {
            this.mapInfo = mapInfo;
            this.seed = seed;
            float[,] perlin = GeneratePerlin();
            return GaussianMask(perlin);
        }

        private int[,] GaussianMask(float[,] perlin)
        {
            int X0 = mapInfo.mapSize.x / 2;
            int Y0 = mapInfo.mapSize.y / 2;

            int[,] mask = new int[mapInfo.mapSize.x, mapInfo.mapSize.y];
            for (int x = 0; x < mapInfo.mapSize.x; x++)
            {
                for (int y = 0; y < mapInfo.mapSize.y; y++)
                {
                    mask[x, y] = Mathf.RoundToInt(perlin[x, y] * mapInfo.mapHeight * Mathf.Exp(-((x - X0) * (x - X0) + (y - Y0) * (y - Y0)) * coefficient));
                }
            }
            return mask;
        }

        /// <summary>
        /// Generate a perlin noise for a 64*64 map size
        /// </summary>
        /// <returns>an array with values between 0 and scale</returns>
        private float[,] GeneratePerlin()
        {
            float[,] map = new float[mapInfo.mapSize.x, mapInfo.mapSize.y];
            float y = 0.0F;

            while (y < mapInfo.mapSize.x)
            {
                float x = 0.0F;
                while (x < mapInfo.mapSize.y)
                {
                    float xCoord = x / mapInfo.mapSize.x * mapInfo.mapHeight;
                    float yCoord = y / mapInfo.mapSize.y * mapInfo.mapHeight;
                    map[(int)x, (int)y] = Mathf.PerlinNoise(seed + xCoord, seed + yCoord);

                    x++;
                }
                y++;
            }

            return map;

        }
    }
}
