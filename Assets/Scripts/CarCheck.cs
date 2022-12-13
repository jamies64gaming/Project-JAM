using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCheck : MonoBehaviour
{

    [SerializeField] Transform car;

    [SerializeField] Transform wave;

    [SerializeField] GameObject wastedUI;

    private bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (car.position.z <= wave.position.z+3.5)
        {
            wastedUI.SetActive(true);
            gameOver = true;
        }
        
    }

    public void Restart()
    {
        SceneManager.LoadScene("Main");
    }
}
