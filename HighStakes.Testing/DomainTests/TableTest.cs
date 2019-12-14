using System.Collections.Generic;
using HighStakes.Domain.Models;
using Xunit;

namespace HighStakes.Testing.DomainTests
{
    public class TableTest
    {
        [Fact]
        public void Test_JoinGame()
        {
            DTable table = new DTable();
            DUser user1 = new DUser();
            DUser user2 = new DUser();
            table.Initialize(5, 10);
            user1.ChipTotal = 100;
            user2.ChipTotal = 100;

            Assert.True(table.JoinGame(user1, 50));
            Assert.True(table.JoinGame(user2, 50));
            Assert.Equal(50, user1.ChipTotal);
        }

        [Fact]
        public void Test_NumOfActivePlayers()
        {
            DTable table = new DTable();
            DUser user1 = new DUser();
            DUser user2 = new DUser();
            table.Initialize(5, 10);
            user1.ChipTotal = 100;
            user2.ChipTotal = 100;

            table.JoinGame(user1, 50);
            table.JoinGame(user2, 50);
            
            Assert.Equal(2, table.NumOfActivePlayers());
        }

        [Fact]
        public void Test_StartGame()
        {
            DTable table = new DTable();
            DUser user1 = new DUser();
            DUser user2 = new DUser();
            table.Initialize(5, 10);
            user1.ChipTotal = 100;
            user2.ChipTotal = 100;

            table.JoinGame(user1, 50);
            table.JoinGame(user2, 50);

            table.StartGame();

            Assert.True(table.Seats[0].SmallBlind);
            Assert.True(table.Seats[1].BigBlind);
        }

        [Fact]
        public void Test_GetTurnOrder()
        {
            DTable table = new DTable();
            DUser user1 = new DUser();
            DUser user2 = new DUser();
            table.Initialize(5, 10);
            user1.ChipTotal = 100;
            user2.ChipTotal = 100;

            table.JoinGame(user1, 50);
            table.JoinGame(user2, 50);

            table.StartGame();
            table.GetTurnOrder();

            Assert.True(table.SeatsInTurnOrder[0].SmallBlind);
            Assert.True(table.SeatsInTurnOrder[1].BigBlind);
        }

        // public void Test_EndRound()
        // {

        // }

        [Fact]
        public void Test_MoveBlinds()
        {
            DTable table = new DTable();
            DUser user1 = new DUser();
            DUser user2 = new DUser();
            table.Initialize(5, 10);
            user1.ChipTotal = 100;
            user2.ChipTotal = 100;

            table.JoinGame(user1, 50);
            table.JoinGame(user2, 50);

            table.StartGame();
            table.GetTurnOrder();
            table.MoveBlinds();

            Assert.True(table.SeatsInTurnOrder[0].BigBlind);
            Assert.True(table.SeatsInTurnOrder[1].SmallBlind);
        }

        [Fact]
        public void Test_StartRound()
        {
            DTable table = new DTable();
            DUser user1 = new DUser();
            DUser user2 = new DUser();
            table.Initialize(5, 10);
            user1.ChipTotal = 100;
            user2.ChipTotal = 100;

            table.JoinGame(user1, 50);
            table.JoinGame(user2, 50);

            table.StartGame();
            table.StartRound();

            Assert.Equal(45, table.SeatsInTurnOrder[0].ChipTotal);
            Assert.Equal(40, table.SeatsInTurnOrder[1].ChipTotal);
            Assert.Equal(2, table.SeatsInTurnOrder[0].Pocket.Count);
        }
    }
}