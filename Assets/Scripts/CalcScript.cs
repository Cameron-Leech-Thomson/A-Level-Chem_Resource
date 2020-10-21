using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading; //Allows use of TextReader function & StreamReader function.
using System.IO;       //Allows use of TextReader function & StreamReader function.
using System.Linq;    //Allows use of File.ReadLines extensions.
using Random = System.Random; //Allows use of creating random integers.


public class CalcScript : MonoBehaviour
{
    public static void Resize<T>(ref T[] array, int newSize) { } //Creates a function to change the size of an array to a set amount.

    public Text TextToChange; //Declares a text UI object to be linked to an existing one in the Unity editor, this is where the question is printed to.

    Random rnd = new Random(); //Creates a random number in a given range.

    public bool Clicked = false; //Bool to ensure the Quiz function only runs once, while a button is pressed multiple times.

    public string Answer; //The final answer that will be shown on screen.

    public void Calculations()
    {
        if (Clicked == false)
        {
            int TopicInt = rnd.Next(0, 4);

            switch (TopicInt)
            {
                case 0:
                    IGE(); //Calls the function that generated an ideal gas equation question.
                    break;
                case 1:
                    Moles(); //Calls the function that generated a moles question.
                    break;
                case 2:
                    AtomEco(); //Calls the function that generated an atom economy question.
                    break;
                case 3:
                    Yield(); //Calls the function that generated a % yield question.
                    break;
                case 4:
                    Calorimetry();//Calls the function that generated a calorimetry question.
                    break;
                default: //Error followthrough.
                    break;
            }
            Clicked = true;
        }
        else
        {
            TextToChange.text = Answer;
            Clicked = false;
        }
    }

    public void IGE() //Generates an ideal gas equation question.
    {
        string[] Units = { "Temperature", "Pressure", "Moles", "Volume" }; //Array containing all the units used in IGE.

        double IGEAnswer; //The value that the user will need to find.

        int FindAt = rnd.Next(0, 3); //Picks a random unit for the user to find.

        string FindUnit = Units.GetValue(FindAt).ToString(); //Finds the corresponding element in the array.

        if (FindUnit == "Volume")
        {
            Resize(ref Units, 3); //Removes "Volume" from the array by reducing the array's total length.
        }
        else
        {
            Units.SetValue("Volume", FindAt); //Overwrites the element at 'FindAt' with "Volume".
            Resize(ref Units, 3); //Removes the duplicate "Volume" by reducing the array's total length.
        }

        //Temperature:
        int TempVal = rnd.Next(0, 350); //Picks a random value for the temperature.
        int TUnit = rnd.Next(0, 1); //Picks a unit for temperature.
        int TempAns = 0;
        string Temp;

        if (TUnit == 0) //TUnit == 0 means Kelvin.
        {
            TempVal = TempVal + 273; //Turns the tempval into Kelvin.
            Temp = (TempVal + "K"); //Creates the message for temperature to be used in the question.
            TempAns = TempVal;
        }
        else
        {
            Temp = (TempVal + "C"); //Keeps temperature in degrees.
            TempAns = TempVal + 273;
        }

        //Pressure:
        int PresVal = rnd.Next(1, 350); //Picks a random value for the pressure.
        int PUnit = rnd.Next(0, 1); //Picks a unit for pressure.
        int PresAns = 0;
        string Pres;

        if (PUnit == 0) //PUnit == 0 means Pa.
        {
            PresVal = PresVal * 1000; //Turns the presval into Pascals.
            Pres = (PresVal + "Pa"); //Creates the message for pressure to be used in the question.
            PresAns = PresVal;
        }
        else
        {
            Pres = (PresVal + "KPa"); //Keeps pressure in KPa.
            PresAns = PresVal * 1000;
        }

        //Moles:
        double MolVal = rnd.Next(3, 1300);
        MolVal = MolVal / 100;
        string Mol = (MolVal + "Moles");

        //Volume:
        double VolVal = rnd.Next(1, 10); //Picks a random value for the volume.
        int VUnit = rnd.Next(0, 2); //Picks a unit for volume.
        double VolAns = 0;
        string Vol;

        if (VUnit == 0) //VUnit == 0 means centimetres cubed.
        {
            VolAns = VolVal;
            VolVal = VolVal * 1000000; //Turns the volval into centimetres cubed.
            Vol = (VolVal + "cm3"); //Creates the message for volume to be used in the question.
        }
        else if (VUnit == 1) //VUnit == 1 means decimetres cubed.
        {
            VolAns = VolVal;
            VolVal = VolVal * 1000; //Turns the volval into decimetres cubed.
            Vol = (VolVal + "dm3"); //Creates the message for volume to be used in the question.
        }
        else
        {
            Vol = (VolVal + "m3"); //Keeps volume in metres.
            VolAns = VolVal;
        }

        string IGEQuestion;

        //Answers:        
        switch (FindAt)
        {
            //Finding Temp (T = PV/NR):
            case 0:
                IGEAnswer = (PresAns * VolAns) / (MolVal * 8.31);
                IGEQuestion = ("Find the temperature, given that: Pressure = " + Pres + ", Volume = " + Vol + ", Moles = " + Mol + ". The gas constant R is 8.31.");
                break;
            //Finding Pressure (P = NRT/V):
            case 1:
                IGEAnswer = (MolVal * 8.31 * TempAns) / VolAns;
                IGEQuestion = ("Find the pressure, given that: Temperature = " + Temp + ", Volume = " + Vol + ", Moles = " + Mol + ". The gas constant R is 8.31.");
                break;
            //Finding Moles (N = PV/RT):
            case 2:
                IGEAnswer = (PresAns * VolAns) / (8.31 * TempAns);
                IGEQuestion = ("Find the moles, given that: Pressure = " + Pres + ", Volume = " + Vol + ", Temperature = " + Temp + ". The gas constant R is 8.31.");
                break;
            //Finding Volume (V = NRT/P):
            case 3:
                IGEAnswer = (MolVal * 8.31 * TempAns) / PresAns;
                IGEQuestion = ("Find the volume, given that: Pressure = " + Pres + ", Temperature = " + Temp + ", Moles = " + Mol + ". The gas constant R is 8.31.");
                break;
            default: //Error followthrough.:
                IGEQuestion = ("An error has occurred.");
                IGEAnswer = 0;
                break;
        }
        TextToChange.text = IGEQuestion;
        Answer = IGEAnswer.ToString();
    

    }

