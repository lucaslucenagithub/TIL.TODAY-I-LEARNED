using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ocelot.Middleware;
using Ocelot.Middleware.Multiplexer;

namespace Gateway.Aggregators
{
    public class QuizUsuarioAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<DownstreamContext> responses)
        {
            return Task.FromResult(new DownstreamResponse(new HttpResponseMessage(HttpStatusCode.NotImplemented)));
        }
    }
}