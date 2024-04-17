using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace optcg.Server
{
    [Table("cards")]
    public class OnePieceCards
    {
        [Key]
        [Column("id")]
        public string? CardId { get; set; }

        [Column("name")]
        public string? CardName { get; set; }

        [Column("category")]
        public string? CardCategory { get; set;}

        [Column("color")]
        public string? CardColor { get; set; }

        [Column("life")]
        public int? CardLife { get; set; }

        [Column("cost")]
        public int? CardCost { get; set; }

        [Column("power")]
        public int? CardPower { get; set; }

        [Column("attribute")]
        public string? CardAttribute { get; set; }

        [Column("blocker")]
        public int? CardBlocker { get; set; }

        [Column("description")]
        public string? CardDescription { get; set; }

        [Column("type")]
        public string? CardType { get; set; }

        [Column("status")]
        public string? CardStatus { get; set; }

        [Column("booster")]
        public string? CardBooster { get; set; }

        [Column("images")]
        public string? CardImages { get; set; }

    }
}
