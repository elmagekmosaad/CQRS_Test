using CQRS_lib.CQRS.Queries;
using CQRS_lib.Data;
using CQRS_lib.Models;
using MediatR;

namespace CQRS_lib.CQRS.Handelers
{
    internal class GetItemsListHandler : IRequestHandler<GetAllItemsQuery,List<Items>>
    {
        AppDbContext _db;
        public GetItemsListHandler(AppDbContext db)
        {
            _db = db;
        }

        public async Task<List<Items>> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            return await Task.FromResult(_db.Items.ToList());
        }
    }
}
