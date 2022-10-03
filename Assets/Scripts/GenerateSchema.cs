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

    private int positionToFill;

    private SpawnManager spawnManager;

    private List<string> newSchemaList;

    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        canvasImgTransform = transform.Find("Canvas");
        Debug.Log("transform canvas: " + canvasImgTransform.position);

        float canvasSize = canvasImgTransform.GetComponent<RectTransform>().rect.width;
        Debug.Log("size canvas: " + canvasSize);

        newSchemaList = spawnManager.SpawnRandomSchemaInGame();

        // todo: depends of a param in SpawnManager.cs
        positionToFill = -1;

        GenerateShapeInGame();
    }

    void GenerateShapeInGame()
    {
        for (int i = 0; i < newSchemaList.Count; i++)
        {
            switch (newSchemaList[i])
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