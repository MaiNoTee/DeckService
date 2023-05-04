using DeckService.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;

namespace DeckServiceTests;

[TestFixture]
public class ApiTests
{
	[Test]
	public void IsCreateDeck_ReturnsCreatedResult_WithValidDeck()
	{
		var deckService = new DeckService.Models.DeckService();
		var mockLogger = new Mock<ILogger<DeckServiceController>>();
		var controller = new DeckServiceController(deckService, mockLogger.Object);

		var result = controller.CreateDeck("test_deck");

		Assert.That(result, Is.Not.Null);
		Assert.That(result, Is.InstanceOf<OkObjectResult>());
		var okResult = (OkObjectResult)result;
		Assert.Multiple(
			() =>
			{
				Assert.That(okResult.Value, Is.InstanceOf<string>());

				Assert.That(deckService.GetDeckNames(), Does.Contain("test_deck"));
			});
	}
}
