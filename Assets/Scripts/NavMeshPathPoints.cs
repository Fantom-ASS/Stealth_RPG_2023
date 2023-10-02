using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshPathPoints : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float lineWidth = 0.2f;
    public NavMeshAgent agent;
    public List<Vector3> pathPoints = new List<Vector3>();
    public Vector3 attackPoint;
    public float attackRange; //диста
    public GameObject mark; //де стане наша кулька - сугубо декоративний момент
    public Renderer myRenderer;
    public Vector2 newTiling;


    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
        myRenderer = GetComponent<Renderer>();
        lineRenderer.startWidth = lineWidth;
        lineRenderer.endWidth = lineWidth;
        newTiling = new Vector2(3, 3);

    }

    private void Update()
    {
        
        if (agent.hasPath)
        {
            GetPathPoints();
        }
        if (agent.pathPending)
            return;

        DrawPath(agent.path);
        if (myRenderer != null && myRenderer.material != null)
        {
            // Change the material's tiling.
            myRenderer.material.mainTextureScale = newTiling;
        }

    }


    private void GetPathPoints()
    {
        pathPoints.Clear();
        NavMeshPath path = agent.path;

        for (int i = 0; i < path.corners.Length; i++)
        {     
            pathPoints.Add(path.corners[i]);
        }
        float distance = Vector3.Distance(pathPoints[pathPoints.Count-2], pathPoints[pathPoints.Count - 1]);
        //Vector3 vectorBetween = pathPoints[pathPoints.Count - 2] - pathPoints[pathPoints.Count - 1];
        Debug.Log(distance);
        if (attackRange>=distance) { attackPoint = pathPoints[pathPoints.Count - 2]; } else
        {
            attackPoint = Vector3.Lerp(pathPoints[pathPoints.Count - 1], pathPoints[pathPoints.Count - 2], attackRange/distance);
        }
        mark.transform.position = attackPoint;
        //newTiling = new Vector2(1/distance, 1/distance);
        myRenderer.material.mainTextureScale = newTiling;
        //myRenderer.material.SetTextureScale("_EmissionMap", newTiling);

    }

    // You can expose a method to retrieve the path points from other scripts.
    public List<Vector3> GetPathPointsList()
    {
        return pathPoints;
    }

    private void DrawPath(NavMeshPath path)
    {
        if (path.corners.Length < 2)
            return;

        lineRenderer.positionCount = path.corners.Length;
        lineRenderer.SetPositions(path.corners);
    }
}