using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task4, char[,]>TaskSolver = task =>
            {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                char[,] board = task.Board;

                int x = board.GetLength(0);
                int y = board.GetLength(1);

                char[,] newBoard = new char[x,y];

                for(int i = 0; i < x; i++) 
                {
                    for (int j = 0; j < y; j++) 
                    {
                        int aliveNeighbors = 0;

                        int leftMargin = i - 1 >= 0 ? i - 1 : i;
                        int rightMargin = i + 1 < x ? i + 1 : i;
                        int topMargin = j - 1 >= 0 ? j - 1 : j;
                        int bottomMargin = j + 1 < y ? j + 1 : j; 

                        for (int k = leftMargin; k <= rightMargin; k++) 
                        {
                            for (int l = topMargin; l <= bottomMargin; l++) 
                            {
                                if (i != k || j != l) 
                                {
                                    if(board[k,l] == '1')
                                    {
                                        aliveNeighbors++;
                                    }
                                }
                            }
                        }
                        if(aliveNeighbors < 2 || aliveNeighbors > 3) 
                        {
                            newBoard[i, j] = '0';
                        }
                        else if (aliveNeighbors == 3) 
                        {
                            newBoard[i, j] = '1';
                        }
                        else
                        {
                            newBoard[i, j] = board[i, j];
                        }
                    }
                }

                return newBoard;
            };

            Task4.CheckSolver(TaskSolver);
        }


    }
}
