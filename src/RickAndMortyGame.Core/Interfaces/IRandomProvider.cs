using RickAndMortyGame.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RickAndMortyGame.Core.Interfaces
{
    public interface IRandomProvider
    {
        FairRandomResult GenerateFairRandomAsync(int maxValue);
    }
}
