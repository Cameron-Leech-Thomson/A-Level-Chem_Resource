using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading; //Allows use of TextReader function & StreamReader function.
using System.IO;       //Allows use of TextReader function & StreamReader function.
using System.Linq;    //Allows use of File.ReadLines extensions.
using Random = System.Random; //Allows use of creating random integers.

public class MiniGame : MonoBehaviour
{
    public GameObject Term1;
    public GameObject Term2;
    public GameObject Term3;
    public GameObject Term4;

    public Button T1Button;
    public Button T2Button;
    public Button T3Button;
    public Button T4Button;

    public GameObject Definition1;
    public GameObject Definition2;
    public GameObject Definition3;
    public GameObject Definition4;

    public Button Def1Button;
    public Button Def2Button;
    public Button Def3Button;
    public Button Def4Button;

    public int Joiner1;
    public int Joiner2;
    public int Joiner3;
    public int Joiner4;

    Random rnd = new Random();

    public int LowBound;
    public int HighBound;

    public string Topic;

    private void OnEnable() //The function will be called once the panel is opened.
    {
        string TermsPath = @"D:\Documents\Computing Project\Terms.txt"; //Saves the path to find the .txt with all of the terms in it.
        string DefPath = @"D:\Documents\Computing Project\Definitions.txt"; //Saves the path to find the .txt with all of the definitions in it.

        string[] Terms = File.ReadAllLines(TermsPath); //Reads all the lines in the 2 files.
        string[] Definitions = File.ReadAllLines(DefPath);

        switch (Topic)
        {
            case "Atomic Structure":
                LowBound = 1;
                HighBound = 15;
                break;
            case "AoS":
                LowBound = 16;
                HighBound = 18;
                break;
            case "Bonding":
                LowBound = 18;
                HighBound = 29;
                break;
            case "Energetics":
                LowBound = 30;
                HighBound = 44;
                break;
            case "Kinetics":
                LowBound = 45;
                HighBound = 61;
                break;
            case "Equilibria":
                LowBound = 61;
                HighBound = 78;
                break;
            case "Oxidation":
                LowBound = 78;
                HighBound = 88;
                break;
            case "Periodicity":
                LowBound = 89;
                HighBound = 95;
                break;
            case "Group 2":
                LowBound = 95;
                HighBound = 103;
                break;
            case "Group 7":
                LowBound = 104;
                HighBound = 116;
                break;
            case "OrganicIntro":
                LowBound = 117;
                HighBound = 125;
                break;
            case "Alkanes":
                LowBound = 126;
                HighBound = 138;
                break;
            case "Halogenoalkanes":
                LowBound = 139;
                HighBound = 151;
                break;
            case "Alkenes":
                LowBound = 152;
                HighBound = 169;
                break;
            case "Alcohols":
                LowBound = 170;
                HighBound = 183;
                break;
            case "Analysis":
                LowBound = 184;
                HighBound = 191;
                break;
            default:
                break;
        }

        Text Term1Text = Term1.GetComponentInChildren<Text>(); //Creates a varaible for the text component of the buttons.
        Text Term2Text = Term2.GetComponentInChildren<Text>();
        Text Term3Text = Term3.GetComponentInChildren<Text>();
        Text Term4Text = Term4.GetComponentInChildren<Text>();

        Text Definition1Text = Definition1.GetComponentInChildren<Text>(); //Creates a varaible for the text component of the buttons.
        Text Definition2Text = Definition2.GetComponentInChildren<Text>();
        Text Definition3Text = Definition3.GetComponentInChildren<Text>();
        Text Definition4Text = Definition4.GetComponentInChildren<Text>();        

        int i1 = rnd.Next(LowBound, HighBound - 1);
        Term1Text.text = Terms.GetValue(i1).ToString(); //Sets the value of the button text to the term.        
        Remove(ref Terms, Term1Text.text); //Removes the value from the array.

        int i2 = rnd.Next(LowBound, HighBound - 1);
        Term2Text.text = Terms.GetValue(i2).ToString();
        Remove(ref Terms, Term2Text.text);

        int i3 = rnd.Next(LowBound, HighBound - 1);
        Term3Text.text = Terms.GetValue(i3).ToString();
        Remove(ref Terms, Term3Text.text);

        int i4 = rnd.Next(LowBound, HighBound - 1);
        Term4Text.text = Terms.GetValue(i4).ToString();
        Remove(ref Terms, Term4Text.text);

        var Positions = Enumerable.Range(1, 4).OrderBy(x => rnd.Next()).ToArray(); //Generates the sequence 1,2,3,4 and then shuffles it randomly.

        int Pos1 = Convert.ToInt16(Positions.GetValue(0));
        int Pos2 = Convert.ToInt16(Positions.GetValue(1));
        int Pos3 = Convert.ToInt16(Positions.GetValue(2));
        int Pos4 = Convert.ToInt16(Positions.GetValue(3));

        switch (Pos1)
        {
            case 1:
                Definition1Text.text = Definitions.GetValue(i1).ToString();
                Joiner1 = 1;
                break;
            case 2:
                Definition1Text.text = Definitions.GetValue(i2).ToString();
                Joiner1 = 2;
                break;
            case 3:
                Definition1Text.text = Definitions.GetValue(i3).ToString();
                Joiner1 = 3;
                break;
            case 4:
                Definition1Text.text = Definitions.GetValue(i4).ToString();
                Joiner1 = 4;
                break;
            default:
                break;
        }

        switch (Pos2)
        {
            case 1:
                Definition2Text.text = Definitions.GetValue(i1).ToString();
                Joiner2 = 1;
                break;
            case 2:
                Definition2Text.text = Definitions.GetValue(i2).ToString();
                Joiner2 = 2;
                break;
            case 3:
                Definition2Text.text = Definitions.GetValue(i3).ToString();
                Joiner2 = 3;
                break;
            case 4:
                Definition2Text.text = Definitions.GetValue(i4).ToString();
                Joiner2 = 4;
                break;
            default:
                break;
        }

        switch (Pos3)
        {
            case 1:
                Definition3Text.text = Definitions.GetValue(i1).ToString();
                Joiner3 = 1;
                break;
            case 2:
                Definition3Text.text = Definitions.GetValue(i2).ToString();
                Joiner3 = 2;
                break;
            case 3:
                Definition3Text.text = Definitions.GetValue(i3).ToString();
                Joiner3 = 3;
                break;
            case 4:
                Definition3Text.text = Definitions.GetValue(i4).ToString();
                Joiner3 = 4;
                break;
            default:
                break;
        }

        switch (Pos4)
        {
            case 1:
                Definition4Text.text = Definitions.GetValue(i1).ToString();
                Joiner4 = 1;
                break;
            case 2:
                Definition4Text.text = Definitions.GetValue(i2).ToString();
                Joiner4 = 2;
                break;
            case 3:
                Definition4Text.text = Definitions.GetValue(i3).ToString();
                Joiner4 = 3;
                break;
            case 4:
                Definition4Text.text = Definitions.GetValue(i4).ToString();
                Joiner4 = 4;
                break;
            default:
                break;
        }
    }

