using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading; //Allows use of TextReader function & StreamReader function.
using System.IO;       //Allows use of TextReader function & StreamReader function.
using System.Linq;    //Allows use of File.ReadLines extensions.

public class QuizScript : MonoBehaviour
{
    public static void Resize<T>(ref T[] array, int newSize) { } //Creates a function to change the size of an array to a set amount.

    public Text TextToChange; //Declares a text UI object to be linked to an existing one in the Unity editor, this is where the question is printed to.

    public GameObject NextButton; //Declares a button UI object to be linked to an existig one in the Unity editor.

    public GameObject FinishButton; //Declares a button UI object to be linked to an existig one in the Unity editor.  

    public string[] Questions = { "Question1", "Question2", "Question3", "Question4", "Question5" };
    public string[] Answers = { "Answer1", "Answer2", "Answer3", "Answer4", "Answer5" };

    public int QuestionCycle = 0; //Sets a pointer to select the questions in the Questions array.
    public int AnswerCycle = 0; //Sets a pointer to select the answer in the Answers array.

    public bool Clicked = false; //Bool to ensure the Quiz function only runs once, while a button is pressed multiple times.

    public void Quiz(string Topic) //Script takes in string to check what topic the quiz is being used on. Allows one code to be used on every quiz.
    {
        if (Clicked == false)
        {
            string QPath = @"D:\Documents\Computing Project\QuizQuestions.txt"; //Saves the location of the text file containing the questions to be referred to later.
            string APath = @"D:\Documents\Computing Project\QuizAnswers.txt"; //Saves the location of the text file containing the answers to be referred to later.

            int LowBound = 0; //Lower bound for range of lines that will be used.
            int HighBound = 0; //Upper bound for range of lines that will be used.

            switch (Topic) //Switch to allow the range of lines that include the relevent questions to be found.
            {
                case "Atomic Structure":
                    LowBound = 1;
                    HighBound = 13;
                    break;
                case "AoS":
                    LowBound = 14;
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

            System.Random QNumber = new System.Random(); //Random number to be used to pick the questions in the range. "System." required before due to Unity clash.

            int i = 0; //i will be used as a counter for the amount questions used in the quiz.             

            int QTemp; //Temporary value to allow the question number to move between the random number generator and the array.

            string[] QLines = File.ReadAllLines(QPath); //Creates an array with each element being a line from the text file, in order.
            string[] ALines = File.ReadAllLines(APath); //Creates an array with each element being a line from the text file, in order.

            for (i = 0; i < 5; i++)
            {
                QTemp = QNumber.Next(LowBound, HighBound - i); //Picks a line number in the range of the relevent questions.

                Questions.SetValue(QLines[QTemp - 1], i); //Sets the element at position i to whatever line had been chosen by QNumber.  
                Answers.SetValue(ALines[QTemp - 1], i); //Sets the element of the answers array to the answer to the corresponding question.

                string QLineTemp = QLines.GetValue(QLines.Length - 1).ToString(); //Creates a dummy value to hold a position of the final element of the array.
                string ALineTemp = ALines.GetValue(ALines.Length - 1).ToString(); //Creates a dummy value to hold a position of the final element of the array.

                QLines[QTemp - 1] = QLineTemp; //Replaces the element of the array with the dummy value.
                ALines[QTemp - 1] = ALineTemp; //Replaces the element of the array with the dummy value.

                Array.Resize(ref QLines, QLines.Length - 1); //Reduces array length by 1. Removing the element that had already been used, so there are no duplicates.
                Array.Resize(ref ALines, ALines.Length - 1); //Reduces array length by 1. Removing the element that had already been used, so there are no duplicates.
            }
            Clicked = true;
        }
        else
        { }
    }

    public void SetQuestionOnClick()
    {        
        if (QuestionCycle != 5) //While QuestionCycle is still displaying questions.
        {            
            TextToChange.text = Questions.GetValue(QuestionCycle).ToString(); //Changes the text for the UI object to make it equal to the question.
            QuestionCycle = QuestionCycle + 1; //Increases the value of QuestionCycle for the next question in the array.
        }
        else if (QuestionCycle == 5) //For when the quiz is finished.
        {
            Text NextButtonText = NextButton.GetComponentInChildren<Text>();
            NextButtonText.text = "Continue to Answers";
            if (AnswerCycle != 5)
            {
                TextToChange.text = Answers.GetValue(AnswerCycle).ToString(); //Changes the text for the UI object to make it equal to the question.
                AnswerCycle = AnswerCycle + 1; //Increases the value of AnswerCycle for the next question in the array.
            }
            else if (AnswerCycle == 5)
            {
                NextButton.SetActive(false); //Brings up the finish button so the user can quit.
                TextToChange.gameObject.SetActive(false);
                FinishButton.SetActive(true);                
            }

        }
        Clicked = false;//Resets the Clicked bool so the quiz can be redone.
    }      

    
}
