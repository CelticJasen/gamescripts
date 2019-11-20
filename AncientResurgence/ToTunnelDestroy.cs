using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToTunnelDestroy : MonoBehaviour
{
    public float delay = 0.0f;

    // Use this for initialization
    void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (SceneManager.GetActiveScene().name == "DemoTunnel")
        {
            DestroyThisBeforeTunnel();
        }
	}

    public void DestroyThisBeforeTunnel()
    {
        Destroy(this.gameObject);
    }
}