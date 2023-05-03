using static DeckService.Model.DeckService;

namespace DeckService.Model;

public class Deck
{
	List<Card> Cards { get; }
	string Name { get; }

	public Deck(string name)
	{
		Name = name;
		Cards = new List<Card>();
		string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
		string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

		foreach (string suit in suits)
		{
			foreach (string rank in ranks)
			{
				Cards.Add(new Card { Suit = suit, Rank = rank });
			}
		}
	}

	public void Shuffle(Shuffle shuffle)
	{
		switch (shuffle)
		{
			case DeckService.Shuffle.Random:
			{
				var random = new Random();
				for (int i = 0; i < Cards.Count; i++)
				{
					int j = random.Next(i + 1);
					(Cards[i], Cards[j]) = (Cards[j], Cards[i]); // bubble-sort
				}

				break;
			}
			case DeckService.Shuffle.ByHalf:
			{
				ShuffleByHalf(Cards, 0, Cards.Count / 2 - 1);
				break;
			}

			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	public List<Card> GetCards()
	{
		return Cards;
	}

	static void ShuffleByHalf(IList<Card> cards, int left, int depth)
	{
		if (depth == 0) return;

		int mid = cards.Count / 2;

		for (int i = left; i < mid; i++)
		{
			int j = i + (mid - left);
			(cards[i], cards[j]) = (cards[j], cards[i]);
		}

		ShuffleByHalf(cards, left, depth - 1);
		ShuffleByHalf(cards, mid + 1, depth - 1);
	}
}
