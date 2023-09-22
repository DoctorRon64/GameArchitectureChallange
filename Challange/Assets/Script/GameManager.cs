using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] List<GameObject> prefabActors = new List<GameObject>();
	[SerializeField] private Transform emptySpanwer;
	[SerializeField] private Vector2 startArea = Vector2.zero;
	[SerializeField] private Vector2 endArea = Vector2.zero;
	[SerializeField] private float stepsAmount = 1f;

    private void Awake()
	{
		//KIJK HIER AUB NIET NAAR DIT WAS EEN QUICK PROTOTYPE IK WIL HIER LATER EEN BETER DESIGN VOOR MAKEN

		emptySpanwer.transform.position = startArea;

		for (int i = 0; i < 100; i++)
		{
			if (emptySpanwer.transform.position.y >= endArea.y)
			{
				if (emptySpanwer.transform.position.x <= endArea.x)
				{
					emptySpanwer.transform.position = new Vector2(emptySpanwer.transform.position.x + stepsAmount, emptySpanwer.transform.position.y);
					Instantiate(prefabActors[Random.Range(0, prefabActors.Count)], emptySpanwer.transform.position, Quaternion.identity);
				}
				else
				{
					emptySpanwer.transform.position = new Vector2(emptySpanwer.transform.position.x, emptySpanwer.transform.position.y - stepsAmount);
					Instantiate(prefabActors[Random.Range(0, prefabActors.Count)], emptySpanwer.transform.position, Quaternion.identity);
				}
			}
		}
	}
}