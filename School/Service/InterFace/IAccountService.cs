using School.Domain.Models;
using School.Domain.Response;
using System.Security.Claims;
using System.Threading.Tasks;


namespace School.Service.InterFace
{
    public interface IAccountService
    {
        Task<BaseResponse<string>> Register(User model);
        Task<BaseResponse<ClaimsIdentity>> Login(User model);

        Task<BaseResponse<ClaimsIdentity>> ConfirmEmail(User model, string code,string confirmCode);

        Task<BaseResponse<ClaimsIdentity>> IsCreatedAccount(User model);
    }
}
