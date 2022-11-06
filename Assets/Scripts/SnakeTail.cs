using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    public float CircleDiametr;
    public Food Food;
    public Block Block;
    public int Health;
    public TextMeshProUGUI HealthText;


    private List<Transform> snakeCircles = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    void Start()
    {
        positions.Add(SnakeHead.position);
    }

    void Update()
    {
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;

        if (distance > CircleDiametr)
        {
            Vector3 direction = ((Vector3)SnakeHead.position - positions[0]).normalized;

            positions.Insert(0, positions[0] + direction * CircleDiametr);
            positions.RemoveAt(positions.Count - 1);

            distance -= CircleDiametr;
        }
        for (int i = 0; i < snakeCircles.Count; i++)
        {
            snakeCircles[i].position = Vector3.Lerp(positions[i+1], positions[i], distance / CircleDiametr);
        }
    }

    public void AddCircle()
    {
        //Health++;
        //HealthText.text = Health.ToString();
       Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1],Quaternion.identity, transform);
        snakeCircles.Add(circle);
        positions.Add(circle.position);
    }

   

    public void RemoveCircle()
    {
        int lastIndex = snakeCircles.Count - 1;

       if (snakeCircles.Count == 0)
        {
            Destroy(gameObject);
       }
       else
        {
            //Health--;
            //HealthText.text = Health.ToString();
            Destroy(snakeCircles[lastIndex].gameObject);
            snakeCircles.RemoveAt(lastIndex);
            positions.RemoveAt(lastIndex + 1);
        }
    }
}

