using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCheck : MonoBehaviour
{

    [SerializeField] Transform car;
    [SerializeField] Transform wave;

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
