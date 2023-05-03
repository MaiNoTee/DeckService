namespace DeckService;

public static class Program
{
	public static void Main()
	{
		var deckService = new Model.DeckService();
		deckService.CreateDeck("My Deck");
		deckService.ShuffleDeck("My Deck", Model.DeckService.Shuffle.Random);
		deckService.ShuffleDeck("My Deck", Model.DeckService.Shuffle.ByHalf);
		foreach (var card in deckService.GetDeck("My Deck").GetCards())
		{
			Console.WriteLine($"{card.Suit} {card.Rank}");
		}
	}
}
