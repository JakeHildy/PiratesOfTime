using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Control;
using RPG.Movement;

namespace RPG.Core
{
    public class Spawner : MonoBehaviour
    {

        [SerializeField] Transform[] spawnLocations;
        [SerializeField] [Range(0, 60)] float spawnRateMin = 8f;
        [SerializeField] [Range(0, 60)] float spawnRateMax = 8f;
        [SerializeField] GameObject objectPrefab;
        [SerializeField] PatrolPath patrolPath;

        private float timeSinceLastSpawn = Mathf.Infinity;
        private float spawnRate;

        // Start is called before the first frame update
        void Start()
        {
            SetSpawnRate();
        }

        // Update is called once per frame
        void Update()
        {
            if (timeSinceLastSpawn > spawnRate)
            {
                timeSinceLastSpawn = 0;
                SetSpawnRate();
                SpawnGameObject();
            }
            timeSinceLastSpawn += Time.deltaTime;
        }

        private void SpawnGameObject()
        {
            GameObject gameObject;
            Transform spawnLocation = PickSpawnLocation();
            gameObject = Instantiate(objectPrefab, spawnLocation.position, spawnLocation.rotation) as GameObject;
            if (gameObject.GetComponent<AIController>())
            {
                gameObject.GetComponent<AIController>().SetPatrolPath(patrolPath);
            }
        }

        private Transform PickSpawnLocation()
        {
            return spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Length)];
        }

        private void SetSpawnRate()
        {
            spawnRate = UnityEngine.Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}

