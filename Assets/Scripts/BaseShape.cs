using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseShape : MonoBehaviour
{
    private GameManager gameManager;
    private MoveInCenter moveInCenter;

    protected TextMeshProUGUI shapeText;
    protected Transform canvasBuildedSchema;

    private GameObject panelSchema;

    public static List<string> bf_shapeList = new List<string>() { "Gr", "Bl", "Ye", "Wh", "Re", "Pi", "Or", "Pu", "Cy" };

    public List<string> shapeList
    {
        get { return bf_shapeList; }
    }

    private GameObject generateSchema;

    public List<float> position3Shapes { get; private set; }
    public List<float> position4Shapes { get; private set; }
    public List<float> position5Shapes { get; private set; }
    public List<float> position6Shapes { get; private set; }
    public List<float> position7Shapes { get; private set; }

    
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveInCenter = FindObjectOfType<MoveInCenter>().gameObject.GetComponent<MoveInCenter>();

        position3Shapes = new List<float>() { -1, 0, 1 };
        position4Shapes = new List<float>() { -1.5f, -0.5f, 0.5f, 1.5f };
        position5Shapes = new List<float>() { -2, -1, 0, 1, 2 };
        position6Shapes = new List<float>() { -2.5f, -1.5f, 0.5f, 0.5f, 1.5f, 2.5f };
        position7Shapes = new List<float>() { -3, -2, -1, 0, 1, 2, 3 };

        panelSchema = GameObject.Find("PanelSchema");
        
        shapeText = GameObject.Find("ShapeText").GetComponent<TextMeshProUGUI>();
        canvasBuildedSchema = transform.parent.transform.Find("PanelSchema");
    }

    private void Update()
    {
        generateSchema = FindObjectOfType<GenerateSchema>().gameObject;
        Debug.Log("POSITION TO FILL: " + gameManager.schemaPositionToFill);

        string tmpPrint = "";
        for (int i = 0; i < gameManager.currentSchemaList.Count; i++)
        {
            tmpPrint += " " + gameManager.currentSchemaList[i];
        }
        Debug.Log("CURRENT SCHEMA LIST: "+ tmpPrint);

        string tmpPrint2 = "";
        for (int i = 0; i < gameManager.newSchemaList.Count; i++)
        {
            tmpPrint2 += " " + gameManager.newSchemaList[i];
        }
        Debug.Log("SCHEMA TO REPRODUCE: " + tmpPrint2);

        if (gameManager.schemaPositionToFill == 3)
        {
            gameManager.schemaPositionToFill = 0;

            bool isSchemaTrue = false;

            if (gameManager.currentSchemaList.Count == gameManager.newSchemaList.Count)
            {
                isSchemaTrue = true;
                for (int i = 0; i < gameManager.currentSchemaList.Count; i++)
                {
                    if (gameManager.currentSchemaList[i] != gameManager.newSchemaList[i])
                    {
                        isSchemaTrue = false;
                        foreach (Transform child in panelSchema.transform)
                        {
                            GameObject.Destroy(child.gameObject);
                        }
                        gameManager.currentSchemaList.Clear();
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
                gameManager.currentSchemaList.Clear();

                gameManager.moveTile = true;

                // Panel screen green pop 0.2s
                StartCoroutine(CoroutineSetPanelGreen());

                gameManager.panelShapesUIGrey.SetActive(true);
            }
        }
    }

    public virtual void DisplayOnScreen()
    {
        Debug.Log("baseShape.DisplayOnScreen");
    }

    public virtual void GenerateShape()
    {
        Debug.Log("baseShape.GenerateShape");
    }

    public void BuildShapeGenerated(GameObject shape, string idShape)
    {
        shape.transform.localPosition += new Vector3(position3Shapes[gameManager.schemaPositionToFill] * 50, 0, 0);
        gameManager.schemaPositionToFill++;
        gameManager.currentSchemaList.Add(idShape);
    }


    public IEnumerator CoroutineSetPanelRed()
    {
        gameManager.redScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameManager.redScreen.SetActive(false);
    }

    public IEnumerator CoroutineSetPanelGreen()
    {
        gameManager.greenScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameManager.greenScreen.SetActive(false);
    }

}
