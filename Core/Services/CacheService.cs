using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Contracts;
using Services.Abstraction;

namespace Services
{
    public class CacheService(ICashRepository cashRepository) : ICacheService
    {
        public async Task<string?> GetCacheValueAsync(string key)
        {
          var value =  await cashRepository.GetAsync(key);
            return value == null ? null : value;
        }

        public async Task SetCacheValueAsync(string key, object value, TimeSpan duration)
        {
           await cashRepository.SetAsync(key, value, duration);
        }
    }
}
