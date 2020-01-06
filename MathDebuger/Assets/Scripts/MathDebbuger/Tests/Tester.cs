using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
public class Tester : MonoBehaviour
{
    void Start()
    {

        VectorDebugger.EnableCoordinates();
        List<Vector3> vectors = new List<Vector3>();
        vectors.Add(new Vec3(10.0f, 0.0f, 0.0f));
        vectors.Add(new Vec3(10.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 20.0f, 0.0f));
        VectorDebugger.AddVectorsSecuence(vectors, false, Color.red, "secuencia");
        VectorDebugger.AddVector(new Vector3(10, 10, 0), Color.blue, "elAzul");
        VectorDebugger.AddVector(Vector3.down * 7, Color.green, "elVerde");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            StartCoroutine(UpdateVector());
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            VectorDebugger.TurnOffVector("elAzul");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            VectorDebugger.TurnOnVector("elAzul");
        }
    }

    IEnumerator UpdateVector()
    {
        while(true)
        {
            List<Vector3> vectors = new List<Vector3>();
            for (int j = 0; j < VectorDebugger.GetVectorsPositions("secuencia").Count; j++)
            {
                vectors.Add(Quaternion.Euler(new Vec3(0.0f, 1.0f, 0.0f)) * VectorDebugger.GetVectorsPositions("secuencia")[j]);
            }
            VectorDebugger.UpdatePositionsSecuence("secuencia", vectors);
            yield return null;
        }
    }

}
