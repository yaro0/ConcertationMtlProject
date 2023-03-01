# ConcertationMtlProject: Alice in Code Land

## Credits
- Programming: Yaroslava Kost
- Art: Heba Jawad, Kaitlin May Wong, Yaroslava Kost
- Sound: Kaitlin May Wong

## Motivation
We build this game with the intention of creating a unique and fun way for people to learn the idea and basics of coding. It is amed towards complete beginners but can be fun for anyone.

## Build Status
The game is currently in a demo status with two functionnal levels.
This allows us to get our idea accross and show off some key mechanics.

## Features
- Two playable levels.
- Opening story cutscene
- Dialogue in all levels
- Hints from Bunny character
- Ambient music
- 1st level: 
- character is falling and the player must avoid obstacle for a certain amount of time.
- 2nd level:
- Player must find a way to fit Alice through a door. 
- Player realizes that it needs to change lines of code to change the width of the door.

## Screenshots
First Level
![gamePhoto2](https://user-images.githubusercontent.com/93663497/222021585-e53d2fc3-07f5-41e6-8213-a52d5c3ee7f7.PNG)
![gamePhoto3](https://user-images.githubusercontent.com/93663497/222021596-2bd930b8-a3cb-4174-b16a-d1a2b0c30a99.PNG)

Second Level
![gamePhoto4](https://user-images.githubusercontent.com/93663497/222021608-e6539643-715d-4aaf-a9d3-eb6f592a0096.PNG)
![gamePhoto5](https://user-images.githubusercontent.com/93663497/222021615-95d80044-e209-469a-ace3-3ad0fe4c9506.PNG)

## Coding
We used C# and unity to code the game.

## Example of code:
Code that is behind the "fake code" in level two
```
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
```
## How to play
The game is still in the making but you can play the current demo on itch.io : https://yaro0.itch.io/alice-in-code-land
