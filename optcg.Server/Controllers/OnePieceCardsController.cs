using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;


namespace optcg.Server.Controllers
{
    [ApiController]
    [Route("cards")]
    public class OnePieceCardsController : ControllerBase
    {
        private static readonly OnePieceCards _placeholderCard = new OnePieceCards
        {
            CardId = "OP01-001",
            CardName = "Monkey D. Luffy",
            CardCategory = "Leader",
            CardColor = "Red",
            CardLife = 4000,
            CardCost = 3,
            CardPower = 2000,
            CardAttribute = "Slash",
            CardBlocker = 0,
            CardDescription = "Can't be blocked by Don!! cards.",
            CardType = "Straw Hat",
            CardStatus = "LEGAL",
            CardBooster = "Test Booster",
            CardImages = "PlaceholderImage"
        };

        private readonly OnePieceCardContext _context;

        public OnePieceCardsController(OnePieceCardContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetOnePieceCards()
        {
            var cards = _context.OnePieceCards.Select(c => c).ToList();

            if (!cards.Any())
            {
                return NotFound();
            }

            return Ok(cards);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetOnePieceCard(string? id)
        {
            if (id == "placeholder")
            {
                return Ok(_placeholderCard);
            }
            else
            {
                var card = _context.OnePieceCards.FirstOrDefault(c => c.CardId == id);
                if (card == null)
                {
                    return NotFound();
                }
                return Ok(card);
            }

        }
    }
}
