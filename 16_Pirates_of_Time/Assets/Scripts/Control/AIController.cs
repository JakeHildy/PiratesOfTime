using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Movement;
using RPG.Core;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] [Range(0, 1)] float patrolSpeedFraction = 0.2f;
        [SerializeField] float waypointDwellTime = 3f;
        [SerializeField] float waypointTolerance = 1f;

        Mover mover;
        Health health;

        Vector3 guardPosition;

        float timeSinceArrivedAtWaypoint = Mathf.Infinity;
        int currentWaypointIndex = 0;


        // Start is called before the first frame update
        void Start()
        {
            mover = GetComponent<Mover>();
            health = GetComponent<Health>();
            guardPosition = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            if (health.IsDead()) return;
            PatrolBehaviour();
            UpdateTimers();
        }

        public void SetPatrolPath(PatrolPath path)
        {
            patrolPath = path;
        }


        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardPosition;

            if (patrolPath != null)
            {
                if (AtWaypoint())
                {
                    timeSinceArrivedAtWaypoint = 0;
                    CycleWaypoint();
                }
                nextPosition = GetCurrentWaypoint();

            }
            if (timeSinceArrivedAtWaypoint > waypointDwellTime)
            {
                mover.StartMoveAction(nextPosition, patrolSpeedFraction);
            }
        }

        private bool AtWaypoint()
        {

            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());
            return distanceToWaypoint < waypointTolerance;
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private void UpdateTimers()
        {
            //timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArrivedAtWaypoint += Time.deltaTime;
        }
    }
}



