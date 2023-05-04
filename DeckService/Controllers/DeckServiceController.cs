using DeckService.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DeckService.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class DeckServiceController : ControllerBase
{
	readonly IDeckService _deckService;

	readonly ILogger<DeckServiceController> _logger;

	public DeckServiceController(IDeckService deckService, ILogger<DeckServiceController> logger)
	{
		_deckService = deckService ?? throw new ArgumentNullException(nameof(deckService));
		_logger = logger;
	}

	[HttpPost]
	public IActionResult CreateDeck(string deckName)
	{
		if (string.IsNullOrWhiteSpace(deckName))
		{
			_logger.LogError("Bad Request: Deck name cannot be null or empty");
			return BadRequest("Deck name cannot be null or empty.");
		}

		_deckService.CreateDeck(deckName);
		_logger.LogInformation($"Created deck: {deckName}");
		return Ok(deckName);
	}

	[HttpGet("{deckName}")]
	public IActionResult GetDeck(string deckName)
	{
		try
		{
			var deck = _deckService.GetDeck(deckName);
			_logger.LogInformation($"Got Deck: {deckName}");
			return Ok(deck.GetCards());
		}
		catch (Exception)
		{
			_logger.LogInformation($"Tried to get deck: {deckName}. Not Found");
			return NotFound(deckName);
		}
	}

	[HttpGet]
	public IActionResult GetDecks()
	{
		var deckNames = _deckService.GetDeckNames();
		_logger.LogInformation("Got Decks");
		return Ok(deckNames);
	}

	[HttpPost("{deckName}/shuffle/{shuffle}")]
	public IActionResult ShuffleDeck(string deckName, Models.DeckService.Shuffle shuffle)
	{
		try
		{
			_deckService.ShuffleDeck(deckName, shuffle);
			_logger.LogInformation($"Shuffled Deck: {deckName} {shuffle}");
			return Ok();
		}
		catch (Exception)
		{
			_logger.LogInformation($"Tried to use deck: {deckName}. Not Found");
			return NotFound(deckName);
		}
	}

	[HttpDelete("{deckName}")]
	public IActionResult RemoveDeck(string deckName)
	{
		try
		{
			_deckService.RemoveDeck(deckName);
			_logger.LogInformation($"Removed Deck: {deckName}");
			return Ok();
		}
		catch (Exception)
		{
			_logger.LogInformation($"Tried to remove deck: {deckName}. Not Found");
			return NotFound(deckName);
		}
	}
}
