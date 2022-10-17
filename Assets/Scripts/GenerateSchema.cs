using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateSchema : MonoBehaviour
{
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

        canvasImgTransform = transform.Find("Canvas"); 
        Debug.Log("transform canvas: " + canvasImgTransform.position);

        float canvasSize = canvasImgTransform.GetComponent<RectTransform>().rect.width;
        Debug.Log("size canvas: " + canvasSize);

        gameManager.newSchemaList = spawnManager.SpawnRandomSchemaInGame();

        // todo: depends of a param in SpawnManager.cs
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

        StartCoroutine(CoroutinePanelGrey());

        GenerateShapeInGame();
    }

    public IEnumerator CoroutinePanelGrey()
    {
        yield return new WaitForSeconds(4.5f);
        gameManager.panelShapesUIGrey.SetActive(false);
    }

    void GenerateShapeInGame()
    {
        for (int i = gameManager.newSchemaList.Count-1; i > -1; i--)
        {
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
