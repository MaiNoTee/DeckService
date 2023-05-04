namespace DeckServiceTests;

public class MainTests
{
	[SetUp]
	public void Setup()
	{
	}

	[Test]
	public void IsDeckCreated()
	{
		var deckService = new DeckService.Models.DeckService();
		deckService.CreateDeck("Test deck");
		Assert.That(deckService.GetDeckNames(), Is.Not.Empty);
	}
}
