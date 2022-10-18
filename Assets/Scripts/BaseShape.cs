using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// INHERITANCE - Parent class
public class BaseShape : MonoBehaviour
{
    private GameManager gameManager;
    private MoveInCenter moveInCenter;

    protected TextMeshProUGUI shapeText;
    protected Transform canvasBuildedSchema;

    private GameObject panelSchema;

    public static List<string> bf_shapeList = new List<string>() { "Gr", "Bl", "Ye", "Wh", "Re", "Pi", "Or", "Pu", "Cy" };
    
    private GameObject generateSchema;

    // ENCAPSULATION
    public List<string> shapeList
    {
        get { return bf_shapeList; }
    }

    public List<float> position3Shapes { get; private set; }
    public List<float> position4Shapes { get; private set; }
    public List<float> position5Shapes { get; private set; }
    public List<float> position6Shapes { get; private set; }
    public List<float> position7Shapes { get; private set; }
    
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        moveInCenter = FindObjectOfType<MoveInCenter>().gameObject.GetComponent<MoveInCenter>();

        // Define different list of position for schemas
        position3Shapes = new List<float>() { -1, 0, 1 };
        position4Shapes = new List<float>() { -1.5f, -0.5f, 0.5f, 1.5f };
        position5Shapes = new List<float>() { -2, -1, 0, 1, 2 };
        position6Shapes = new List<float>() { -2.5f, -1.5f, 0.5f, 0.5f, 1.5f, 2.5f };
        position7Shapes = new List<float>() { -3, -2, -1, 0, 1, 2, 3 };

        // Get the panel where construct the current schema
        panelSchema = GameObject.Find("PanelSchema");
        
        shapeText = GameObject.Find("ShapeText").GetComponent<TextMeshProUGUI>();
        canvasBuildedSchema = transform.parent.transform.Find("PanelSchema");
    }

    private void Update()
    {
        generateSchema = FindObjectOfType<GenerateSchema>().gameObject;
        Debug.Log("POSITION TO FILL: " + gameManager.schemaPositionToFill);

        // Debug section
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

        // Check if the player builded a correct length schema (the length varies according the score) & also check if
        // the length is valid
        if (gameManager.schemaPositionToFill == gameManager.newSchemaList.Count && gameManager.schemaPositionToFill != 0)
        {
            // Reset the position to fill at 0
            gameManager.schemaPositionToFill = 0;

            // Set the boolean which check the schema as false
            bool isSchemaTrue = false;

            // Double Check the length
            if (gameManager.currentSchemaList.Count == gameManager.newSchemaList.Count)
            {
                // Set the boolean as true until a difference between shapes in the two schemas (current & to reproduce) is found
                isSchemaTrue = true;

                // For all element try to find a difference: if there is a difference so set the boolean as false
                for (int i = 0; i < gameManager.currentSchemaList.Count; i++)
                {
                    if (gameManager.currentSchemaList[i] != gameManager.newSchemaList[i])
                    {
                        isSchemaTrue = false;
                        // Destroy all shapes in the panel
                        foreach (Transform child in panelSchema.transform)
                        {
                            GameObject.Destroy(child.gameObject);
                        }

                        // Clear the builded schema
                        gameManager.currentSchemaList.Clear();

                        // Display quickly a red screen to indicates the error
                        StartCoroutine(CoroutineSetPanelRed());

                        // Reset the multiplier score as 1
                        gameManager.multiplierScore = 1;
                    }
                }
            }

            // Case where the builded schema is correct (no differences)
            if (isSchemaTrue)
            {
                // Destroy shapes in the panel
                foreach (Transform child in panelSchema.transform)
                {
                    GameObject.Destroy(child.gameObject);
                }
                // Clear also the builded schema
                gameManager.currentSchemaList.Clear();

                // Move a tile to enable the character walking on the running path (not falling which implies a game over) 
                gameManager.moveTile = true;

                // Display quickly a green screen to indicates the victory
                StartCoroutine(CoroutineSetPanelGreen());

                // Incrase the score multiplier by 1
                gameManager.multiplierScore += 1;

                // Disable shapes to click at the bottom until a new schema is generated & behind the player
                gameManager.panelShapesUIGrey.SetActive(true);
            }
        }
    }

    // POLYMORPHISM
    public virtual void DisplayOnScreen()
    {
        Debug.Log("baseShape.DisplayOnScreen");
    }

    // POLYMORPHISM
    public virtual void GenerateShape()
    {
        Debug.Log("baseShape.GenerateShape");
    }

    // ABSTRACTION
    public void BuildShapeGenerated(GameObject shape, string idShape)
    {
        // According the difficulty, generate correctly the builded schema by the player
        if (gameManager.difficultyScore == 3)
        {
            shape.transform.localPosition += new Vector3(position3Shapes[gameManager.schemaPositionToFill] * 50, 0, 0);
        }
        else if (gameManager.difficultyScore == 4)
        {
            shape.transform.localPosition += new Vector3(position4Shapes[gameManager.schemaPositionToFill] * 50, 0, 0);
        }
        else if (gameManager.difficultyScore == 5)
        {
            shape.transform.localPosition += new Vector3(position5Shapes[gameManager.schemaPositionToFill] * 50, 0, 0);
        }
        else if (gameManager.difficultyScore == 6)
        {
            shape.transform.localPosition += new Vector3(position6Shapes[gameManager.schemaPositionToFill] * 50, 0, 0);
        }
        else if (gameManager.difficultyScore == 7)
        {
            shape.transform.localPosition += new Vector3(position7Shapes[gameManager.schemaPositionToFill] * 50, 0, 0);
        }

        // Increase the position to build each time
        gameManager.schemaPositionToFill++;

        // Add the id related to the shape in the current schema variable
        gameManager.currentSchemaList.Add(idShape);
    }


    // Coroutine to manage the red screen
    public IEnumerator CoroutineSetPanelRed()
    {
        gameManager.redScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameManager.redScreen.SetActive(false);
    }

    // Coroutine to manage the green screen
    public IEnumerator CoroutineSetPanelGreen()
    {
        gameManager.greenScreen.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        gameManager.greenScreen.SetActive(false);
    }

}
