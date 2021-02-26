using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using TranslationStation.DataModel.Models.API;
using TranslationStation.DataModel.Models.EF;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Expression = System.Linq.Expressions.Expression;
using System.Linq;

namespace TranslationStation.DataModel
{
    public interface ITranslationOps
    {
        IEnumerable<TranslationDto> GetAll();
        Task<IEnumerable<TranslationDto>> GetAllAsync();
        List<TranslationDto> GetAll( params Expression<Func<TranslationDto, object>>[] navigationProperties);
        Task<List<TranslationDto>> GetAllAsync( params Expression<Func<TranslationDto, object>>[] navigationProperties);

        List<TranslationDto> GetList(Func<TranslationDto, bool> where, 
            params Expression<Func<TranslationDto,object>>[] navigationProperties);

        TranslationDto GetSingle(Expression<Func<TranslationDto, bool>> where,
            params Expression<Func<TranslationDto, object>>[] navigationProperties);

        Task<TranslationDto> GetSingleAsync(Expression<Func<TranslationDto, bool>>  where,
            params Expression<Func<TranslationDto, object>>[] navigationProperties);

        TranslationDto Get(string key);
        Task<TranslationDto> GetAsync(string key);
        IEnumerable<TranslationDto> GetAll();
        Task<IEnumerable<TranslationDto>> GetAllAsync();
        void Add(TranslationDto incomingXltn);
        Task AddAsync(TranslationDto incomingXltn);
        TranslationDto Upsert(TranslationDto incomingXltn);
        Task<TranslationDto> UpsertAsync(TranslationDto incomingXltn);
        Task<IEnumerable<TranslationDto>> UpsertAllAsync(IEnumerable<TranslationDto> incomingXltn);
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
        private readonly GenericDataRepository<Translation> _translationRepo;

        public TranslationOps(TranslationContext translationContext, IMapper mapper)
        {
            _trnsCtx = translationContext;
            _mapper = mapper;
            _translationRepo = new GenericDataRepository<Translation>(translationContext);
        }

        public IEnumerable<TranslationDto> GetAll()
        {
            return _mapper.Map<List<TranslationDto>>(_translationRepo.GetAll());
        }

        public async Task<IEnumerable<TranslationDto>> GetAllAsync()
        {
            return _mapper.Map<List<TranslationDto>>(await _translationRepo.GetAllAsync());
        }


        public List<TranslationDto> GetAll( params Expression<Func<TranslationDto, object>>[] navigationProperties)
        {
            var expression = _mapper.Map<Expression<Func<Translation, object>>[]>(navigationProperties);
            return _mapper.Map<List<TranslationDto>>(_translationRepo.GetAll(expression));
        }
        public async Task<List<TranslationDto>> GetAllAsync( params Expression<Func<TranslationDto, object>>[] navigationProperties)
        {
            var expression = _mapper.Map<Expression<Func<Translation, object>>[]>(navigationProperties);
            var result = await _translationRepo.GetAllAsync(expression);
            return _mapper.Map<List<TranslationDto>>(result);
        }

        public List<TranslationDto> GetList(Func<TranslationDto, bool> where, 
             params Expression<Func<TranslationDto,object>>[] navigationProperties)
        {
            var where2 = _mapper.Map<Func<Translation, bool>>(where);
            var navProp = _mapper.Map<Expression<Func<Translation, object>>[]>(navigationProperties);
            return  _mapper.Map<List<TranslationDto>>(_translationRepo.GetList(where2, navProp));
        }

        public TranslationDto GetSingle(Expression<Func<TranslationDto, bool>> where,
            params Expression<Func<TranslationDto, object>>[] navigationProperties)
        {
            var where2 = _mapper.Map<Func<Translation, bool>>(where);
            var navProp = _mapper.Map<Expression<Func<Translation, object>>[]>(navigationProperties);
            return _mapper.Map<TranslationDto>(_translationRepo.GetSingle(where2, navProp));
        }
        public async Task<TranslationDto> GetSingleAsync(Expression<Func<TranslationDto, bool>>  where,
            params Expression<Func<TranslationDto, object>>[] navigationProperties)
        {
            var where2 = _mapper.Map<Expression<Func<Translation, bool>>>(where);
            var navProp = _mapper.Map<Expression<Func<Translation, object>>[]>(navigationProperties);
            var result = await _translationRepo.GetSingleAsync(where2, navProp);
            return _mapper.Map<TranslationDto>(result);
        }
        // Basic CRUD functions
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

        public async Task<IEnumerable<TranslationDto>> UpsertAllAsync(IEnumerable<TranslationDto> incomingXltns)
        {
            var existingXltns = new List<Translation>();
            var newXltns = new List<Translation>();
            var returnValue = new List<TranslationDto>();
            foreach (var incomingXltn in incomingXltns)
            {
                var existingXltn = await _trnsCtx.Translations.FindAsync(incomingXltn.Key);
                if (existingXltn != null)
                {
                    existingXltn.EnglishWord = incomingXltn.EnglishWord;
                    existingXltn.SpanishWord = incomingXltn.SpanishWord;
                    existingXltn.IsVerified = incomingXltn.IsVerified;
                    existingXltns.Add(existingXltn);
                } else
                {
                    newXltns.Add(_mapper.Map<Translation>(incomingXltn));
                }
            }


            await _trnsCtx.AddRangeAsync(newXltns);
            _trnsCtx.Translations.UpdateRange(existingXltns);
            await _trnsCtx.SaveChangesAsync();

            returnValue.AddRange(newXltns.Select(x => _mapper.Map<TranslationDto>(x)));
            returnValue.AddRange(existingXltns.Select(x => _mapper.Map<TranslationDto>(x)));
            return returnValue;
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