    public void Pair1() //For Term1 & its definition.
    {
        Def1Button = Definition1.GetComponent<Button>(); //Retrieves the Button component from the gameobjects.
        Def2Button = Definition2.GetComponent<Button>();
        Def3Button = Definition3.GetComponent<Button>();
        Def4Button = Definition4.GetComponent<Button>();

        T1Button = Term1.GetComponent<Button>();
        T2Button = Term2.GetComponent<Button>();
        T3Button = Term3.GetComponent<Button>();
        T4Button = Term4.GetComponent<Button>();

        switch (Joiner1)
        {
            case 1:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 2:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 3:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            default:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                break;
        }
    }
    public void Pair2() //For Term2 & its definition.
    {
        Def1Button = Definition1.GetComponent<Button>(); //Retrieves the Button component from the gameobjects.
        Def2Button = Definition2.GetComponent<Button>();
        Def3Button = Definition3.GetComponent<Button>();
        Def4Button = Definition4.GetComponent<Button>();

        T1Button = Term1.GetComponent<Button>();
        T2Button = Term2.GetComponent<Button>();
        T3Button = Term3.GetComponent<Button>();
        T4Button = Term4.GetComponent<Button>();

        switch (Joiner2)
        {
            case 1:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 2:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 3:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            default:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                break;
        }
    }
    public void Pair3() //For Term3 & its definition.
    {
        Def1Button = Definition1.GetComponent<Button>(); //Retrieves the Button component from the gameobjects.
        Def2Button = Definition2.GetComponent<Button>();
        Def3Button = Definition3.GetComponent<Button>();
        Def4Button = Definition4.GetComponent<Button>();

        T1Button = Term1.GetComponent<Button>();
        T2Button = Term2.GetComponent<Button>();
        T3Button = Term3.GetComponent<Button>();
        T4Button = Term4.GetComponent<Button>();

        switch (Joiner3)
        {
            case 1:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 2:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 3:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            default:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                break;
        }
    }
    public void Pair4() //For Term4 & its definition.
    {
        Def1Button = Definition1.GetComponent<Button>(); //Retrieves the Button component from the gameobjects.
        Def2Button = Definition2.GetComponent<Button>();
        Def3Button = Definition3.GetComponent<Button>();
        Def4Button = Definition4.GetComponent<Button>();

        T1Button = Term1.GetComponent<Button>();
        T2Button = Term2.GetComponent<Button>();
        T3Button = Term3.GetComponent<Button>();
        T4Button = Term4.GetComponent<Button>();

        switch (Joiner4)
        {
            case 1:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go green to show the correct item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 2:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            case 3:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                break;
            default:
                if (Def1Button.isActiveAndEnabled == true)
                {
                    Def1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go green to show the wrong item has been selected.
                }
                else if (Def2Button.isActiveAndEnabled == true)
                {
                    Def2Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def3Button.isActiveAndEnabled == true)
                {
                    Def3Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                    T1Button.GetComponent<Image>().color = Color.red; //Makes the button go red to show the wrong item has been selected.
                }
                else if (Def4Button.isActiveAndEnabled == true)
                {
                    Def4Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                    T1Button.GetComponent<Image>().color = Color.green; //Makes the button go red to show the right item has been selected.
                }
                break;
        }
    }

