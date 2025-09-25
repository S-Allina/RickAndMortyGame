using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Models
{
    public class FairRandomResult
    {
        public int ComputerValue {  get; set; }
        public int UserValue { get; set; }
        public byte[] SecretKey { get; set; }
        public string Hmac {  get; set; }
        public int FinalValue { get; set; }
    }
}
