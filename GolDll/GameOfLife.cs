using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GolDll
{
    public class GameOfLife
    {
        public const string deadcell = " ";
        public const string livingcell = "0";

        public void RandomizeLivingCells()
        {
            var r = new Random(Guid.NewGuid().GetHashCode());

            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalColumns; j++)
                {
                    if (r.Next(1, 100) < 50)
                        SetAliveCell(i, j);
                }
            }

        }

        private readonly int totalRows;
        private readonly int totalColumns;

        private Cell[,] cells;

        public GameOfLife(int rows, int columns)
        {
            this.totalRows = rows;
            this.totalColumns = columns;
            this.cells = getEmptyMatrice(this.totalRows, this.totalColumns);
        }


        public override string ToString()
        {
            var result = new StringBuilder();

            for (int x = 0; x < totalRows; x++)
            {
                for (int y = 0; y < totalColumns; y++)
                {
                    result.Append(getCell(x, y).ToString());
                }

                if (x != totalRows - 1)
                    result.AppendLine();
            }

            return result.ToString();
        }

        public void generateNextStep()
        {
            var newCells = getEmptyMatrice(this.totalRows, this.totalColumns);

            foreach (Cell item in newCells)
            {
                int numberOfLivingsCells = 0;
                int numberOfDeadCells = 0;
                item.alive = getCell(item.x, item.y).alive;



                for (int i = -1; i <= 1; i++)
                {
                    for (int j = -1; j <= 1; j++)
                    {
                        if (i != 0 || j != 0)
                        {
                            var cell = getCell(item.x + i, item.y + j);
                            if (cell != null)
                            {
                                if (cell.alive)
                                    numberOfLivingsCells++;
                                numberOfDeadCells++;
                            }
                        }
                    }
                }

                if (item.alive && (numberOfLivingsCells < 2 || numberOfLivingsCells > 3))
                    item.alive = false;

                if (item.alive && (numberOfLivingsCells == 2 || numberOfLivingsCells == 3))
                    item.alive = true;

                if (!item.alive && numberOfLivingsCells == 3)
                    item.alive = true;
            }

            this.cells = newCells;
        }

        private Cell[,] getEmptyMatrice(int rows, int columns)
        {
            var result = new Cell[rows, columns];
            for (int i = 0; i < totalRows; i++)
            {
                for (int j = 0; j < totalColumns; j++)
                {
                    result[i, j] = new Cell(i, j, false);
                }
            }
            return result;
        }

        private Cell getCell(int x, int y)
        {
            if (x < 0 || y < 0 || x >= cells.GetLength(0) || y >= cells.GetLength(1))
                return null;
            return (Cell)cells.GetValue(x, y);
        }

        public void SetAliveCell(int x, int y)
        {
            var c = getCell(x, y);
            if (c != null)
                c.alive = true;
        }

        private class Cell
        {
            public Cell(int x, int y, bool alive)
            {
                this.x = x;
                this.y = y;
                this.alive = alive;
            }

            public int x { get; set; }
            public int y { get; set; }
            public Boolean alive { get; set; }

            public override string ToString()
            {
                return alive ? livingcell : deadcell;
            }
        }
    }
}
