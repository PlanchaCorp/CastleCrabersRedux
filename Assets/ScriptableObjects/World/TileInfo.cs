using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CastleCrabers.ScriptableObjects {
    public enum TileType {
        SAND = 1,
        ROCK = 2
    }

    public class TileInfo : ScriptableObject
    {
        [SerializeField]
        public TileType type;
        [SerializeField]
        public int height;
        [SerializeField]
        public bool isSubmersed;

        public TileInfo(TileType type, int height, bool isSubmersed) {
            this.type = type;
            this.height = height;
            this.isSubmersed = isSubmersed;
        }
    }
}
