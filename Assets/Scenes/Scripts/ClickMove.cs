using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ClickMove : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector3 target;

    public Flowchart flowchart;
    // Start is called before the first frame update
    void Start()
    {
        target = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Variable hero = flowchart.GetVariable("ActiveHero");

        if (hero.GetValue().Equals(true)) {
            if (Input.GetMouseButtonDown(0))
            {
                target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                target.z = transform.position.z;
                target.y = transform.position.y;
            }
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

    }
}
