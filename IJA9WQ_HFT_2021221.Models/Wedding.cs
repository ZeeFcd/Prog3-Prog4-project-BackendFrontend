using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Models
{
    public class Wedding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public virtual Husband Husband { get; set; }
        [NotMapped]
        public virtual Wife Wife { get; set; }

        [ForeignKey(nameof(Husband))]
        public int HusbandID { get; set; }

        [ForeignKey(nameof(Wife))]
        public int WifeID { get; set; }


        public string Place { get; set; }
        public int Price { get; set; }

    }
}