    public void Moles() //Generates a moles calculation.
    {
        int FindUnit = rnd.Next(0, 1); //Decided whether the user should find the mass or the moles of a susbtance.

        int Mr = rnd.Next(12, 70); //Picks the relative atomic mass of whatever substance the user is presented with.

        double Moles = (rnd.Next(1, 100) / 10); //Picks the moles of the substance.
        
        double Mass = (rnd.Next(1, 1000) / 10); //Picks  the mass of the substance.

        double MolAnswer; //The value of the answer.

        string MolQuestion; //The question.

        if (FindUnit == 0) //Finding Mass (Mass = Mr x Moles) .
        {
            MolAnswer = (Mr * Moles);
            MolQuestion = ("Find the mass of the substance with Mr = " + Mr + ", and Moles = " + Moles + ".");
        }
        else //Finding Moles (Moles = Mass/Mr)
        {
            MolAnswer = (Mass / Mr);
            MolQuestion = ("Find the moles of the substance with Mr = " + Mr + ", and Mass = " + Mass + ".");
        }

        TextToChange.text = MolQuestion;
        Answer = Math.Round(MolAnswer, 3).ToString();
    }

    public void AtomEco() //Generates an atom economy question.
    {
        int X = rnd.Next(1, 3); //The molar ratio of X.
        int Y = rnd.Next(1, 3); //The molar ratio of Y.
        int Z = rnd.Next(1, 3); //The molar ratio of Z.

        string Equation = ("A + B → " + X + "X + " + Y + "Y + " + Z + "Z"); //Creates the equation.
                
        double MolX = rnd.Next(10, 30) / 10; //The moles of X.
        double MolY = rnd.Next(10, 30) / 10; //The moles of Y.
        double MolZ = rnd.Next(10, 30) / 10; //The moles of Z.

        double MassX = rnd.Next(1, 500) / 10; //The mass of X.
        double MassY = rnd.Next(1, 500) / 10; //The mass of Y.
        double MassZ = rnd.Next(1, 500) / 10; //The mass of Z.

        double MrX = MassX / MolX; //The Mr of X.
        double MrY = MassY / MolY; //The Mr of Y.
        double MrZ = MassZ / MolZ; //The Mr of Z.
        double MrA = rnd.Next(1, 250); //The Mr of A.
        double MrB = rnd.Next(1, 250); //The Mr of B.

        int FindUnit = rnd.Next(0, 5);
        double AtEc;

        string AtomEcoQuestion;
        double AtomEcoAnswer;

        switch(FindUnit)
        {
            case 0: //Find AE of X.
                AtEc = (MrX / (MrA + MrB)) * 100;
                AtomEcoAnswer = AtEc;
                AtomEcoQuestion = ("In the equation: " + Equation + "." +
                    "Substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with substance B (Mr = " + Math.Round(MrB,3) + ") to form " + Math.Round(MolX, 3) + "Mol & " + Math.Round(MassX, 3) + "g X, " + Math.Round(MolY, 3) + "Mol & " + Math.Round(MassY, 3) + "g Y, " + Math.Round(MolZ, 3) + "Mol & " + Math.Round(MassZ, 3) + "g Z. Find the atom economy of substance X.");
                break;
            case 1: //Find AE of Y.
                AtEc = (MrY / (MrA + MrB)) * 100;
                AtomEcoAnswer = AtEc;
                AtomEcoQuestion = ("In the equation: " + Equation + "." +
                    "Substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with substance B (Mr = " + Math.Round(MrB, 3) + ") to form " + Math.Round(MolX, 3) + "Mol & " + Math.Round(MassX, 3) + "g X, " + Math.Round(MolY, 3) + "Mol & " + Math.Round(MassY, 3) + "g Y, " + Math.Round(MolZ, 3) + "Mol & " + Math.Round(MassZ, 3) + "g Z. Find the atom economy of substance Y.");
                break;
            case 2: //Find AE of Z.
                AtEc = (MrZ / (MrA + MrB)) * 100;
                AtomEcoAnswer = AtEc;
                AtomEcoQuestion = ("In the equation: " + Equation + "." +
                    "Substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with substance B (Mr = " + Math.Round(MrB, 3) + ") to form " + Math.Round(MolX, 3) + "Mol & " + Math.Round(MassX, 3) + "g X, " + Math.Round(MolY, 3) + "Mol & " + Math.Round(MassY, 3) + "g Y, " + Math.Round(MolZ, 3) + "Mol & " + Math.Round(MassZ, 3) + "g Z. Find the atom economy of substance Z.");
                break;
            case 3: //Find MrX.
                AtEc = (MrX / (MrA + MrB)) * 100;
                AtomEcoAnswer = ((AtEc * (MrA + MrB)) / 100);
                AtomEcoQuestion = ("In the equation: " + Equation + "." +
                    "Substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with substance B (Mr = " + Math.Round(MrB, 3) + "). The atom economy of susbtance X is " + Math.Round(AtEc, 3) + "%. Find the Mr of X.");
                break;
            case 4: //Find MrY.
                AtEc = (MrY / (MrA + MrB)) * 100;
                AtomEcoAnswer = ((AtEc * (MrA + MrB)) / 100);
                AtomEcoQuestion = ("In the equation: " + Equation + "." +
                    "Substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with substance B (Mr = " + Math.Round(MrB, 3) + "). The atom economy of susbtance X is " + Math.Round(AtEc,3) + "%. Find the Mr of Y.");
                break;
            case 5: //Find MrZ.
                AtEc = (MrZ / (MrA + MrB)) * 100;
                AtomEcoAnswer = ((AtEc * (MrA + MrB)) / 100);
                AtomEcoQuestion = ("In the equation: " + Equation + "." +
                    "Substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with substance B (Mr = " + Math.Round(MrB,3) + "). The atom economy of susbtance X is " + AtEc + "%. Find the Mr of Z.");
                break;
            default: //Error followthrough.:
                AtomEcoAnswer = 0;
                AtomEcoQuestion = ("An error has occurred.");
                break;
        }
        TextToChange.text = AtomEcoQuestion;
        Answer = Math.Round(AtomEcoAnswer,3).ToString();
        
    }

