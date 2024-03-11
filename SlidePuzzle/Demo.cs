using System;
using System.Collections.Generic;


public class PuzzleNode
{
    public int[,] Board { get; set; }
    public int Cost { get; set; }
    public int Heuristic { get; set; }
    public int Depth { get; set; }
    public PuzzleNode Parent { get; set; }
}

public class PriorityQueue<T>
{
    private SortedDictionary<int, Queue<T>> _dictionary = new SortedDictionary<int, Queue<T>>();

    public void Enqueue(int priority, T item)
    {
        if (!_dictionary.ContainsKey(priority))
        {
            _dictionary[priority] = new Queue<T>();
        }
        _dictionary[priority].Enqueue(item);
    }
    public T Dequeue()
    {
        var firstKey = _dictionary.Keys.First();
        var queue = _dictionary[firstKey];
        var item = queue.Dequeue();
        if (queue.Count == 0)
        {
            _dictionary.Remove(firstKey);
        }
        return item;
    }

    public bool IsEmpty => _dictionary.Count == 0;
}

public class SlidePuzzleSolver
{
    private static readonly int[] DX = { 1, 0, -1, 0 }; // Hareket: sağ, aşağı, sol, yukarı
    private static readonly int[] DY = { 0, 1, 0, -1 };

    public static List<int[,]> Solve(int[,] initialBoard, int[,] goalState)
    {
            PuzzleNode initialState = new PuzzleNode
            {
                Board = initialBoard,
                Cost = 0,
                Heuristic = CalculateHeuristic(initialBoard, goalState),
                Depth = 0,
                Parent = null
            };

            PriorityQueue<PuzzleNode> openList = new PriorityQueue<PuzzleNode>();
            Dictionary<string, int> closedList = new Dictionary<string, int>(); 
            List<int[,]> solution = new List<int[,]>();

            openList.Enqueue(initialState.Cost + initialState.Heuristic, initialState); 

            while (!openList.IsEmpty)
            {
                PuzzleNode currentNode = openList.Dequeue();

                string boardString = BoardToString(currentNode.Board);

                
                if (closedList.ContainsKey(boardString))
                {
                    
                    if (currentNode.Cost < closedList[boardString])
                    {
                        closedList[boardString] = currentNode.Cost;
                    }
                    else
                    {
                        continue; 
                    }
                }
                else
                {
                    closedList.Add(boardString, currentNode.Cost); 
                }

                if (IsGoalState(currentNode.Board, goalState))
                {
                    
                    while (currentNode != null)
                    {
                        solution.Insert(0, currentNode.Board);
                        currentNode = currentNode.Parent;
                    }
                    break;
                }

                for (int i = 0; i < DX.Length; i++)
                {
                    int newX = 0, newY = 0;
                    FindEmptyTile(currentNode.Board, out newX, out newY);

                    int nextX = newX + DX[i];
                    int nextY = newY + DY[i];

                    if (nextX >= 0 && nextX < initialBoard.GetLength(0) && nextY >= 0 && nextY < initialBoard.GetLength(1))
                    {
                        int[,] newBoard = (int[,])currentNode.Board.Clone();
                        int temp = newBoard[newX, newY];
                        newBoard[newX, newY] = newBoard[nextX, nextY];
                        newBoard[nextX, nextY] = temp;

                        string newBoardString = BoardToString(newBoard);

                        if (!closedList.ContainsKey(newBoardString) || currentNode.Cost + 1 < closedList[newBoardString])
                        {
                            PuzzleNode newNode = new PuzzleNode
                            {
                                Board = newBoard,
                                Cost = currentNode.Cost + 1,
                                Heuristic = CalculateHeuristic(newBoard, goalState),
                                Depth = currentNode.Depth + 1,
                                Parent = currentNode
                            };
                            openList.Enqueue(newNode.Cost + newNode.Heuristic, newNode);
                        }
                    }
                }
            }
            return solution;
    }

    private static bool IsGoalState(int[,] board, int[,] goalState)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != goalState[i, j])
                    return false;
            }
        }
        return true;
    }

    private static void FindEmptyTile(int[,] board, out int x, out int y)
    {
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] == 0)
                {
                    x = i;
                    y = j;
                    return;
                }
            }
        }
        x = -1;
        y = -1;
    }

    private static int CalculateHeuristic(int[,] board, int[,] goalState)
    {
        int h = 0;
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                if (board[i, j] != 0)
                {
                    int expectedX = (board[i, j] - 1) / board.GetLength(1);
                    int expectedY = (board[i, j] - 1) % board.GetLength(1);
                    h += Math.Abs(i - expectedX) + Math.Abs(j - expectedY);
                }
            }
        }
        return h;
    }
    private static string BoardToString(int[,] board)
    {
        string boardString = "";
        for (int i = 0; i < board.GetLength(0); i++)
        {
            for (int j = 0; j < board.GetLength(1); j++)
            {
                boardString += board[i, j].ToString();
            }
        }
        return boardString;
    }
}

