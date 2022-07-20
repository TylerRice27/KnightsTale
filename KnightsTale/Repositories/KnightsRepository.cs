

using System.Data;

namespace KnightsTale.Repositories
{

    public class KnightsRepository
    {
        private readonly IDbConnection _db;

        public KnightsRepository(IDbConnection db)
        {
            _db = db;
        }
    }














}