using GoodsApp.Core.Entities;
using MediatR;

namespace GoodsApp.Application.Queries;

public record GetGoodsTreeQuery(string Code) : IRequest<GoodsTree>; 
