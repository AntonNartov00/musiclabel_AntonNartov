using MusicLabel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicLabel.Domain.Interfaces
{
    public interface IInterpretRepository
    {
        List<Interpret> HoleAlle();
        Interpret? HoleNachId(int id);
        bool ExistiertName(string kuenstlername);
        void Hinzufuegen(Interpret interpret);
    }
}
