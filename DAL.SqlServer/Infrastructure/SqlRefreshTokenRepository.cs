using DAL.SqlServer.Context;
using Domain.Entities;
using Repository.Repositories;

namespace DAL.SqlServer.Infrastructure;

public class SqlRefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
	private readonly AppDbContext _context = context;
	public async Task<RefreshToken> GetStoredRefreshToken(string refreshToken)
	{
		return await context.RefreshTokens.FirstOrDefaultAsync(rt => rt.Token == refreshToken);
	}

	public Task SaveRefreshToken(RefreshToken refreshToken)
	{
		throw new NotImplementedException();
	}
}
