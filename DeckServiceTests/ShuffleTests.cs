using DeckService.Model;

namespace DeckServiceTests;

public class ShuffleTests
{
	const string DeckName = "Test deck";

	[Test]
	public void IsShuffledByRandomShuffle()
	{
		var deckService = new DeckService.Model.DeckService();
		deckService.CreateDeck(DeckName);
		var cardsBefore = new List<Card>(deckService.GetDeck(DeckName).GetCards());

		deckService.ShuffleDeck(DeckName, DeckService.Model.DeckService.Shuffle.Random);

		var cardsAfter = deckService.GetDeck(DeckName).GetCards();

		Assert.That(!cardsAfter.SequenceEqual(cardsBefore) && cardsAfter.Count == cardsBefore.Count);
	}

	[Test]
	public void IsShuffledByShuffleByHalf()
	{
		var deckService = new DeckService.Model.DeckService();
		deckService.CreateDeck(DeckName);
		var cardsBefore = new List<Card>(deckService.GetDeck(DeckName).GetCards());

		deckService.ShuffleDeck(DeckName, DeckService.Model.DeckService.Shuffle.ByHalf);

		var cardsAfter = deckService.GetDeck(DeckName).GetCards();

		Assert.That(!cardsAfter.SequenceEqual(cardsBefore) && cardsAfter.Count == cardsBefore.Count);
	}

}
