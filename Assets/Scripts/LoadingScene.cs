using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class LoadingScene : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(3f);
        GameManager.instance.LoadScene(1);
    }
}