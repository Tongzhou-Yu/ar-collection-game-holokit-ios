using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchGame : MonoBehaviour
{
    public Material touchMaterial;
    public GameObject touchBurst;
    private Counting collection;

    void Start()
    {
        touchMaterial.color = Color.blue;
        collection = GameObject.Find("Collection Manager").GetComponent<Counting>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "IndexTip")
        {
            touchMaterial.color = Color.red;
            this.GetComponent<AudioSource>().Play();
            GameObject touchFinger = GameObject.Find("IndexTip");
            GameObject newTouchBurst = Instantiate(touchBurst, touchFinger.transform.position, Quaternion.identity);
            float totalDuration = touchBurst.GetComponent<ParticleSystem>().main.duration;
            Destroy(newTouchBurst, totalDuration);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "IndexTip")
        {
            collection.collectedObjects++;
            Destroy(this.gameObject.transform.parent.gameObject);
        }
    }
}