    public void Yield() //Generates a % yield question.
    {
        int X = rnd.Next(1, 3); //The molar ratio of X.
        int Y = rnd.Next(1, 3); //The molar ratio of Y.

        string Equation = ("A + B → " + X + "X + " + Y + "Y"); //Creates the equation.

        double MolA = rnd.Next(10, 30) / 10; //The moles of A.
        double MolB = rnd.Next(10, 30) / 10; //The moles of B.
        double MolX = rnd.Next(10, 30) / 10; //The moles of X.
        double MolY = rnd.Next(10, 30) / 10; //The moles of Y.

        double MassA = rnd.Next(30, 500) / 10; //The mass of A.
        double MassB = rnd.Next(30, 500) / 10; //The mass of B.
        double MassX = rnd.Next(30, 500) / 10; //The mass of X.
        double MassY = rnd.Next(30, 500) / 10; //The mass of Y.

        double MrA = MassX / MolX; //The Mr of A.
        double MrB = MassY / MolY; //The Mr of B.
        double MrX = MassX / MolX; //The Mr of X.
        double MrY = MassY / MolY; //The Mr of Y.

        int FindUnit = rnd.Next(0, 3);

        double MaxYield;
        double Yield;
        double Ratio;
        string YieldQuestion;
        string YieldAnswer;

        switch(FindUnit)
        {
            case 0: //Yield X.
                YieldQuestion = ("In the equation: " + Equation + "." +
                    MassA + "g of substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with an excess of substance B (Mr = " + Math.Round(MrB,3) + ") to form " + Math.Round(MassX,3) + "g of substance X (Mr = " + Math.Round(MrX,3) + "). Find: a) The theoretical maximum yield of substance X. b) The percentage yield of the reaction.");
                Ratio = (X * MrX) / MrA;
                MaxYield = MassA * Ratio;
                Yield = (MassX / MaxYield) * 100;
                YieldAnswer = ("a) " + MaxYield + ". b) " + Math.Round(Yield, 3) + ".");
                break;
            case 1: //Yield Y.
                YieldQuestion = ("In the equation: " + Equation + "." +
                    MassA + "g of substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with an excess of substance B (Mr = " + Math.Round(MrB,3) + ") to form " + Math.Round(MassY,3) + "g of substance Y (Mr = " + Math.Round(MrY,3) + "). Find: a) The theoretical maximum yield of substance Y. b) The percentage yield of the reaction.");
                Ratio = (Y * MrY) / MrA;
                MaxYield = MassA * Ratio;
                Yield = (MassY / MaxYield) * 100;
                YieldAnswer = ("a) " + MaxYield + ". b) " + Math.Round(Yield,3) + ".");
                break;
            case 2: //Mass X.
                Ratio = (X * MrX) / MrA;
                MaxYield = MassA * Ratio;
                Yield = (MassX / MaxYield) * 100;
                YieldAnswer = Math.Round(MassX, 3).ToString();
                YieldQuestion = ("In the equation: " + Equation + "." +
                    MassA + "g of substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with an excess of substance B (Mr = " + Math.Round(MrB,3) + ") with a percentage yield " + Math.Round(Yield,3) + "% of to form substance X (Mr = " + Math.Round(MrX,3) + "). Find the mass of substance X formed.");
                break;
            case 3: //Mass Y.
                Ratio = (Y * MrY) / MrA;
                MaxYield = MassA * Ratio;
                Yield = (MassY / MaxYield) * 100;
                YieldAnswer = Math.Round(MassY,3).ToString();
                YieldQuestion = ("In the equation: " + Equation + "." +
                    MassA + "g of substance A (Mr = " + Math.Round(MrA, 3) + ") reacts with an excess of substance B (Mr = " + Math.Round(MrB,3) + ") with a percentage yield " + Math.Round(Yield,3) + "% of to form substance Y (Mr = " + Math.Round(MrY,3) + "). Find the mass of substance Y formed.");
                break;
            default: //Error followthrough.:
                YieldQuestion = ("An error has occurred");
                MaxYield = 0;
                Yield = 0;
                YieldAnswer = ("An error has occurred.");
                break;            
        }
        TextToChange.text = YieldQuestion;
        Answer = YieldAnswer;
    }

