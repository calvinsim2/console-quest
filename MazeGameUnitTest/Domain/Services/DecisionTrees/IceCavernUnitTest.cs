using MazeGameDomain.Enums;
using MazeGameDomain.Models;
using MazeGameDomain.Services.DecisionTrees;

namespace MazeGameDomain.Domain.Services.DecisionTrees.Tests
{
    public class IceCavernUnitTest
    {
        private readonly IceCavern IceCavernMock = new IceCavern();

        private void CallTransverseIceCavernAsync()
        {
            _ = IceCavernMock.TransverseIceCavernAsync(MazeGameDataModelMock);
        }

        private static readonly Adventurer AdventurerMock = new Adventurer
        {
            Name = "Annoying NBAK",
            Class = (int)Class.Magician,
            Specialisation = (int)Specialisation.IceMage
        };

        private static readonly MazeGameDataModel MazeGameDataModelMock = new MazeGameDataModel
        {
            Adventurer = AdventurerMock,
        };

        [Fact]
        public void CallTransverseIceCavernAsync_Positive_AdventurerIsResistantToIce_ReturnTrue()
        {
            // Arrange
            AdventurerMock.Class = (int)Class.Magician;
            AdventurerMock.Specialisation = (int)Specialisation.IceMage;

            try
            {
                // Act
                CallTransverseIceCavernAsync();

                Func<bool> isAdventurerIceResistantQuery = IceCavernMock.IsAdventurerIceResistant.ProcessPhase;

                bool results = isAdventurerIceResistantQuery.Invoke();

                // Assert
                Assert.True(results);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly.
                throw new InvalidOperationException("Test case failed due to an unexpected error.", ex);
            }
        }

        [Fact]
        public void CallTransverseIceCavernAsync_Negative_AdventurerIsNotResistantToIce_ReturnFalse()
        {
            // Arrange
            AdventurerMock.Class = (int)Class.Magician;
            AdventurerMock.Specialisation = (int)Specialisation.FireMage;

            try
            {
                // Act
                CallTransverseIceCavernAsync();

                Func<bool> isAdventurerIceResistantQuery = IceCavernMock.IsAdventurerIceResistant.ProcessPhase;

                bool results = isAdventurerIceResistantQuery.Invoke();

                // Assert
                Assert.False(results);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly.
                throw new InvalidOperationException("Test case failed due to an unexpected error.", ex);
            }
        }
    }
}