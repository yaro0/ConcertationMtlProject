using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputText : MonoBehaviour
{
    private string input1;
    private string input2;

    private Transform transform;

    public TMP_InputField inputField1;
    public TMP_InputField inputField2;
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        input1 = inputField1.GetComponent<TMP_InputField>().text;
        input2 = inputField2.GetComponent<TMP_InputField>().text;
        ReadStringInput(input1,"h");
        ReadStringInput(input2,"w");
    }
    
    

    public async void ReadStringInput(string input, string x)
    {
        //input = s;
        float numErreur = 0;
        bool valid = true;
        string scale = "";
        float scaleFloat;


        if (input.Length >= 2)
        {
            for (int i = 0; i <= input.Length - 2; i++)
            {
                valid = (char.IsDigit(input[i]) || input[i] == '.');

                if (valid)
                {
                    //Debug.Log(input + " is valid");
                    scale += input[i];
                }
                else if (!valid)
                {
                    numErreur++;
                }

            }

            if (!(input[input.Length - 1] == ';'))
            {
                numErreur++;
            }
        }
        
        else
        {
            numErreur++;
        }

        


        if (numErreur == 0 && x == "w")
        {
            //Debug.Log(input.Length);
            scaleFloat = float.Parse(scale);
            changeWidth(scaleFloat);
        }
        else if (numErreur == 0 && x == "h")
        {
            scaleFloat = float.Parse(scale);
            changeHeight(scaleFloat);
        }
        else if (numErreur != 0 && x == "w")
        {
            changeWidth(0);
        }
        else if (numErreur != 0 && x == "h")
        {
            changeHeight(0);
        }
    }

    public void changeWidth(float w)
    {
         float xScale = w / 40;
         transform.localScale = new Vector2(xScale, transform.localScale.y);

        //transform.position = new Vector2(transform.position.x, (float)(-3 + transform.localScale.y / 2));
        /*
        transform.localScale = new Vector2(w, transform.localScale.y);
        transform.position = new Vector2(transform.position.x, (float)(-3 + transform.localScale.y / 2));
        */
    }
    public void changeHeight(float h)
    {
        float yScale = h / 80;
         transform.localScale = new Vector2(transform.localScale.y, yScale);
         transform.position = new Vector2(transform.position.x, -2.873f);
        //transform.localScale = new Vector2(transform.localScale.x, h);

    }

}