    public void Remove<T>(ref T[] array, string RemoveVal) //A function to remove a value from an array.
    {
        int Index = Array.IndexOf(array, RemoveVal); //Finds the index of the value it is trying to remove.
        array = array.Where((val, idx) => idx != Index).ToArray(); //Removes the value.
    }

}
    //Graveyard
    // int Pos1 = 0;
    // int Pos2 = 0;
    // int Pos3 = 0;
    // int Pos4 = 0;
    // int[] Pos = { 1, 2, 3, 4 }; //An array that allows a search to happen to make sure a position isn't taken.
    //
    // while (Pos.Length != 0)
    //       {
    //if (Pos1 != 0) //Makes sure that if Pos1 has already been chosen, it isnt overwritten.
    //  {
    // Pos1 = rnd.Next(1, 4); //Generates a value for Pos1 between the available numbers in the list.
    // Remove(ref Pos, Pos1.ToString());
    //  }
    //else { }
    //
    //if (Pos2 != 0) //Makes sure that if Pos2 has already been chosen, it isnt overwritten.
    //           {
    // Pos2 = rnd.Next(1, 4); //Generates a value for Pos2 between the available numbers in the list.
    // (Pos.Contains(Pos2) == true) //If the value is still in the list
    //              {
    // Remove(ref Pos, Pos2.ToString()); //Save it and remove.
    //               }
    // { } //If not, wait for the next iteration.
    //           }
    //            else { }
    //
    //            if (Pos3 != 0) //Makes sure that if Pos2 has already been chosen, it isnt overwritten.
    //            {
    //Pos3 = rnd.Next(1, 4); //Generates a value for Pos2 between the available numbers in the list.
    //           if (Pos.Contains(Pos3) == true) //If the value is still in the list
    //         {
    //move(ref Pos, Pos3.ToString()); //Save it and remove.

    //               else { } //If not, wait for the next iteration.

//           else { }

//          if (Pos4 != 0) //Makes sure that if Pos2 has already been chosen, it isnt overwritten.
//           {
//Pos4 = rnd.Next(1,4); //Generates a value for Pos2 between the available numbers in the list.
//                if (Pos.Contains(Pos4) == true) //If the value is still in the list
//               {
//Remove(ref Pos, Pos4.ToString()); //Save it and remove.
//               }
//               else { } //If not, wait for the next iteration.
//            }
//           else { }
//       }
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//int Pos11 = 0;
//int Pos22 = 0;
//int Pos33 = 0;
//int Pos44 = 0;

//int[] Poss = { 1, 2, 3, 4 }; //An array that allows a search to happen to make sure a position isn't taken.

// while (Pos1 == 0)
//{
//Pos1 = rnd.Next(Pos.First() - 1, Pos.Last() + 1); //Generates a value for Pos1 between the available numbers in the list.
//Remove(ref Pos, Pos1.ToString());
//      }
//   while (Pos2 == 0)
//   {
//Pos2 = rnd.Next(Pos.First() - 1, Pos.Last() + 1); //Generates a value for Pos2 between the available numbers in the list.
//Remove(ref Pos, Pos2.ToString());
//  }
//      while (Pos3 == 0)
//  {
//        Pos3 = rnd.Next(Pos.First() - 1, Pos.Last() + 1); //Generates a value for Pos3 between the available numbers in the list.
//       Remove(ref Pos, Pos3.ToString());
//  }
// while (Pos4 == 0)
//  {
//       Pos4 = rnd.Next(Pos.First() - 1, Pos.Last() + 1); //Generates a value for Pos4 between the available numbers in the list.
//        Remove(ref Pos, Pos4.ToString());



