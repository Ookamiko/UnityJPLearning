using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;

    private float r, g, b, a;
    private float scale;

    private float changeR;
    private float changeG;
    private float changeB;
    private float changeA;
    private float changeScale;

    private float minScale;
    private float maxScale;

    private bool decreaseR, decreaseG, decreaseB, decreaseA = false;
    private bool decreaseScale = false;

    private int rotationX, rotationY, rotationZ;

    private Material material;
    void Start()
    {
        material = Renderer.material;

        changeR = Random.Range(0.05f, 0.25f);
        changeG = Random.Range(0.05f, 0.25f);
        changeB = Random.Range(0.05f, 0.25f);
        changeA = Random.Range(0.01f, 0.1f);

        minScale = Random.Range(0.5f, 1);
        maxScale = Random.Range(1.5f, 3);
        changeScale = Random.Range(0.01f, 0.25f);

        r = 0;
        g = 0;
        b = 0;
        a = 0;

        scale = minScale;

        transform.localScale = Vector3.one * scale;
        material.color = new Color(r, g, b, a);

        rotationX = Random.Range(1, 11);
        rotationY = Random.Range(1, 11);
        rotationZ = Random.Range(1, 11);
    }

    void Update()
    {
        r += (decreaseR ? -1 : 1) * changeR * Time.deltaTime;
        if (r < 0) { r = 0; decreaseR = false; }
        else if (r > 1) { r = 1; decreaseR = true; }

        g += (decreaseG ? -1 : 1) * changeG * Time.deltaTime;
        if (g < 0) { g = 0; decreaseG = false; }
        else if (g > 1) { g = 1; decreaseG = true; }

        b += (decreaseB ? -1 : 1) * changeB * Time.deltaTime;
        if (b < 0) { b = 0; decreaseB = false; }
        else if (b > 1) { b = 1; decreaseB = true; }

        a += (decreaseA ? -1 : 1) * changeA * Time.deltaTime;
        if (a < 0) { a = 0; decreaseA = false; }
        else if (a > 1) { a = 1; decreaseA = true; }

        material.color = new Color(r, g, b, a);

        scale += (decreaseScale ? -1 : 1) * changeScale * Time.deltaTime;
        if (scale < minScale) { scale = minScale; decreaseScale = false; }
        else if (scale > maxScale) { scale = maxScale; decreaseScale = true; }

        transform.localScale = Vector3.one * scale;

        transform.Rotate(rotationX * Time.deltaTime, rotationY * Time.deltaTime, rotationZ * Time.deltaTime);
    }
}
