using DeckService.Models;

namespace DeckServiceTests;

public class ShuffleTests
{
	

	[Test]
	public void IsShuffledByRandomShuffle()
	{
		const string deckName = "Test Deck 1";
		var deckService = new DeckService.Models.DeckService();
		deckService.CreateDeck(deckName);
		var cardsBefore = new List<Card>(deckService.GetDeck(deckName).GetCards());

		deckService.ShuffleDeck(deckName, DeckService.Models.DeckService.Shuffle.Random);

		var cardsAfter = deckService.GetDeck(deckName).GetCards();

		Assert.That(!cardsAfter.SequenceEqual(cardsBefore) && cardsAfter.Count == cardsBefore.Count);
	}

	[Test]
	public void IsShuffledByShuffleByHalf()
	{
		const string deckName = "Test Deck 2";
		var deckService = new DeckService.Models.DeckService();
		deckService.CreateDeck(deckName);
		var cardsBefore = new List<Card>(deckService.GetDeck(deckName).GetCards());

		deckService.ShuffleDeck(deckName, DeckService.Models.DeckService.Shuffle.ByHalf);

		var cardsAfter = deckService.GetDeck(deckName).GetCards();

		Assert.That(!cardsAfter.SequenceEqual(cardsBefore) && cardsAfter.Count == cardsBefore.Count);
	}

}
