using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseShape : MonoBehaviour
{
    private GameManager gameManager;

    protected TextMeshProUGUI shapeText;
    protected Transform canvasBuildedSchema;

    private GameObject panelSchema;

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
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        position3Shapes = new List<float>() { -1, 0, 1 };
        position4Shapes = new List<float>() { -1.5f, -0.5f, 0.5f, 1.5f };
        position5Shapes = new List<float>() { -2, -1, 0, 1, 2 };
        position6Shapes = new List<float>() { -2.5f, -1.5f, 0.5f, 0.5f, 1.5f, 2.5f };
        position7Shapes = new List<float>() { -3, -2, -1, 0, 1, 2, 3 };

        schemaPositionToFill = 0;

        panelSchema = GameObject.Find("PanelSchema");

        
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
                        foreach (Transform child in panelSchema.transform)
                        {
                            GameObject.Destroy(child.gameObject);
                        }
                        currentSchemaList.Clear();
                        // Panel screen red pop 0.2s
                        StartCoroutine(CoroutineSetPanelRed());
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
                StartCoroutine(CoroutineSetPanelGreen());
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


    public IEnumerator CoroutineSetPanelRed()
    {
        Debug.Log("ici1?");
        gameManager.redScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameManager.redScreen.SetActive(false);
        Debug.Log("ici2?");
    }

    public IEnumerator CoroutineSetPanelGreen()
    {
        gameManager.greenScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameManager.greenScreen.SetActive(false);
    }

}
