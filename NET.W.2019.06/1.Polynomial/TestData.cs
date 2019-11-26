using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polynomial.Tests
{
    public class TestData
    {
        public Polynom P1 { get; set; }

        public Polynom P2 { get; set; }

        public Polynom Expected_Add { get; set; }

        public Polynom Expected_Subtract { get; set; }

        public Polynom Expected_Multiply { get; set; }

        public bool Expected_Equal { get; set; }

        public int Expected_HashCode { get; set; }

        public string Expected_ToString { get; set; }
    }
}
