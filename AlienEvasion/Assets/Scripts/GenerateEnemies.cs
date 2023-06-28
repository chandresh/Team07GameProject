/*
Randomly generates enemies in the game.
Will later use AI to generate enemies based on player's level.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab, enemyShipPrefab;

    [SerializeField] private float enemySpawnDistance = 12f;
    [SerializeField] private float enemyShipSpawnDistance = 22f;

    [SerializeField] private float enemyPositionY = 10f;
    [SerializeField] private float enemyShipPositionY = 3.76f;

    [SerializeField] private LayerMask terrainLayer;


    void InstantiateEnemiesOfType(GameObject prefab, float positionY, float spawnDistance)
    {
        Vector3 checkPosition = new Vector3(Camera.main.transform.position.x + spawnDistance, 50, 0);
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, 100, terrainLayer);

        if (hit.collider != null)
        {
            float terrainHeight = hit.point.y;
            Debug.Log("Terrain height " + spawnDistance + " meters away is: " + terrainHeight);

            Vector3 spawnPosition = new Vector3(transform.position.x + spawnDistance, positionY + hit.point.y, 0);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }

    // Used for debugging for terrain height
    void checkTerrainHeight(float spawnDistance)
    {
        // check height using main camera
        Vector3 checkPosition = new Vector3(Camera.main.transform.position.x + spawnDistance, 50, 0);
        RaycastHit2D hit = Physics2D.Raycast(checkPosition, Vector2.down, 100, terrainLayer);

        // Generate a debug ray
        // Debug.DrawRay(checkPosition, Vector2.down * 100, Color.red);

        if (hit.collider != null)
        {
            float terrainHeight = hit.point.y;
            Debug.Log("Terrain height " + spawnDistance + " meters away is: " + terrainHeight);

            Vector3 spawnPosition = new Vector3(transform.position.x + spawnDistance, enemyShipPositionY + hit.point.y, 0);
        }
    }


    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length == 0)
        {
            InstantiateEnemiesOfType(enemyPrefab, enemyPositionY, enemySpawnDistance);
        }

        foreach (GameObject enemy in enemies)
        {
            if (enemy.transform.position.x < transform.position.x - 5) // If the enemy is off-screen
            {
                InstantiateEnemiesOfType(enemyPrefab, enemyPositionY, enemySpawnDistance);
                Destroy(enemy); // Destroy the current off-screen enemy
            }
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
