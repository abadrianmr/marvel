using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using VisualApp.Models;

namespace VisualApp.Services
{
    public class HeroService : IHeroService
    {
        private const string BaseUrl = "https://superheroapi.com/api/712922574350968/";

        public async IAsyncEnumerable<Hero> GetHeroes()
        {
            int id = 1;

            do
            {
                var hero = await GetHero( id++ );
                if( hero is not null )
                {
                    yield return hero;
                }
                else
                {
                    break;
                }
            } while( true );
        }

        public async Task<Hero?> GetHero( int id )
        {
            string HeroRequestUrl = BaseUrl + id;
            using HttpClient Client = new();

            HttpResponseMessage response = await Client.GetAsync( HeroRequestUrl );
            string WebResponseAsJson = await response.Content.ReadAsStringAsync();

            var heroResponse = JsonConvert.DeserializeObject<HeroResponse>( WebResponseAsJson );

            if( heroResponse?.Response == "success" )
            {
                return JsonConvert.DeserializeObject<Hero>( WebResponseAsJson );
            }
            else
            {
                return null;
            }
        }
    }
}
