using MazeGameDomain.Enums;
using MazeGameDomain.Models;
using Xunit;

namespace MazeGameDomain.Services.DecisionTrees.Tests
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
            Name = "Angella Sim",
            Class = Class.Magician,
            Specialisation = Specialisation.IceMage,
            Inventory = new List<string>()
        };

        private static readonly MazeGameDataModel MazeGameDataModelMock = new MazeGameDataModel
        {
            Adventurer = AdventurerMock,
        };

        [Fact]
        public async Task CallTransverseIceCavernAsync_Positive_AdventurerIsResistantToIce_ReturnTrue()
        {
            // Arrange
            AdventurerMock.Class = Class.Magician;
            AdventurerMock.Specialisation = Specialisation.IceMage;

            try
            {
                // Act
                CallTransverseIceCavernAsync();

                Func<string, Task<bool>> isAdventurerIceResistantQuery = IceCavernMock.IsAdventurerIceResistant.ProcessPhase;

                bool results = await isAdventurerIceResistantQuery.Invoke(string.Empty);

                // Assert
                Assert.IsTrue(results);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly.
                throw new InvalidOperationException("Test case failed due to an unexpected error.", ex);
            }
        }
    }
}