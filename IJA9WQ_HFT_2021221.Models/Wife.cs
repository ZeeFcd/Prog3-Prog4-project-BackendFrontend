using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IJA9WQ_HFT_2021221.Models
{
    public class Wife
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [NotMapped]
        public virtual Husband Husband { get; set; }

        [NotMapped]
        public virtual Wedding Wedding { get; set; }


        public string Name { get; set; }
        public int Age { get; set; }
    }
}
