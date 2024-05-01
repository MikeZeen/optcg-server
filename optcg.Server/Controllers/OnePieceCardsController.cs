using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;


namespace optcg.Server.Controllers
{
    [ApiController]
    [Route("cards")]
    public class OnePieceCardsController : ControllerBase
    {
        private readonly OnePieceCardContext _context;

        public OnePieceCardsController(OnePieceCardContext context)
        {
            _context = context;
        }

        //ALL Cards

        [HttpGet]
        public IActionResult GetOnePieceCards()
        {

            var cards = _context.OnePieceCards
                                .ToList();

            if (!cards.Any())
            {
                return NotFound();
            }

            int totalCards = _context.OnePieceCards.Count();

            Console.WriteLine("All Cards Retrieved from Database");

            return Ok(new { Cards = cards, TotalCards = totalCards });
        }

        //By All Variables
        [HttpGet]
        [Route("search")]
        public IActionResult CheckOnePieceCard([FromQuery] OnePieceCards card)
        {
            var existingCards = _context.OnePieceCards.Where(c =>
                (string.IsNullOrEmpty(card.CardId) || (c.CardId != null && c.CardId.Contains(card.CardId))) &&
                (string.IsNullOrEmpty(card.CardName) || (c.CardName != null && c.CardName.Contains(card.CardName))) &&
                (string.IsNullOrEmpty(card.CardCategory) || (c.CardCategory != null && c.CardCategory.Contains(card.CardCategory))) &&
                (string.IsNullOrEmpty(card.CardColor) || (c.CardColor != null && c.CardColor.Contains(card.CardColor))) &&
                (string.IsNullOrEmpty(card.CardAttribute) || (c.CardAttribute != null && c.CardAttribute.Contains(card.CardAttribute))) &&
                (string.IsNullOrEmpty(card.CardDescription) || (c.CardDescription != null && c.CardDescription.Contains(card.CardDescription))) &&
                (string.IsNullOrEmpty(card.CardType) || (c.CardType != null && c.CardType.Contains(card.CardType))) &&
                (string.IsNullOrEmpty(card.CardStatus) || (c.CardStatus != null && c.CardStatus.Contains(card.CardStatus))) &&
                (string.IsNullOrEmpty(card.CardBooster) || (c.CardBooster != null && c.CardBooster.Contains(card.CardBooster))) &&
                (string.IsNullOrEmpty(card.CardImages) || (c.CardImages != null && c.CardImages.Contains(card.CardImages))) &&
                (card.CardLife == null || c.CardLife == card.CardLife) &&
                (card.CardCost == null || c.CardCost == card.CardCost) &&
                (card.CardPower == null || c.CardPower == card.CardPower) &&
                (card.CardBlocker == null || c.CardBlocker == card.CardBlocker)
            );

            if (!existingCards.Any())
            {
                return NotFound();
            }

            var result = existingCards.ToList();

            Console.WriteLine(result.ToString() + " Retrieved from Database");
            return Ok(new { Cards = result, TotalCount = existingCards.Count() });
        }
    }
}
