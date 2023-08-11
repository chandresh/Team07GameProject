using UnityEngine;
using UnityEngine.U2D;

public class TerrainGenerator : MonoBehaviour
{
    // The controller that manipulates the Sprite Shape's spline
    [SerializeField] private SpriteShapeController spriteShapeController;

    // Length of the level in world units
    [SerializeField, Range(3f, 500f)] private int levelLength = 100;

    // Controls the horizontal stretch of the terrain
    [SerializeField, Range(1f, 50f)] private float horizontalStretch = 2f;

    // Controls the vertical stretch of the terrain
    [SerializeField, Range(1f, 50f)] private float verticalStretch = 2f;

    // Controls the smoothness of the curves in the terrain
    [SerializeField, Range(0f, 1f)] private float curveSmoothness = 0.5f;

    // Step size for Perlin noise
    [SerializeField] private float noiseStep = 0.5f;

    // Distance from the base of the terrain to the bottom of the world
    [SerializeField] private float terrainBottom = 10f;

    // Stores the position of the last generated terrain point
    private Vector3 lastPosition;

    // Called when the script is loaded or a value is changed in the inspector
    private void OnValidate()
    {
        ClearSpline(); // Clears the spline before generating a new terrain
        GenerateTerrain(); // Generates the terrain
        CloseTerrainShape(); // Closes off the terrain shape at the bottom
    }

    // Clears all points from the spline
    private void ClearSpline()
    {
        spriteShapeController.spline.Clear();
    }

    // Generates the terrain by creating a series of points along the spline
    private void GenerateTerrain()
    {
        for (int i = 0; i < levelLength; i++)
        {
            GenerateTerrainPoint(i); // Generates a point along the terrain
            SetTerrainCurvature(i); // Sets the curvature of the terrain at the generated point
        }
    }

    // Generates a terrain point at the given index and inserts it into the spline
    private void GenerateTerrainPoint(int i)
    {
        lastPosition = transform.position + new Vector3(i * horizontalStretch, CalculateNoise(i) * verticalStretch);
        spriteShapeController.spline.InsertPointAt(i, lastPosition);
    }

    // Calculates a noise value for the given index
    private float CalculateNoise(int i)
    {
        float perlinValue = Mathf.PerlinNoise(0, i * noiseStep);
        float sinValue = Mathf.Sin(i * noiseStep);
        return perlinValue * sinValue;
    }

    // Sets the curvature of the terrain at the given index
    private void SetTerrainCurvature(int i)
    {
        if (i != 0 && i != levelLength - 1)
        {
            spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteShapeController.spline.SetLeftTangent(i, Vector3.left * horizontalStretch * curveSmoothness);
            spriteShapeController.spline.SetRightTangent(i, Vector3.right * horizontalStretch * curveSmoothness);
        }
    }

    // Closes off the terrain shape by adding points at the bottom
    private void CloseTerrainShape()
    {
        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPosition.x, transform.position.y - terrainBottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - terrainBottom));
    }

}
