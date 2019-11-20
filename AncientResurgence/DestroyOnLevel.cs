using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyOnLevel : MonoBehaviour
{
    public float delay = 0.0f;
    public string level;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == level)
        {
            DestroyThisBeforeTunnel();
        }
    }

    public void DestroyThisBeforeTunnel()
    {
        Destroy(this.gameObject);
    }
}