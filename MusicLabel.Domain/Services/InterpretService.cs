using MusicLabel.Domain.Entities;
using MusicLabel.Domain.Interfaces;
using MusicLabel.Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace MusicLabel.Domain.Services
{
    public class InterpretService:IInterpretRepository
    {
        
        private readonly IInterpretRepository _interpretRepository;
        private List<Interpret> reader= new List<Interpret>();
        public InterpretService(IInterpretRepository interpretRepository,List<Interpret> readers)
        {
            _interpretRepository = interpretRepository;
            reader = readers;
        }
        public List<Interpret> HoleAlle()
        {
            return  reader;
        }
        public Interpret HoleNachId(int id)
        {
            var interpret = reader.FirstOrDefault(r=>r.Id== id);
            if (interpret == null)
            {
                throw new InterpretNotFoundException("Der Interpret wurde nicht gefunden.");
            }
            return interpret;
        }
        public Interpret Anlegen(string kuenstlername, string genre, decimal tagesgage)
        {
            if (string.IsNullOrWhiteSpace(kuenstlername))
            {
               throw new InvalidOperationException("Der Künstlername darf nicht leer sein.");
            }
            
            Interpret interpret= new Interpret(kuenstlername, genre, tagesgage);
            
            if(reader.Any(r=> r != null && r.Kuenstlername==kuenstlername))
            {
                throw new InvalidOperationException("Der Künstlername darf nicht doppelt sein.");
            }
            
            interpret.Id = reader.Count + 1;
            reader.Add(interpret);
            return interpret;
        }
        public decimal BerechneGage(int id, int tage)
        {
            InterpretService service = new InterpretService(_interpretRepository, reader);
            var interpret = service.HoleNachId(id);
            if(interpret == null)
            {
                throw new NullReferenceException("Keine Leere Id");
            }
            return interpret.BerechneGage(tage);
        }
        public void Hinzufuegen(Interpret interpret) { }
        public bool ExistiertName(string kuenstlername)
        {
            return true;
        }
    }
}
