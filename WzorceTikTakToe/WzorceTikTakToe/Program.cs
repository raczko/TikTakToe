using System;
using System.Linq;

class Program
{
    private char[] Board = {' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    private char Player = 'X'; //defult 
    private char Winner = '0'; //defult 

    public void StartGame()
    {
        PrintBoard();
        Move();
        WinnerIs();
    }
    private void PrintBoard()
    {
        Console.Clear();
        Console.WriteLine($" {Board[0]} | {Board[1]} | {Board[2]} ");
        Console.WriteLine(" --------- ");
        Console.WriteLine($" {Board[3]} | {Board[4]} | {Board[5]} ");
        Console.WriteLine(" --------- ");
        Console.WriteLine($" {Board[6]} | {Board[7]} | {Board[8]} ");
    }
    private void ChangePlayer()
    {
        if (Player == 'X')
        {
            Player = 'Y';
            return;
        }
        Player = 'X';
    }
    private void WinnerIs()
    {
        if (Winner == '0')
        {
            Console.WriteLine("No one won.");
        }
        else
        {
            Console.WriteLine($"The winner is {Winner}!");
        }
    }
    private bool CheckEndGame()
    {
        //remis
        if (!Board.Contains(' '))
        {
            return true;
        }
        //wiersze
        else if (Board[0] != ' ' && Board[0] == Board[1] && Board[1] == Board[2]) // 123
        {
            Winner = Board[0];
            return true;
        }

        else if (Board[3] != ' ' &&  Board[3] == Board[4] && Board[4] == Board[5]) //456
        {
            Winner = Board[3];
            return true;
        }

        else if (Board[6] != ' ' &&  Board[6] == Board[7] && Board[7] == Board[8]) //789
        {
            Winner = Board[5];
            return true;
        }
        //kolumny
        else if (Board[0] != ' ' &&  Board[0] == Board[3] && Board[3] == Board[6]) //147
        {
            Winner = Board[0];
            return true;
        }
       
        else if (Board[1] != ' ' &&  Board[1] == Board[4] && Board[4] == Board[7]) //258
        {
            Winner = Board[1];
            return true;
        }

        else if (Board[2] != ' ' &&  Board[2] == Board[5] && Board[5] == Board[8]) //369
        {
            Winner = Board[2];
            return true;
        }
        //przekatna
        else if (Board[0] != ' ' &&  Board[0] == Board[4] && Board[4] == Board[8]) //159
        {
            Winner = Board[0];
            return true;
        }
        else if (Board[2] != ' ' &&  Board[2] == Board[4] && Board[4] == Board[6]) //357
        { 
            Winner = Board[2];
            return true;
        }
        return false;
    }
    private void Move()
    {
        while (!CheckEndGame())
        {
            bool correctPlace;
            do
            {
                Console.WriteLine($"What box do you want to place {Player} in? (1-9)");
                int aPlace;
                correctPlace = ((int.TryParse(Console.ReadLine(), out aPlace) && aPlace >= 1 && aPlace <= 9));
                if (!correctPlace)
                {
                    Console.WriteLine("Wrong selection entered!");
                    Console.WriteLine("Select a number between 1-9");
                    break;
                }
                else if (Board[aPlace - 1] != ' ')
                {
                    Console.WriteLine("Error: box not vacant! The box of your choice has already been taken");
                    correctPlace = false;
                    break;
                }
                Board[aPlace - 1] = Player;
                if (CheckEndGame())
                {
                    WinnerIs();
                }
                ChangePlayer();
                PrintBoard();
            } while (!correctPlace);
        }
    }

    static void Main()
    {
        Program program = new Program();
        program.StartGame();
    }
}