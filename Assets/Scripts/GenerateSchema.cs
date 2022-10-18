using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSchema : MonoBehaviour
{
    // Get texture images for the shapes
    public GameObject greenTexture;
    public GameObject blueTexture;
    public GameObject yellowTexture;
    public GameObject whiteTexture;
    public GameObject redTexture;
    public GameObject pinkTexture;
    public GameObject orangeTexture;
    public GameObject purpleTexture;
    public GameObject cyanTexture;

    public Transform canvasImgTransform;

    private float positionToFill;

    private SpawnManager spawnManager;
    private GameManager gameManager;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        // Find the canvas in the map to generate the schema
        canvasImgTransform = transform.Find("Canvas"); 

        // Get its size
        float canvasSize = canvasImgTransform.GetComponent<RectTransform>().rect.width;

        // Spawn the new schema
        gameManager.newSchemaList = spawnManager.SpawnRandomSchemaInGame();

        // Depending the difficulty set up the position to fill
        if (gameManager.difficultyScore == 3)
        {
            positionToFill = -1;
        }
        else if (gameManager.difficultyScore == 4)
        {
            positionToFill = -1.5f;
        }
        else if (gameManager.difficultyScore == 5)
        {
            positionToFill = -2;
        }
        else if (gameManager.difficultyScore == 6)
        {
            positionToFill = -2.5f;
        }
        else if (gameManager.difficultyScore == 7)
        {
            positionToFill = -3;
        }

        // Disable the shape buttons for a short moment
        StartCoroutine(CoroutinePanelGrey());

        // Then generate shapes
        GenerateShapeInGame();
    }

    // Coroutine disable buttons
    public IEnumerator CoroutinePanelGrey()
    {
        yield return new WaitForSeconds(4.5f);
        gameManager.panelShapesUIGrey.SetActive(false);
    }

    void GenerateShapeInGame()
    {
        // Display each shapes in the schema on the panel in game
        for (int i = gameManager.newSchemaList.Count-1; i > -1; i--)
        {
            // Switch case according to the shape ids
            switch (gameManager.newSchemaList[i])
            {
                case "Gr":
                    GameObject grShape = Instantiate(greenTexture, canvasImgTransform);
                    grShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    grShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Bl":
                    GameObject blShape = Instantiate(blueTexture, canvasImgTransform);
                    blShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    blShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Ye":
                    GameObject yeShape = Instantiate(yellowTexture, canvasImgTransform);
                    yeShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    yeShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Wh":
                    GameObject whShape = Instantiate(whiteTexture, canvasImgTransform);
                    whShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    whShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Re":
                    GameObject reShape = Instantiate(redTexture, canvasImgTransform);
                    reShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    reShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Pi":
                    GameObject piShape = Instantiate(pinkTexture, canvasImgTransform);
                    piShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    piShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Or":
                    GameObject orShape = Instantiate(orangeTexture, canvasImgTransform);
                    orShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    orShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Pu":
                    GameObject puShape = Instantiate(purpleTexture, canvasImgTransform);
                    puShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    puShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                case "Cy":
                    GameObject cyShape = Instantiate(cyanTexture, canvasImgTransform);
                    cyShape.transform.localScale = new Vector3(1, 1, 1) / 40;
                    cyShape.transform.localPosition += new Vector3(positionToFill, 0, 0);
                    break;
                default:
                    Debug.Log("Error in Instantiate switch");
                    break;
            }
            positionToFill += 1;
        }
    }
}
