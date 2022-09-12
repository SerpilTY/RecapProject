using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Business.Concrete
{

        public class CardManager : ICardService
        {
            private ICardDal _cardDal;

            public CardManager(ICardDal cardDal)
            {
                _cardDal = cardDal;
            }

            public IResult Add(Card card)
            {

                var result = BusinessRules.Run(CheckIsCreditCardExist(card.CardNumber));
                if (result == null)
                {
                    return new ErrorResult();
                }
                _cardDal.Add(card);
                return new SuccessResult(Messages.CardAdded);
            }

            public IResult Delete(Card card)
            {
                _cardDal.Delete(card);
                return new SuccessResult(Messages.CardDeleted);
            }

            public IDataResult<List<Card>> GetAll()
            {
                return new SuccessDataResult<List<Card>>(_cardDal.GetAll(), Messages.CardListed);
            }

            public IDataResult<Card> GetById(int cardId)
            {
                return new SuccessDataResult<Card>(_cardDal.Get(c => c.CardId == cardId));
            }



            public IDataResult<List<Card>> GetCardsByCustomerId(int customerId)
            {
                //  var result = BusinessRules.Run(IsCustomerExist(customerId));
                // if (result != null)
                //{
                //    return new ErrorDataResult<List<Card>>();
                // }
                return new SuccessDataResult<List<Card>>(_cardDal.GetAll(x => x.CustomerId == customerId));
            }

            public IResult Update(Card card)
            {

                _cardDal.Update(card);
                return new SuccessResult(Messages.CardUpdated);
            }

        IResult ICardService.Add(Card card)
        {
            throw new NotImplementedException();
        }


    
        private IResult CheckIsCreditCardExist(string cardNumber)
            {
                if (!_cardDal.Any(x => x.CardNumber == cardNumber))
                {
                    return new ErrorResult("Kredi Kartı Mevcut");
                }
                return new SuccessResult();
            }

        
    }
    }