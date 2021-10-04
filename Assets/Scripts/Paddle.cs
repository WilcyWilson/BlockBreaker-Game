using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration parameters
    //[SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float maxX=15f;
    [SerializeField] float minX=1f;
    // Start is called before the first frame update

    //cache references
    GameSession theGameSession;
    Ball theBall;

    void Start()
    {
        theGameSession = FindObjectOfType<GameSession>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 padddlePos = new Vector2(transform.position.x, transform.position.y);
        padddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = padddlePos;
    }



    private float GetXPos()
    {
        if (theGameSession.IsAutoPlayEnabled()) 
        {
            return theBall.transform.position.x; 
        }
        else
        {
            return KeyboardControl();
            //return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
        
    }
    private float KeyboardControl()
    {
        float paddlePos;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            paddlePos = transform.position.x - (Time.deltaTime * 12f);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            paddlePos = transform.position.x + (Time.deltaTime * 12f);
        }
        else
        {
            paddlePos = transform.position.x;
        }
        return paddlePos;
    }

}
