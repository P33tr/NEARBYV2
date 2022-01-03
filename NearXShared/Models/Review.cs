using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NearXShared.Models
{
    public class Review
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Note { get; set; }

        public int ElementId { get; set; }
    }
}
