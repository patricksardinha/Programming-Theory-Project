using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseShape : MonoBehaviour
{
    protected TextMeshProUGUI shapeText;
    protected Transform canvasBuildedSchema;

    private GameObject panelSchema;
    private GameObject panelGreen;
    private GameObject panelRed;

    public int schemaPositionToFill;

    public static List<string> bf_shapeList = new List<string>() { "Gr", "Bl", "Ye", "Wh", "Re", "Pi", "Or", "Pu", "Cy" };
    //public static List<string> bf_shapeList = new List<string>() { "Bl", "Bl", "Bl", "Bl", "Bl", "Bl", "Bl", "Bl", "Bl" };

    public List<string> shapeList
    {
        get { return bf_shapeList; }
    }

    private GameObject generateSchema;

    public List<string> currentSchemaList = new List<string>();

    public List<float> position3Shapes { get; private set; }
    public List<float> position4Shapes { get; private set; }
    public List<float> position5Shapes { get; private set; }
    public List<float> position6Shapes { get; private set; }
    public List<float> position7Shapes { get; private set; }

    private void Start()
    {
        position3Shapes = new List<float>() { -1, 0, 1 };
        position4Shapes = new List<float>() { -1.5f, -0.5f, 0.5f, 1.5f };
        position5Shapes = new List<float>() { -2, -1, 0, 1, 2 };
        position6Shapes = new List<float>() { -2.5f, -1.5f, 0.5f, 0.5f, 1.5f, 2.5f };
        position7Shapes = new List<float>() { -3, -2, -1, 0, 1, 2, 3 };

        schemaPositionToFill = 0;

        panelSchema = GameObject.Find("PanelSchema");
        panelGreen = GameObject.Find("GreenScreen");
        panelRed = GameObject.Find("RedScreen");


        Debug.Log("---------->" + panelGreen);

        shapeText = GameObject.Find("ShapeText").GetComponent<TextMeshProUGUI>();
        canvasBuildedSchema = transform.parent.transform.Find("PanelSchema");
        Debug.Log("la: "+ canvasBuildedSchema);
    }

    private void Update()
    {

        generateSchema = FindObjectOfType<GenerateSchema>().gameObject;

        if (schemaPositionToFill == 3)
        {
            schemaPositionToFill = 0;

            bool isSchemaTrue = false;

            if (currentSchemaList.Count == generateSchema.GetComponent<GenerateSchema>().newSchemaList.Count)
            {
                isSchemaTrue = true;
                for (int i = 0; i < currentSchemaList.Count; i++)
                {
                    if (currentSchemaList[i] != generateSchema.GetComponent<GenerateSchema>().newSchemaList[i])
                    {
                        isSchemaTrue = false;
                        // Panel screen red pop 0.2s
                        panelRed.SetActive(true);
                        Invoke("SetInactivePanelRed", 0.2f);
                    }
                }
            }

            if (isSchemaTrue)
            {
                foreach (Transform child in panelSchema.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                currentSchemaList.Clear();
                // Panel screen green pop 0.2s
                panelGreen.SetActive(true);
                Invoke("SetInactivePanelGreen", 0.2f);
            }
        }
    }

    public virtual void DisplayOnScreen()
    {
        shapeText.text = "";
        Debug.Log("baseShape.DisplayOnScreen");
    }

    public virtual void GenerateShape()
    {
        Debug.Log("baseShape.GenerateShape");
    }


    public void SetInactivePanelRed()
    {
        panelRed.SetActive(false);
    }

    public void SetInactivePanelGreen()
    {
        panelGreen.SetActive(false);
    }

}
