using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Map Info")]
    [System.Serializable]
    public class MapInfo : ScriptableObject
    {
            /// <summary>
            /// How many tiles in the map (x & y)
            /// </summary>
            [SerializeField]
            public Vector2Int mapSize;
            /// <summary>
            /// How many different height level can the map have
            /// </summary>
            [SerializeField]
            public int mapHeight;
            /// <summary>
            /// Chance to have a rock instead of sand (between 0 and 1)
            /// </summary>
            [SerializeField]
            public float rockChance;
            /// <summary>
            /// At what height level does the water start
            /// </summary>
            [SerializeField]
            public int waterInitialLevel;
    }
}