    public void Calorimetry() //Generates a calorimetry question.
    {
        int InitialTemp = rnd.Next(270, 450); //Creates a value for the initial temperature.
        int FinalTemp = rnd.Next(280, 460); //Creates a value for the final temperature.

        while (FinalTemp < InitialTemp) //Guaruntees that the final temp is larger, so that in the calculations below, there isn't a negative answer.
        {
            FinalTemp = rnd.Next(280, 460);
        }

        double MassHeated = rnd.Next(110, 700) / 10; //Creates the mass of what will be heated.
        double MassFuel = rnd.Next(11, 120) / 10; //Creates the mass of the fuel.
        double MolesFuel = MassFuel / 32; //Calculates the moles of the fuel burned.

        int FindValue = rnd.Next(0, 1);

        string CaloQuestion;
        double CaloAnswer;
        double Q;

        switch(FindValue)
        {
            case 0: //Finding Q.
                CaloQuestion = (MassFuel + "g of methanol (CH3OH) is burned, heating " + MassHeated + "cm3 of solution to " + FinalTemp + "K. The solution was previously " + InitialTemp + "K. " +
                    "Find the enthalpy change of this reaction. You may assume that the solution has the density 1g/cm3 & that it has a specific heat capacity of 4.18J/g/°C.");
                CaloAnswer = (MassHeated * 4.18 * (FinalTemp - InitialTemp)) / (MolesFuel * 1000); //Q=MCAT
                break;
            case 1: //Finding Mass.
                Q = (MassHeated * 4.18 * (FinalTemp - InitialTemp)) / (MolesFuel * 1000);
                CaloQuestion = ("An unknown mass of a solution was heated by " + MassFuel + "g of methanol (CH3OH). The temperature change of this reaction was " + (FinalTemp - InitialTemp) + "K. The total enthalpy change for this reaction was " + Q + "KJ/Mol." +
                    "Find the mass of the solution. You may assume that the solution has the density 1g/cm3 & that it has a specific heat capacity of 4.18J/g/°C.");
                CaloAnswer = MassHeated;
                break;
            default: //Error followthrough.
                Q = 0;
                CaloAnswer = 0;
                CaloQuestion = ("An error has occurred.");
                break;
        }

        TextToChange.text = CaloQuestion;
        Answer = Math.Round(CaloAnswer,3).ToString();
    }
}

