using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Shape[] objectsToSpawn;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private float secondsBetweenSpawns;
    [SerializeField] private string[] possibleNames;

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        // this coroutine will spawn a new random shape with a random name and a random color every 3 seconds placing them in the next spawn position in order each time.
        int spawnPos = 0;
        while (true)
        {
            Shape obj = Instantiate(objectsToSpawn[UnityEngine.Random.Range(0, objectsToSpawn.Length)], spawnPositions[spawnPos].position, spawnPositions[spawnPos].rotation, spawnPositions[spawnPos]).GetComponent<Shape>();
            spawnPos = (spawnPos + 1) % spawnPositions.Length;

            obj.Name = possibleNames[UnityEngine.Random.Range(0, possibleNames.Length)];

            Array values = Enum.GetValues(typeof(ShapeColor));
            ShapeColor randomColor = (ShapeColor)values.GetValue(UnityEngine.Random.Range(0, values.Length));
            obj.Color = randomColor;

            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
