using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public string pieceStatus = "";

    public Transform edgeParticles;

    public KeyCode placePiece;
    public KeyCode returntoinv;
    public string checkPlacement = "";

    public float yDiff;
    public Vector2 invPos;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        invControl();

        if (pieceStatus == "pickedup")
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;

        }
        if ((Input.GetKeyDown(placePiece)) && (pieceStatus == "pickedup")) //queremos que sea yes s�lo cuando clickemos y el rat�n est� cerca del socket
        {
            checkPlacement = "y";
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == gameObject.name)
        {
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            Instantiate(edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);
        }
    }
    void onTriggerStay2D(Collider2D other)
    {
        if ((other.gameObject.name == gameObject.name) && (checkPlacement == "y"))
        {
            other.GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            transform.position = other.gameObject.transform.position;
            pieceStatus = "locked";
            Instantiate(edgeParticles, other.gameObject.transform.position, edgeParticles.rotation);
            checkPlacement = "n";
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        if ((other.gameObject.name != gameObject.name) && (checkPlacement == "y"))
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            checkPlacement = "n";
        }
    }
    void OnMouseDown()
    {
        pieceStatus = "pickedup";
        checkPlacement = "n";
        // GetComponent<Renderer> ().sortingOrder = 0;
        invPos = transform.position;

    }
    void invControl()
    {
        if ((Input.GetAxis("Mouse ScrollWheel") > 0) && (pieceStatus != "locked"))
        {
            transform.position = new Vector2(8.04f, transform.position.y - 1.2f);
            yDiff -= 1.2f;
        }
        if ((Input.GetAxis("Mouse ScrollWheel") < 0) && (pieceStatus != "locked"))
        {
            transform.position = new Vector2(8.04f, transform.position.y + 1.2f);
            yDiff += 1.2f;
        }
        if ((Input.GetKeyDown(returntoinv)) && (pieceStatus == "pickedup"))
        {
            transform.position = new Vector2(8.04f, invPos.y + yDiff);
            pieceStatus = "";
        }
    }



}
