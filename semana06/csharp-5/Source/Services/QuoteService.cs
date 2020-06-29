using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            var listOfQuotes = _context.Quotes.ToList();
            return !listOfQuotes.Any()? null : GetNewQuote(listOfQuotes);
        }

        public Quote GetAnyQuote(string actor)
        {
            var listOfActorQuotes = _context.Quotes.Where(x => x.Actor == actor).ToList();
            return !listOfActorQuotes.Any() ? null : GetNewQuote(listOfActorQuotes);
        }

        private Quote GetNewQuote(List<Quote> list)
        {
            return list[_randomService.RandomInteger(list.Count)];
        }
    }
}