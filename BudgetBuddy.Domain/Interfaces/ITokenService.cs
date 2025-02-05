using BudgetBuddy.Application.DTO.Login;

namespace BudgetBuddy.Domain.Interfaces;

public interface ITokenService
{
    string GenerateToken(LoginDto loginDto);
}