using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace CastleCrabers.ScriptableObjects {
    [CreateAssetMenu(menuName = "Scriptable Objects/Crab Stats")]
    public class CrabStats : ScriptableObject
    {

        /// <summary>
        /// Crab walking speed in case per second
        /// </summary>
        [SerializeField]
        public float speed;

        /// <summary>
        /// Time the crab can breath underwater, in seconds
        /// </summary>
        [SerializeField]
        public float breathingCapacity;
    }
}
