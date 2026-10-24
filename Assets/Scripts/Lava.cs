using.System.Collections;
using.System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Lava : MonoBehaviour
{
    public Slider Health;
    
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Health.value = Health.value - 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
