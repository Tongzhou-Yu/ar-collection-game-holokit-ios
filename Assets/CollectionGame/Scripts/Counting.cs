using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counting : MonoBehaviour
{
    public Camera mainCamera;
    public float fieldSize = 2f;
    [HideInInspector]
    public int collectedObjects = 0;
    private GameObject currentSphere;
    public Text collectedObjectsText;
    public GameObject targetPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // Create cube
        GameObject field = GameObject.CreatePrimitive(PrimitiveType.Cube);
        field.name = "field";
        field.transform.position = mainCamera.transform.position;
        field.transform.localScale = new Vector3(fieldSize, fieldSize, fieldSize);
        field.GetComponent<Renderer>().enabled = false;
        field.GetComponent<BoxCollider>().enabled = false;

        CreateSphere();
    }

    // Update is called once per frame
    void Update()
    {
        collectedObjectsText.text = "收集到:" + collectedObjects.ToString() + "个";
        if (currentSphere == null)
        {
            CreateSphere();
        }
    }

    public void CreateSphere()
    {
        Vector3 spherePos = new Vector3(Random.Range(-fieldSize / 2f, fieldSize / 2f), Random.Range(-fieldSize / 2f, fieldSize / 2f), Random.Range(-fieldSize / 2f, fieldSize / 2f));
        currentSphere = Instantiate(targetPrefab, spherePos, Quaternion.identity);
        currentSphere.name = "currentSphere";
        currentSphere.transform.parent = GameObject.Find("field").transform;
        currentSphere.transform.localScale = new Vector3(1f, 1f, 1f);
        currentSphere.AddComponent<SphereCollider>().isTrigger = true;
        currentSphere.AddComponent<Rigidbody>().useGravity = false;
        currentSphere.AddComponent<CollectibleSphere>().collection = this;
    }
}

public class CollectibleSphere : MonoBehaviour
{
    public Counting collection;

    private void OnMouseDown()
    {
        collection.collectedObjects++;
        Destroy(gameObject);
    }
}