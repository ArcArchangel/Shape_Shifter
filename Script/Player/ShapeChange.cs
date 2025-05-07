using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeChange : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject spherePrefab;
    public GameObject rectanglePrefab;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;
    private void Awake()
    {
        // Grab references for rigidbody and animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Keypad4))
            {
                Cube();
                gameObject.tag = "Cube";
            }

        if (Input.GetKey(KeyCode.Keypad5))
            {
                Sphere();
                gameObject.tag = "Player";
            }

        if (Input.GetKey(KeyCode.Keypad6))
            {
                Plate();
                gameObject.tag = "Rectangle";
            }
    }

    private void Cube()
    {
        anim.SetTrigger("cube");
        GameObject cubePrefab1 = cubePrefab;
    }

    private void Sphere()
    {
        anim.SetTrigger("sphere");
        GameObject spherePrefab1 = spherePrefab;
    }

    private void Plate()
    {
        anim.SetTrigger("plate");
        GameObject rectanglePrefab1 = rectanglePrefab;
    }
}
