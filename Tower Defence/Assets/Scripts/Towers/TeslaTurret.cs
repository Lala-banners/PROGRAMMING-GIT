using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TowerDefence.Utilities;

//Always start new tower script with namespace and abstract class
namespace TowerDefence.Towers
{
    public class TeslaTurret : Tower
    {
        #region Variables
        [Header("Telsa Bebe Specs")]
        [SerializeField]
        private Transform ball;
        [SerializeField]
        private LineRenderer lightningLine;
        [SerializeField, Range(1, 10), Tooltip("The amount of segments within a line to the enemy.")]
        private int segments;
        [SerializeField, Range(0.01f, 0.25f), Tooltip("The maximum amount of offset a segment can have.")]
        private float maxVariance = 0.25f;

        private int recursionIndex = 0;
        #endregion

       
        protected override void RenderAttackVisuals()
        {
            recursionIndex = 0;

            MathUtils.DistanceAndDirection(out float distance, out Vector3 direction, ball, TargetedEnemy.transform);

            //Generate the List of segments points from the ball to the targeted enemy
            List<Vector3> segmentPoints = new List<Vector3>();
            for (int i = 0; i < segments; i++)
            {
                //Vector3.Lerp (from, to, factor)
                segmentPoints.Add(ball.position + direction * ((distance / segments) * i));
            }
            //Add enemy position as one more point
            segmentPoints.Add(TargetedEnemy.transform.position);

            //Render the points onto the lightning
            RenderLightning(segmentPoints, direction);
            lightningLine.SetPosition(0, segmentPoints[0]);

            lightningLine.SetPosition(segments, segmentPoints[segmentPoints.Count - 1]);
        }

        protected override void RenderLevelUpVisuals()
        {
            
        }

        /// <summary>
        /// Render the lightning beam from the ball to the targeted enemy.
        /// </summary>
        /// <param name="_positions">All segments in the list.</param>
        /// <param name="_direction">Direction of segments.</param>
        private void RenderLightning(List<Vector3> _positions, Vector3 _direction)
        {
            //Making the position equal segments
            lightningLine.positionCount = segments;

            Vector3 newDir = Vector3.Cross(_direction, _positions[recursionIndex]);

            _positions[recursionIndex] += newDir * Random.Range(-maxVariance, maxVariance);
            lightningLine.SetPosition(recursionIndex, _positions[recursionIndex]);

            //Recurse into the function is possible
            recursionIndex++;
            if (recursionIndex < segments - 1)
            {
                RenderLightning(_positions, _direction);
            }
        }
    }

}

