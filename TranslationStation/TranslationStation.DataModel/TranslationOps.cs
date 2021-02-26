﻿using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using TranslationStation.DataModel.Models.API;
using TranslationStation.DataModel.Models.EF;

namespace TranslationStation.DataModel
{
    public interface ITranslationOps
    {
        TranslationDto Get(string key);
        Task<TranslationDto> GetAsync(string key);
        IEnumerable<TranslationDto> GetAll();
        Task<IEnumerable<TranslationDto>> GetAllAsync();
        void Add(TranslationDto incomingXltn);
        Task AddAsync(TranslationDto incomingXltn);
        TranslationDto Upsert(TranslationDto incomingXltn);
        Task<TranslationDto> UpsertAsync(TranslationDto incomingXltn);
        void Delete(TranslationDto incomingXltn);
        Task DeleteAsync(TranslationDto incomingXltn);
    }

    /// <summary>
    /// I forgot the term "data access" when naming this class.
    /// </summary>
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
        public async Task<TranslationDto> GetAsync(string key)
        {
            var existingXtln = await _trnsCtx.Translations.FindAsync(key);
            return _mapper.Map<TranslationDto>(existingXtln);
        }

        public void Add(TranslationDto incomingXltn)
        {
            var xltn = _mapper.Map<Translation>(incomingXltn);
            _ = _trnsCtx.Translations.Add(xltn);
            _ = _trnsCtx.SaveChanges();
        }
        public async Task AddAsync(TranslationDto incomingXltn)
        {
            var xltn = _mapper.Map<Translation>(incomingXltn);
            _ = await _trnsCtx.Translations.AddAsync(xltn);
            _ = await _trnsCtx.SaveChangesAsync();
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
            _ = _trnsCtx.SaveChanges();
            return _mapper.Map<TranslationDto>(updatedXltn.Entity);
        }
        public async Task<TranslationDto> UpsertAsync(TranslationDto incomingXltn)
        {
            var existingXltn = await _trnsCtx.Translations.FindAsync(incomingXltn.Key);

            // Insert if null
            if (existingXltn == null)
            {
                var xltn = _mapper.Map<Translation>(incomingXltn);
                var addedXltn = await _trnsCtx.AddAsync(xltn);
                return _mapper.Map<TranslationDto>(addedXltn.Entity);
            }

            existingXltn.EnglishWord = incomingXltn.EnglishWord;
            existingXltn.SpanishWord = incomingXltn.SpanishWord;
            existingXltn.IsVerified = incomingXltn.IsVerified;

            // There is no UpdateAsync in EFCore
            // https://github.com/dotnet/efcore/issues/18746
            var updatedXltn = _trnsCtx.Translations.Update(existingXltn);
            _ = await _trnsCtx.SaveChangesAsync();
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

        public async Task DeleteAsync(TranslationDto incomingXltn)
        {
            var existingXltn = await _trnsCtx.Translations.FindAsync(incomingXltn.Key);
            if (existingXltn == null)
            {
                return;
            }

            // There is no RemoveAsync in EFCore
            // https://github.com/dotnet/efcore/issues/18746
            _ = _trnsCtx.Translations.Remove(existingXltn);
            _ = await _trnsCtx.SaveChangesAsync();
        }

        public IEnumerable<TranslationDto> GetAll()
        {
            var existingXtln = _trnsCtx.Translations;
            return _mapper.Map<List<TranslationDto>>(existingXtln);
        }

        public async Task<IEnumerable<TranslationDto>> GetAllAsync()
        {
            var translations = _trnsCtx.Translations.AsAsyncEnumerable();
            List<TranslationDto> translationDTOs = new List<TranslationDto>();
            await foreach (var item in translations)
            {
                translationDTOs.Add(_mapper.Map<TranslationDto>(item));
            }
            return translationDTOs;
        }
    }
}
