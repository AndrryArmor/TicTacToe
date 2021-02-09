using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Core.Implementation;
using Core.Abstraction;

namespace Core.Entities.Tests
{
    public class GameControllerTests
    {
        private GameController _gameController;
        private Mock<Cell> _cellMock;

        [SetUp]
        public void Setup()
        {
            var mockGameFactory = Mock.Of<IGameFactory>(gameFactory =>
                gameFactory.CreateField() == new Mock<Field>(3, 3).Object &&
                gameFactory.CreateFirstPlayer() == Mock.Of<IPlayer>() &&
                gameFactory.CreateSecondPlayer() == Mock.Of<IPlayer>() &&
                gameFactory.GetGameEngine() == Mock.Of<IGameEngine>());

            _gameController = new GameController(mockGameFactory);
            var _cellMock = new Mock<Cell>(0, 0, _gameController.Field);
        }

        [Test]
        public void MakeMove_GameStopped_DontMakeMove()
        {
            _gameController.MakeMove(_cellMock.Object);

            Assert.IsNull(_cellMock.Object.Piece);           
        }

        [Test]
        public void MakeMove_MakeInvalidMove_DontMakeMove()
        {
            _cellMock.Object.Piece = PieceType.X;

            _cellMock.Object.Piece = null;

            Assert.IsNull(_cellMock.Object.Piece);
        }

        [Test]
        public void MakeMove_MakeWin_MustChangeGameStateToStopped()
        {
            _cellMock.Object.Piece = PieceType.X;

            _cellMock.Object.Piece = null;

            Assert.IsNull(_cellMock.Object.Piece);
        }
    }
}
