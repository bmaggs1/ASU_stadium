using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiScript : MonoBehaviour
{
    public GameObject objectToPlace;
    public GameObject button;
    public Vector3 placementPosition = new Vector3(794f, 6.2f, 347f);
    public float rotationAngleY = 146f; // Rotation angle around the y-axis
    public Vector3 objectScale = Vector3.one; // Scale of the object
    public GameObject[] uiInputFields;

    void Start()
    {
        for (int i = 0; i < uiInputFields.Length; i++)
        {
            uiInputFields[i].SetActive(false);
        }
    }

    public void PlaceObject()
    {
        GameObject placedObject = Instantiate(objectToPlace, placementPosition, Quaternion.identity);

        // Adjust rotation
        placedObject.transform.rotation = Quaternion.Euler(0f, rotationAngleY, 0f);

        // Adjust scale
        placedObject.transform.localScale = objectScale;

        //Delete button
        button.SetActive(false);

        //add input fields
        for (int i = 0; i < uiInputFields.Length; i++)
        {
            uiInputFields[i].SetActive(true);
        }
    }

    public void AddData()
    {
        double[] inputs = new double[10];
        int i = 0;
        foreach (GameObject uiElement in uiInputFields)
        {
            InputField inputField = uiElement.GetComponent<InputField>();
            
            // Parse the text value as a double and store it in the inputs array
            if (double.TryParse(inputField.text, out double parsedValue))
            {
                inputs[i] = parsedValue;
                i++;
            }
            else
            {
                Debug.LogError("Failed to parse input field text as double!");
            }
            inputField.text = "";
        }
        GameObject newCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newCube.transform.position = new Vector3((float)inputs[0], (float)inputs[1], (float)inputs[2]);
    }
}
