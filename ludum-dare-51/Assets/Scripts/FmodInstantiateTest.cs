using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FmodInstantiateTest : MonoBehaviour
{
    [SerializeField]
    private GameObject circlePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            InstantiteDummyCircle(mouse);
        }
    }

    void InstantiteDummyCircle(Vector3 position)
    {
        position.z = 0;
        GameObject circle = GameObject.Instantiate(circlePrefab, position, Quaternion.identity);
    }
}
