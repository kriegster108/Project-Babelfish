using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using TranslationStation.DataModel.Models.API;
using TranslationStation.DataModel.Models.EF;

namespace TranslationStation.DataModel
{
    public interface ITranslationOps
    {
        TranslationDto Get(string key);
        void Add(TranslationDto incomingXltn);
        TranslationDto Upsert(TranslationDto incomingXltn);
        void Delete(TranslationDto incomingXltn);
    }

    public class TranslationOps : ITranslationOps
    {
        private readonly TranslationContext _trnsCtx;
        private readonly IMapper _mapper;

        public TranslationOps(TranslationContext translationContext, IMapper mapper)
        {
            _trnsCtx = translationContext;
            _mapper = mapper;
        }

        public TranslationDto Get(string key)
        {
            var existingXtln = _trnsCtx.Translations.Find(key);
            return _mapper.Map<TranslationDto>(existingXtln);
        }

        public void Add(TranslationDto incomingXltn)
        {
            var xltn = _mapper.Map<Translation>(incomingXltn);
            _trnsCtx.Translations.Add(xltn);
            _trnsCtx.SaveChanges();
        }

        public TranslationDto Upsert(TranslationDto incomingXltn)
        {
            var existingXltn = _trnsCtx.Translations.Find(incomingXltn.Key);

            // Insert if null
            if (existingXltn == null)
            {
                var xltn = _mapper.Map<Translation>(incomingXltn);
                var addedXltn = _trnsCtx.Add(xltn);
                return _mapper.Map<TranslationDto>(addedXltn.Entity);
            }

            existingXltn.EnglishWord = incomingXltn.EnglishWord;
            existingXltn.SpanishWord = incomingXltn.SpanishWord;
            existingXltn.IsVerified = incomingXltn.IsVerified;
            var updatedXltn = _trnsCtx.Translations.Update(existingXltn);
            _trnsCtx.SaveChanges();
            return _mapper.Map<TranslationDto>(updatedXltn.Entity);
        }

        public void Delete(TranslationDto incomingXltn)
        {
            var existingXltn = _trnsCtx.Translations.Find(incomingXltn.Key);
            if (existingXltn == null)
            {
                return;
            }

            _trnsCtx.Translations.Remove(existingXltn);
            _trnsCtx.SaveChanges();
        }
    }
}
