using Dapper;
using GoodsApp.Core.Entities;
using GoodsApp.Infrastructure.SQLConstants;
using MediatR;
using System.Data;

namespace GoodsApp.Application.Queries;

public class GetGoodsTreeQueryHandler(IDbConnection dbConnection) : IRequestHandler<GetGoodsTreeQuery, GoodsTree>
{
    public async Task<GoodsTree> Handle(GetGoodsTreeQuery request, CancellationToken cancellationToken)
    {
        const string query = SQL.GetGoodsTnvedTree;

        var goodsList = (await dbConnection.QueryAsync<GoodsTree>(query, new { Code = request.Code })).Distinct().ToList();

        var lookup = goodsList.ToLookup(x => x.ParentId);
        foreach (var item in goodsList)
        {
            if(item.Children is null)
                item.Children = new List<GoodsTree>();  

            item.Children = lookup[item.Id]
            .Where(child => !item.Children.Any(existing => existing.Id == child.Id))
            .ToList();
        }

        return goodsList.FirstOrDefault(x => x.ParentId == 0);
    }
}
