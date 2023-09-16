using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is used to make the alien ship drop bombs
public class DropTheBomb : MonoBehaviour
{

    [SerializeField] private GameObject alienBombPrefab;
    [SerializeField] private Transform dropPosition;

    private AudioManager am;

    private void Start()
    {
        am = FindObjectOfType<AudioManager>();
        am.BindSoundToGameObjectLocation(name: "ufo-hover", gameObject: gameObject);
        am.Play("ufo-hover");
    }

    private void Update()
    {
        DropBomb();
    }

    void DropBomb()
    {
        // Instantiate the alienBombPrefab at dropPosition with a random rotation / angle
        // Only if there are less than GameManager.CurrentLevel + 1 prefabs already in the scene
        // This will make the game challenging as the level increases

        GameObject[] existingBombs = GameObject.FindGameObjectsWithTag("AlienBomb");

        if (existingBombs.Length < GameManager.CurrentLevel + 1)
        {
            GameObject alienBomb = Instantiate(alienBombPrefab, dropPosition.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            alienBomb.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            am.BindSoundToGameObjectLocation(name: "ufo-shoot", gameObject: alienBomb);
            am.Play("ufo-shoot");

            // Destroy the alienBombPrefab after 1 second
            Destroy(alienBomb, 2f);
        }

    }
}
