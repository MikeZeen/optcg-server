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
        [Route("page={page}&perPage={perPage}")]
        public IActionResult GetOnePieceCards(int page = 1, int perPage = 25)
        {
            int skip = (page - 1) * perPage;

            var cards = _context.OnePieceCards
                                .Skip(skip)
                                .Take(perPage)
                                .ToList();

            if (!cards.Any())
            {
                return NotFound();
            }

            int totalCards = _context.OnePieceCards.Count();

            return Ok(new { Cards = cards, TotalCards = totalCards });
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
