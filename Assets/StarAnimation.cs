using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarAnimation : MonoBehaviour
{
    public GameObject[] stars;
    [SerializeField]
    private float delay;


    public void ShowStar(int starAmount)
    {
        StartCoroutine(StarAnim(starAmount));
    }
    private IEnumerator StarAnim(int PlayAmount)
    {
        for(int i = 0; i < PlayAmount; i++)
        {
            stars[i].SetActive(true);
            yield return new WaitForSeconds(delay);
        }
    }
}
