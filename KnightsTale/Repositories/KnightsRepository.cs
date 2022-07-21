using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using KnightsTale.Models;

namespace KnightsTale.Repositories
{

    public class KnightsRepository
    {
        private readonly IDbConnection _db;

        public KnightsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Knight> Get()
        {
            string sql = @"
          SELECT
          k.*,
          acts.*
          FROM knights k
          JOIN accounts acts ON acts.id = k.creatorId
        ";

            return _db.Query<Knight, Profile, Knight>(sql, (knight, profile) =>
            {
                knight.Creator = profile;
                return knight;
            }).ToList();
        }
    }














}