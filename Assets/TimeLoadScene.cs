using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLoadScene : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int idScene;

    private void Start()
    {
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene(idScene);
    }
}
