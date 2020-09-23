using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefence.Utilities
{
    //Common math functions here :(
    public class MathUtils
    {
        /// <summary>
        /// OutParams give info in and within the function you set them, then they come out
        /// </summary>
        /// <param name="_distance"></param>
        /// <param name="_direction"></param>
        /// <param name="_from"></param>
        /// <param name="_to"></param>
        public static void DistanceAndDirection(out float _distance, out Vector3 _direction, Transform _from, Transform _to)
        {
            Vector3 heading = _to.position - _from.position;
            _distance = heading.magnitude; //Magnitude is length of distance
            _direction = heading.normalized; //Vector has length of 1 because of normalized
        }
    }
}


