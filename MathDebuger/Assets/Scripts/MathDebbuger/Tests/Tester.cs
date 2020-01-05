using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MathDebbuger;
using CustomMath;
public class Tester : MonoBehaviour
{
    void Start()
    {
        List<Vector3> vectors = new List<Vector3>();
        vectors.Add(new Vec3(10.0f, 0.0f, 0.0f));
        vectors.Add(new Vec3(10.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 10.0f, 0.0f));
        vectors.Add(new Vec3(20.0f, 20.0f, 0.0f));
        Vector3Debugger.AddVectorsSecuence(vectors, false, Color.red, "secuencia");
        Vector3Debugger.EnableEditorView("secuencia");
        Vector3Debugger.AddVector(new Vector3(10, 10, 0), Color.blue, "elAzul");
        Vector3Debugger.EnableEditorView("elAzul");
        Vector3Debugger.AddVector(Vector3.down * 7, Color.green, "elVerde");
        Vector3Debugger.EnableEditorView("elVerde");

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
            Vector3Debugger.TurnOffVector("elAzul");
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Vector3Debugger.TurnOnVector("elAzul");
        }
    }

    IEnumerator UpdateVector()
    {
        for (float i = 0.0f; i <= 360.0f; i += 1.0f)
        {
            List<Vector3> vectors = new List<Vector3>();
            for (int j = 0; j < Vector3Debugger.GetVectorsPositions("secuencia").Count; j++)
            {
                vectors.Add(Quaternion.Euler(new Vec3(0.0f, 1.0f, 0.0f)) * Vector3Debugger.GetVectorsPositions("secuencia")[j]);
            }
            Vector3Debugger.UpdatePositionsSecuence("secuencia", vectors);
            yield return null;
        }
    }

}
