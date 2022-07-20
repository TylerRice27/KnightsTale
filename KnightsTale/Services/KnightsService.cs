

using System;
using System.Collections.Generic;
using KnightsTale.Models;
using KnightsTale.Repositories;

namespace KnightsTale.Services
{

    public class KnightsService
    {


        private readonly KnightsRepository _repo;

        public KnightsService(KnightsRepository repo)
        {
            _repo = repo;
        }

        internal List<Knight> Get()
        {
            return _repo.Get();
        }

        internal Knight Get(int id)
        {
            throw new NotImplementedException();
        }

        internal Knight Create(Knight knightData)
        {
            throw new NotImplementedException();
        }

        internal Knight Edit(object knightData)
        {
            throw new NotImplementedException();
        }

        internal Knight Delete(int id1, string id2)
        {
            throw new NotImplementedException();
        }
    }









}