using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

[ExecuteInEditMode]
public class TerrainGenerator : MonoBehaviour
{
    [SerializeField] private SpriteShapeController spriteShapeController;
    [SerializeField, Range(3f, 100f)] private int levelLength = 100;
    [SerializeField, Range(1f, 50f)] private float horizontalStretch = 2f;
    [SerializeField, Range(1f, 50f)] private float verticalStretch = 2f;
    [SerializeField, Range(0f, 1f)] private float curveSmoothness = 0.5f;

    [SerializeField] private float noiseStep = 0.5f;
    [SerializeField] private float terrainBottom = 10f;

    private Vector3 lastPosition;

    private void OnValidate()
    {
        ClearSpline();
        GenerateTerrain();
        CloseTerrainShape();
    }

    private void ClearSpline()
    {
        spriteShapeController.spline.Clear();
    }

    private void GenerateTerrain()
    {
        for (int i = 0; i < levelLength; i++)
        {
            GenerateTerrainPoint(i);
            SetTerrainCurvature(i);
        }
    }

    private void GenerateTerrainPoint(int i)
    {
        lastPosition = transform.position + new Vector3(i * horizontalStretch, CalculateNoise(i) * verticalStretch);
        spriteShapeController.spline.InsertPointAt(i, lastPosition);
    }

    private float CalculateNoise(int i)
    {
        return Mathf.PerlinNoise(0, i * noiseStep);
    }

    private void SetTerrainCurvature(int i)
    {
        if (i != 0 && i != levelLength - 1)
        {
            spriteShapeController.spline.SetTangentMode(i, ShapeTangentMode.Continuous);
            spriteShapeController.spline.SetLeftTangent(i, Vector3.left * horizontalStretch * curveSmoothness);
            spriteShapeController.spline.SetRightTangent(i, Vector3.right * horizontalStretch * curveSmoothness);
        }
    }

    private void CloseTerrainShape()
    {
        spriteShapeController.spline.InsertPointAt(levelLength, new Vector3(lastPosition.x, transform.position.y - terrainBottom));
        spriteShapeController.spline.InsertPointAt(levelLength + 1, new Vector3(transform.position.x, transform.position.y - terrainBottom));
    }
}
