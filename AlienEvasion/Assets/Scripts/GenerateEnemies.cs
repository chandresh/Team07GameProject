/*
Randomly generates enemies in the game.
Will later use AI to generate enemies based on player's level.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    [SerializeField] GameObject enemyShipPrefab;
    [SerializeField] GameObject[] enemyPrefabs;

    [SerializeField] private float enemySpawnDistance = 12f;
    [SerializeField] private float enemyShipSpawnDistance = 22f;

    [SerializeField] private float enemyPositionY = 10f;
    [SerializeField] private float enemyShipPositionY = 3.76f;

    [SerializeField] private LayerMask terrainLayer;



    // Create enemies at a certain distance from the player
    void InstantiateEnemiesOfType(GameObject prefab, float positionY, float spawnDistance)
    {
        Vector3 checkPosition = new Vector3(Camera.main.transform.position.x + spawnDistance, 50, 0);
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, 100, terrainLayer);

        if (hit.collider != null)
        {
            float terrainHeight = hit.point.y;
            // Debug.Log("Terrain height " + spawnDistance + " meters away is: " + terrainHeight);

            Vector3 spawnPosition = new Vector3(transform.position.x + spawnDistance, positionY + hit.point.y, 0);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            GameObject randomEnemy = enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Length)];
            InstantiateEnemiesOfType(randomEnemy, enemyPositionY, enemySpawnDistance);
        }

        GameObject[] enemyShips = GameObject.FindGameObjectsWithTag("EnemyShip");

        if (enemyShips.Length == 0)
        {
            InstantiateEnemiesOfType(enemyShipPrefab, enemyShipPositionY, enemyShipSpawnDistance);
        }

        foreach (GameObject enemyShip in enemyShips)
        {
            if (enemyShip.transform.position.x < Camera.main.transform.position.x - 5) // If the enemyShip is off-screen
            {
                InstantiateEnemiesOfType(enemyShipPrefab, enemyShipPositionY, enemyShipSpawnDistance);
                Destroy(enemyShip); // Destroy the current off-screen enemyShip
            }
        }
    }


}
