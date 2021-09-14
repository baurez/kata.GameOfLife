using System;
using System.Collections.Generic;

using GolDll;

using NFluent;

using Xunit;

namespace GolTest
{
    public class GolTest
    {
        [Fact]
        public void should0by0InitReturnEmptyString()
        {
            Check.That("").Equals(GetGameResult(0, 0, null));
        }

        [Fact]
        public void should1by1InitReturnX()
        {
            Check.That(GameOfLife.deadcell).Equals(GetGameResult(1, 1, null));
        }

        [Fact]
        public void should1by3InitReturn1RowAnd3ColumnsWithX()
        {
            Check.That(GetGameResult(1, 3, null)).AsLines().ContainsExactly(GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell);
        }

        [Fact]
        public void should3by3InitReturn3RowsAnd3ColumnsWithX()
        {
            Check.That(GetGameResult(3, 3, null)).AsLines().ContainsExactly(GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell, GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell, GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell);
        }


        [Fact]
        public void should1by3WithAliveCellInRow1Col2()
        {
            var result = GetGameResult(1, 3, new Dictionary<int, int> { { 0, 1 } });
            Check.That(result).AsLines().ContainsExactly(GameOfLife.deadcell + GameOfLife.livingcell + GameOfLife.deadcell);
        }

        [Fact]
        public void should3by3WithAliveCellInRow2Col2()
        {
            var result = GetGameResult(3, 3, new Dictionary<int, int> { { 1, 1 } });
            Check.That(result).AsLines().ContainsExactly(
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
                GameOfLife.deadcell + GameOfLife.livingcell + GameOfLife.deadcell,
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell
                );
        }


        [Fact]
        public void scenarioWith1LivingCellAndLessThanTwoNeighborsDies()
        {
            //given
            var g = new GameOfLife(3, 3);
            g.SetAliveCell(1, 1);
            Check.That(g.ToString()).AsLines().ContainsExactly(
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
                GameOfLife.deadcell + GameOfLife.livingcell + GameOfLife.deadcell,
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell);

            //when
            g.generateNextStep();

            //then
            Check.That(g.ToString()).AsLines().ContainsExactly(
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell);
        }

        [Fact]
        public void scenario2()
        {
            //given
            var g = new GameOfLife(3, 3);
            g.SetAliveCell(0, 0);
            g.SetAliveCell(0, 1);
            g.SetAliveCell(0, 2);

            g.SetAliveCell(1, 0);
            g.SetAliveCell(1, 1);
            g.SetAliveCell(1, 2);

            g.SetAliveCell(2, 0);
            g.SetAliveCell(2, 1);
            g.SetAliveCell(2, 2);

            Check.That(g.ToString()).AsLines().ContainsExactly(
                GameOfLife.livingcell + GameOfLife.livingcell + GameOfLife.livingcell,
                GameOfLife.livingcell + GameOfLife.livingcell + GameOfLife.livingcell,
                GameOfLife.livingcell + GameOfLife.livingcell + GameOfLife.livingcell);

            //when
            g.generateNextStep();

            //then
            Check.That(g.ToString()).AsLines().ContainsExactly(
                GameOfLife.livingcell + GameOfLife.deadcell + GameOfLife.livingcell,
                GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
                GameOfLife.livingcell + GameOfLife.deadcell + GameOfLife.livingcell
                );
            //Check.That(g.ToString()).AsLines().ContainsExactly("0X0", "XXX", "0X0");

            //when
            g.generateNextStep();

            //then
            Check.That(g.ToString()).AsLines().ContainsExactly(
             GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
             GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell,
             GameOfLife.deadcell + GameOfLife.deadcell + GameOfLife.deadcell);
            //Check.That(g.ToString()).AsLines().ContainsExactly("XXX", "XXX", "XXX");
        }



        private string GetGameResult(int rowsNumber, int columnsNumber, Dictionary<int, int> alivesCells)
        {
            var game = new GameOfLife(rowsNumber, columnsNumber);

            if (alivesCells != null)
            {
                foreach (var cell in alivesCells)
                {
                    game.SetAliveCell(cell.Key, cell.Value);
                }
            }

            return game.ToString();
        }

    }
}
